1. �D�n�e���ɮ׵��c�P�γ~
(1) index.html
�� Vite �w�]�� SPA �J�f�����C

���c�G

<div id="app"></div>�GVue ���Ϊ��w�]�����I�C

<script type="module" src="/src/main.js"></script>�G���J�D�{���C

�\��G�z�L npm run dev �Ұ� Vite �ɡA�۰ʸ��J�������ê�l�� Vue ���ΡC

(2) Goods_Page.html
�۩w�q���ĤG�ӤJ�f�����C

���c�G

<div id="good"></div>�GVue �ե󪺱����I�C

<script type="module" src="/src/main.js"></script>�G���J�P�@���D�{���C

�\��G�����}�Ҧ� HTML �ɮɡAVue ���η|������ #good�C

(3) src/main.js
�e�����Ϊ��D�{���C

�\��G

�פJ Pinia ���A�޲z�B�D���ե�]�p Goods_Page.vue�^�B�ʵe���ҲաC

�إ� Pinia ��ҡC

������� Vue app�G

createApp(App).use(pinia).mount('#app')�G���� index.html�C

createApp(Goods).mount('#good')�G���� Goods_Page.html�C

�����G�P�ɤ䴩��ӤJ�f�����I�]�@�뱡�p�U�ȨϥΤ@�ӡ^�C

(4) src/Store.js
�ϥ� Pinia �w�q���쪬�A�޲z�C

�\��G

�޲z currentView ���A�C

���� switchTo(viewName) ��k�A�ΥH����������ܤ��e�C

(5) src/components/Goods_Page.vue
���D�n�~���޿譶���]�f���޲z�^�C

���c�G�]�t�T�ӥD�n�\��϶��G

�d�߰�

�s�W��

�s���

����覡�G�z�L���a���A�� Pinia ���A������ܰ϶��C

�\��G�P��� API ���ʡA��{��ƪ��d�ߡB���J�B��s�B�R���A�ô�V���G�C

(6) ��L�]�w��
�]�t vite.config.js�Beslint.config.js ���C

�γ~�G���Ѷ}�o���ҳ]�w�BLint �W�h�BHTTPS ���ҡBProxy ���\��A�T�O�}�o�y�{���Q�C

2. ������V�P�����y�{
(A) �Ұʬy�{
���� npm run dev �Ұ� Vite �}�o���A���C

�w�]���J index.html�A�Ϊ����}�� Goods_Page.html�C

���J /src/main.js�AVue app �ھڤJ�f������ #app �� #good�C

(B) �e����V�y�{
Vue app �����G

index.html�G�ھ� Pinia �� currentView ���A�ʺA��V�����C

Goods_Page.html�G������V Goods_Page.vue �����e�C

��l���A�G

�����w�]��ܬd�߰ϡA�æ۰ʩI�s API ���o�f����ơA��V�����C

���������G

�ϥΪ��I����]�d�ߡB�s�W�B�s��^�C

�I�s Pinia �� switchTo(viewName) �Υ��a�禡�������A�C

�ھڪ��A�A�z�L v-if �� v-show ����϶���ܡC

��ƾާ@�G

�s�W�G�ϥΪ�洣���ơA�I�s API�A���\��۰ʨ�s�d�߸�ơC

�s��/�R���G�b�s��ϰ���ާ@�A�I�s���� API�A�è�s�����ܡC

3. ���������޿�B�J
�}�Һ����]index.html �� Goods_Page.html�^�C

Vue app ����������� DOM �`�I�]#app �� #good�^�C

��l�e����ܬd�߰ϡA�æ۰ʸ��J��ơC

�ϥΪ̳z�L���Ĳ�o���������޿�C

�ھ� currentView ���A��V�۹������϶��]�d�ߡB�s�W�B�s��^�C

�U�϶��i���ƾާ@�ûP��� API ���q�C

�ާ@���\��A�۰ʨ�s�d�߰ϸ�ƥH�P�B�e���C

4. �ɥR����
�t�Υi�䴩�h�ӤJ�f�]�p index.html �P Goods_Page.html�^�A��ĳ��ȤW�Τ@�J�f�קK�V�c�C

�ϥ� Pinia �޲z�������A�A��{²��B������@�����������޿�C

�Ҧ����������z�L���A�ܧ�P�����V�]v-if / v-show�^����A�D�ǲΦh�����������C

�`��
���t�ά��歶���Ρ]SPA�^�A�z�L Vue�BPinia ��{���A�X�ʪ����������P���e��V�C
�D�{���ھڤJ�f���� Vue app �ܫ��w DOM �����A�������e�̪��A����ʺA�����A
�ûP��� API ���ʹ�{��ƾާ@�P��s�C