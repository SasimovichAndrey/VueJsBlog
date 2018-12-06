import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router';
import routes from './routes'
import { store } from './store/store';
import Vuelidate from 'vuelidate';
import axios from 'axios';
import constants from './constants';

import 'bootstrap';
// import 'bootstrap/dist/css/bootstrap.min.css'
import 'font-awesome/css/font-awesome.css';
// import 'codemirror'
// import 'codemirror/mode/htmlembedded/htmlembedded'
import 'summernote/dist/summernote-bs4.css';
import 'summernote/dist/summernote-bs4';

Vue.use(VueRouter)
var router = new VueRouter({
  routes
})

// axios.interceptors.request.use(cfg => {
//   if(store.state.user.token != null && cfg.url != '/token'){
//     cfg.headers.common['Authorization'] = `Bearer ${store.state.user.token}`
//   }

//   return cfg;
// })
import axiosMocksSetup from './mocks/axiosMocksSetup'
axiosMocksSetup(axios);

Vue.use(Vuelidate)

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})
