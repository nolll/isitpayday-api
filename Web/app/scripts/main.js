import Vue from 'vue';
import Store from './store';
import App from './App.vue';

import Styles from '../styles/styles.css'; // needed for style import

function domReady(callback) {
    document.readyState === 'interactive' || document.readyState === 'complete'
        ? callback()
        : document.addEventListener('DOMContentLoaded', callback);
}

domReady(function () {
    new Vue({
        store: Store,
        render: h => h(App)
    }).$mount('#app');
});
