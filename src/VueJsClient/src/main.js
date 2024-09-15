import { createApp } from 'vue';
import './index.css';
import router from './router';

import 'primeicons/primeicons.css';
import Toast from 'vue-toastification';
import "vue-toastification/dist/index.css"

import App from './App.vue';

const app = createApp(App);

app.use(router);
app.use(Toast);
app.mount('#app');
