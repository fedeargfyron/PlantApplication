import React, { useEffect } from 'react';
import { useMetricsStore } from '../../../Store/metricsStore';
import { createChart } from 'lightweight-charts';

const HealthyPlants = () => {
    const healthyPlantByMonthAmount = useMetricsStore((state) => state.healthyPlantByMonthAmount);
    const fetchHealthyPlantByMonthAmount = useMetricsStore((state) => state.fetchHealthyPlantByMonthAmount);

    useEffect(() => {
        fetchHealthyPlantByMonthAmount();
    }, [fetchHealthyPlantByMonthAmount])
    
    const formatDate = (date) => {
        var d = new Date(date),
            day = '01',
            month = '' + (d.getMonth() + 1),
            year = d.getFullYear();
    
        if (month.length < 2) 
            month = '0' + month;
    
        return [year, month, day].join('-');
    }

    useEffect(() => {
        if(healthyPlantByMonthAmount.length === 0)
            return;

        const data = healthyPlantByMonthAmount.map(x => ({
            value: x.amount,
            time: formatDate(x.date)
        })).sort()
        const chartOptions = { layout: { textColor: 'black', background: { type: 'solid', color: 'white' } }, width: 1200, height: 800 };
        const chart = createChart(document.getElementById('container'), chartOptions);
        const areaSeries = chart.addAreaSeries({ lineColor: '#2962FF', topColor: '#2962FF', bottomColor: 'rgba(41, 98, 255, 0.28)' });
        areaSeries.setData(data);
        chart.timeScale().fitContent();
        return () => [chart.remove()]
    }, [healthyPlantByMonthAmount])

    return (
        <div className='pt-3' id='container'>
        </div>
    );
}

export default HealthyPlants