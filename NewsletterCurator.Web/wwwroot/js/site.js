(function () {
    $(document).ready(function () {
        $(document).on('click',
            '.media',
            function () {
                var url = $(this).find('img').attr('src');
                $('#image').val(url);
                $('.img-preview').css('background-image', 'url(\'' + url + '\')');
                $('.media').removeClass('selected');
                $(this).addClass('selected');

            });

        $(document).on('click',
            '#reset-url',
            function() {
                $('#image').val('');
            });

        $(window).on("load", function () {
            $('.media img')
                .each(function (i, e) {
                    var img = new Image();
                    img.onload = function () {
                        if (this.width < 400 || this.height < 400) {
                            $(e).parents('.media').first().addClass('small');
                        }
                    };
                    img.src = $(e).attr('src');
                });
        });
    });
}());
