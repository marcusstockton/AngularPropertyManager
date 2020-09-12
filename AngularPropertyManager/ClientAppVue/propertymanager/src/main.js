import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { ValidationProvider } from 'vee-validate'
import { MdButton, MdContent, MdTabs, MdTable, MdField } from 'vue-material/dist/components'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'

Vue.config.productionTip = false

Vue.use(MdButton)
Vue.use(MdContent)
Vue.use(MdTabs)
Vue.use(MdTable)
Vue.use(MdField)
Vue.component('ValidationProvider', ValidationProvider)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
