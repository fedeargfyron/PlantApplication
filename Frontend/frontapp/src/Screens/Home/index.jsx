import { useEffect } from 'react';
import { usePlantStore } from '../../Store/plantsStore.jsx'

function Home() {
  const fetchPlants = usePlantStore((state) => state.fetchPlants);
  var plantsStore = usePlantStore(state => state.plants);
  useEffect(() => {
    fetchPlants();
  }, [fetchPlants])

  console.log(plantsStore)

  return (
    <div className="container mx-auto object-center">
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>
        <h1 className="text-2xl font-bold underline">
          Home
        </h1>

        <h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1><h1 className="text-2xl font-bold underline">
          Home
        </h1>
    </div>
  )
}

export default Home
