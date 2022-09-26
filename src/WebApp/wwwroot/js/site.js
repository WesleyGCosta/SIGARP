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
    //Máscaras
    $(document).on("focus", "#NumeroProcesso", function () {
        $(this).mask("0000.00000-00-0000");
    });
    $(document).on("focus", "#Cnpj", function () {
        $(this).mask("00.000.000/0000-00");
    });

    $(document).on("focus", "#Cpf", function () {
        $(this).mask("000.000.000-00");
    });

    $(document).on("focus", "#Endereco_Cep", function () {
        $(this).mask('00.000-000');
    });

    $(document).on("focus", "#PrecoMercado", function () {
        $(this).mask('#.##0,00', { reverse: true });
    });

    $(document).on("focus", "#PrecoRegistrado", function () {
        $(this).mask('#.##0,00', { reverse: true });
    });

    $(document).on("focus", "#Telefone", function () {
        $(this).mask('(00) 00000-0000');
        $(this).blur(function (event) {
            if ($(this).val().length == 15) {
                $('#Telefone').mask('(00) 00000-0000');
            } else {
                $('#Telefone').mask('(00) 0000-0000');
            }
        }); 0
    });

    //Formatação de Texto

    $(document).on("focus", ".uppercase", function () {
        $(this).upperFirstAll();
    });

    $(document).on("focus", ".capitalize", function () {
        $(this).upperFirst();
    });
})


