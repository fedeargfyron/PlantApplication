import React, { useEffect, useState } from 'react';
import { Modal, ModalContent, ModalBody, ModalHeader, useDisclosure, Input, Button, CircularProgress } from "@nextui-org/react"
import { useForm } from 'react-hook-form';
import { useUserStore } from '../../Store/usersStore';
import InformationModal from '../InformationModal';

const RecoverPasswordModal = ({openModal, setOpenModal}) => {
    const {isOpen, onOpen, onOpenChange} = useDisclosure();
    const { 
      register, 
      handleSubmit, 
      formState: { errors } } = useForm();
    const { 
      recoverPassword,
      recoverIsLoading,
      recoverIsError
    } = useUserStore((state) => state);
    const [open, setOpen] = useState(false);

    useEffect(() => {
        if(openModal)
            onOpen();
    }, [openModal, onOpen])

    useEffect(() => {
      if(recoverIsLoading || recoverIsError)
        setOpen(true)
      else{
        setOpen(false)
      }
      
      }, [recoverIsLoading, recoverIsError])

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
          <InformationModal open={open} setOpen={setOpen} title='Recover password'>
            {recoverIsLoading && <CircularProgress />}
            {recoverIsError && <p>Error!</p>}
          </InformationModal>
          <ModalContent>
            {() => (
              <>
                <ModalHeader className="flex gap-1 max-h-[700px]">Recover Password</ModalHeader>
                <ModalBody className="flex flex-row max-h-[700px]">
                <form className='flex w-full items-center' onSubmit={handleSubmit(onSubmit)}>
                  <div className='w-full'>
                    <Input label="Email" color={errors.email ? 'danger' : ''} placeholder='Email123@gmail.com' {...register("email", { required: "Required" })} />
                  </div>
                    
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