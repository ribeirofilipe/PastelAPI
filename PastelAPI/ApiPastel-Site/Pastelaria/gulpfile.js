const
    browsersync = require('browser-sync'),
    del = require('del'),
    gulp = require('gulp'),
    sass = require('gulp-sass')
    ;

gulp.task('server', ['sass:watch'], () => {
    let options = {
        port: 8025,
        host: 'localhost',
        server: {
            baseDir: './dist'
        },
        ui: {
            port: 8051
        }
    };

    gulp.watch(['!app/application/index.html', '!app/**/*.scss', 'app/**/*.*']).on('change', (event) => {
        if (event.path.indexOf('teste.html') > 0)
            return;

        return gulp.src(event.path)
            .pipe(gulp.dest(
                __dirname + '/dist/' +
                event.path.substring(event.path.indexOf("app") + 4,
                    event.path.lastIndexOf('\\'))
            ));
    });

    gulp.watch('app/application/index.html').on('change', (event) => {

        return gulp.src(event.path)
            .pipe(gulp.dest(
                __dirname + '/dist/'
            ));
    });

    return browsersync('app/**/*', options);

});

gulp.task('generate-dist', ['clean'], () => {
    gulp.start('copy');
    gulp.start('sass');
});

gulp.task('copy', () => {
    return gulp.src([
        __dirname + '/app/application/*.html',
        __dirname + '/app/**/*',
    ])
        .pipe(gulp.dest(__dirname + '/dist'));
});

gulp.task('clean', () => {
    return del.sync(__dirname + '/dist/**');
});

gulp.task('sass', () => {
    return gulp.src('./app/sass/style.scss')
        .pipe(sass.sync({
            sourceComments: 'map'
        }))
        .pipe(gulp.dest('./dist/style'));
});

gulp.task('sass:watch', () => {
    gulp.watch('./app/sass/**/*.scss', ['sass']);
});

gulp.task('default', ['generate-dist'], () => {
    gulp.start('server');
});


