import React, { useEffect, useState } from "react";
import './calendar.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTemperatureHigh, faWind, faCloudRain, faDroplet } from '@fortawesome/free-solid-svg-icons'
import { usePlantRiskStore } from '../../Store/plantsRisksStore.jsx';
import { wateringDaysStore } from "../../Store/wateringDaysStore.jsx";
import { Tooltip } from "@nextui-org/react";
import Calendar from "../Calendar";

let icons = {
  'Rain': faCloudRain,
  'Wind': faWind,
  'Temperature': faTemperatureHigh,
  'Humidity': faDroplet,
}

const PlantCalendar = ({id}) => {
  const [wateringSpecificDates, setWateringSpecificDates] = useState(null);
  const [actualPlantRisks, setActualPlantRisks] = useState(null);
  const [selectedCalendarDay, setSelectedCalendarDay] = useState(new Date());
  const fetchPlantsRisks = usePlantRiskStore(state => state.fetchPlantsRisks);
  const plantRisks = usePlantRiskStore(state => state.plantRisks);
  const fetchWateringDays = wateringDaysStore(state => state.fetchWateringDays);
  const wateringDays = wateringDaysStore(state => state.wateringDays);

  useEffect(() => {
    navigator.geolocation.getCurrentPosition((position) => {
      const lat = position.coords.latitude;
      const long = position.coords.longitude;
      fetchPlantsRisks(lat, long);
    })
  }, [fetchPlantsRisks])


  useEffect(() => {
    fetchWateringDays();
  }, [fetchWateringDays])

  useEffect(() => {
    if(plantRisks.length == 0)
      return; 

    setActualPlantRisks(plantRisks.find(x => x.plantId === id))
  }, [plantRisks, setActualPlantRisks])

  useEffect(() => {
    if(wateringDays.length == 0)
      return;

    setWateringSpecificDates(wateringDays.find(x => x.id === id).wateringSpecificDates.map(x => new Date(x).getTime()))
  }, [wateringDays, setWateringSpecificDates])

  const getDangerColor = (plantRisk) => {
    if(plantRisk === 'high')
      return 'text-danger';

    if(plantRisk === 'medium')
      return 'text-warning';

    return 'text-success';
  }

  const getIcon = (risk) => {
    return (<Tooltip key={risk.day + risk.risk} showArrow={true} content={risk.description}>
      <FontAwesomeIcon icon={icons[risk.risk]} className={getDangerColor(risk.level)} />
    </Tooltip>)
  }

  const checkEqualDates = (date1, date2) => date1.getDate() === date2.getDate()

  const getTodayRisks = (day) => {
    if(!actualPlantRisks)
      return;

    let dayRisks = actualPlantRisks.risks.filter(x => checkEqualDates(new Date(x.day), day));
    if(dayRisks.length === 0)
      return;

    return (<>{dayRisks.map(x => getIcon(x))}</>)
  }

  return <Calendar setSelectedCalendarDay={setSelectedCalendarDay} getTodayRisks={getTodayRisks} wateringSpecificDates={wateringSpecificDates} />
}

export default PlantCalendar;