<template>
  <div class="form-container">
    <div class="form-wrapper">
      <h2 class="form-title">登入</h2>
      <form @submit.prevent="onSubmit" class="login-form">
        <div class="input-group">
          <label for="account" class="input-label">帳號</label>
          <div class="input-wrapper">
            <input type="text"
                   id="account"
                   v-model="form_data.account"
               
                   class="form-input"
                   :class="{ 'error': errors.account }"
                   placeholder="請輸入帳號" />
            <div class="input-underline"></div>
          </div>
          <transition name="error-slide">
            <span v-if="errors.account" class="error-message">{{errors.account}}</span>
          </transition>
        </div>

        <div class="input-group">
          <label for="password" class="input-label">密碼</label>
          <div class="input-wrapper">
            <input type="password"
                   id="password"
                   v-model="form_data.password"
            
                   class="form-input"
                   :class="{ 'error': errors.password }"
                   placeholder="請輸入密碼" />
            <div class="input-underline"></div>
          </div>
          <transition name="error-slide">
            <span v-if="errors.password" class="error-message">{{errors.password}}</span>
          </transition>
        </div>

        <transition name="error-slide">
          <div v-if="response" class="response-message">{{response}}</div>
        </transition>

        <button type="submit" class="submit-btn">
          <span class="btn-text">提交</span>
          <div class="btn-ripple"></div>
        </button>
      </form>
    </div>
  </div>
</template>

<script setup>
  import { ref, onMounted, reactive } from 'vue'

  var form_data = reactive({
    account: '',
    password: ''
  })

  var errors = reactive({
    account: '',
    password: ''
  })

  var response = ref('')

  /*  JavaScript 中，空字串 '' 是 false（代表 false - like 值）*/
  function validate() {
    errors.account = form_data.account.trim() ? '' : '欄位必填'
    errors.password = form_data.password.trim() ? '' : '欄位必填'

    return !errors.account && !errors.password
  }

  function onSubmit() {
    if (validate() ) {
      response.value = '正在提交中...';
      window.location.href = '../Goods_Page.html'
    }else{
      response.value = '請修正錯誤後再提交';
    }
  }
</script>

<style scoped>
  .form-container {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    padding: 20px;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    margin: 0;
    box-sizing: border-box;
  }

  .form-wrapper {
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border-radius: 20px;
    box-shadow: 0 20px 40px rgba(0, 0, 0, 0.1);
    padding: 40px;
    width: 100%;
    max-width: 400px;
    animation: slideUp 0.6s ease-out;
  }

  @keyframes slideUp {
    from {
      opacity: 0;
      transform: translateY(30px);
    }

    to {
      opacity: 1;
      transform: translateY(0);
    }
  }

  .form-title {
    text-align: center;
    margin-bottom: 30px;
    font-size: 28px;
    font-weight: 600;
    color: #333;
    background: linear-gradient(135deg, #667eea, #764ba2);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
  }

  .login-form {
    display: flex;
    flex-direction: column;
    gap: 25px;
  }

  .input-group {
    position: relative;
  }

  .input-label {
    display: block;
    margin-bottom: 8px;
    font-weight: 500;
    color: #555;
    font-size: 14px;
    transition: color 0.3s ease;
  }

  .input-wrapper {
    position: relative;
  }

  .form-input {
    width: 100%;
    padding: 12px 16px;
    border: 2px solid #e1e5e9;
    border-radius: 10px;
    font-size: 16px;
    background: #fafbfc;
    transition: all 0.3s ease;
    box-sizing: border-box;
  }

    .form-input:focus {
      outline: none;
      border-color: #667eea;
      background: white;
      box-shadow: 0 0 0 3px rgba(102, 126, 234, 0.1);
      transform: translateY(-2px);
    }

    .form-input.error {
      border-color: #e74c3c;
      background: #fdf2f2;
    }

  .input-underline {
    position: absolute;
    bottom: 0;
    left: 0;
    height: 2px;
    width: 0;
    background: linear-gradient(135deg, #667eea, #764ba2);
    transition: width 0.3s ease;
  }

  .form-input:focus + .input-underline {
    width: 100%;
  }

  .error-message {
    display: block;
    color: #e74c3c;
    font-size: 12px;
    margin-top: 5px;
    font-weight: 500;
  }

  .response-message {
    color: #e74c3c;
    font-size: 14px;
    text-align: center;
    padding: 10px;
    background: #fdf2f2;
    border-radius: 8px;
    border-left: 4px solid #e74c3c;
  }

  .submit-btn {
    position: relative;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
    border: none;
    padding: 14px 28px;
    border-radius: 12px;
    font-size: 16px;
    font-weight: 600;
    cursor: pointer;
    overflow: hidden;
    transition: all 0.3s ease;
    margin-top: 10px;
  }

    .submit-btn:hover {
      transform: translateY(-2px);
      box-shadow: 0 10px 25px rgba(102, 126, 234, 0.3);
    }

    .submit-btn:active {
      transform: translateY(0);
    }

  .btn-text {
    position: relative;
    z-index: 2;
  }

  .btn-ripple {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(255, 255, 255, 0.1);
    transform: scaleX(0);
    transform-origin: left;
    transition: transform 0.3s ease;
  }

  .submit-btn:hover .btn-ripple {
    transform: scaleX(1);
  }

  /* 錯誤訊息動畫 */
  .error-slide-enter-active,
  .error-slide-leave-active {
    transition: all 0.3s ease;
  }

  .error-slide-enter-from {
    opacity: 0;
    transform: translateY(-10px);
  }

  .error-slide-leave-to {
    opacity: 0;
    transform: translateY(-10px);
  }

  /* 響應式設計 */
  @media (max-width: 480px) {
    .form-wrapper {
      padding: 30px 20px;
      margin: 10px;
    }

    .form-title {
      font-size: 24px;
    }
  }

  /* 載入動畫 */
  @keyframes pulse {
    0%, 100% {
      opacity: 1;
    }

    50% {
      opacity: 0.7;
    }
  }

  .form-wrapper:hover {
    animation: pulse 2s infinite;
  }
</style>
