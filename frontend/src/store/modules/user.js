import axios from 'axios'
import qs from 'qs'

export default {
    state: {
        token: null,
        name: null
    },
    mutations: {
        userLogin(state, {userName, token}){
            state.name = userName;
            state.token = token;
        }
    },
    getters: {
        isLoggedIn: state =>  {
            return state.token != null
        }
    },
    actions: {
        userLogin(context, {email, password}){
            const config = {
                headers: {
                  'Content-Type': 'application/x-www-form-urlencoded'
                }
              }

            const authData = {
                grant_type: 'password',
                username: email,
                password: password
            }

            axios.post('http://localhost:57845/token', qs.stringify(authData), config)
              .then(response => {
                context.commit('userLogin', { userName: authData.username, token: response.data.access_token })
              })      
        }
    }
}