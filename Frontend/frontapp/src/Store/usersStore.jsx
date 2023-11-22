import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import { SendEmail } from '../Components/Helpers/EmailHelper';
import axios from 'axios'

export const useUserStore = create((set) => ({
  users: [],
  usersIsLoading: false,
  usersIsError: false,
  user: null,
  userIsLoading: false,
  userIsError: null,
  loginToken: null,
  loginIsLoading: false,
  loginIsError: false,
  registerResponse: null,
  registerIsLoading: false,
  registerIsError: false,
  recoverIsLoading: false,
  recoverIsError: false,
  addUserResponse: null,
  addUserIsLoading: false,
  addUserIsError: false,
  updateUserResponse: null,
  updateUserIsLoading: false,
  updateUserIsError: false,
  deleteUserIsLoading: false,
  deleteUserIsError: false,
  fetchUsers: () => {
    set({ usersIsLoading: true });
    set({ usersIsError: false });
    axios.get('https://localhost:44374/users', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res =>{
        set({ users: res.data })
        set({ usersIsLoading: false });
        set({ usersIsError: false });
      })
      .catch(err => {
        set({ usersIsLoading: true });
        set({ usersIsError: false });
        console.log(err);
      })
  },
  fetchUserById: (id) => {
    set({ userIsLoading: true });
    set({ userIsError: false });
    axios.get(`https://localhost:44374/users/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res =>{
        set({ user: res.data })
        set({ userIsLoading: false });
        set({ userIsError: false });
      })
      .catch(err => {
        set({ userIsLoading: true });
        set({ userIsError: false });
        console.log(err);
      })
  },
  registerUser: (data) => {
    set({ registerIsLoading: true });
    set({ registerIsError: false });
    axios.post(`https://localhost:44374/users/register`, data)
      .then(res =>{
        set({ registerResponse: res.data })
        set({ registerIsLoading: false });
        set({ registerIsError: false });
      })
      .catch(err => {
        set({ registerIsError: true });
        set({ registerIsLoading: false });
        console.log(err);
      })
  },
  addUser: (data, navigate) => {
    set({ addUserIsLoading: true });
    set({ addUserIsError: false });
    axios.post(`https://localhost:44374/users`, data, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res =>{
        set({ addUserResponse: res.data })
        set({ addUserIsLoading: false });
        set({ addUserIsError: false });
        navigate('/users');
      })
      .catch(err => {
        set({ addUserIsError: true });
        set({ addUserIsLoading: false });
        console.log(err);
      })
  },
  updateUser: (data, id, navigate) => {
    set({ updateUserIsLoading: true });
    set({ updateUserIsError: false });
    axios.put(`https://localhost:44374/users/${id}`, data, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res =>{
        set({ updateUserResponse: res.data })
        set({ updateUserIsLoading: false });
        set({ updateUserIsError: false });
        navigate('/users');
      })
      .catch(err => {
        set({ updateUserIsError: true });
        set({ updateUserIsLoading: false });
        console.log(err);
      })
  },
  deleteUser: (id, fetchUsers) => {
    set({ deleteUserIsLoading: true });
    set({ deleteUserIsError: false });
    axios.delete(`https://localhost:44374/users/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(() => {
        set({ deleteUserIsLoading: false });
        set({ deleteUserIsError: false });
        fetchUsers();
      })
      .catch(err =>{
        set({ deleteUserIsLoading: false });
        set({ deleteUserIsError: true });
        console.log(err)
      });
  },
  recoverPassword: async (data) => {
    try{
      set({ recoverIsLoading: true });
      set({ recoverIsError: false });
      let res = await axios.post(`https://localhost:44374/users/recover`, data);
      let emailData = {
        email: data.email,
        message: `Your new password is: ${res.data.password}`,
        subject: 'Recover password'
      }
      await SendEmail(emailData);
      set({ recoverIsLoading: false });
      set({ recoverIsError: false });
    } catch(err) {
      set({ recoverIsError: true });
      set({ recoverIsLoading: false });
      console.log(err);
    }
  },
  resetPassword: (data) => {
    axios.post(`https://localhost:44374/users/reset`, data)
    .then(res => {
      let emailData = {
        email: data.email,
        message: `Your new password is: ${res.data.password}`,
        subject: 'Reset password'
      }
      SendEmail(emailData);
    })
    .catch(err => console.log(err));
  },
  login: (data) => {
    set({ loginIsLoading: true });
    set({ loginIsError: false });
    axios.post('https://localhost:44374/security', data)
      .then(res =>{
        set({ loginToken: res.data })
        set({ loginIsLoading: false });
        set({ loginIsError: false });
      })
      .catch(err => {
        set({ loginIsError: true });
        set({ loginIsLoading: false });
        console.log(err);
      })
  },
  logout: () => set({ loginToken: null }),
}));