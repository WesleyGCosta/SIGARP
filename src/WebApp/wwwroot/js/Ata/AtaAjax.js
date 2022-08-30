import { GetMessageDomain } from '../site.js';

$(document).ready(function () {
    $("#AnoAta").change(function () {
        var year = $(this).find("option:selected").val();
        if (year != "") {
            $.ajax({
                type: 'GET',
                url: '/Ata/AutoCompleteNumberAta/',
                data: { yearAta: year },
                success: function (response) {
                    $('#CodigoAta').attr('value', response)
                }
            })
        } else {
            $('#CodigoAta').attr('value', '')
        }
    })

    $('.AnoAtaSelect').change(function () {
        var year = $(this).find("option:selected").val();
        if (year != "") {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteListCodeAta/',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: { yearAta: year },
                success: function (response) {
                    $('.CodigoAtaSelect').find('option').remove();
                    $('<option>').val("").text("...").appendTo($('.CodigoAtaSelect'))
                    if (response.length > 0) {
                        $.each(response, function (i, d) {
                            $('<option>').val(d).text(d).appendTo($('.CodigoAtaSelect'))
                        })
                    }
                }
            })
        } else {
            $('.CodigoAtaSelect').find('option').remove();
            $('<option>').val("").text("...").appendTo($('.CodigoAtaSelect'))
        }
    })

    $('#CodigoAtaInfo').change(function () {
        var year = $(this).find("option:selected").val();
        if (year != "") {
            $.ajax({
                type: 'GET',
                url: '/Ata/GetAta/',
                data: { yearAta: $('#AnoAtaInfo').val(), codeAta: $('#CodigoAtaInfo').val() },
                success: function (response) {
                    $('#result').empty()
                    $('#result').append(response)
                },
                error: function () {
                    $('#result').empty()
                    GetMessageDomain()
                }
            })
        }
    })


    $(".AnoAtaDetete").change(function () {
        var yearAta = $(this).find("option:selected").val();
        if (yearAta != null) {
            $.ajax({
                type: 'GET',
                url: '/Ata/GetListAtaByYear/',
                data: { yearAta },
                success: function (response) {
                    $('#result').empty()
                    $('#result').append(response)
                },
                error: function () {
                    $('#result').empty()
                    GetMessageDomain()
                }
            })
        }
    })

    /*exclusão de ata*/

    $(document).on('click', '.deleteAta', function () {
        const codeAta = $(this).attr('data-codeata');
        const yearAta = $(this).attr('data-anoata');

        $.ajax({
            type: 'GET',
            url: '/Ata/Delete/',
            data: { yearAta, codeAta },
            success: function (response) {
                $('#result').empty()
                $('#result').append(response)
                GetMessageDomain()
            },
            error: function () {
                $('#result').empty()
                GetMessageDomain()
            }
        })
    })
})