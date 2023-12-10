import { Button, Card, Image, CardFooter, CardBody, CircularProgress, Pagination, Tooltip } from "@nextui-org/react"
import { useState, useEffect, useMemo } from "react";
import { FilePond, registerPlugin } from 'react-filepond';
import FilePondPluginImagePreview from 'filepond-plugin-image-preview'
import FilePondPluginFileEncode from 'filepond-plugin-file-encode';
import { usePlantStore } from "../../Store/plantsStore";
import PlantModal from '../../Components/PlantModal/index.jsx'
import RiskAlerts from "../../Components/RiskAlerts";
import 'filepond-plugin-image-preview/dist/filepond-plugin-image-preview.css'
import 'filepond/dist/filepond.min.css';
import { useNavigate } from "react-router-dom";
import {DeleteIcon} from "../../Components/Icons/DeleteIcon.jsx";
import InformationModal from "../../Components/InformationModal";
import { Permission } from "../../Enums/Permission";

registerPlugin(FilePondPluginImagePreview, FilePondPluginFileEncode)

export default function RecognizePlant() {
  const [files, setFiles] = useState([]);
  const [permissions, setPermissions] = useState([]);
  const [open, setOpen] = useState(false);
  const [selectedIndex, setSelectedIndex] = useState(-1);
  const navigate = useNavigate();
  const { 
    fetchPlants,
    plantsIsLoading,
    plantsIsError,
    plants,
    recognizePlant,
    recognizedPlant,
    removeRecognizedPlant,
    recognizedPlantIsLoading,
    recognizedPlantIsError,
    deletePlantIsLoading,
    deletePlantIsError,
    deletePlant
  } = usePlantStore((state) => state);

  const [page, setPage] = useState(1);
  const maxItemsPerPage = 8;
  const pages = Math.ceil(plants.length / maxItemsPerPage);
  const items = useMemo(() => {
      const start = (page - 1) * maxItemsPerPage;
      const end = start + maxItemsPerPage;
  
      return plants.slice(start, end);
    }, [page, plants, maxItemsPerPage]);

    useEffect(() => {
      if(deletePlantIsLoading || deletePlantIsError)
          return setOpen(true)
  
      setOpen(false)
    }, [deletePlantIsLoading, deletePlantIsError])

  useEffect(() => {
    fetchPlants();
  }, [fetchPlants])

  const submit = () => {
    let file = files.at(0);
    let fileName = `${file.filename}-${Date.now()}`;
    let base64image = file.getFileEncodeBase64String();
    recognizePlant(base64image, fileName);
  }

  useEffect(() => {
    let localPermissions = JSON.parse(localStorage.getItem("permissions"));

    if(!localPermissions){
        return;
    }

    setPermissions(Object.keys(localPermissions));
  }, [setPermissions])

  return (
    <>
      <PlantModal selectedIndex = {selectedIndex} setSelectedIndex={setSelectedIndex}/>
      <div className="flex pt-5 justify-center min-h-screen bg-softwhite w-full mx-auto">
        <InformationModal open={open} setOpen={setOpen} title='Delete plant'>
        {(deletePlantIsLoading) && <CircularProgress />}
        {(deletePlantIsError) && <p>Error!</p>}
        </InformationModal>
        <div className="flex flex-col">
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4 relative h-fit">
            { permissions.includes(Permission[Permission.GetRiskAlerts]) && 
              <RiskAlerts key='alerts' plants={plants} />
            }
            { permissions.includes(Permission[Permission.RecognizePlants]) && 
              <Card key='newCard' isFooterBlurred className="h-[300px] max-w-[225px] min-w-[200px]">
                <CardBody className="p-0">
                  { recognizedPlantIsLoading ?<div className="flex h-full justify-center text-center align-middle"><CircularProgress /></div>
                  : recognizedPlantIsError ? <p>Error!</p>
                  : recognizedPlant ? <Image 
                  radius="none"
                  removeWrapper
                  alt = {`recognized user image`}
                  src={recognizedPlant.userImageUrl}
                  className="object-cover max--full h-full max-w-full z-0"
                  /> 
                  :
                  <FilePond
                    files={files}
                    maxFiles={1}
                    name="files"
                    credits={false}
                    onupdatefiles={(files) => setFiles(files)}
                    acceptedFileTypes={"image/png, image/jpeg"}
                />}
                  
                {recognizedPlant && 
                <div key='plantscontainer' className="absolute bottom-0 grid max-w-[225px] grid-cols-3 justify-center text-center">
                  {recognizedPlant.results.slice(0, 3).map((result, index) => 
                  <div className="hover:cursor-pointer" onClick={() => setSelectedIndex(index)} key={`result-${index}`}>
                    <Image 
                      radius="none"
                      removeWrapper
                      alt = {`result ${index}`}
                      src={result.images.at(0).url.m}
                      className="border border-softwhite"
                    />
                    <p className="bg-softwhite">%{(result.score * 100).toFixed(2)}</p>
                  </div>
                  )}
                  
                </div>}
                </CardBody>
                <CardFooter className="bg-white/30 border-t-1 justify-between">
                  <Button isDisabled={!files.at(0) || recognizedPlant} className="text-tiny text-white" onClick={submit} color="success" radius="full" size="sm">
                    Recognize
                  </Button>
                  <Button isDisabled={!recognizedPlant} className="text-tiny" color="danger" radius="full" size="sm" onClick={removeRecognizedPlant}>
                    Remove
                  </Button>
                </CardFooter>
              </Card>
            }
             
            {plantsIsLoading && <CircularProgress />}
            {plantsIsError && <p>Error!</p>}
            {items.map(x => 
            <Card key={x.id} onPress={() => permissions.includes(Permission[Permission.GetPlantById]) && navigate(`${x.id}`)} isFooterBlurred isPressable className="h-[300px] max-w-[225px] min-w-[200px]">
              { permissions.includes(Permission[Permission.AddGroup]) && 
                <Tooltip color="danger" content="Delete plant">
                  <span onClick={() => {deletePlant(x.id, fetchPlants)}} className="text-lg text-danger rounded p-1 absolute top-2 right-2 z-10 bg-white cursor-pointer active:opacity-50">
                    <DeleteIcon />
                  </span>
                </Tooltip>
              }
              <Image
                removeWrapper
                alt="Card example background"
                className="z-0 w-full h-full scale-125 -translate-y-8 object-cover"
                src={x.imageLink}
              />
              <CardFooter className="absolute bg-white/30 bottom-0 border-t-1 border-zinc-100/50 z-10">
                <div className="justify-start text-start">
                  <h4 className="font-bold">{x.name}</h4>
                  <p className="text-black text-tiny">{x.scientificName}</p>
                </div>
              </CardFooter>
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