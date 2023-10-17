import React from 'react';
import { DropdownItem, DropdownMenu, Avatar, Dropdown, DropdownTrigger } from "@nextui-org/react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import DayText from '../../DayText';

const RiskAlert = ({ icon, plantsRisks, type }) => {
  let days = ['D', 'L', 'M', 'M', 'J', 'V', 'S'];

  const getDangerousColorType = () => {
    let colors = plantsRisks && plantsRisks.filter(x => x.risks[type]).map(x => getDangerousColor(x));

    if(colors.some(x => x === 'danger'))
      return 'danger';

    if(colors.some(x => x === 'warning'))
      return 'warning';

    return 'success';
  }

  const getDangerousColor = (plantRisk) => {
    let uniqueLevels = [...new Set(plantRisk.risks[type].map(item => item.level))]

    if(uniqueLevels.some(x => x === 'high'))
      return 'danger';

    if(uniqueLevels.some(x => x === 'medium'))
      return 'warning';

    return 'success';
  }

  return (
    <Dropdown placement="left-start">
        <DropdownTrigger>
          <Avatar
            showFallback
            fallback={
              <FontAwesomeIcon className="w-6 h-6" icon={icon} />
            }
            isBordered
            as="button"
            className="transition-all mb-4"
            color={getDangerousColorType()}
            size="m"
          />
        </DropdownTrigger>
        <DropdownMenu aria-label="Profile Actions" variant="flat">
        {plantsRisks && plantsRisks.filter(x => x.risks[type]).map(x => 
          <DropdownItem key={x.plantId}>
            <div className="flex flex-row align-middle text-center items-center p-1">
              <Avatar
                src={x.imageLink}
                isBordered
                as="button"
                className="transition-transform"
                color={getDangerousColor(x)} //Change with risk maximum danger
                size="sm"
              />  
                <div className='flex flex-col text-start'>
                  <p className='ml-2 font-bold'>{x.plantName}</p>
                  <div className="flex ml-2 text-xs">
                    {days.map((d, i) => <DayText key={d} day={d} index={i} risks={x.risks[type]} /> )}
                  </div>
              </div>
            </div>
          </DropdownItem>
          )}

        </DropdownMenu>
      </Dropdown>
  );
}

export default RiskAlert