import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const useHealthAssesmentsStore = create((set) => ({
  healthAssesments: [],
  healthAssesmentsIsLoading: false,
  healthAssesmentsIsError: false,
  healthAssesmentIsLoading: false,
  healthAssesmentIsError: false,
  healthAssesment: null,
  addHealthAssesmentIsLoading: false,
  addHealthAssesmentIsError: false,
  fetchHealthAssesments: () => {
    set({ healthAssesmentsIsLoading: true });
    set({ healthAssesmentsIsError: false });
    axios.get('https://localhost:44374/plants/healthassesment', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res =>{
        set({ healthAssesments: res.data })
        set({ healthAssesmentsIsLoading: false });
        set({ healthAssesmentsIsError: false });
      })
      .catch(err => {
        set({ healthAssesmentsIsError: true });
        set({ healthAssesmentsIsLoading: false });
        console.log(err);
      })
  },
  fetchHealthAssesmentById: (id) => {
    set({ healthAssesmentIsLoading: true });
    set({ healthAssesmentIsError: false });
    axios.get(`https://localhost:44374/plants/healthassesment/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res =>{
        set({ healthAssesment: res.data })
        set({ healthAssesmentIsLoading: false });
        set({ healthAssesmentIsError: false });
      })
      .catch(err => {
        set({ healthAssesmentIsError: true });
        set({ healthAssesmentIsLoading: false });
        console.log(err);
      })
  },
  addHealthAssesment: (data, fetchHealthAssesments) => {
    set({ addHealthAssesmentIsLoading: true });
    set({ addHealthAssesmentIsError: false });
    axios.post('https://localhost:44374/plants/healthassesment', data, {
      headers: {
        Authorization: GetToken()
      }
    })
    .then(() =>{
      set({ addHealthAssesmentIsLoading: false });
      set({ addHealthAssesmentIsError: false });
      fetchHealthAssesments();
    })
    .catch(err => {
      set({ addHealthAssesmentIsError: true });
      set({ addHealthAssesmentIsLoading: false });
      console.log(err);
    })
  }
}));