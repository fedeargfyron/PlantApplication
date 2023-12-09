import React, { useEffect } from 'react';
import { useMetricsStore } from '../../../Store/metricsStore';
import { createChart } from 'lightweight-charts';

const CreatedUsers = ({widthValue}) => {
    const createdUsersByMonthAmount = useMetricsStore((state) => state.createdUsersByMonthAmount);
    const fetchCreatedUsersByMonthAmount = useMetricsStore((state) => state.fetchCreatedUsersByMonthAmount);

    useEffect(() => {
        fetchCreatedUsersByMonthAmount();
    }, [fetchCreatedUsersByMonthAmount])
    
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
        if(createdUsersByMonthAmount.length === 0)
            return;

        const data = createdUsersByMonthAmount.map(x => ({
                value: x.amount,
                time: formatDate(x.date)
            })).sort()
        const chartOptions = { layout: { textColor: 'black', background: { type: 'solid', color: 'white' } }, width: widthValue ? widthValue : 1200, height: 800 };
        const chart = createChart(document.getElementById('container'), chartOptions);
        const areaSeries = chart.addAreaSeries({ lineColor: '#2962FF', topColor: '#2962FF', bottomColor: 'rgba(41, 98, 255, 0.28)' });
        areaSeries.setData(data);
        chart.timeScale().fitContent();
        return () => [chart.remove()]
    }, [createdUsersByMonthAmount, widthValue])
    return (
        <div className='pt-3 flex justify-center' id='container'>
        </div>
    );
}

export default CreatedUsers