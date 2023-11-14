import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const wateringDaysStore = create((set) => ({
  wateringDays: [],
  fetchWateringDays: () => {
    axios.get('https://localhost:44374/wateringcalendar', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ wateringDays: res.data }))
      .catch(err => console.log(err));
  }
}));