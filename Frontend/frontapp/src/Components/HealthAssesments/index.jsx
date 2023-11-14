import React, { useEffect } from 'react';
import { Card, CardBody } from "@nextui-org/react"
import { useHealthAssesmentsStore } from '../../Store/healthAssesmentsStore'
const HealthAssesments = ({ setHealthAssesmentId }) => {
    const fetchHealthAssesments = useHealthAssesmentsStore(state => state.fetchHealthAssesments);
    const healthAssesments = useHealthAssesmentsStore((state) => state.healthAssesments); 

    const getBackgroundColor = (probability) => {
        if(probability > 0.8){
            return 'bg-success'
        }

        if(probability > 0.5){
            return 'bg-warning'
        }

        return 'bg-danger' 
    }
    useEffect(() => {
        fetchHealthAssesments();
    }, [fetchHealthAssesments])

    return (
        <>
            <div className="info grid grid-cols-4 gap-1 pt-1">
                {healthAssesments.length > 0 && healthAssesments.map(x => 
                    <Card key={x.date + x.plantName} isPressable onPress={() => setHealthAssesmentId(x.id)} className={`${getBackgroundColor(x.isHealthyProbability)}`}>
                        <CardBody>
                            <div className="flex flex-col">
                                <p className="text-lg font-bold">Plant</p>
                                <p className="text-small">{x.plantName}</p>
                            </div>
                            <div className="flex flex-col">
                                <p className="text-lg font-bold">Date</p>
                                <p className="text-small">{new Date(x.date).toLocaleDateString()}</p>
                            </div>
                            <div className="flex flex-col">
                                <p className="text-lg font-bold">Disease</p>
                                <p className="text-small">{x.disease}</p>
                            </div>
                        </CardBody>
                    </Card>
                )}
            </div>
        </>
       
    );
}

export default HealthAssesments