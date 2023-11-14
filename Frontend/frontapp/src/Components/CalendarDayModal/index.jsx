import React, { useEffect } from 'react';
import { Table, TableHeader, TableBody, TableCell, TableColumn, TableRow, Modal, ModalContent, ModalBody, ModalHeader, useDisclosure } from "@nextui-org/react"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTemperatureHigh, faWind, faCloudRain, faDroplet, faHandHoldingDroplet } from '@fortawesome/free-solid-svg-icons'

const CalendarDayModal = ({selectedCalendarDay, setSelectedCalendarDay}) => {
    const {isOpen, onOpen, onOpenChange} = useDisclosure();
    const onClose = () => {
        setSelectedCalendarDay(null);
}
    const columns = [
      {name: "PLANT", uid: "plant"},
      {name: "STATUS", uid: "status"}
    ];
    useEffect(() => {
      console.log(selectedCalendarDay)
      if(selectedCalendarDay === null){
          return;
      }
      onOpen();
    }, [selectedCalendarDay, onOpen])

    if(selectedCalendarDay === null){
        return;
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
                <ModalHeader className="flex gap-1 max-h-[700px]">Day</ModalHeader>
                <ModalBody className="flex flex-row max-h-[700px]">
                <Table aria-label="Example table with custom cells">
                  <TableHeader columns={columns}>
                    {(column) => (
                      <TableColumn key={column.uid} align="start">
                        {column.name}
                      </TableColumn>
                    )}
                  </TableHeader>
                  <TableBody>
                    <TableRow key="2">
                      <TableCell>Planta 1</TableCell>
                      <TableCell>
                        <FontAwesomeIcon icon={faCloudRain} className='text-warning'/>
                        <FontAwesomeIcon icon={faWind} className='text-success'/>
                      </TableCell>
                    </TableRow>
                    <TableRow key="3">
                      <TableCell>Planta 1</TableCell>
                      <TableCell>
                        <FontAwesomeIcon icon={faHandHoldingDroplet} className='text-softblue'/>
                        <FontAwesomeIcon icon={faDroplet} className='text-success'/>
                        <FontAwesomeIcon icon={faTemperatureHigh} className='text-danger'/>
                      </TableCell>
                    </TableRow>
                  </TableBody>
                </Table>
                </ModalBody>
              </>
            )}
          </ModalContent>
        </Modal>
        
  );
}

export default CalendarDayModal