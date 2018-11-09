

export default {
    state: {
        token: null,
        name: null
    },
    mutations: {
        setUser(state, {userName, token}){
            state.name = userName;
            state.token = token;
        },
        logoutUser(state){
            state.name = null,
            state.token = null
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
        loginUser(context, userData){
            const {expiresIn, userName, token} = userData
            const now = new Date();
            const expDate = new Date(now.getTime() + expiresIn * 1000);
            localStorage.setItem('expirationDate', expDate);
            localStorage.setItem('userName', userName)
            localStorage.setItem('token', token)  

            setTimeout(() => {
                context.dispatch('logoutUser')
            }, expiresIn * 1000)

            context.commit('setUser', userData)
        },
        logoutUser(context){
            localStorage.removeItem('expirationDate');
            localStorage.removeItem('userName');
            localStorage.removeItem('token');  

            context.commit('logoutUser')
        }
    }
}