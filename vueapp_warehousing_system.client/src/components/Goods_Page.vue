<template>
  <div id="container">

    <div id="top_bar">
      <h2>📦 貨物管理系統</h2>

      <div id="menu">
        <label @click="but_click('search')"> 查詢區</label>
        <label @click="but_click('insert')"> 新增貨物區</label>
        <label @click="but_click('edit')"> 編輯區</label>
      </div>
    </div>

    <div id="List_Good">

      <transition name="fade-slide" mode="out-in">

        <!-- 查詢區內容 -->
        <div id="search_view" v-if="display_search_check" class="card-view">

          <h1>查詢區</h1>

          <table class="styled-table" border="1" cellpadding="8" cellspacing="0" style="margin-top: 10px; width: auto">
            <thead>
              <tr>
                <th>名稱</th>
                <th>SKU (存貨單位)</th>
                <th>數量</th>
                <th>單位</th>
                <th>位置</th>
                <th>操作</th>
              </tr>
            </thead>

            <tbody>

              <tr v-for="item in goods" :key="item.id">
                <td>{{ item.name }}</td>
                <td>{{ item.sku }}</td>
                <td>{{ item.quantity }}</td>
                <td>{{ item.unit }}</td>
                <td>{{ item.location }}</td>
              </tr>

            </tbody>
          </table>

        </div>
      </transition>

      <!--新增貨物-->
      <transition name="fade-slide" mode="out-in">
        <div id="insert_view" v-if="display_insert_check" class="card-view">
          <h1>新增貨物區</h1>
          <form @submit.prevent>
            <table class="styled-table" border="1" cellpadding="8" cellspacing="0" style="margin-top: 10px; width: auto">
              <thead>
                <tr>
                  <th>名稱</th>
                  <th>SKU (存貨單位)</th>
                  <th>數量</th>
                  <th>單位</th>
                  <th>位置</th>
                  <th>操作</th>
                </tr>
              </thead>

              <tbody>

                <tr>
                  <td>
                    <input type="text" v-model="new_goods.name" />
                  </td>
                  <td>
                    <input type="text" v-model="new_goods.sku" />
                  </td>
                  <td>
                    <input type="number" v-model.number="new_goods.quantity" />
                  </td>
                  <td>
                    <input type="text" v-model="new_goods.unit" />
                  </td>
                  <td>
                    <input type="text" v-model="new_goods.location" />
                  </td>
                  <td>
                    <button type="button" @click="call_api_insert_good()">Insert</button>
                  </td>
                </tr>

              </tbody>
            </table>
          </form>

        </div>
      </transition>

      <!--edit 和 delete 寫在一起，還有延伸可以跟後台串接-->
      <transition name="fade-slide" mode="out-in">
        <div id="edit_view" v-if="display_edit_check" class="card-view">
          <h1>編輯區</h1>
          <table class="styled-table" border="1" cellpadding="8" cellspacing="0" style="margin-top: 10px; width: auto">
            <thead>
              <tr>
                <th>名稱</th>
                <th>SKU</th>
                <th>數量</th>
                <th>單位</th>
                <th>位置</th>
                <th colspan="2">操作</th>
              </tr>
            </thead>

            <tbody>

              <tr v-for="item in goods" :key="item.id">
                <td>
                  <input type="text" v-model="item.name" />
                </td>
                <td>
                  <input type="text" v-model="item.sku" />
                </td>
                <td>
                  <input type="number" v-model.number="item.quantity" />
                </td>
                <td>
                  <input type="text" v-model="item.unit" />
                </td>
                <td>
                  <input type="text" v-model="item.location" />
                </td>

                <td>
                  <button @click="call_api_save_good(item)">Save</button>
                </td>
                <td>
                  <button @click="call_api_delete_good(item)">Delete</button>
                </td>
              </tr>


            </tbody>
          </table>
        </div>

      </transition>

    </div>

    </div>

</template>

