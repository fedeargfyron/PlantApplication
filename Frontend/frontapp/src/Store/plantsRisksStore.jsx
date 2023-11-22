import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const usePlantRiskStore = create((set) => ({
  plantRisks: [],
  fetchPlantsRisks: (latitude, longitude) => {
    axios.post('https://localhost:44374/plants/riskalerts', {
      "latitude": latitude,
      "longitude": longitude
    }, {
      headers: {
        Authorization: GetToken()
      }
    })
    .then(res => set({ plantRisks: res.data }))
    .catch(err => console.log(err));
},  
}));