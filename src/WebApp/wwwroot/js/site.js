(function ($) {
    $.fn.extend({

        // Deixa primeiras letras em maiúscula
        upperFirst: function () {
            $(this).keyup(function (event) {
                var box = event.target;
                var txt = $(this).val();
                var start = box.selectionStart;
                var end = box.selectionEnd;

                $(this).val(txt.toLowerCase().replace(/^(.)|(\s|\-)(.)/g,
                    function (c) {
                        return c.toUpperCase();
                    }));
                box.setSelectionRange(start, end);
            });
            return this;
        },

        // Deixa Todas as letras em maiúscula
        upperFirstAll: function () {
            $(this).keyup(function (event) {
                var box = event.target;
                var txt = $(this).val();
                var start = box.selectionStart;
                var end = box.selectionEnd;

                $(this).val(txt.toLowerCase().replace(/^(.)/g,
                    function (c) {
                        return c.toUpperCase();
                    }));
                box.setSelectionRange(start, end);
            });
            return this;
        }
    });
}(jQuery));

$(document).ready(function () {
    //Mascaras
    $('#NumeroProcesso').mask("0000.00000-00-0000");

    //Formatação de Texto
    $('.uppercase').upperFirstAll()
    $('.capitalize').upperFirst();
})