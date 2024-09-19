const gulp = require('gulp');
const { series, parallel } = require('gulp');
const uglify = require('gulp-uglify');
const cssnano = require('gulp-cssnano');
const rename = require('gulp-rename');

const configCss = {
    src: ['wwwroot/css/**/*.css']
};
const configJs = {
    src: ['wwwroot/js/app/*.js']
};
const configDeleteJs = {
    src: ['wwwroot/js/app/**/*.min.js']
};
const configDeleteCss = {
    src: ['wwwroot/css/**/*.min.css']
};

async function loadDel() {
    const del = await import('del');
    return del.default;
}
async function clean(cb) {
    const del = await loadDel();
    await del([...configDeleteJs.src, ...configDeleteCss.src]);
    cb();
}

function styles(cb) {
    gulp.src(configCss.src)
        .pipe(cssnano())
        .pipe(rename({ extname: '.min.css' }))
        .pipe(gulp.dest('wwwroot/css/'))
        .on('end', cb);
}

function scripts(cb) {
    gulp.src(configJs.src)
        .pipe(uglify())
        .pipe(rename({ extname: '.min.js' }))
        .pipe(gulp.dest('wwwroot/js/app/'))
        .on('end', cb);
}
function defaultTask(cb) {
    series(clean, parallel(scripts, styles))(cb);
}
function watch() {
    gulp.watch([...configCss.src, ...configJs.src], defaultTask);
}
exports.clean = clean;
exports.styles = styles;
exports.scripts = scripts;
exports.watch = watch;
exports.default = defaultTask;