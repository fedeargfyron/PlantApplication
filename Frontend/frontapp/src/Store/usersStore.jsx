import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const useUserStore = create((set) => ({
  users: [],
  usersLoading: false,
  user: {},
  fetchUsers: () => {
    axios.get('https://localhost:44374/users', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ users: res.data }))
      .catch(err => console.log(err));
  },
}));