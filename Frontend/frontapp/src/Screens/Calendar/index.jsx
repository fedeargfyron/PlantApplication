import React, { useState } from "react";
import Calendar from "../../Components/Calendar";
import HealthAssesments from "../../Components/HealthAssesments";
import HealthAssesmentModal from "../../Components/HealthAssesmentModal";
export default function App() {
  const [healthAssesmentId, setHealthAssesmentId] = useState(-1);

  return (
    <div className="mx-auto max-w-5xl pt-10 flex flex-col">
        <HealthAssesmentModal id={healthAssesmentId} setHealthAssesmentId={setHealthAssesmentId}/>
        <Calendar />
        <HealthAssesments healthAssesmentId={healthAssesmentId} setHealthAssesmentId={setHealthAssesmentId} />
    </div>
  );
}