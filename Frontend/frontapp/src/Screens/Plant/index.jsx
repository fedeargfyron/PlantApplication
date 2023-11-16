import { Button, Card, Image, CardFooter, Input, Table, TableHeader, TableRow, TableCell, TableColumn, TableBody, Textarea, Checkbox  } from "@nextui-org/react"
import { useState, useEffect } from "react";
import { usePlantStore } from "../../Store/plantsStore";
import PlantCalendar from "../../Components/PlantCalendar";
import HealthAssesments from "../../Components/HealthAssesments";
import HealthAssesmentModal from "../../Components/HealthAssesmentModal";
import { useParams } from "react-router-dom";


export default function Plant() {
    const [healthAssesmentId, setHealthAssesmentId] = useState(-1);
    const [isOutside, setIsOutside] = useState(false);
    const [selectedCalendarDay, setSelectedCalendarDay] = useState(null);
    const params = useParams();
    const plantId = params.id;
    const fetchPlantById = usePlantStore((state) => state.fetchPlantById);
    const plant = usePlantStore(state => state.plant);

    useEffect(() => {
        fetchPlantById(plantId);
      }, [fetchPlantById])

    return (
        <div className="flex justify-center pt-10 min-h-screen bg-softwhite w-full">
            <div className="w-1/2 p-2 flex flex-col">
                <HealthAssesmentModal id={healthAssesmentId} setHealthAssesmentId={setHealthAssesmentId}/>
                <PlantCalendar id={Number(plantId)} setSelectedCalendarDay={setSelectedCalendarDay}/>
                <HealthAssesments healthAssesmentId={healthAssesmentId} plantId={plantId} addNewHealthAssesment={true} setHealthAssesmentId={setHealthAssesmentId} />
            </div>
            <div className="p-2 flex flex-col">
                {plant && 
                <form>
                    <div className="flex flex-col justify-center w-fit">
                        <Card isFooterBlurred className="h-[400px] mb-3">
                            <Image
                                removeWrapper
                                alt="Card example background"
                                className="z-0 w-full h-full scale-125 -translate-y-6 object-cover"
                                src={plant.imageLink}
                            />
                            <CardFooter className="absolute bg-white/30 bottom-0 border-t-1 border-zinc-100/50 z-10 justify-between">
                            <div className="justify-start text-start">
                                <Input 
                                    variant='bordered'
                                    radius="sm"
                                    defaultValue={plant.name}
                                    classNames={{
                                        input: [
                                            "text-lg bg-transparent"
                                        ]
                                    }}
                                />
                                <p className="pt-1 text-black text-sm">{plant.scientificName}</p>
                            </div>
                            </CardFooter>
                        </Card>
                        <Card className="flex flex-col p-2 justify-between">
                            <Table isStriped aria-label="Example table with custom cells" className="w-full">
                                <TableHeader>
                                    <TableColumn>
                                        FIELD
                                    </TableColumn>
                                    <TableColumn>
                                        VALUE
                                    </TableColumn>
                                </TableHeader>
                                <TableBody>
                                    <TableRow>
                                        <TableCell>Common Name</TableCell>
                                        <TableCell>{plant.commonName}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Watering Days Frequency</TableCell>
                                        <TableCell>{plant.wateringDaysFrequency} days</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Cycle</TableCell>
                                        <TableCell>{plant.cycle}</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell>Type</TableCell>
                                        <TableCell>{plant.type}</TableCell>
                                    </TableRow>
                                </TableBody>
                            </Table>
                            <Checkbox color="success" className="text-white pt-3 pb-3" isSelected={isOutside} onValueChange={setIsOutside}>
                                Outside
                            </Checkbox>
                            <Textarea
                            labelPlacement="outside"
                            placeholder="Description"
                            >
                                {plant.description}
                            </Textarea>
                            <div className="flex justify-start pt-2">
                                <Button className=" text-white text-md p-4 mr-2" color="success" radius="full" size="sm">
                                    Update
                                </Button>
                                <Button className="p-4 text-md" color="danger" radius="full" size="sm">
                                    Back
                                </Button>
                            </div>
                        </Card>
                    </div>
                </form>}
            </div>
        </div>
    )
}