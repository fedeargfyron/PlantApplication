import { Button, Card, Image, CardFooter, CardBody } from "@nextui-org/react"
import { useState, useEffect } from "react";
import { usePlantStore } from "../../Store/plantsStore";
import PlantCalendar from "../../Components/PlantCalendar";
import HealthAssesments from "../../Components/HealthAssesments";
import HealthAssesmentModal from "../../Components/HealthAssesmentModal";
import { useParams } from "react-router-dom";


export default function Plant() {
    const [selectedCalendarDay, setSelectedCalendarDay] = useState(null);
    const params = useParams();
    const id = params.id;
  //const fetchPlantById = usePlantStore((state) => state.fetchPlantById);
  //const plant = usePlantStore(state => state.plant);
    return (
        <div className="flex justify-center pt-10 h-screen bg-softwhite w-full mx-auto">
            <div className="w-1/2 flex flex-col">
                <PlantCalendar id={Number(id)} setSelectedCalendarDay={setSelectedCalendarDay}/>
            </div>
            {/*<HealthAssesmentModal id={healthAssesmentId} setHealthAssesmentId={setHealthAssesmentId}/>*/}
            {/*<HealthAssesments healthAssesmentId={healthAssesmentId} setHealthAssesmentId={setHealthAssesmentId} />*/}
        </div>
    )
}