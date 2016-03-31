var webpack = require("webpack");

module.exports = {
    entry: "./Scripts/script.js",
    output: {
        path: "assets",
        filename: "scripts.js"
    },
    plugins: [
        new webpack.ProvidePlugin({
            "fetch": "imports?this=>global!exports?global.fetch!whatwg-fetch"
        })
    ]
};