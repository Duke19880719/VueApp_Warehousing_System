1. 主要前端檔案結構與用途
(1) index.html
為 Vite 預設的 SPA 入口頁面。

結構：

<div id="app"></div>：Vue 應用的預設掛載點。

<script type="module" src="/src/main.js"></script>：載入主程式。

功能：透過 npm run dev 啟動 Vite 時，自動載入此頁面並初始化 Vue 應用。

(2) Goods_Page.html
自定義的第二個入口頁面。

結構：

<div id="good"></div>：Vue 組件的掛載點。

<script type="module" src="/src/main.js"></script>：載入同一份主程式。

功能：直接開啟此 HTML 檔時，Vue 應用會掛載到 #good。

(3) src/main.js
前端應用的主程式。

功能：

匯入 Pinia 狀態管理、主頁組件（如 Goods_Page.vue）、動畫等模組。

建立 Pinia 實例。

掛載兩個 Vue app：

createApp(App).use(pinia).mount('#app')：對應 index.html。

createApp(Goods).mount('#good')：對應 Goods_Page.html。

說明：同時支援兩個入口掛載點（一般情況下僅使用一個）。

(4) src/Store.js
使用 Pinia 定義全域狀態管理。

功能：

管理 currentView 狀態。

提供 switchTo(viewName) 方法，用以切換頁面顯示內容。

(5) src/components/Goods_Page.vue
為主要業務邏輯頁面（貨物管理）。

結構：包含三個主要功能區塊：

查詢區

新增區

編輯區

控制方式：透過本地狀態或 Pinia 狀態控制顯示區塊。

功能：與後端 API 互動，實現資料的查詢、插入、更新、刪除，並渲染結果。

(6) 其他設定檔
包含 vite.config.js、eslint.config.js 等。

用途：提供開發環境設定、Lint 規則、HTTPS 憑證、Proxy 等功能，確保開發流程順利。

2. 頁面渲染與切換流程
(A) 啟動流程
執行 npm run dev 啟動 Vite 開發伺服器。

預設載入 index.html，或直接開啟 Goods_Page.html。

載入 /src/main.js，Vue app 根據入口掛載至 #app 或 #good。

(B) 畫面渲染流程
Vue app 掛載：

index.html：根據 Pinia 的 currentView 狀態動態渲染頁面。

Goods_Page.html：直接渲染 Goods_Page.vue 的內容。

初始狀態：

頁面預設顯示查詢區，並自動呼叫 API 取得貨物資料，渲染為表格。

頁面切換：

使用者點選選單（查詢、新增、編輯）。

呼叫 Pinia 的 switchTo(viewName) 或本地函式切換狀態。

根據狀態，透過 v-if 或 v-show 控制區塊顯示。

資料操作：

新增：使用表單提交資料，呼叫 API，成功後自動刷新查詢資料。

編輯/刪除：在編輯區執行操作，呼叫對應 API，並刷新資料顯示。

3. 頁面切換邏輯步驟
開啟網頁（index.html 或 Goods_Page.html）。

Vue app 掛載到對應的 DOM 節點（#app 或 #good）。

初始畫面顯示查詢區，並自動載入資料。

使用者透過選單觸發頁面切換邏輯。

根據 currentView 狀態渲染相對應的區塊（查詢、新增、編輯）。

各區塊進行資料操作並與後端 API 溝通。

操作成功後，自動刷新查詢區資料以同步畫面。

4. 補充說明
系統可支援多個入口（如 index.html 與 Goods_Page.html），建議實務上統一入口避免混淆。

使用 Pinia 管理頁面狀態，實現簡潔且易於維護的頁面切換邏輯。

所有頁面切換透過狀態變更與條件渲染（v-if / v-show）控制，非傳統多頁面跳轉機制。

總結
本系統為單頁應用（SPA），透過 Vue、Pinia 實現狀態驅動的頁面切換與內容渲染。
主程式根據入口掛載 Vue app 至指定 DOM 元素，頁面內容依狀態條件動態切換，
並與後端 API 互動實現資料操作與更新。