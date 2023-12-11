import React, { useEffect } from 'react';
import { Table, TableHeader, TableBody, TableCell, TableColumn, TableRow, Modal, ModalContent, ModalBody, ModalHeader, useDisclosure, Avatar, Tooltip } from "@nextui-org/react"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTemperatureHigh, faWind, faCloudRain, faDroplet, faHandHoldingDroplet } from '@fortawesome/free-solid-svg-icons'
import { usePlantRiskStore } from '../../Store/plantsRisksStore.jsx';
import { wateringDaysStore } from "../../Store/wateringDaysStore";

const CalendarDayModal = ({selectedCalendarDay, setSelectedCalendarDay}) => {
    const {isOpen, onOpen, onOpenChange} = useDisclosure();
    const onClose = () => {
        setSelectedCalendarDay(null);
    }

    const fetchPlantsRisks = usePlantRiskStore(state => state.fetchPlantsRisks);
    const plantRisks = usePlantRiskStore(state => state.plantRisks);
    const fetchWateringDays = wateringDaysStore(state => state.fetchWateringDays);
    const wateringDays = wateringDaysStore(state => state.wateringDays);

    let icons = {
      'Rain': faCloudRain,
      'Wind': faWind,
      'Temperature': faTemperatureHigh,
      'Humidity': faDroplet,
    }

    const getDangerColor = (plantRisk) => {
      if(plantRisk === 'high')
        return 'text-danger';
  
      if(plantRisk === 'medium')
        return 'text-warning';
  
      return 'text-success';
    }

    const columns = [
      {name: "PLANT", uid: "plant"},
      {name: "STATUS", uid: "status"}
    ];
    useEffect(() => {
      if(selectedCalendarDay === null){
          return;
      }
      onOpen();
    }, [selectedCalendarDay, onOpen])

    const checkEqualDates = (date1, date2) => date1.getDate() === date2.getDate()

    useEffect(() => {
      navigator.geolocation.getCurrentPosition((position) => {
        const lat = position.coords.latitude;
        const long = position.coords.longitude;
        fetchPlantsRisks(lat, long);
      })
    }, [fetchPlantsRisks])
    const getPlantsWithIcons = () => {
      let mergedResult = mergeById(wateringDays, plantRisks);
      let todayResults = mergedResult.filter(x => 
            x.wateringSpecificDates.some(w => checkEqualDates(new Date(w), selectedCalendarDay))
            ||(x.risks && x.risks.some(r => checkEqualDates(new Date(r.day), selectedCalendarDay))));
      return todayResults.map(x => 
        <TableRow key={x.id + x.name}>
          <TableCell className='flex gap-4'>
            <Avatar isBordered radius="full" size="md" src={x.imageLink} />
            <div className="flex flex-col gap-1 items-start justify-center">
              <h4 className="text-small font-semibold leading-none text-default-600">{x.name}</h4>
              <h5 className="text-small tracking-tight text-default-400">{x.plantScientificName}</h5>
            </div>
          </TableCell>
          <TableCell>
            {x.wateringSpecificDates.some(w => checkEqualDates(new Date(w), selectedCalendarDay)) && 
            <Tooltip showArrow={true} content='This plant should be watered'>
              <FontAwesomeIcon icon={faHandHoldingDroplet} className='text-softblue'/>
            </Tooltip> }
            {x.risks && x.risks.filter(r => checkEqualDates(new Date(r.day), selectedCalendarDay)).map(r => 
            <Tooltip key={`${x.id}-${r.risk}`} showArrow={true} content={r.description}>
              <FontAwesomeIcon  icon={icons[r.risk]} className={`${getDangerColor(r.level)}`} />
            </Tooltip>)}
          </TableCell>
        </TableRow>)
    }
    const mergeById = (wateringDays, plantRisks) => {
      return wateringDays.map(x => ({
        ...plantRisks.find(({plantId}) => (plantId == x.id)),
        ...x
      }));
    }
      

    useEffect(() => {
      fetchWateringDays();
    }, [fetchWateringDays])

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
                    {getPlantsWithIcons()}
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