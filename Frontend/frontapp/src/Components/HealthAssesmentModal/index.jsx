import React, { useEffect } from 'react';
import { Image, Modal, ModalContent, ModalBody, ModalHeader, useDisclosure } from "@nextui-org/react"
import { useHealthAssesmentsStore } from '../../Store/healthAssesmentsStore'

const HealthAssesmentModal = ({id, setHealthAssesmentId}) => {

    const {isOpen, onOpen, onOpenChange} = useDisclosure();
    const fetchHealthAssesmentById = useHealthAssesmentsStore(state => state.fetchHealthAssesmentById);
    const healthAssesment = useHealthAssesmentsStore((state) => state.healthAssesment); 

    const onClose = () => {
        setHealthAssesmentId(-1);
      }

    useEffect(() => {
        if(id === -1){
            return;
        }

        fetchHealthAssesmentById(id);
        onOpen();
    }, [fetchHealthAssesmentById, id, onOpen])

    if(id === -1){
        return;
    }

    return (
    <Modal 
        backdrop="blur"
        isOpen={isOpen} 
        onOpenChange={onOpenChange}
        onClose={onClose}
        size="5xl">
          <ModalContent>
            {() => (
              <>
                <ModalHeader className="flex gap-1 max-h-[700px] bg-softwhite">Health Assesment</ModalHeader>
                <ModalBody className="flex flex-row max-h-[700px]">
                  <Image
                    removeWrapper
                    alt="Card example background"
                    className="max-w-[400px] max-h-full object-cover"
                    src={healthAssesment.plantImage}
                  />
                  <div className="flex bg-softwhite">
                    <div className="flex justify-between">
                        <div className="flex flex-col">
                        <p className="text-bold text-lg capitalize">Match probability</p>
                        <p className="text-bold text-m capitalize">%</p>
                        </div>
                        <div className="flex flex-col">
                        <p className="text-bold text-lg capitalize">Scientific name</p>
                        <p className="text-bold text-m capitalize"></p>
                        </div>
                    </div>
                  </div>
                </ModalBody>
              </>
            )}
          </ModalContent>
        </Modal>
        
  );
}

export default HealthAssesmentModal