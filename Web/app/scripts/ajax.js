import axios from 'axios';

export default {
    get: (url) => axios({
        method: 'get',
        url: url
    })
};
