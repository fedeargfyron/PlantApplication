import { useState } from "react"
import { Select, SelectItem } from "@nextui-org/react"
import HealthyPlants from "../../Components/Metrics/HealthyPlants"
import Scans from "../../Components/Metrics/Scans"
import CreatedUsers from "../../Components/Metrics/CreatedUsers"

const metricsComponents = {
    'HealthyPlants': <HealthyPlants />,
    'CreatedUsers': <CreatedUsers />,
    'Scans': <Scans />,
}

function Metrics() {
    const [selectedItem, setSelectedItem] = useState('HealthyPlants');
    const handleSelectionChange = (e) => {
        setSelectedItem(e.target.value);
    };

    return (
        <div className="flex pt-5 justify-center h-screen bg-softwhite w-full mx-auto">
            <div className="flex flex-col min-w-[400px]">
                <Select 
                    size='sm'
                    label="Select a metric"
                    onChange={handleSelectionChange}
                    className="max-w-[200px]"
                    defaultSelectedKeys={["HealthyPlants"]}
                >
                    <SelectItem key='HealthyPlants' value='HealthyPlants'>
                        Healthy plants
                    </SelectItem>
                    <SelectItem key='CreatedUsers' value='CreatedUsers'>
                        Created users
                    </SelectItem>
                    <SelectItem key='Scans' value='Scans'>
                        Scans
                    </SelectItem>
                </Select>
                {metricsComponents[selectedItem]}
            </div>
        </div>
    )
}

export default Metrics