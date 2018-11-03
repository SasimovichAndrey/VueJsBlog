import Vue from 'vue';
import Vuex from 'vuex';
import userModule from './modules/user'

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
        }
    }
}) 