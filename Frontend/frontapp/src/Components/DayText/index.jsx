const DayText = ({ day, risks, index }) => {
    let colors = {
        low: 'success',
        medium: 'warning',
        high: 'danger'
    };
    const getColoredDay = () => {
        let riskDay = risks.filter(x => new Date(x.day).getDay() === index)
        if(riskDay.length === 0)
            return 'success';

        return colors[riskDay[0].level]
    }

    return (
      <p className={`text-${getColoredDay()} pr-1 ${new Date(Date.now()).getDay() === index && 'font-bold'}`}>{day}</p>
    );
  }
  
  export default DayText