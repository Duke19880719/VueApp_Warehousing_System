// Store.js
// Vue 3 狀態管理 ( Vuex/Pinia)

//狀態管理，來進行畫面跳轉，採用官方推薦的Pinia


import { defineStore } from 'pinia'

export const useViewStore = defineStore('view', {
  state: () => ({
    currentView: null
  }),
  actions: {
    switchTo(viewName) {
      this.currentView = viewName
    }
  }
})
