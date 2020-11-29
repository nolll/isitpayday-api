import vue from 'vue';
import vuex from 'vuex';
import store from './store';
import App from './App.vue';
import './styles';

vue.use(vuex);

function domReady(callback: () => void) {
    document.readyState === 'interactive' || document.readyState === 'complete'
        ? callback()
        : document.addEventListener('DOMContentLoaded', callback);
}

function init(){
    new vue({
        store: new vuex.Store(store),
        render: h => h(App)
    }).$mount('#app');
}

domReady(init);
