import React, { useState, useEffect } from 'react';
import RiskAlert from './RiskAlert';
import { faTemperatureHigh, faWind, faCloudRain, faDroplet } from '@fortawesome/free-solid-svg-icons'
import { usePlantRiskStore } from '../../Store/plantsRisksStore.jsx';

const RiskAlerts = ({plants}) => {
  const [risks, setRisks] = useState([]);
  let fetchPlantsRisks = usePlantRiskStore(state => state.fetchPlantsRisks);
  let plantRisks = usePlantRiskStore(state => state.plantRisks);
  useEffect(() => {
    navigator.geolocation.getCurrentPosition((position) => {
      const lat = position.coords.latitude;
      const long = position.coords.longitude;
      fetchPlantsRisks(lat, long);
    })
  }, [fetchPlantsRisks])

  useEffect(() => {
    if(!plantRisks || !plants || plantRisks.length === 0 || plants.length === 0)
      return;

    let newRisks = [];
    plantRisks.map(x => {
      let plantInformation = plants.find((element) => element.id == x.plantId);
      let result = Object.groupBy(x.risks, ({ risk }) => risk);
      newRisks.push({
        imageLink: plantInformation.imageLink,
        plantName: plantInformation.name,
        plantId: x.plantId,
        risks: result
      })
    })
    
    setRisks(newRisks);
  }, [plantRisks, plants, setRisks])

  return (
    <div className="absolute -left-12">
      <RiskAlert key={'Temperature'} icon={faTemperatureHigh} type={'Temperature'} plantsRisks={risks}/>
      <RiskAlert key={'Rain'} icon={faCloudRain} type={'Rain'} plantsRisks={risks}/>
      <RiskAlert key={'Humidity'} icon={faDroplet} type={'Humidity'} plantsRisks={risks}/>
      <RiskAlert key={'Wind'} icon={faWind} type={'Wind'} plantsRisks={risks}/>
    </div>
  );
}

export default RiskAlerts