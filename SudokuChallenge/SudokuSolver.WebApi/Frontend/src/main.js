import Vue from 'vue';
import App from './App';
import vuetify from './plugins/vuetify';
import 'devextreme/dist/css/dx.common.css';
import 'devextreme/dist/css/dx.light.css';

new Vue({
    vuetify,
    render: h => h(App)
}).$mount('#app');