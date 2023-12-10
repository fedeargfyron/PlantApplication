import React, { useEffect, useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Button, Image, Modal, ModalContent, ModalBody, ModalHeader, Divider, Input, Textarea, useDisclosure, Checkbox, CircularProgress } from "@nextui-org/react"
import { faChevronLeft, faChevronRight } from '@fortawesome/free-solid-svg-icons'
import { usePlantStore } from '../../Store/plantsStore';
import { useForm } from 'react-hook-form';
import InformationModal from '../InformationModal';

const PlantModal = ({selectedIndex, setSelectedIndex}) => {
  const {isOpen, onOpen, onOpenChange } = useDisclosure();
  const [selectedItem, setSelectedItem] = useState({});
  const [open, setOpen] = useState(false);
  const [selectedItemIndex, setSelectedItemIndex] = useState(-1);
  const [isOutside, setIsOutside] = useState(true);
  const { 
    register, 
    handleSubmit, 
    formState: { errors }
  } = useForm();
  
  const {
    recognizedPlant, 
    addPlant,
    fetchPlants,
    addPlantIsError,
    addPlantIsLoading
  } = usePlantStore(state => state);

  useEffect(() => {
    if(selectedIndex === -1)
      return;

    let item = recognizedPlant.results.at(selectedIndex);
    setSelectedItem(item);
    setSelectedItemIndex(selectedIndex);
    onOpen();
  }, [selectedIndex, onOpen, recognizedPlant]);

  const onClose = () => {
    setSelectedIndex(-1);
  }

  useEffect(() => {
    if(addPlantIsLoading || addPlantIsError)
        return setOpen(true)

    setOpen(false)
  }, [addPlantIsLoading, addPlantIsError])
  
  const onSubmit = (e) => {
    let data = {
      imageUrl: recognizedPlant.userImageUrl,
      scientificName: selectedItem.species.scientificName,
      name: e.personalname,
      outside: isOutside,
      description: e.description,
    }

    navigator.geolocation.getCurrentPosition((position) => {
      data.latitude = position.coords.latitude;
      data.longitude = position.coords.longitude;
    })
    
    addPlant(data, fetchPlants);
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

  if(selectedIndex === -1){
    return;
  }

  return (
    <Modal 
        backdrop="blur"
        size="5xl"
        isOpen={isOpen} 
        onClose={onClose}
        onOpenChange={onOpenChange}>
          <InformationModal open={open} setOpen={setOpen} title='Recognized Plant'>
            {(addPlantIsLoading) && <CircularProgress />}
            {(addPlantIsError) && <p>Error!</p>}
          </InformationModal>
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
                    <form onSubmit={handleSubmit(onSubmit)} className="basis-4/6 flex flex-col justify-between">
                      <div>
                        <div className="grid max-w-full grid-cols-3 gap-1">
                          {selectedItem && selectedItem.images.map((image, index)=> 

                            <Image 
                            key={`${index}-${image.url}`}
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
                        <Input label="Personal name" color={errors.personalname ? 'danger' : ''} placeholder='Planta patio 1' {...register("personalname", { required: "Required" })} />
                        <Textarea
                          {...register("description")}
                          label="Description"
                          labelPlacement="outside"
                          placeholder="Enter your description (optional)"
                        />
                        <Checkbox color="success" className="text-white" isSelected={isOutside} onValueChange={setIsOutside}>
                          Outside
                        </Checkbox>
                      </div>
                      <div className="flex justify-between p-2">
                        <Button className="bg-green text-white" type='submit'>
                          Save plant
                        </Button>
                        <Button color="danger" variant="flat" onPress={onClose}>
                          Close
                        </Button>
                      </div>
                    </form>
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
  );
}

export default PlantModal