<style scoped>

  #container {
    width: 100vw;
    min-height: 100vh;
    margin: 0;
    padding: 0;
    /* 柔和暖色系漸層動畫背景 */
    background: linear-gradient(270deg, #ffe29f, #ffb07c, #ff7e5f, #feb47b, #ffe29f);
    background-size: 200% 200%;
    animation: gradientBG 10s ease-in-out infinite;
  }

  @keyframes gradientBG {
    0% {
      background-position: 0% 50%;
    }

    50% {
      background-position: 100% 50%;
    }

    100% {
      background-position: 0% 50%;
    }
  }

  #List_Good {
    width: 100vw;
    min-height: 100vh;
    display: flex;
    justify-content: center;
    align-items: flex-start;
    box-sizing: border-box;
    padding-top: 100px; /* 預留 top_bar 空間 */
  }



  #top_bar{
    position:fixed;
    top:0;
    height:auto;
    width:100%;
    background-color:aliceblue;
    display:flex;
    padding:20px;
  }

  #menu {
    margin-left: auto; /* 推到最右邊 */
    margin-right: 10px; /* 與右邊距離10px */
  }
    #menu label {
      display: inline-block;
      padding: 8px 16px;
      background-color: #D3D3D3 ;
      color: #333;
      font-size: 18px;
      border-radius: 6px;
      cursor: pointer;
      transition: background-color 0.3s ease, transform 0.1s ease, box-shadow 0.3s ease;
      user-select: none;
      font-weight: bold;
    }

      #menu label:hover {
        background-color: #e0e7ef;
        transform: translateY(-2px) scale(1.02);
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
      }

      #menu label:active {
        transform: translateY(0) scale(0.98);
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
      }

      #menu label input {
        display: none; /* 隱藏實際 input 元素 */
      }

  /*search_view、insert_view、edit_view ui 美化和動畫*/
  /* 卡片樣式區塊 */
  .card-view {
    margin: 100px auto 20px auto;
    width: fit-content;
    padding: 20px;
    border-radius: 12px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    background-color: #fff;
  }

  /* 表格樣式美化 */
  table {
    margin: 0 auto; /* 讓表格置中 */
    border-collapse: collapse;
    background-color: #fefefe;
    width: auto; /* 根據內容自動調整寬度 */
  }

  th {
    background-color: #f0f4f8;
    color: #333;
    font-weight: bold;
  }

  th, td {
    padding: 12px;
    text-align: center;
  }

  input[type="text"],
  input[type="number"] {
    padding: 6px;
    width: 100%;
    box-sizing: border-box;
    border: 1px solid #ccc;
    border-radius: 6px;
  }

  button {
    padding: 6px 12px;
    background-color: #4CAF50;
    border: none;
    color: white;
    font-weight: bold;
    border-radius: 6px;
    cursor: pointer;
    transition: background-color 0.3s ease;
  }

    button:hover {
      background-color: #45a049;
    }

    button:active {
      background-color: #388e3c;
    }

  /* 動畫 transition */
  .fade-slide-enter-active,
  .fade-slide-leave-active {
    transition: all 0.5s ease;
  }

  .fade-slide-enter-from,
  .fade-slide-leave-to {
    opacity: 0;
    transform: translateY(10px);
  }

  /* 卡片進場動畫 */
  @keyframes fadeIn {
    from {
      opacity: 0;
      transform: translateY(10px);
    }

    to {
      opacity: 1;
      transform: translateY(0);
    }
  }

  .styled-table {
    margin: 0 auto;
    width: auto;
    min-width: 700px;
  }

</style>
<script setup>
  import { ref, reactive, computed } from 'vue';
  import axios from 'axios';


  // ✅ 假資料（模擬資料庫）
  //var goods = ref([
  //  { id: 1, name: '筆記型電腦', sku: 'NB123', quantity: 10, unit: '台', location: 'A1' },
  //  { id: 2, name: '滑鼠', sku: 'MS456', quantity: 50, unit: '個', location: 'B3' },
  //  { id: 3, name: '螢幕', sku: 'MN789', quantity: 20, unit: '台', location: 'C2' },
  //])

  var goods = ref([]);
  var display_search_check = ref(false);
  var display_insert_check = ref(false);
  var display_edit_check = ref(false);

  var new_goods = ref({
    id: null,
    name: '',
    sku: '',
    quantity: 0,
    unit: '',
    location: ''
  });


  //切換 新增、查詢 、編輯頁面
  function but_click(insert_value) {
    switch (insert_value) {
      case 'search':
        call_api_get_goods();

        display_search_check.value = false;
        display_insert_check.value = false;
        display_edit_check.value = false;

        display_search_check.value = true;


        break;
      case 'insert':
        display_search_check.value = false;
        display_insert_check.value = false;
        display_edit_check.value = false;

        display_insert_check.value = true;
        break;
      case 'edit':
        display_search_check.value = false;
        display_insert_check.value = false;
        display_edit_check.value = false;

        display_edit_check.value = true;
        break;
    }
  }

  async function call_api_get_goods() {
    const Get_Api = 'https://localhost:7229/api/Warehousing_Api/GetGoods';

    await axios.get(Get_Api)
      .then(response => {
        goods.value = response.data;

        console.log("call_api_get_goods");

      }).catch(err => {
        console.error('取得資料失敗:', err)
      })
  }

  function call_api_insert_good() {
    //模擬插入資料
    //goods.value.push(
    //  {
    //    id: new_goods_id.value,
    //    name: new_goods.value.name,
    //    sku: new_goods.value.sku,
    //    quantity: new_goods.value.quantity,
    //    unit: new_goods.value.unit,
    //    location: new_goods.value.location
    //  }
    //);

    //new_goods.value = {
    //  id: null,
    //  name: '',
    //  sku: '',
    //  quantity: 0,
    //  unit: '',
    //  location: ''
    //};
    const Post_Api = 'https://localhost:7229/api/Warehousing_Api/InsertGood';

    axios.post(Post_Api, new_goods.value)
      .then(() => {
        alert(new_goods.value.name+' 新增成功')
        console.log("call_api_insert_goods");
        new_goods.value = {
          id: null,
          name: '',
          sku: '',
          quantity: 0,
          unit: '',
          location: ''
        };

      }
    ).catch(err => {
      console.error('新增資料上傳失敗:', err)
    })

    call_api_get_goods();

  }




  //刪除
  function call_api_delete_good (item){
    const Delete_Api = 'https://localhost:7229/api/Warehousing_Api/DeleteGood';

    axios.delete(Delete_Api, { data: item })
      .then(response => {


        console.log("call_api_delete_good");
        goods.value = goods.value.filter(g => g.id != item.id);

      }).catch(err => {
        console.error('刪除資料失敗:', err)
      })


  }

/*  var new_goods_id = goods.value.length > 0 ? Math.max(...goods.value.map(g=> g.id) )+1 :  1 ;*/



  function call_api_save_good(item){
    alert(item.name + '已修改');

    const Put_Api = 'https://localhost:7229/api/Warehousing_Api/UpdateGood';

    axios.put(Put_Api, item)
      .then(response => {
      
        call_api_get_goods();
        console.log("call_api_save_good");

      }).catch(err => {
        console.error('更新資料失敗:', err)
      })

    call_api_get_goods();
  }
</script>

