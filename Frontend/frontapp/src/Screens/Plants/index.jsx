import { Button, Card, CardHeader, Image, CardFooter, CardBody, Modal, ModalContent, ModalBody, ModalHeader, useDisclosure, Divider, Input, Textarea } from "@nextui-org/react"
import { useState, useEffect } from "react";
import { FilePond, registerPlugin } from 'react-filepond';
import FilePondPluginImagePreview from 'filepond-plugin-image-preview'
import FilePondPluginFileEncode from 'filepond-plugin-file-encode';
import { usePlantStore } from "../../Store/plantsStore";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faChevronLeft } from '@fortawesome/free-solid-svg-icons'
import { faChevronRight } from '@fortawesome/free-solid-svg-icons'
import 'filepond-plugin-image-preview/dist/filepond-plugin-image-preview.css'
import 'filepond/dist/filepond.min.css';

registerPlugin(FilePondPluginImagePreview, FilePondPluginFileEncode)

export default function RecognizePlant() {
  const [files, setFiles] = useState([]);
  const {isOpen, onOpen, onOpenChange} = useDisclosure();
  const [selectedItem, setSelectedItem] = useState({});
  const [selectedItemIndex, setSelectedItemIndex] = useState(-1);

  const fetchPlants = usePlantStore((state) => state.fetchPlants);
  var plantsStore = usePlantStore(state => state.plants);
  console.log(plantsStore)
  useEffect(() => {
    fetchPlants();
  }, [fetchPlants])

  const recognizePlant = usePlantStore((state) => state.recognizePlant);
  let recognizedPlant = usePlantStore(state => state.recognizedPlant);
  const removeRecognizedPlant = usePlantStore(state => state.removeRecognizedPlant);

  const submit = () => {
    let file = files.at(0);
    let fileName = `${file.filename}-${Date.now()}`;
    let base64image = file.getFileEncodeBase64String();
    recognizePlant(base64image, fileName);
  }

  const openModal = (index) => {
    let item = recognizedPlant.results.at(index);
    setSelectedItem(item);
    setSelectedItemIndex(index);
    onOpen();
  }

  const switchItem = (value) => {
    let newIndex = selectedItemIndex + value;
    let arrayLength = recognizedPlant.results.length;
    if(newIndex < 0)
      newIndex = arrayLength - 1;

    if(newIndex >= arrayLength)
      newIndex = 0

    let item = recognizedPlant.results.at(newIndex);
    setSelectedItem(item);
    setSelectedItemIndex(newIndex);
  }

  return (
    <>
        <Modal 
        backdrop="blur"
        size="5xl"
        isOpen={isOpen} 
        onOpenChange={onOpenChange}>
          <ModalContent>
            {(onClose) => (
              <>
                <ModalHeader className="flex gap-1 max-h-[700px] bg-softwhite">Add new plant</ModalHeader>
                <ModalBody className="flex flex-row max-h-[700px]">
                  <Image
                    removeWrapper
                    alt="Card example background"
                    className="max-w-[400px] max-h-full object-cover"
                    src={recognizedPlant.userImageUrl}
                  />
                  <div className="flex bg-softwhite rounded">
                    <div 
                    className="basis-1/6 flex justify-center align-middle items-center hover:cursor-pointer hover:bg-darkersoftwhite rounded transition-all"
                    onClick={() => switchItem(-1)}
                    >
                    <FontAwesomeIcon icon={faChevronLeft} className="text-2xl" />
                    </div>
                    <div className="basis-4/6 flex flex-col justify-between">
                      <div>
                        <div className="grid max-w-full grid-cols-3 gap-1">
                          {selectedItem && selectedItem.images.map((image, index)=> 

                            <Image 
                            radius="none"
                            removeWrapper
                            alt = {`image ${index}`}
                            src={image.url.m}
                            className="border border-softwhite"
                          />
                          )}
                        </div>
                        <Divider className="my-4"/>
                        <div className="flex justify-between">
                          <div className="flex flex-col">
                            <p className="text-bold text-lg capitalize">Match probability</p>
                            <p className="text-bold text-m capitalize">%{(selectedItem && selectedItem.score * 100).toFixed(2)}</p>
                          </div>
                          <div className="flex flex-col">
                            <p className="text-bold text-lg capitalize">Scientific name</p>
                            <p className="text-bold text-m capitalize">{selectedItem && selectedItem.species.scientificName}</p>
                          </div>
                        </div>
                      </div>
                      <div>
                        <Input label="Personal name (optional)" />
                        <Textarea
                          label="Description"
                          labelPlacement="outside"
                          placeholder="Enter your description (optional)"
                        />
                      </div>
                      <div className="flex justify-between p-2">
                        <Button color="primary" onPress={onClose}>
                          Save plant
                        </Button>
                        <Button color="danger" onPress={onClose}>
                          Close
                        </Button>
                      </div>
                    </div>
                    <div 
                    className="basis-1/6 flex justify-center align-middle items-center hover:cursor-pointer hover:bg-darkersoftwhite rounded transition-all"
                    onClick={() => switchItem(1)}
                    >
                      <FontAwesomeIcon icon={faChevronRight} className="text-2xl" />
                    </div>  
                  </div>
                </ModalBody>
              </>
            )}
          </ModalContent>
        </Modal>
      <div className="flex pt-5 justify-center h-screen bg-softwhite w-full mx-auto">
        <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
          <Card isFooterBlurred className="h-[300px] max-w-[225px] min-w-[200px]">
            <CardBody className="p-0">
              {recognizedPlant ? <Image 
                  radius="none"
                  removeWrapper
                  alt = {`recognized user image`}
                  src={recognizedPlant.userImageUrl}
                  className="object-cover max--full h-full max-w-full z-0"
                /> :
                <FilePond
                  files={files}
                  maxFiles={1}
                  name="files"
                  credits={false}
                  onupdatefiles={(files) => setFiles(files)}
                  acceptedFileTypes={"image/png, image/jpeg"}
              />}
              
            {recognizedPlant && 
            <div className="absolute bottom-0 grid max-w-[225px] grid-cols-3 justify-center text-center">
              {recognizedPlant.results.slice(0, 3).map((result, index) => 
              <div className="hover:cursor-pointer" onClick={() => openModal(index)} key={`result-${index}`}>
                <Image 
                  radius="none"
                  removeWrapper
                  alt = {`result ${index}`}
                  src={result.images.at(0).url.m}
                  className="border border-softwhite"
                />
                <p className="bg-softwhite">%{(result.score * 100).toFixed(2)}</p>
              </div>
              )}
              
            </div>}
            </CardBody>
            <CardFooter className="bg-white/30 border-t-1 justify-between">
              <Button isDisabled={!files.at(0) || recognizedPlant} className="text-tiny" onClick={submit} color="primary" radius="full" size="sm">
                Recognize
              </Button>
              <Button isDisabled={!recognizedPlant} className="text-tiny" color="secondary" radius="full" size="sm" onClick={removeRecognizedPlant}>
                Remove
              </Button>
            </CardFooter>
          </Card>
          <Card isFooterBlurred className="h-[300px] max-w-[225px] min-w-[200px] hover:cursor-pointer">
            <CardHeader className="absolute z-10 top-1 flex-col items-start">
              <h4 className="text-black font-medium text-2xl">Planta test {/*nombre planta*/}</h4>
            </CardHeader>
            <Image
              removeWrapper
              alt="Card example background"
              className="z-0 w-full h-full scale-125 -translate-y-8 object-cover"
              src="https://ik.imagekit.io/y2oac6m6s/test?updatedAt=1694210302114"
            />
            <CardFooter className="absolute bg-white/30 bottom-0 border-t-1 border-zinc-100/50 z-10 justify-between">
              <div>
                <p className="text-black text-tiny">Stromanthe thalia (Vell.) J.M.A.Braga{/*nombre cientifico planta*/}</p>
                <p className="text-black text-tiny">Esta es una descripcion {/*descripcion planta*/}</p>
              </div>
            </CardFooter>
          </Card>
          <Card isFooterBlurred className="h-[300px] max-w-[225px] min-w-[200px]">
            <CardHeader className="absolute z-10 top-1 flex-col items-start">
              <p className="text-tiny text-white/60 uppercase font-bold">New</p>
              <h4 className="text-black font-medium text-2xl">Planta test</h4>
            </CardHeader>
            <Image
              removeWrapper
              alt="Card example background"
              className="z-0 w-full h-full scale-125 -translate-y-6 object-cover"
              src="https://ik.imagekit.io/y2oac6m6s/test?updatedAt=1694210302114"
            />
            <CardFooter className="absolute bg-white/30 bottom-0 border-t-1 border-zinc-100/50 z-10 justify-between">
              <div>
                <p className="text-black text-tiny">Available soon.</p>
                <p className="text-black text-tiny">Get notified.</p>
              </div>
              <Button className="text-tiny" color="primary" radius="full" size="sm">
                Notify Me
              </Button>
            </CardFooter>
          </Card>
          <Card isFooterBlurred className="h-[300px] max-w-[225px] min-w-[200px]">
            <CardHeader className="absolute z-10 top-1 flex-col items-start">
              <p className="text-tiny text-white/60 uppercase font-bold">New</p>
              <h4 className="text-black font-medium text-2xl">Planta test</h4>
            </CardHeader>
            <Image
              removeWrapper
              alt="Card example background"
              className="z-0 w-full h-full scale-125 -translate-y-6 object-cover"
              src="https://ik.imagekit.io/y2oac6m6s/test?updatedAt=1694210302114"
            />
            <CardFooter className="absolute bg-white/30 bottom-0 border-t-1 border-zinc-100/50 z-10 justify-between">
              <div>
                <p className="text-black text-tiny">Available soon.</p>
                <p className="text-black text-tiny">Get notified.</p>
              </div>
              <Button className="text-tiny" color="primary" radius="full" size="sm">
                Notify Me
              </Button>
            </CardFooter>
          </Card>
        </div>
      </div>
    </>
    
  )
}