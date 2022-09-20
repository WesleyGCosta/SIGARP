import { GetMessageDomain } from '../site.js';

$(document).ready(function () {
    $("#formProgramacaoConsumo").submit(function (e) {
        e.preventDefault();
        if ($(this).valid()) {
            $.ajax({
                type: 'POST',
                url: '/ProgramacaoConsumo/Create/',
                data: $(this).serialize(),
                success: function () {              
                    GetMessageDomain();
                },
                error: function () {
                    GetMessageDomain();
                }
            })
        }
    })

    $('#CodigoItem').change(function () {
        let yearAta = $('#AnoAta').val();
        let codeAta = $('#CodigoAta').val();
        let codeItem = $(this).find("option:selected").text();

        $.ajax({
            type: 'GET',
            url: '/ProgramacaoConsumo/GetItemIncludeUnidadeAdministrativa/',
            data: { yearAta, codeAta, codeItem },
            success: function (response) {
                $('#listProgramacao').empty()
                $('#listProgramacao').append(response)
            }
        })
    })
})