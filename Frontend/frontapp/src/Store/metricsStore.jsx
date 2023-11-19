import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const useMetricsStore = create((set) => ({
  scansByMonthAmount: [],
  healthyPlantByMonthAmount: [],
  createdUsersByMonthAmount: [],
  fetchScansByMonthAmount: () => {
    axios.get('https://localhost:44374/metrics/scanamounts', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ scansByMonthAmount: res.data }))
      .catch(err => console.log(err));
  },
  fetchHealthyPlantByMonthAmount: () => {
    axios.get('https://localhost:44374/metrics/healthyplantsamount', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ healthyPlantByMonthAmount: res.data }))
      .catch(err => console.log(err));
  },
  fetchCreatedUsersByMonthAmount: () => {
    axios.get('https://localhost:44374/metrics/createdusersamount', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ createdUsersByMonthAmount: res.data }))
      .catch(err => console.log(err));
  },
}));