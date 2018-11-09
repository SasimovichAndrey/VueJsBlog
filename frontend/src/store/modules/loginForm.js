import axios from 'axios'
import qs from 'qs'

export default {
    state: {
        loginError: null
    },
    mutations: {
        setloginError(state, errorDesc){
            state.loginError = errorDesc;
        }
    },
    actions: {
        userLogin(context, {email, password, router}){
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

            axios.post('/token', qs.stringify(authData), config)
              .then(response => {
                const {access_token, expires_in} = response.data;

                context.dispatch('user/loginUser', { userName: authData.username, token: access_token, expiresIn: expires_in}, { root: true})
                context.commit('setloginError', null)

                router.replace({path: '/'})
              })
              .catch(error => {
                context.commit('setloginError', error.response.data.error_description)
              }) 
        }
    }
}