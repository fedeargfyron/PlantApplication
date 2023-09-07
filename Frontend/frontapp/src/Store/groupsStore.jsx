import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const useGroupStore = create((set) => ({
  groups: [],
  groupsLoading: false,
  group: null,
  fetchGroups: () => {
    axios.get('https://localhost:44374/groups', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ groups: res.data }))
      .catch(err => console.log(err));
  },
  fetchGroupById: (id) => {
    axios.get(`https://localhost:44374/groups/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ group: res.data }))
      .catch(err => console.log(err));
  },
}));