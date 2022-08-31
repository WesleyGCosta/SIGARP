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
            cleanSelects();
        }
    })

    $('#CodigoAtaInfo').change(function () {
        var year = $(this).find("option:selected").val();
        if (year != "") {
            $.ajax({
                type: 'GET',
                url: '/Ata/GetAtaByYearAndCode/',
                data: { yearAta: $('#AnoAtaInfo').val(), codeAta: $('#CodigoAtaInfo').val() },
                success: function (response) {
                    fillDivResult(response)
                },
                error: function () {
                    $('#result').empty()
                    GetMessageDomain()
                }
            })
        }
    })

    $('#CodigoAtaEdit').change(function () {
        var yearAta = $(this).find("option:selected").val();
        if (yearAta != "") {
            $.ajax({
                type: 'GET',
                url: '/Ata/GetAtaByYearAndCodeEdit/',
                data: { yearAta: $('#AnoAtaEdit').val(), codeAta: $('#CodigoAtaEdit').val() },
                success: function (response) {
                    fillDivResult(response)
                },
                error: function () {
                    $('#result').empty()
                    GetMessageDomain()
                }
            })
        }
    })


    $("#AnoAtaDelete").change(function () {
        var yearAta = $(this).find("option:selected").val();
        if (yearAta != null) {
            $.ajax({
                type: 'GET',
                url: '/Ata/GetListAtaByYear/',
                data: { yearAta },
                success: function (response) {
                    fillDivResult(response);
                    GetMessageDomain()  
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
                fillDivResult(response)
                GetMessageDomain()
            },
            error: function () {
                $('#result').empty()
                GetMessageDomain()
            }
        })
    })

    function fillDivResult(response) {
        $('#result').empty();
        $('#result').append(response);
    }

    function cleanSelects() {
        $('.CodigoAtaSelect').find('option').remove();
        $('<option>').val("").text("...").appendTo($('.CodigoAtaSelect'));
    }
})