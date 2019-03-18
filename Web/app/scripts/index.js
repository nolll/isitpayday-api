import app from './app';
import styles from '../styles/styles.css';

function domReady(callback) {
    document.readyState === 'interactive' || document.readyState === 'complete'
        ? callback()
        : document.addEventListener('DOMContentLoaded', callback);
}

domReady(function () {
    app.init();
});
