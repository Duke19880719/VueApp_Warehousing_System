import './assets/main.css'

import { createApp,h } from 'vue'

import { createPinia } from 'pinia'
/*import App from './App.vue'*/
import 'animate.css/animate.min.css'
import master_animation from './components/master_page_animation.vue'
import { useViewStore } from './Store'
import Goods from './components/Goods_Page.vue'

const pinia = createPinia()

const App = {
  setup() {
    const store = useViewStore()
    if (!store.currentView)
      store.switchTo(master_animation)

    return () => h(store.currentView)
  }
}

createApp(App).use(pinia).mount('#app')

createApp(Goods).mount('#good')
