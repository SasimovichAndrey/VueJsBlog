import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router';
import routes from './routes'
import { store } from './store/store';

import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css'

Vue.use(VueRouter)
var router = new VueRouter({
  routes
})

new Vue({
  el: '#app',
  router: router,
  store,
  render: h => h(App)
})
