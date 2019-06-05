(function () {
    $(document).ready(function () {
        $(document).on('click',
            '.media',
            function () {
                var url = $(this).find('img').attr('src');
                $('#image').val(url);
                $('.img-preview').attr('src', url);
                $('.media').removeClass('selected');
                $(this).addClass('selected');

            });

        $(document).on('click',
            '#reset-url',
            function () {
                $('#image').val('');
            });

        $(document).on('click',
            '#reset-faviconurl',
            function () {
                $('#faviconurl').val('');
            });

        $(document).on('click',
            '.deletePost',
            function () {
                var that = $(this);
                $.ajax({
                    url: $(this).data("deleteurl") + '/' + $(this).data("newsitemid"),
                    success: function () {
                        that.parents("tr").remove();
                    }
                });


            });

        $(window).on("load", function () {
            $('.media img')
                .each(function (i, e) {
                    if ($(e).attr('src').endsWith('.svg')) {
                        return;
                    }

                    var img = new Image();
                    img.onload = function () {
                        if (this.width < 400 || this.height < 200) {
                            $(e).parents('.media').first().addClass('small');
                        }
                    };
                    img.src = $(e).attr('src');
                });
        });

        $(document)
            .on('click',
                'button.select-all',
                function () {
                    $('.category input[type="checkbox"]').prop('checked', true);
                    $(this).removeClass('select-all').addClass('deselect-all');
                })
            .on('click',
                'button.deselect-all',
                function () {
                    $('.category input[type="checkbox"]').prop('checked', false);
                    $(this).removeClass('deselect-all').addClass('select-all');
                });
    });
}());
