import { useState, useEffect } from "react"
import { Select, SelectItem } from "@nextui-org/react"
import HealthyPlants from "../../Components/Metrics/HealthyPlants"
import Scans from "../../Components/Metrics/Scans"
import CreatedUsers from "../../Components/Metrics/CreatedUsers"
import Logins from "../../Components/Metrics/Logins"
import { Permission } from "../../Enums/Permission"

const metricsComponents = {
    'HealthyPlants': <HealthyPlants />,
    'CreatedUsers': <CreatedUsers />,
    'Scans': <Scans />,
    'Logins': <Logins />,
}

function Metrics() {
    const [selectedItem, setSelectedItem] = useState('HealthyPlants');
    const [permissions, setPermissions] = useState([]);
    const handleSelectionChange = (e) => {
        setSelectedItem(e.target.value);
    };

    useEffect(() => {
        let localPermissions = JSON.parse(localStorage.getItem("permissions"));

        if(!localPermissions){
            return;
        }

        setPermissions(Object.keys(localPermissions));
    }, [setPermissions])

    return (
        <div className="flex pt-5 justify-center min-h-screen bg-softwhite w-full mx-auto">
            <div className="flex flex-col min-w-[400px]">
                <Select 
                    size='sm'
                    label="Select a metric"
                    onChange={handleSelectionChange}
                    className="max-w-[200px]"
                    defaultSelectedKeys={["HealthyPlants"]}
                >
                    { permissions.includes(Permission[Permission.GetCreatedUsersAmount]) && 
                    <SelectItem key='CreatedUsers' value='CreatedUsers'>
                        Created users
                    </SelectItem>
                    }
                    { permissions.includes(Permission[Permission.GetHealthyPlantsAmount]) && 
                    <SelectItem key='HealthyPlants' value='HealthyPlants'>
                        Healthy plants
                    </SelectItem> 
                    }
                    { permissions.includes(Permission[Permission.GetScansAmount]) && 
                    <SelectItem key='Scans' value='Scans'>
                        Scans
                    </SelectItem>
                    }
                    { permissions.includes(Permission[Permission.GetLoginsAmount]) && 
                    <SelectItem key='Logins' value='Logins'>
                        Logins
                    </SelectItem>
                    }
                </Select>
                {metricsComponents[selectedItem]}
            </div>
        </div>
    )
}

export default Metrics