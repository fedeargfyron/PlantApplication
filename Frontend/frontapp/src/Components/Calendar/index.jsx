import React, { useEffect, useState } from "react";
import { format, addDays, startOfWeek, startOfMonth, endOfMonth, endOfWeek, isSameMonth, isSameDay, parse, addMonths, subMonths } from 'date-fns'
import './calendar.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faChevronLeft, faChevronRight, faTemperatureHigh, faWind, faCloudRain, faDroplet, faHandHoldingDroplet } from '@fortawesome/free-solid-svg-icons'
import { usePlantRiskStore } from '../../Store/plantsRisksStore.jsx';
import { wateringDaysStore } from "../../Store/wateringDaysStore";


let icons = {
  'Rain': faCloudRain,
  'Wind': faWind,
  'Temperature': faTemperatureHigh,
  'Humidity': faDroplet,
}

const Calendar = () => {
  const [currentMonth, setCurrentMonth] = useState(new Date());
  const [selectedDate, setSelectedDate] = useState(new Date());
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


  useEffect(() => {
    fetchWateringDays();
  }, [fetchWateringDays])
  console.log(wateringDays);

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
    return (<FontAwesomeIcon icon={icons[key]} className={color} />)
  }

  const getTodayRisks = (day) => {
    let dayRisks = risks.filter(x => new Date(x.day).getTime() === day.getTime())
    if(dayRisks.length === 0)
      return;

    let groupedRisks = Object.groupBy(dayRisks, ({ risk }) => risk);
    return (<>{Object.keys(groupedRisks).map(x => getIcon(x, groupedRisks[x]))}</>)
  }

  const renderHeader = () => {
    const dateFormat = "MMMM yyyy";

    return (
      <div className="header row flex-middle">
        <div className="col col-start">
            <div className="icon" onClick={prevMonth}>
                <FontAwesomeIcon icon={faChevronLeft} />
            </div>
        </div>
        <div className="col col-center">
          <span>{format(currentMonth, dateFormat)}</span>
        </div>
        <div className="col col-end" onClick={nextMonth}>
            <div className="icon" onClick={nextMonth}>
                <FontAwesomeIcon icon={faChevronRight} />
            </div>
        </div>
      </div>
    );
  }

  const renderDays = () => {
    const dateFormat = "dd";
    const days = [];

    let startDate = startOfWeek(currentMonth);

    for (let i = 0; i < 7; i++) {
      days.push(
        <div className="col col-center" key={i}>
          {format(addDays(startDate, i), dateFormat)}
        </div>
      );
    }

    return <div className="days row">{days}</div>;
  }
  
  const renderCells = () => {
    const monthStart = startOfMonth(currentMonth);
    const monthEnd = endOfMonth(monthStart);
    const startDate = startOfWeek(monthStart);
    const endDate = endOfWeek(monthEnd);

    const dateFormat = "d";
    const rows = [];

    let days = [];
    let day = startDate;
    let formattedDate = "";

    const wateringSpecificDates = [...new Set(wateringDays.map(x => x.wateringSpecificDates).flat())].map(x => new Date(x).getTime());


    while (day <= endDate) {
      for (let i = 0; i < 7; i++) {
        formattedDate = format(day, dateFormat);
        const cloneDay = day;
        days.push(
          <div
            className={`col cell flex flex-col justify-between p-1 ${
              !isSameMonth(day, monthStart)
                ? "disabled"
                : isSameDay(day, selectedDate) ? "selected" : ""
            }`}
            key={day}
            onClick={() => onDateClick(parse(cloneDay))}
          >
            <div>
              {getTodayRisks(cloneDay)}
              <span className="number">{formattedDate}</span>
              <span className="bg">{formattedDate}</span>
            </div>
            <div>
              {wateringSpecificDates.includes(cloneDay.getTime()) && <FontAwesomeIcon icon={faHandHoldingDroplet} className="text-softblue" />}
            </div>
          </div>
        );
        day = addDays(day, 1);
      }
      rows.push(
        <div className="row" key={day}>
          {days}
        </div>
      );
      days = [];
    }
    return <div className="body">{rows}</div>;
  }

  const onDateClick = (day) => {
    setSelectedDate(day);
  };

  const nextMonth = () => {
    setCurrentMonth(addMonths(currentMonth, 1));
  };

  const prevMonth = () => {
    setCurrentMonth(subMonths(currentMonth, 1));
  };

  return (
    <div className="calendar">
      {renderHeader()}
      {renderDays()}
      {renderCells()}
    </div>
  );
}

export default Calendar;