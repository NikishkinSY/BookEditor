﻿/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

var paths = { webroot: "./wwwroot/" };

var itemsToCopy = {
    './node_modules/angular/angular.min.js': paths.webroot + 'lib/angular',
    './node_modules/angular-messages/angular-messages.min.js': paths.webroot + 'lib/angular',

    './node_modules/angular-material/angular-material.min.js': paths.webroot + 'lib/angular',
    './node_modules/angular-material/angular-material.min.css': paths.webroot + 'lib/angular',
    './node_modules/angular-aria/angular-aria.min.js': paths.webroot + 'lib/angular',
    './node_modules/angular-animate/angular-animate.min.js': paths.webroot + 'lib/angular',
    './node_modules/angular-cookies/angular-cookies.min.js': paths.webroot + 'lib/angular',
    
    './node_modules/bootstrap/dist/css/bootstrap.min.css': paths.webroot + 'lib/bootstrap',
    './node_modules/bootstrap/dist/js/bootstrap.min.js': paths.webroot + 'lib/bootstrap',

    './node_modules/jquery/dist/jquery.min.js': paths.webroot + 'lib/jquery'
};

gulp.task('copy', function () {
    for (var src in itemsToCopy) {
        if (!itemsToCopy.hasOwnProperty(src)) continue;
        gulp.src(src).pipe(gulp.dest(itemsToCopy[src]));
    }
});