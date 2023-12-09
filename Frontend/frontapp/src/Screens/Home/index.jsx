import { Image, Button } from '@nextui-org/react'
import PlantPot from '../../Images/PlantPot.png'
import PlantPhotos from '../../Images/PlantPhotos.jpg'
import PlantWithWater from '../../Images/PlantWithWater.jpg'
import WateringPlant from '../../Images/WateringPlant.jpg'
import PlantWithFungus from '../../Images/PlantWithFungus.jpg'
import CreatedUsers from '../../Components/Metrics/CreatedUsers'
function Home() {

  return (
    <>
    <div className="flex flex-wrap flex-col md:flex-row items-center min-w-full bg-gradient-to-r from-softpink to-softgreen text-white min-h-screen">
        <div className="flex flex-col w-full md:w-2/5 justify-center items-start text-center md:text-left p-10">
          <p className="uppercase tracking-loose w-full">MYPLANTCARE</p>
          <h1 className="my-4 text-5xl font-bold leading-tight">
            La aplicación perfecta para el bienestar de tus plantas
          </h1>
          <p className="leading-normal text-2xl mb-8">
            Cultivando relaciones verdes
          </p>
          <Button className="m-1 bg-green text-white transition p-8 text-xl">
              Register
          </Button>
        </div>
        <div className="w-full md:w-3/5 py-6 flex justify-center">
          <Image src={PlantPot} className='max-h-[800px]' />
        </div>
      </div>
    <section className="bg-white border-b py-8">
      <div className="max-w-5xl mx-auto m-8">
        <h2 className="w-full my-2 text-5xl font-bold leading-tight text-center text-gray-800">
          Caracteristicas
        </h2>
        <div className="w-full mb-4">
          <div className="h-1 mx-auto gradient w-64 opacity-25 my-0 py-0 rounded-t"></div>
        </div>
        <div className="flex flex-wrap">
          <div className="w-5/6 sm:w-1/2 p-6">
            <h3 className="text-3xl text-gray-800 font-bold leading-none mb-3">
              Reconocimiento de imagenes
            </h3>
            <p className="text-gray-600 mb-8">
              Los amantes de las plantas pueden simplemente tomar una fotografía de una planta desconocida y recibir instantáneamente información detallada sobre ella. Esto no solo facilita la identificación de las especies, sino que también brinda a los usuarios la oportunidad de aprender más sobre sus plantas y entender sus requerimientos específicos.
            </p>
          </div>
          <div className="w-full sm:w-1/2 p-6">
            <Image src={PlantPhotos} />
          </div>
        </div>
        <div className="flex flex-wrap flex-col-reverse sm:flex-row">
          <div className="w-full sm:w-1/2 p-6 mt-6">
            <Image src={PlantWithFungus} />
          </div>
          <div className="w-full sm:w-1/2 p-6 mt-6">
            <div className="align-middle">
              <h3 className="text-3xl text-gray-800 font-bold leading-none mb-3">
                Identificación de enfermedades
              </h3>
              <p className="text-gray-600 mb-8">
                Esta característica innovadora permite a los usuarios diagnosticar y abordar problemas de salud en sus plantas de manera rápida y precisa. Al capturar imágenes de las plantas afectadas, la aplicación utiliza tecnología avanzada de reconocimiento para identificar patrones, síntomas y características específicas asociadas a enfermedades o condiciones adversas.
              </p>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section className="bg-white border-b py-8">
      <div className="max-w-5xl mx-auto m-8">
        <div className="w-full mb-4">
          <div className="h-1 mx-auto gradient w-64 opacity-25 my-0 py-0 rounded-t"></div>
        </div>
        <div className="flex flex-wrap">
          <div className="w-5/6 sm:w-1/2 p-6">
            <h3 className="text-3xl text-gray-800 font-bold leading-none mb-3">
              Vinculación al clima
            </h3>
            <p className="text-gray-600 mb-8">
              La vinculación del clima permite a los usuarios recibir alertas personalizadas en base al estado del clima y cómo éste afecta a sus plantas, lo que ayuda a prevenir daños o enfermedades en las mismas.
            </p>
          </div>
          <div className="w-full sm:w-1/2 p-6">
            <Image src={PlantWithWater} />
          </div>
        </div>
        <div className="flex flex-wrap flex-col-reverse sm:flex-row">
          <div className="w-full sm:w-1/2 p-6 mt-6 max-h-[400px]">
            <Image 
            src={WateringPlant}
            width={500}
            className='z-0 object-cover max-h-[300px]' />
          </div>
          <div className="w-full sm:w-1/2 p-6 mt-6">
            <div className="align-middle">
              <h3 className="text-3xl text-gray-800 font-bold leading-none mb-3">
                Calendario de riego
              </h3>
              <p className="text-gray-600 mb-8">
                La planificación de riego y las notificaciones pueden ayudar a los usuarios a mantener un régimen adecuado de cuidado para sus plantas, lo que puede ser especialmente útil para aquellos que tienen dificultades para recordar cuándo deben regarlas.
              </p>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section className="bg-white border-b py-8">
      <div className="max-w-5xl mx-auto">
        <div className="w-full mb-4 text-center">
          <h3 className="text-3xl text-gray-800 font-bold leading-none mb-3">
            Cantidad de usuarios ingresados
          </h3>
          <div className="mx-auto"></div>
          <CreatedUsers widthValue={800} />
        </div>
      </div>
    </section>
    </>
  )
}

export default Home
