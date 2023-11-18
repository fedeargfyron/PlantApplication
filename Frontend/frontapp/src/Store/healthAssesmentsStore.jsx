import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const useHealthAssesmentsStore = create((set) => ({
  healthAssesments: [],
  healthAssesment: null,
  fetchHealthAssesments: () => {
    axios.get('https://localhost:44374/plants/healthassesment', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ healthAssesments: res.data }))
      .catch(err => console.log(err));
  },
  fetchHealthAssesmentById: (id) => {
    axios.get(`https://localhost:44374/plants/healthassesment/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ healthAssesment: res.data }))
      .catch(err => console.log(err));
  },
  addHealthAssesment: (latitude, longitude, plantId, base64Image, fileName) => {
    axios.post('https://localhost:44374/plants/healthassesment', {
      "latitude": latitude,
      "longitude": longitude,
      "plantId": plantId,
      "base64Image": base64Image,
      "fileName": fileName
    }, {
      headers: {
        Authorization: GetToken()
      }
    })
    .then(res => set({ plantRisks: res.data }))
    .catch(err => console.log(err));
  }
}));