import React, { useEffect } from 'react';
import { Image, Modal, ModalContent, ModalBody, ModalHeader, useDisclosure, CircularProgress } from "@nextui-org/react"
import { useHealthAssesmentsStore } from '../../Store/healthAssesmentsStore'

const HealthAssesmentModal = ({id, setHealthAssesmentId}) => {

    const {isOpen, onOpen, onOpenChange} = useDisclosure();
    const {
      fetchHealthAssesmentById,
      healthAssesment, 
      healthAssesmentIsLoading, 
      healthAssesmentIsError
    } = useHealthAssesmentsStore((state) => state); 
    
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

    if(id === -1 || healthAssesment == null){
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
                <ModalHeader className="flex gap-1 max-h-[700px]">Health Assesment</ModalHeader>
                <ModalBody className="flex flex-row max-h-[700px]">
                  {healthAssesmentIsLoading && <CircularProgress />}
                  {healthAssesmentIsError && <p>Error!</p>}
                  <Image
                    removeWrapper
                    alt="Card example background"
                    className="max-w-[400px] max-h-full object-cover"
                    src={healthAssesment.plantImage}
                  />
                  <div className="flex w-full justify-between p-2">
                    <div className="flex flex-col w-6/12 justify-between">
                        <div className="flex flex-col">
                          <p className="text-bold text-lg capitalize font-bold">Plant</p>
                          <p className="text-bold text-m capitalize">{healthAssesment.plantName}</p>
                        </div>
                        <div className="flex flex-col">
                          <p className="text-bold text-lg capitalize font-bold">Is Healthy Probability</p>
                          <p className="text-bold text-m capitalize">%{healthAssesment.isHealthyProbability * 100}</p>
                        </div>
                        <div className="flex flex-col">
                          <p className="text-bold text-lg capitalize font-bold">Disease Common Names</p>
                          <p className="text-bold text-m capitalize">{healthAssesment.diseaseCommonNames}</p>
                        </div>
                        <div className="flex flex-col">
                          <p className="text-bold text-lg capitalize font-bold">Disease Probability</p>
                          <p className="text-bold text-m capitalize">%{healthAssesment.diseaseProbability * 100}</p>
                        </div>
                    </div>
                    <div className="flex flex-col w-6/12 justify-between">
                      <div className="flex flex-col">
                          <p className="text-bold text-lg capitalize font-bold">Date</p>
                          <p className="text-bold text-m capitalize">{healthAssesment.date}</p>
                        </div>
                        <div className="flex flex-col">
                          <p className="text-bold text-lg capitalize font-bold">Disease</p>
                          <p className="text-bold text-m capitalize">{healthAssesment.disease}</p>
                        </div>
                        <div className="flex flex-col">
                          <p className="text-bold text-lg capitalize font-bold">Disease Description</p>
                          <p className="text-bold text-m capitalize">{healthAssesment.diseaseDescription}</p>
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