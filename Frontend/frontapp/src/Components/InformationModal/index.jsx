import React, { useEffect } from 'react';
import { Modal, ModalContent, ModalBody, ModalHeader, useDisclosure } from "@nextui-org/react"

const InformationModal = ({open, setOpen, children, title }) => {
    const {isOpen, onOpen, onOpenChange, onClose} = useDisclosure();

    useEffect(() => {
      if(open)
        onOpen();
      else{
        onClose();
      }
    }, [open, onOpen, onClose]);
    const close = () => {
      setOpen(false);
    }
    return (
    <Modal 
        backdrop="blur"
        isOpen={isOpen} 
        onOpenChange={onOpenChange}
        onClose={close}
        size="xl">
          <ModalContent>
            {() => (
              <>
                <ModalHeader className="flex gap-1 max-h-[700px]">{title}</ModalHeader>
                <ModalBody className="flex flex-row max-h-[700px] justify-center">
                  { children }
                </ModalBody>
              </>
            )}
          </ModalContent>
        </Modal>
        
  );
}

export default InformationModal