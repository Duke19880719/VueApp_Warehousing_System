<template>
  <transition enter-active-class="animate__animated animate__fadeInDown"
              leave-active-class="animate__animated animate__fadeOutUp">
    <section v-if="show" class="hero">
      <h1 class="animate__animated animate__bounceIn">我的倉儲系統</h1>
      <p class="animate__animated animate__fadeIn" style="animation-delay: 0.5s;">
        歡迎使用倉儲管理小工具
      </p>
      <button class="animate__animated animate__zoomIn" @click="display_user_view" style="animation-delay: 1s;">
        開始使用
      </button>
    </section>
  </transition>
</template>

<script setup>
  import { ref, onMounted } from 'vue'
  import { useViewStore } from '../Store'
  import Login from './Login_Page.vue'
  const show = ref(false)



onMounted(() => {
  setTimeout(() => { show.value = true }, 100)
})

  var store = useViewStore()
  function display_user_view() {

    store.switchTo(Login)
}
</script>


<style scoped>
  @import url('https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css');

  /* 主要容器設置 */
  .hero {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    min-height: 100vh;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    text-align: center;
    padding: 0;
    margin: 0;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 25%, #f093fb 50%, #f5576c 75%, #4facfe 100%);
    background-size: 400% 400%;
    animation: gradientShift 8s ease-in-out infinite;
    overflow: hidden;
  }

  /* 背景動畫 */
  @keyframes gradientShift {
    0%, 100% {
      background-position: 0% 50%;
    }

    50% {
      background-position: 100% 50%;
    }
  }

  /* 背景裝飾元素 */
  .hero::before,
  .hero::after {
    content: '';
    position: absolute;
    border-radius: 50%;
    background: rgba(255, 255, 255, 0.1);
    backdrop-filter: blur(20px);
    animation: float 6s ease-in-out infinite;
    z-index: 1;
  }

  .hero::before {
    width: 200px;
    height: 200px;
    top: 10%;
    left: 10%;
    animation-delay: 0s;
  }

  .hero::after {
    width: 150px;
    height: 150px;
    bottom: 15%;
    right: 15%;
    animation-delay: 3s;
  }

  @keyframes float {
    0%, 100% {
      transform: translateY(0px) rotate(0deg);
      opacity: 0.7;
    }

    50% {
      transform: translateY(-30px) rotate(180deg);
      opacity: 1;
    }
  }

  /* 確保內容在裝飾元素之上 */
  .hero > * {
    position: relative;
    z-index: 2;
  }

  /* 標題樣式 */
  h1 {
    font-size: 4rem;
    font-weight: 800;
    margin: 2rem 0 1rem 0;
    background: linear-gradient(135deg, #fff 0%, #f8f9ff 50%, #e8eeff 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    text-shadow: 0 0 30px rgba(255, 255, 255, 0.5);
    line-height: 1.2;
    filter: drop-shadow(0 4px 8px rgba(0, 0, 0, 0.1));
  }

  /* 描述文字 */
  p {
    font-size: 1.4rem;
    color: rgba(255, 255, 255, 0.95);
    margin-bottom: 3rem;
    font-weight: 300;
    text-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
    max-width: 600px;
    line-height: 1.6;
    backdrop-filter: blur(5px);
    padding: 0.5rem 1rem;
    border-radius: 10px;
    background: rgba(255, 255, 255, 0.05);
  }

  /* 按鈕設計 */
  button {
    position: relative;
    padding: 1.2rem 3rem;
    font-size: 1.2rem;
    font-weight: 600;
    border: none;
    border-radius: 50px;
    cursor: pointer;
    color: white;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    box-shadow: 0 15px 35px rgba(102, 126, 234, 0.4), inset 0 1px 1px rgba(255, 255, 255, 0.2);
    transition: all 0.4s cubic-bezier(0.175, 0.885, 0.32, 1.275);
    overflow: hidden;
    backdrop-filter: blur(10px);
    border: 1px solid rgba(255, 255, 255, 0.2);
    transform-style: preserve-3d;
  }

    /* 按鈕發光效果 */
    button::before {
      content: '';
      position: absolute;
      top: 0;
      left: -100%;
      width: 100%;
      height: 100%;
      background: linear-gradient(90deg, transparent, rgba(255, 255, 255, 0.4), transparent);
      transition: left 0.6s ease;
    }

    /* 按鈕懸停效果 */
    button:hover {
      transform: translateY(-8px) scale(1.05);
      box-shadow: 0 25px 50px rgba(102, 126, 234, 0.6), inset 0 1px 1px rgba(255, 255, 255, 0.3), 0 0 20px rgba(255, 255, 255, 0.2);
    }

      button:hover::before {
        left: 100%;
      }

    button:active {
      transform: translateY(-4px) scale(1.02);
      transition: all 0.1s ease;
    }

  /* 脈動效果 */
  @keyframes pulse {
    0% {
      box-shadow: 0 15px 35px rgba(102, 126, 234, 0.4);
    }

    50% {
      box-shadow: 0 15px 35px rgba(102, 126, 234, 0.6);
    }

    100% {
      box-shadow: 0 15px 35px rgba(102, 126, 234, 0.4);
    }
  }

  button {
    animation: pulse 3s ease-in-out infinite;
  }

  /* 響應式設計 */
  @media (max-width: 768px) {
    .hero {
      padding: 50px 15px;
    }

    h1 {
      font-size: 2.8rem;
    }

    p {
      font-size: 1.2rem;
      margin-bottom: 2rem;
      padding: 0.5rem;
    }

    button {
      padding: 1rem 2.5rem;
      font-size: 1.1rem;
      width: 100%;
      max-width: 300px;
    }

    .hero::before,
    .hero::after {
      opacity: 0.3;
    }
  }

  @media (max-width: 480px) {
    h1 {
      font-size: 2.2rem;
    }

    p {
      font-size: 1.1rem;
    }

    .hero::before,
    .hero::after {
      display: none;
    }

    button {
      padding: 0.9rem 2rem;
      font-size: 1rem;
    }
  }
</style>
