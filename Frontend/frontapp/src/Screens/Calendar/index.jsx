import React, { useState } from "react";
import PlantsCalendar from "../../Components/PlantsCalendar";
import HealthAssesments from "../../Components/HealthAssesments";
import HealthAssesmentModal from "../../Components/HealthAssesmentModal";
import CalendarDayModal from "../../Components/CalendarDayModal";
export default function App() {
  const [healthAssesmentId, setHealthAssesmentId] = useState(-1);
  const [selectedCalendarDay, setSelectedCalendarDay] = useState(null);
  return (
    <div className="mx-auto min-h-screen max-w-5xl pt-10 flex flex-col">
        <CalendarDayModal selectedCalendarDay={selectedCalendarDay} setSelectedCalendarDay={setSelectedCalendarDay}/>
        <HealthAssesmentModal id={healthAssesmentId} setHealthAssesmentId={setHealthAssesmentId}/>
        <PlantsCalendar setSelectedCalendarDay={setSelectedCalendarDay}/>
        <HealthAssesments healthAssesmentId={healthAssesmentId} maxHealthAssesmentsCards={4} setHealthAssesmentId={setHealthAssesmentId} />
    </div>
  );
}