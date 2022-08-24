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
})