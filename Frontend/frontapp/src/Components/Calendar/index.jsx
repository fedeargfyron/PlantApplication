import React, { useState } from "react";
import { format, addDays, startOfWeek, startOfMonth, endOfMonth, endOfWeek, isSameMonth, isSameDay, addMonths, subMonths } from 'date-fns'
import './calendar.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faChevronLeft, faChevronRight, faHandHoldingDroplet } from '@fortawesome/free-solid-svg-icons'

const Calendar = ({setSelectedCalendarDay, getTodayRisks, wateringSpecificDates}) => {
  const [currentMonth, setCurrentMonth] = useState(new Date());
  const [selectedDate, setSelectedDate] = useState(new Date());

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
            onClick={() => onDateClick(cloneDay)}
          >
            <div>
              {getTodayRisks(cloneDay)}
              <span className="number">{formattedDate}</span>
              <span className="bg">{formattedDate}</span>
            </div>
            <div>
              {wateringSpecificDates && wateringSpecificDates.includes(cloneDay.getTime()) && <FontAwesomeIcon icon={faHandHoldingDroplet} className="text-softblue" />}
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
    setSelectedCalendarDay(day);
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