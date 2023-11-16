import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTemperatureHigh, faWind, faCloudRain, faDroplet } from '@fortawesome/free-solid-svg-icons'
import { usePlantRiskStore } from '../../Store/plantsRisksStore.jsx';
import { wateringDaysStore } from "../../Store/wateringDaysStore.jsx";
import Calendar from "../Calendar/index.jsx";

let icons = {
  'Rain': faCloudRain,
  'Wind': faWind,
  'Temperature': faTemperatureHigh,
  'Humidity': faDroplet,
}

const PlantsCalendar = ({setSelectedCalendarDay}) => {
  const [risks, setRisks] = useState([]);
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

  const wateringSpecificDates = [...new Set(wateringDays.map(x => x.wateringSpecificDates).flat())].map(x => new Date(x).getTime());
  useEffect(() => {
    fetchWateringDays();
  }, [fetchWateringDays])

  useEffect(() => {
    setRisks(plantRisks.map(x => x.risks).flat())
  }, [plantRisks, setRisks])

  const getDangerousColor = (risks) => {
    let uniqueLevels = risks.map(item => item.level);

    if(uniqueLevels.some(x => x === 'high'))
      return 'danger';

    if(uniqueLevels.some(x => x === 'medium'))
      return 'warning';

    return 'success';
  }

  const getIcon = (key, risks) => {
    let color = `text-${getDangerousColor(risks)}`
    return (<FontAwesomeIcon key={key} icon={icons[key]} className={color} />)
  }

  const getTodayRisks = (day) => {
    let dayRisks = risks.filter(x => new Date(x.day).getTime() === day.getTime())
    if(dayRisks.length === 0)
      return;

    let groupedRisks = Object.groupBy(dayRisks, ({ risk }) => risk);
    return (<>{Object.keys(groupedRisks).map(x => getIcon(x, groupedRisks[x]))}</>)
  }

  return <Calendar setSelectedCalendarDay={setSelectedCalendarDay} getTodayRisks={getTodayRisks} wateringSpecificDates={wateringSpecificDates} />
}

export default PlantsCalendar;