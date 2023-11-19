import { create } from 'zustand'
import { GetToken } from '../Components/Helpers/TokenHelper';
import { SendEmail } from '../Components/Helpers/EmailHelper';
import axios from 'axios'

export const useUserStore = create((set) => ({
  users: [],
  usersLoading: false,
  user: null,
  registerResponse: null,
  fetchUsers: () => {
    axios.get('https://localhost:44374/users', {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ users: res.data }))
      .catch(err => console.log(err));
  },
  fetchUserById: (id) => {
    axios.get(`https://localhost:44374/users/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(res => set({ user: res.data }))
      .catch(err => console.log(err));
  },
  registerUser: (data) => {
    axios.post(`https://localhost:44374/users/register`, data)
      .then(res => set({ registerResponse: res.data }))
      .catch(err => console.log(err));
  },
  recoverPassword: (data) => {
    axios.post(`https://localhost:44374/users/recover`, data)
    .then(res => {
      let emailData = {
        email: data.email,
        message: `Your new password is: ${res.data.password}`,
        subject: 'Recover password'
      }
      SendEmail(emailData);
    })
    .catch(err => console.log(err));
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
  }
}));