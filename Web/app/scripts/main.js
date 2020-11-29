import vue from 'vue';
import vuex from 'vuex';
import store from './store';
import App from './App.vue';
import Styles from '../styles/styles.css'; // needed for style import

vue.use(vuex);

function domReady(callback) {
    document.readyState === 'interactive' || document.readyState === 'complete'
        ? callback()
        : document.addEventListener('DOMContentLoaded', callback);
}

domReady(function () {
    new vue({
        store: new vuex.Store(store),
        render: h => h(App)
    }).$mount('#app');
});
