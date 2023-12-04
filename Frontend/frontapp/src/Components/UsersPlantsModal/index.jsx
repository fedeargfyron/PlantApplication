import React, { useEffect } from 'react';
import { Image, Modal, ModalContent, ModalBody, ModalHeader, useDisclosure, } from "@nextui-org/react"

const PlantModal = ({open, setOpen, images}) => {
  const {isOpen, onOpen, onOpenChange } = useDisclosure();

  useEffect(() => {
    if(open)
        onOpen();
}, [open, onOpen])


    const onClose = () => {
        setOpen(false);
    }
  return (
    <Modal 
        backdrop="blur"
        size="xl"
        isOpen={isOpen} 
        onClose={onClose}
        onOpenChange={onOpenChange}>
          <ModalContent>
            {() => (
              <>
                <ModalHeader className="flex gap-1 max-h-[700px] bg-softwhite">Users plants</ModalHeader>
                <ModalBody className="flex flex-row max-h-[700px] justify-center">
                {images.map(x => 
                    <Image
                    removeWrapper
                    key={x}
                    height={200}
                    alt="Card example background"
                    className="object-cover w-full max-w-[200px] h-[200px]"
                    width="100%"
                    src={x}
                    />
                )}
                </ModalBody>
              </>
            )}
          </ModalContent>
    </Modal>
  );
}

export default PlantModal