import React, { useEffect } from 'react';
import { Card, CardFooter, Image } from "@nextui-org/react"
import { useHealthAssesmentsStore } from '../../Store/healthAssesmentsStore'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTriangleExclamation, faCircleCheck } from '@fortawesome/free-solid-svg-icons';
const HealthAssesments = ({ setHealthAssesmentId }) => {
    const fetchHealthAssesments = useHealthAssesmentsStore(state => state.fetchHealthAssesments);
    const healthAssesments = useHealthAssesmentsStore((state) => state.healthAssesments); 

    const getIcon = (probability) => {
        if(probability > 0.8){
            return <FontAwesomeIcon icon={faCircleCheck} className='text-success text-2xl' />
        }

        if(probability > 0.5){
            return <FontAwesomeIcon icon={faTriangleExclamation} className='text-warning text-2xl' />
        }

        return <FontAwesomeIcon icon={faTriangleExclamation} className='text-danger text-2xl' />
    }
    useEffect(() => {
        fetchHealthAssesments();
    }, [fetchHealthAssesments])

    return (
        <>
            <h1 className='text-xl font-bold pt-2'>Health assesments</h1>
            <div className="info grid grid-cols-4 gap-1 pt-1">
                {healthAssesments.length > 0 && healthAssesments.map(x => 
                    <Card key={x.date + x.plantName} isPressable onPress={() => setHealthAssesmentId(x.id)}>
                        <Image
                        removeWrapper
                        alt="Plant"
                        className="z-0 w-full h-full scale-125 -translate-y-8 object-cover"
                        src={x.plantImage}
                        />
                        <CardFooter>
                            <div className='flex w-full justify-between'>
                                <div className="flex flex-col text-start">
                                    <p className="text-xl font-bold">{x.plantName}</p>
                                    <p className="text-small">{new Date(x.date).toLocaleDateString()}</p>
                                </div>
                                <div className='flex flex-col justify-around text-center'>
                                    {getIcon(x.isHealthyProbability)}
                                </div>
                            </div>
                        </CardFooter>
                    </Card>
                )}
            </div>
        </>
       
    );
}

export default HealthAssesments