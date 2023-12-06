import React, { useEffect, useState } from 'react';
import { Card, CardFooter, Image, CircularProgress, Pagination } from "@nextui-org/react"
import { useHealthAssesmentsStore } from '../../Store/healthAssesmentsStore'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTriangleExclamation, faCircleCheck } from '@fortawesome/free-solid-svg-icons';
import RecognizeCard from '../RecognizeCard';
import { Permission } from '../../Enums/Permission';

const HealthAssesments = ({ setHealthAssesmentId, maxHealthAssesmentsCards, plantId, addNewHealthAssesment }) => {
    const {
        fetchHealthAssesments,
        healthAssesments, 
        healthAssesmentsIsLoading, 
        healthAssesmentsIsError
    } = useHealthAssesmentsStore((state) => state); 
    const [actualHealthAssesments, setActualHealthAssesments] = useState([])
    const [permissions, setPermissions] = useState([])
    const [page, setPage] = React.useState(1);
    const pages = Math.ceil(actualHealthAssesments.length / maxHealthAssesmentsCards);
    const items = React.useMemo(() => {
        const start = (page - 1) * maxHealthAssesmentsCards;
        const end = start + maxHealthAssesmentsCards;
    
        return actualHealthAssesments.slice(start, end);
      }, [page, actualHealthAssesments, maxHealthAssesmentsCards]);

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

    useEffect(() => {
        let localPermissions = JSON.parse(localStorage.getItem("permissions"));
    
        if(!localPermissions){
            return;
        }
    
        setPermissions(Object.keys(localPermissions));
      }, [setPermissions])

    useEffect(() => {
        if(!plantId)
            return setActualHealthAssesments(healthAssesments);

        setActualHealthAssesments(healthAssesments.filter(x => x.plantId == plantId));

    }, [healthAssesments, setActualHealthAssesments, plantId])

    return (
        <>
            <h1 className='text-xl font-bold pt-2'>Health assesments</h1>
            {healthAssesmentsIsLoading && <CircularProgress />}
            {healthAssesmentsIsError && <p>Error!</p>}
            <div className="info grid grid-cols-4 gap-1 pt-1">
                {actualHealthAssesments.length > 0 && items.map(x => 
                    <Card key={x.date + x.plantName} isPressable onPress={() => permissions.includes(Permission[Permission.GetHealthAssesmentById]) && setHealthAssesmentId(x.id)}>
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
                {addNewHealthAssesment && permissions.includes(Permission[Permission.DoHealthAssesments]) && <RecognizeCard plantId={plantId} />}
            </div>
            <div className='flex p-5 justify-center'>
                <Pagination
                isCompact
                showControls
                showShadow
                color="success"
                page={page}
                total={pages}
                onChange={(page) => setPage(page)}
                />
            </div>
            
        </>
       
    );
}

export default HealthAssesments