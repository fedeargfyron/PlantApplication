import React, { useState } from 'react';
import { FilePond, registerPlugin } from 'react-filepond';
import FilePondPluginImagePreview from 'filepond-plugin-image-preview'
import FilePondPluginFileEncode from 'filepond-plugin-file-encode';
import { Button, Card, CardFooter, CardBody } from "@nextui-org/react"
import 'filepond-plugin-image-preview/dist/filepond-plugin-image-preview.css'
import 'filepond/dist/filepond.min.css';
import { useHealthAssesmentsStore } from '../../Store/healthAssesmentsStore';

registerPlugin(FilePondPluginImagePreview, FilePondPluginFileEncode)

const RecognizeCard = ({plantId}) => {
    const [files, setFiles] = useState([]);
    const addHealthAssesment = useHealthAssesmentsStore(state => state.addHealthAssesment);
    const submit = () => {
        navigator.geolocation.getCurrentPosition((position) => {
            const lat = position.coords.latitude;
            const long = position.coords.longitude;
            let file = files.at(0);
            let fileName = `${file.filename}-${Date.now()}`;
            let base64image = file.getFileEncodeBase64String();
            addHealthAssesment(lat, long, plantId, base64image, fileName);
        })
    }

    return (
        <Card key='newCard' isFooterBlurred className="max-w-full max-h-full min-h-[200px]">
            <CardBody>
                <FilePond
                    files={files}
                    maxFiles={1}
                    name="files"
                    credits={false}
                    onupdatefiles={(files) => setFiles(files)}
                    acceptedFileTypes={"image/png, image/jpeg"}
                />
            </CardBody>
            <CardFooter className="flex bg-white/30 border-t-1 justify-center">
                <Button isDisabled={!files.at(0)} className="text-tiny text-white" onClick={submit} color="success" radius="full" size="sm">
                Recognize
                </Button>
            </CardFooter>
        </Card>
    );
}

export default RecognizeCard