const webpack = require('webpack');
const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const VueLoaderPlugin = require('vue-loader/lib/plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');

module.exports = {
    entry: './app/scripts/index.js',
    output: {
        filename: '[name]-[contenthash].js',
        path: path.resolve(__dirname, 'dist'),
        publicPath: '/dist/'
    },
    devtool: 'source-map',
    module: {
        rules: [
            {
                test: /\.css/,
                use: [
                    { loader: MiniCssExtractPlugin.loader },
                    { loader: 'css-loader' }
                ]
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/
            },
            {
                test: /\.html$/,
                use: 'html-loader'
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({
            filename: 'main-[contenthash].css'
        }),
        new VueLoaderPlugin(),
        new webpack.IgnorePlugin(/^\.\/locale$/, /moment$/),
        new HtmlWebpackPlugin({
            filename: path.resolve(__dirname, './Views/Generated/Script.cshtml'),
            template: path.resolve(__dirname, './app/templates/script-template.txt'),
            inject: false
        }),
        new HtmlWebpackPlugin({
            filename: path.resolve(__dirname, './Views/Generated/Style.cshtml'),
            template: path.resolve(__dirname, './app/templates/style-template.txt'),
            inject: false
        })
    ],
    resolve: {
        alias: {
            vue: 'vue/dist/vue.esm.js',
            '@': path.resolve(__dirname, './app/scripts')
        },
        extensions: ['.ts', '.js']
    },
    optimization: {
        splitChunks: {
            chunks: 'all',
            name: 'vendor'
        }
    },
    stats: { children: false }
};


//var webpack = require("webpack");
//var path = require("path");

//module.exports = {
//    entry: __dirname + "/Scripts/app.js",
//    output: {
//        path: __dirname + "/assets",
//        filename: "scripts.js"
//    },
//    devtool: "source-map",
//    resolve: {
//        alias: getAliases(
//            "ajax",
//            "frequencies",
//            "nth-formatter",
//            "storage",
//            "urls",
//            "weekdays")
//    },
//    plugins: [
//        new webpack.ProvidePlugin({
//            "fetch": "imports?this=>global!exports?global.fetch!whatwg-fetch"
//        })
//    ]
//};

//function getAliases() {
//    var i,
//        aliases = {};
//    for (i = 0; i < arguments.length; i++) {
//        var module = arguments[i];
//        aliases[module] = path.resolve("./Scripts/" + module + ".js");
//    }
//    return aliases;
//}