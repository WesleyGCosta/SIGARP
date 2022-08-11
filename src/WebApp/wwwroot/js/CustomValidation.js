

$(document).ready(function () {

    $.validator.methods.number = function (value, element) {
        return this.optional(element) ||
            /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/
                .test(value);
    };

    $.validator.setDefaults({ ignore: ":hidden:not(select)" });

    (function ($) {
        $.validator.addMethod('data-val-cnpj-validation',
            function (value, element, params) {
                console.log(value)
                return isCNPJValid(value);
            }, function (params, element) {
                var msg = $(element).attr('data-val-cnpj-validation');
                if (!msg) {
                    msg = 'CNPJ Inválido';
                }
                return msg;
            });
        $.validator.unobtrusive.adapters.addBool('data-val-cnpj-validation');
    })(jQuery);


    function isCNPJValid(cnpj) {
        var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
        if (cnpj.length === 0) {
            return false;
        }
        cnpj = cnpj.replace(/\D+/g, '');
        digitos_iguais = 1;
        for (i = 0; i < cnpj.length - 1; i++)
            if (cnpj.charAt(i) !== cnpj.charAt(i + 1)) {
                digitos_iguais = 0;
                break;
            }
        if (digitos_iguais)
            return false;
        tamanho = cnpj.length - 2;
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
        if (resultado !== digitos.charAt(0)) {
            return false;
        }
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
        return (resultado === digitos.charAt(1));
    };
})