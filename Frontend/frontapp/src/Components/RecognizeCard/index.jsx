import React from 'react';

const RecognizeCard = () => {
    const [files, setFiles] = useState([]);

    const submit = () => {
        let file = files.at(0);
        let fileName = `${file.filename}-${Date.now()}`;
        let base64image = file.getFileEncodeBase64String();
        recognizePlant(base64image, fileName);
    }

  return (
    <Card key='newCard' isFooterBlurred className="h-[300px] max-w-[225px] min-w-[200px]">
        <CardBody className="p-0">
            <FilePond
                files={files}
                maxFiles={1}
                name="files"
                credits={false}
                onupdatefiles={(files) => setFiles(files)}
                acceptedFileTypes={"image/png, image/jpeg"}
            />
        </CardBody>
        <CardFooter className="bg-white/30 border-t-1 justify-between">
            <Button isDisabled={!files.at(0)} className="text-tiny text-white" onClick={submit} color="success" radius="full" size="sm">
            Recognize
            </Button>
            <Button isDisabled={files.at(0)} className="text-tiny" color="danger" radius="full" size="sm" onClick={removeRecognizedPlant}>
            Remove
            </Button>
        </CardFooter>
    </Card>
  );
}

export default RecognizeCard