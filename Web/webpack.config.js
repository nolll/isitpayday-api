var webpack = require("webpack");
var path = require("path");

module.exports = {
    entry: __dirname + "/Scripts/app.js",
    output: {
        path: __dirname + "/assets",
        filename: "scripts.js"
    },
    devtool: "source-map",
    resolve: {
        alias: getAliases(
            "ajax",
            "frequencies",
            "nth-formatter",
            "storage",
            "urls",
            "weekdays")
    },
    plugins: [
        new webpack.ProvidePlugin({
            "fetch": "imports?this=>global!exports?global.fetch!whatwg-fetch"
        })
    ]
};

function getAliases() {
    var i,
        aliases = {};
    for (i = 0; i < arguments.length; i++) {
        var module = arguments[i];
        aliases[module] = path.resolve("./Scripts/" + module + ".js");
    }
    return aliases;
}