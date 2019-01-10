import axios from 'axios'

export default {
    state: {
        token: null,
        name: null,
        roles: null
    },
    mutations: {
        setToken(state, {userName, token}){
            state.token = token;
        },
        logoutUser(state){
            state.token = null
        },
        setUser(state, {userName, roles}){
            state.userName = userName;
            state.roles = roles;
        }
    },
    getters: {
        isLoggedIn: state =>  {
            return state.token != null
        }
    },
    actions: {
        restoreUserState(context){
            const token = localStorage.getItem('token');
            const expirationDate = new Date(localStorage.getItem('expirationDate'));
            const userName = localStorage.getItem('userName');
            const now = new Date();

            if(token && now <= expirationDate){
                const expiresIn = (expirationDate.getTime() - now.getTime()) / 1000;

                context.dispatch('loginUser', {userName, token, expiresIn});
            }
        },
        loginUser(context, tokenData){
            const {expiresIn, token} = tokenData
            const now = new Date();
            const expDate = new Date(now.getTime() + expiresIn * 1000);
            localStorage.setItem('expirationDate', expDate);
            localStorage.setItem('token', token)  

            setTimeout(() => {
                context.dispatch('logoutUser')
            }, expiresIn * 1000)

            context.commit('setToken', tokenData)
            context.dispatch('loadCurrentUser');
        },
        loadCurrentUser(context){
            let userIsLoggedIn = context.getters.isLoggedIn;

            if(userIsLoggedIn){
                axios.get('/api/auth/getCurrentUser')
                    .then(response => {
                        context.commit('setUser', response.data)
                    })
            }
        },
        logoutUser(context){
            localStorage.removeItem('expirationDate');
            localStorage.removeItem('token');  

            context.commit('logoutUser')
        }
    }
}