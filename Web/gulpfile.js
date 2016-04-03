/// <binding ProjectOpened='watch' />
var gulp = require("gulp");
var webpack = require("gulp-webpack");
var webpackConfig = require("./webpack.config.js");

var paths = {
    jsEntry: "./Scripts/app.js",
    assetFolder: "./assets/",
    allJs: "./Scripts/**/*.js",
    allHtml: "./Scripts/components/**/*.html",
};

gulp.task("default", ["build"]);
gulp.task("build", ["scripts"]);
gulp.task("scripts", taskScripts);
gulp.task("watch", taskWatch);

function taskScripts() {
    return gulp.src(paths.jsEntry)
        .pipe(webpack(webpackConfig))
        .pipe(gulp.dest(paths.assetFolder));
}

function taskWatch() {
    function onChanged(event) {
        console.log("File " + event.path + " was " + event.type + ", running tasks...");
    }

    gulp.watch(paths.allJs, ["scripts"]).on("change", onChanged);
    gulp.watch(paths.allHtml, ["scripts"]).on("change", onChanged);
}