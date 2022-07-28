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
    $('#Cnpj').mask("00.000.000/0000-00");
    $('#Endereco_Cep').mask('00.000-000');
    $('#Telefone').mask('(00) 00000-0000');
    $('#Telefone').blur(function (event) {
        if ($(this).val().length == 15) {
            $('#Telefone').mask('(00) 00000-0000');
        } else {
            $('#Telefone').mask('(00) 0000-0000');
        }
    });0

    //Formatação de Texto
    $('.uppercase').upperFirstAll()
    $('.capitalize').upperFirst();
})