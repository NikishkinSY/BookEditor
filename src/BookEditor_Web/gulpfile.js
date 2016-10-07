/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

var paths = { webroot: "./wwwroot/" };

var itemsToCopy = {
    './node_modules/angular/angular*.js': paths.webroot + 'lib/angular',
    './node_modules/angular-messages/angular-messages.js': paths.webroot + 'lib/angular',

    './node_modules/angular-material/angular-material.js': paths.webroot + 'lib/angular',
    './node_modules/angular-material/angular-material.css': paths.webroot + 'lib/angular',
    './node_modules/angular-aria/angular-aria.js': paths.webroot + 'lib/angular',
    './node_modules/angular-animate/angular-animate.js': paths.webroot + 'lib/angular'
};

gulp.task('copy', function () {
    for (var src in itemsToCopy) {
        if (!itemsToCopy.hasOwnProperty(src)) continue;
        gulp.src(src).pipe(gulp.dest(itemsToCopy[src]));
    }
});