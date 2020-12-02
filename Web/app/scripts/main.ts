import vue from 'vue';
import App from './App.vue';
import './styles';

function domReady(callback: () => void) {
    document.readyState === 'interactive' || document.readyState === 'complete'
        ? callback()
        : document.addEventListener('DOMContentLoaded', callback);
}

function init(){
    new vue({
        render: h => h(App)
    }).$mount('#app');
}

domReady(init);
