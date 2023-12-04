import { Card, Image, CardBody, CircularProgress, Pagination, Tooltip, Select, SelectItem } from "@nextui-org/react"
import { useState, useEffect, useMemo } from "react";
import { usePlantStore } from "../../Store/plantsStore";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHeart, faStar } from "@fortawesome/free-solid-svg-icons";
import { faStar as faRegularStar } from '@fortawesome/free-regular-svg-icons';
import UsersPlantsModal from '../../Components/UsersPlantsModal/index.jsx'

export default function RecognizePlant() {
  const [images, setImages] = useState([])
  const [open, setOpen] = useState(false);
  const [selectedDifficulty, setSelectedDifficulty] = useState('')
  const [selectedZone, setSelectedZone] = useState('')
  const [selectedCycle, setSelectedCycle] = useState('')
  const [page, setPage] = useState(1);

  const { 
    fetchRankedPlants,
    rankedPlantsIsLoading,
    rankedPlantsIsError,
    rankedPlants
  } = usePlantStore((state) => state);

  const maxItemsPerPage = 10;
  const pages = Math.ceil(rankedPlants.length / maxItemsPerPage);
  const getColor = (level) => {
    if(level === 'Easy')
      return 'success'

    if(level === 'Medium')
      return 'warning'

    return 'danger'
  }

  const getDifficulty = (level) => {
    let color = getColor(level)

    return (
      <Tooltip showArrow={true} content={'Indicates the difficulty of this plant to be cared'} color={color} className='text-white'>
        <div className={`flex flex-col border-2 border-b-5 rounded p-1 justify-center text-center text-${color} border-${color}`}>
          <div className="flex">
            <FontAwesomeIcon icon={faStar} className="pr-1" />
            <FontAwesomeIcon icon={level !== 'Easy' ? faStar : faRegularStar } className="pr-1" />
            <FontAwesomeIcon icon={level === 'Hard' ? faStar : faRegularStar} />
          </div>
          {level}
        </div>
      </Tooltip>)
  }

console.log(selectedZone)

  const items = useMemo(() => {
      const filterSelectedZone = (filteredItems) => {
        if(!selectedZone){
          return filteredItems;
        }
    
        let values = selectedZone.split(',');
        if(values.includes('Exterior') && values.includes('Inside')){
          return filteredItems;
        }
        
        if(values.includes('Exterior')){
          return filteredItems.filter(x => x.exterior);
        }
    
        return filteredItems.filter(x => !x.exterior)
      }

      const start = (page - 1) * maxItemsPerPage;
      const end = start + maxItemsPerPage;
      let filteredItems = rankedPlants;
      if(selectedDifficulty){
        let values = selectedDifficulty.split(',');
        filteredItems = filteredItems.filter(x => values.includes(x.careLevel))
      }
      
      filteredItems = filterSelectedZone(filteredItems);

      if(selectedCycle){
        let values = selectedCycle.split(',');
        filteredItems = filteredItems.filter(x => values.includes(x.cycle))
      }

      return filteredItems.slice(start, end);
    }, [page, rankedPlants, maxItemsPerPage, selectedDifficulty, selectedZone, selectedCycle]);

  const handleDifficultySelectionChange = (e) => {
    setSelectedDifficulty(e.target.value);
  };

  const handleZoneSelectionChange = (e) => {
    setSelectedZone(e.target.value);
  };

  const handleCycleSelectionChange = (e) => {
    setSelectedCycle(e.target.value);
  };

  useEffect(() => {
    fetchRankedPlants();
  }, [fetchRankedPlants])
  /*
    Filters
  */
  return (
    <>
      <UsersPlantsModal open={open} setOpen={setOpen} images={images} />
      <div className="flex pt-5 justify-center min-h-screen bg-softwhite w-full mx-auto">
        <div className="flex flex-col">
          <div className="flex flex-col">
            <div className="flex">
              <Select
                label="Difficulty of care"
                onChange={handleDifficultySelectionChange}
                placeholder="Easy"
                selectionMode="multiple"
                className="max-w-xs p-1"
              >
                <SelectItem key={'Easy'} value='Easy'>
                  Easy
                </SelectItem>
                <SelectItem key='Medium' value='Medium'>
                  Medium
                </SelectItem>
                <SelectItem key='Hard' value='Hard'>
                  Hard
                </SelectItem>
              </Select>
              <Select
                label="Zone"
                onChange={handleZoneSelectionChange}
                placeholder="Exterior"
                selectionMode="multiple"
                className="max-w-xs p-1"
              >
                <SelectItem key={'Exterior'} value='Exterior'>
                  Exterior
                </SelectItem>
                <SelectItem key='Inside' value='Inside'>
                  Inside
                </SelectItem>
              </Select>
            </div>
            <div className="flex">
              <Select
                label="Cycle"
                onChange={handleCycleSelectionChange}
                placeholder="Perenial"
                selectionMode="multiple"
                className="max-w-xs p-1 w-1/2"
              >
                <SelectItem key='Annual' value='Annual'>
                  Annual
                </SelectItem>
                <SelectItem key='Biennial' value='Biennial'>
                  Biennial
                </SelectItem>
                <SelectItem key='Perennial' value='Perennial'>
                  Perennial
                </SelectItem>
              </Select>
            </div>
          </div>
        { rankedPlantsIsLoading &&<div className="flex h-full justify-center text-center align-middle"><CircularProgress /></div>}
        { rankedPlantsIsError && <p>Error!</p> }
        <div className="flex flex-col">
          {items.length > 0 && items.sort((a, b) => b.amount - a.amount).map(x => 
            <Card
            isBlurred
            onPress={() => {
              setImages(x.imagesLink);
              setOpen(true);
            }}
            isPressable
            className="border-none bg-background/60 dark:bg-default-100/50 max-w-[610px] m-1"
            shadow="sm"
            key={x.id}
            >
              <CardBody>
                <div className="grid grid-cols-6 md:grid-cols-12 gap-6 md:gap-4 items-center justify-center">
                  <div className="relative col-span-6 md:col-span-4">
                    <Image
                      alt="Album cover"
                      className="object-cover w-full h-[200px]"
                      height={200}
                      shadow="md"
                      src={x.imagesLink[0]}
                      width="100%"
                    />
                    <Tooltip showArrow={true} content={'Amount of users who have this plant'}>
                      <div className="flex justify-end items-center absolute top-2 right-2 z-10 bg-softwhite/60 rounded p-1">
                          {x.amount}
                          <FontAwesomeIcon icon={faHeart} className="pl-1 text-danger" />
                      </div>
                    </Tooltip>
                  </div>
                  <div className="flex flex-col col- span-6 md:col-span-8 h-full">
                    <div className="flex justify-between items-start">
                      <div className="flex flex-col gap-0">
                        <h3 className="font-bold text-foreground/90 text-large">{x.scientificName}</h3>
                        <p className="text-small font-semibold text-foreground/80">{x.commonName}</p>
                        <div className="text-small text-foreground/80 flex">
                          <p className="pr-1 font-semibold">Watering frequency: </p>
                          <p>{x.wateringDaysFrequency} days</p>
                        </div> 
                        <div className="text-small text-foreground/80 flex">
                          <p className="pr-1 font-semibold">Cycle: </p>
                          <p>{x.cycle}</p>
                        </div> 
                        <div className="text-small text-foreground/80 flex">
                          <p className="pr-1 font-semibold">Exterior: </p>
                          <p>{x.exterior ? 'Yes' : 'No'}</p>
                        </div> 
                      </div>
                      <div className="flex flex-col">
                        {getDifficulty(x.careLevel)}
                      </div>
                    </div>
                  </div>
                </div>
              </CardBody>
            </Card>)}
          </div>
          <div className="flex justify-center p-5">
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
        </div>
      </div>
    </>
    
  )
}