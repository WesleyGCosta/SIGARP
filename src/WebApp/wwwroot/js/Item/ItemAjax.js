import { GetMessageDomain } from '../site.js';

$(document).ready(function () {
    const pathname = window.location.pathname.split('/');
    $("#AnoAta").change(function () {
        let year = $(this).find("option:selected").val();

        if (year != "") {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteListCodeAta/',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: { yearAta: year },
                success: function (response) {
                    $('#CodigoAta').find('option').remove();
                    $('<option>').val("").text("...").appendTo($('#CodigoAta'))
                    if (response.length > 0) {
                        $.each(response, function (i, d) {
                            $('<option>').val(d).text(d).appendTo($('#CodigoAta'))
                        })
                    }
                }
            })
        } else {
            $('#CodigoAta').find('option').remove();
            $('<option>').val("").text("...").appendTo($('#CodigoAta'))
        }
    })

    $('#CodigoAta').change(function () {
        AutoCompleteItem()
    })

    $('#CodigoItem').change(function () {
        let yearAta = $('#AnoAta').val();
        let codeAta = $('#CodigoAta').val();
        let codeItem = $(this).find("option:selected").text();

        if (pathname[1] == "ProgramacaoConsumo") {
            $.ajax({
                type: 'GET',
                url: '/Item/GetItemIncludeUnidadeAdministrativa/',
                data: { yearAta, codeAta, codeItem },
                success: function (response) {
                    $('#listProgramacao').empty()
                    $('#listProgramacao').append(response)
                }
            })
        }
    })

    function AutoCompleteItem() {
        
        let yearAta = $('#AnoAta').val()
        let codeAta = $('#CodigoAta').val()

        if (pathname[1] == "Item") {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteCodeItem/',
                data: { yearAta, codeAta },
                success: function (response) {
                    $('#listItens').empty()
                    $('#listItens').append(response)
                    $('#CodigoItem').attr('value', $('#proxItem').val())
                },
                error: function () {
                    $('#listItens').empty()
                    $('#CodigoItem').attr('value', 1)
                }
            })

            GetListDetentoraRegistered(yearAta, codeAta)
        } 
        if (pathname[1] == "ProgramacaoConsumo")
        {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteListCodeItem/',
                data: { yearAta, codeAta },
                success: function (response) {
                    $('#CodigoItem').find('option').remove();
                    $('<option>').val("").text("...").appendTo($('#CodigoItem'))
                    if (response.length > 0) {
                        $.each(response, function (i, d) {
                            $('<option>').val(d.id).text(d.numeroItem).appendTo($('#CodigoItem'))
                        })
                    }
                }
            })
        }
    }

    $(document).on('click', 'button[data-toggle="ajax-modal-infoItem"]',   function () {
        alert($(this).data('itemid'))
        console.log("teste")
    })

    function GetListDetentoraRegistered(yearAta, codeAta) {
        $.ajax({
            type: 'GET',
            url: '/Item/GetListDetentoraRegistered/',
            data: { yearAta, codeAta },
            success: function (response) {
                $('#listDetentoraRegistered').empty()
                $('#listDetentoraRegistered').append(response)
            }
        })
    }
})