import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router';
import routes from './routes'
import { store } from './store/store';
import Vuelidate from 'vuelidate';
import axios from 'axios';
import constants from './constants';

//import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap';
import 'font-awesome/css/font-awesome.css';
import 'summernote/dist/summernote-bs4.css';
import 'summernote/dist/summernote-bs4';

import 'codemirror/lib/codemirror.css'
import 'codemirror/lib/codemirror'
import 'codemirror/mode/xml/xml'

Vue.use(VueRouter)
var router = new VueRouter({
  routes
})

axios.interceptors.request.use(cfg => {
  if(store.state.user.token != null && cfg.url != '/token'){
    cfg.headers.common['Authorization'] = `Bearer ${store.state.user.token}`
  }

  return cfg;
})
// import axiosMocksSetup from './mocks/axiosMocksSetup'
// axiosMocksSetup(axios);

Vue.use(Vuelidate)

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})
