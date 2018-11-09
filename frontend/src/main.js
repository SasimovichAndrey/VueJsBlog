import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router';
import routes from './routes'
import { store } from './store/store';
import Vuelidate from 'vuelidate';
import axios from 'axios';

import VueFroala from 'vue-froala-wysiwyg'
require('froala-editor/js/froala_editor.pkgd.min')
require('froala-editor/css/froala_editor.pkgd.min.css')
require('font-awesome/css/font-awesome.css')
require('froala-editor/css/froala_style.min.css')

import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css'

Vue.use(VueRouter)
var router = new VueRouter({
  routes
})

Vue.use(VueFroala)

axios.defaults.baseURL = 'http://localhost:57845'
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
