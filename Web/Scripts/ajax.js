function load(url, success, error) {
    fetch(url, {
        credentials: "same-origin"
    })
        .then(checkStatus)
        .then(parseJson)
        .then(success)
        .catch(error);
}

function post(url, data, success, error) {
    fetch(url, {
        credentials: "same-origin",
        method: "post",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
    .then(success)
    .catch(error);
}

function checkStatus(response) {
    var t = 0;
    if (response.status >= 200 && response.status < 300) {
        return response;
    } else {
        return new Error(response.statusText);
    }
}

function parseJson(response) {
    return response.json();
}

module.exports = {
    load: load,
    post: post
}