﻿/// <binding AfterBuild='sass' />
var gulp = require('gulp');
var sass = require("gulp-sass");
var rimraf = require("rimraf");
var tildeImporter = require('node-sass-tilde-importer');
var eyeglass = require("eyeglass");

var paths = {
    webroot: "../HomeMyDay.Web/wwwroot/"
};

paths.cssFolder = paths.webroot + 'css';

gulp.task("clean:css", function (cb) {
    rimraf(paths.cssFolder, cb);
});

gulp.task("sass", ['clean:css'], function () {
    return gulp.src("./Styles/**/*.scss")
        .pipe(sass(eyeglass({
            importer: tildeImporter
        })))
        .pipe(gulp.dest(paths.cssFolder));
});

gulp.task('sass:watch', function () {
    gulp.watch('./Styles/**/*.scss', ['sass']);
});
