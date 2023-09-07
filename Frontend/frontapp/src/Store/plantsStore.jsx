import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const usePlantStore = create((set) => ({
  plants: [],
  plantsLoading: false,
  plant: {},
  fetchPlants: () => {
    axios.get('https://localhost:44374/plants', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ plants: res.data }))
      .catch(err => console.log(err));
  },
}));