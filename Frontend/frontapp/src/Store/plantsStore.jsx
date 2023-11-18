import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const usePlantStore = create((set) => ({
  plants: [],
  plantsLoading: false,
  plant: null,
  recognizedPlant: null,
  fetchPlants: () => {
    axios.get('https://localhost:44374/plants', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ plants: res.data }))
      .catch(err => console.log(err));
  },
  fetchPlantById: (id) => {
    axios.get(`https://localhost:44374/plants/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ plant: res.data }))
      .catch(err => console.log(err));
  },
  recognizePlant: (base64Image, filename) => {
      axios.post('https://localhost:44374/plants/recognize', {
        "fileName": filename,
        "base64image": base64Image
      }, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ recognizedPlant: res.data }))
      .catch(err => console.log(err));
  },
  updatePlantById: (data, id) => {
    axios.put(`https://localhost:44374/plants/${id}`, data , {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ plant: res.data }))
      .catch(err => console.log(err));
  },
  removeRecognizedPlant: () => set(() => ({ recognizedPlant: null }))
}));