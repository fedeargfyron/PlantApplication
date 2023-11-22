import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import axios from 'axios'

export const useGroupStore = create((set) => ({
  groups: [],
  groupsIsLoading: false,
  groupsIsError: false,
  group: null,
  groupIsLoading: false,
  groupIsError: false,
  addGroupResponse: null,
  addGroupIsLoading: false,
  addGroupIsError: false,
  updateGroupResponse: null,
  updateGroupIsLoading: false,
  updateGroupIsError: false,
  deleteGroupIsLoading: false,
  deleteGroupIsError: false,
  fetchGroups: () => {
    set({ groupsIsLoading: true });
    set({ groupsIsError: false });
    axios.get('https://localhost:44374/groups', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => {
        set({ groupsIsLoading: false });
        set({ groupsIsError: false });
        set({ groups: res.data })
      })
      .catch(err =>{
        set({ groupsIsLoading: false });
        set({ groupsIsError: true });
        console.log(err)
      });
  },
  fetchGroupById: (id) => {
    set({ groupIsLoading: true });
    set({ groupIsError: false });
    axios.get(`https://localhost:44374/groups/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => {
        set({ groupIsLoading: false });
        set({ groupIsError: false });
        set({ group: res.data })
      })
      .catch(err =>{
        set({ groupIsLoading: false });
        set({ groupIsError: true });
        console.log(err)
      });
  },
  addGroup: (data, navigate) => {
    set({ addGroupIsLoading: true });
    set({ addGroupIsError: false });
    axios.post(`https://localhost:44374/groups`, data, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res =>{
        set({ addGroupResponse: res.data })
        set({ addGroupIsLoading: false });
        set({ addGroupIsError: false });
        navigate('/groups');
      })
      .catch(err => {
        set({ addGroupIsError: true });
        set({ addGroupIsLoading: false });
        console.log(err);
      })
  },
  updateGroup: (data, id, navigate) => {
    set({ updateGroupIsLoading: true });
    set({ updateGroupIsError: false });
    axios.put(`https://localhost:44374/groups/${id}`, data, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res =>{
        set({ updateGroupResponse: res.data })
        set({ updateGroupIsLoading: false });
        set({ updateGroupIsError: false });
        navigate('/groups');
      })
      .catch(err => {
        set({ updateGroupIsError: true });
        set({ updateGroupIsLoading: false });
        console.log(err);
      })
  },
  deleteGroup: (id, fetchGroups) => {
    set({ deleteGroupIsLoading: true });
    set({ deleteGroupIsError: false });
    axios.delete(`https://localhost:44374/groups/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(() => {
        set({ deleteGroupIsLoading: false });
        set({ deleteGroupIsError: false });
        fetchGroups();
      })
      .catch(err =>{
        set({ deleteGroupIsLoading: false });
        set({ deleteGroupIsError: true });
        console.log(err)
      });
  }
}));