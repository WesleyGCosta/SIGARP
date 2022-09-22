$(document).ready(function () {

    $.validator.methods.number = function (value, element) {
        return this.optional(element) ||
            /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/
                .test(value);
    };

    $.validator.setDefaults({ ignore: ":hidden:not(select)" });

    (function ($) {
        $.validator.addMethod('data-val-cnpj-validation',
            function (value, element) {
                return isCNPJValid(value);
            }, function (element) {
                var msg = $(element).attr('data-val-cnpj-validation');
                if (!msg) {
                    msg = 'CNPJ Inválido';
                }
                return msg;
            });
        $.validator.unobtrusive.adapters.addBool('data-val-cnpj-validation');
    })(jQuery);

    (function ($) {
        $.validator.addMethod('data-val-more-than',
            function (value, element, params) {
                var nameCompare = $(element).attr('data-val-more-than-field');// PrecoMercado
                if (nameCompare) {
                    var valueCompare = $("#" + nameCompare).val();
                    var precoMercado = parseInt(valueCompare.replace(/[^\d]+/g, ''));
                    var precoRegistrado = parseInt(value.replace(/[^\d]+/g, ''));

                    if (precoMercado && precoRegistrado && (precoMercado >= precoRegistrado)) {
                        return true;
                    }
                }
                return false;
            }, function (params, element) {
                var msgCompare = $(element).attr('data-val-more-than');
                if (!msgCompare) {
                    msgCompare = 'O Preço Registrado não pode ser maior que Preço de Mercado';
                }
                return msgCompare;
            });
        $.validator.unobtrusive.adapters.addBool('data-val-more-than');
    })(jQuery);

    (function ($) {
        $.validator.addMethod('data-val-less-than',
            function (value, element, params) {
                var nameCompare = $(element).attr('data-val-less-than-field');// Quantidade
                if (nameCompare) {
                    var valueCompare = $("#" + nameCompare).val();
                    var quantidade = parseInt(value.replace(/[^\d]+/g, ''));
                    var quantidadeUso = parseInt(valueCompare.replace(/[^\d]+/g, ''));

                    if (quantidade >= quantidadeUso) {
                        return true;
                    }
                }
                return false;
            }, function (params, element) {
                var msgCompare = $(element).attr('data-val-less-than');
                if (!msgCompare) {
                    msgCompare = 'A Quantidade do Item não pode ser menor que Quantidade que estar em uso';
                }
                return msgCompare;
            });
        $.validator.unobtrusive.adapters.addBool('data-val-more-than');
    })(jQuery);


    function isCNPJValid(cnpj) {
        cnpj = cnpj.replace(/[^\d]+/g, '');
        if (cnpj == '') return false;
        if (cnpj.length != 14)
            return false;
        // Elimina CNPJs invalidos conhecidos
        if (cnpj == "00000000000000" ||
            cnpj == "11111111111111" ||
            cnpj == "22222222222222" ||
            cnpj == "33333333333333" ||
            cnpj == "44444444444444" ||
            cnpj == "55555555555555" ||
            cnpj == "66666666666666" ||
            cnpj == "77777777777777" ||
            cnpj == "88888888888888" ||
            cnpj == "99999999999999")
            return false;

        // Valida DVs
        tamanho = cnpj.length - 2
        numeros = cnpj.substring(0, tamanho);
        digitos = cnpj.substring(tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0))
            return false;

        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1))
            return false;

        return true;
    }
})