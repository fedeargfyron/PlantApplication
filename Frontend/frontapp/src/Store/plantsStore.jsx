import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const usePlantStore = create((set) => ({
  plants: [],
  plantsIsLoading: false,
  plantsIsError: false,
  plant: null,
  plantIsLoading: false,
  plantIsError: false,
  recognizedPlant: null,
  recognizedPlantIsLoading: false,
  recognizedPlantIsError: false,
  addPlantIsLoading: false,
  addPlantIsError: false,
  deletePlantIsLoading: false,
  deletePlantIsError: false,
  fetchPlants: () => {
    set({ plantsIsLoading: true });
    set({ plantsIsError: false });
    axios.get('https://localhost:44374/plants', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => {
        set({ plants: res.data })
        set({ plantsIsLoading: false });
        set({ plantsIsError: false });
      })
      .catch(err => {
        set({ plantsIsLoading: false });
        set({ plantsIsError: true });
        console.log(err)
      });
  },
  fetchPlantById: (id) => {
    set({ plantIsLoading: true });
    set({ plantIsError: false });
    axios.get(`https://localhost:44374/plants/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => {
        set({ plant: res.data })
        set({ plantIsLoading: false });
        set({ plantIsError: false });
      })
      .catch(err => {
        set({ plantIsLoading: false });
        set({ plantIsError: true });
        console.log(err)
      });
  },
  recognizePlant: (base64Image, filename) => {
      set({ recognizedPlantIsLoading: true });
      set({ recognizedPlantIsError: false });
      axios.post('https://localhost:44374/plants/recognize', {
        "fileName": filename,
        "base64image": base64Image
      }, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => {
        set({ recognizedPlant: res.data })
        set({ recognizedPlantIsLoading: false });
        set({ recognizedPlantIsError: false });
      })
      .catch(err => {
        set({ recognizedPlantIsLoading: false });
        set({ recognizedPlantIsError: true });
        console.log(err)
      });
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
  addPlant: (data, fetchPlants) => {
    set({ addPlantIsLoading: true });
    set({ addPlantIsError: false });
    axios.post('https://localhost:44374/plants', data, {
      headers: {
        Authorization: GetToken()
      }
    })
    .then(() => {
      set({ addPlantIsLoading: false });
      set({ addPlantIsError: false });
      fetchPlants();
    })
    .catch(err => {
      set({ addPlantIsLoading: false });
      set({ addPlantIsError: true });
      console.log(err)
    });
  },
  deletePlant: (id, fetchPlants) => {
    set({ deletePlantIsLoading: true });
    set({ deletePlantIsError: false });
    axios.delete(`https://localhost:44374/plants/${id}`, {
      headers: {
        Authorization: GetToken()
      }
    })
    .then(() => {
      set({ deletePlantIsLoading: false });
      set({ deletePlantIsError: false });
      fetchPlants();
    })
    .catch(err => {
      set({ deletePlantIsLoading: false });
      set({ deletePlantIsError: true });
      console.log(err)
    });
  },
  removeRecognizedPlant: () => set(() => ({ recognizedPlant: null }))
}));