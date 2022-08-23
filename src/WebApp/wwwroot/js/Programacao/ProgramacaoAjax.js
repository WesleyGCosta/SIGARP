import { GetMessageDomain } from '../site.js';

$(document).ready(function () {
    $("#formProgramacaoConsumo").submit(function (e) {
        e.preventDefault();
        if ($(this).valid()) {
            $.ajax({
                type: 'POST',
                url: '/ProgramacaoConsumo/Create/',
                data: $(this).serialize(),
                success: function (response) {              
                    GetMessageDomain();
                    $("#listProgramacao").html(response)
                },
                error: function () {
                    GetMessageDomain();
                }
            })
        }
    })
})