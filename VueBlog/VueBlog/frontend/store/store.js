import Vue from 'vue';
import Vuex from 'vuex';
import userModule from './modules/user'
import loginFormModule from './modules/loginForm';
import articlesModule from './modules/articles';

Vue.use(Vuex);

export const store = new Vuex.Store({
    state:{
        
    },
    mutations: {
        
    },
    actions: {
        
    },
    modules: {
        user: {
            namespaced: true,
            ...userModule
        },
        loginForm: {
            namespaced: true,
            ...loginFormModule
        },
        articles: {
            namespaced: true,
            ...articlesModule
        }
    }
}) 