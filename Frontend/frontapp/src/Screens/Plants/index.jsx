import { Button, Card, Image, CardFooter, CardBody } from "@nextui-org/react"
import { useState, useEffect } from "react";
import { FilePond, registerPlugin } from 'react-filepond';
import FilePondPluginImagePreview from 'filepond-plugin-image-preview'
import FilePondPluginFileEncode from 'filepond-plugin-file-encode';
import { usePlantStore } from "../../Store/plantsStore";
import PlantModal from '../../Components/PlantModal/index.jsx'
import RiskAlerts from "../../Components/RiskAlerts";
import 'filepond-plugin-image-preview/dist/filepond-plugin-image-preview.css'
import 'filepond/dist/filepond.min.css';

registerPlugin(FilePondPluginImagePreview, FilePondPluginFileEncode)

export default function RecognizePlant() {
  const [files, setFiles] = useState([]);
  const [selectedIndex, setSelectedIndex] = useState(-1);

  const fetchPlants = usePlantStore((state) => state.fetchPlants);
  let plants = usePlantStore(state => state.plants);
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

  return (
    <>
      <PlantModal selectedIndex = {selectedIndex} setSelectedIndex={setSelectedIndex}/>
      <div className="flex pt-5 justify-center h-screen bg-softwhite w-full mx-auto">
        <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4 relative h-fit">
          <RiskAlerts plants={plants} />
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
              <div className="hover:cursor-pointer" onClick={() => setSelectedIndex(index)} key={`result-${index}`}>
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
              <Button isDisabled={!files.at(0) || recognizedPlant} className="text-tiny text-white" onClick={submit} color="success" radius="full" size="sm">
                Recognize
              </Button>
              <Button isDisabled={!recognizedPlant} className="text-tiny" color="danger" radius="full" size="sm" onClick={removeRecognizedPlant}>
                Remove
              </Button>
            </CardFooter>
          </Card>
          {plants && plants.map(x => 
          <Card isFooterBlurred isPressable className="h-[300px] max-w-[225px] min-w-[200px]">
            <Image
              removeWrapper
              alt="Card example background"
              className="z-0 w-full h-full scale-125 -translate-y-8 object-cover"
              src={x.imageLink}
            />
            <CardFooter className="absolute bg-white/30 bottom-0 border-t-1 border-zinc-100/50 z-10">
              <div className="justify-start text-start">
                <h4 className="font-bold">{x.name}</h4>
                <p className="text-black text-tiny">{x.scientificName}</p>
              </div>
            </CardFooter>
          </Card>)}
        </div>
      </div>
    </>
    
  )
}