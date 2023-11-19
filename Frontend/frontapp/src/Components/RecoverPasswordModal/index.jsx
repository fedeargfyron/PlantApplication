import React, { useEffect } from 'react';
import { Modal, ModalContent, ModalBody, ModalHeader, useDisclosure, Input, Button } from "@nextui-org/react"
import { useForm } from 'react-hook-form';
import { useUserStore } from '../../Store/usersStore';

const RecoverPasswordModal = ({openModal, setOpenModal}) => {
    const {isOpen, onOpen, onOpenChange} = useDisclosure();
    const { register, handleSubmit } = useForm();
    const recoverPassword = useUserStore((state) => state.recoverPassword);
    
    useEffect(() => {
        if(openModal)
            onOpen();
    }, [openModal, onOpen])

    const onClose = () => {
        setOpenModal(false);
    }

    const onSubmit = (e) => {
        let data = {
            email: e.email
        };

        recoverPassword(data);
    }

    return (
    <Modal 
        backdrop="blur"
        isOpen={isOpen} 
        onOpenChange={onOpenChange}
        onClose={onClose}
        size="lg">
          <ModalContent>
            {() => (
              <>
                <ModalHeader className="flex gap-1 max-h-[700px]">Recover Password</ModalHeader>
                <ModalBody className="flex flex-row max-h-[700px]">
                <form className='flex w-full items-center' onSubmit={handleSubmit(onSubmit)}>
                    <Input label="Email" placeholder='Email123@gmail.com' {...register("email", { required: true })} />
                    <Button type="submit" color="success" className="p-5 ml-2 font-bold text-white">Send</Button>
                </form>
                </ModalBody>
              </>
            )}
          </ModalContent>
        </Modal>
        
  );
}

export default RecoverPasswordModal