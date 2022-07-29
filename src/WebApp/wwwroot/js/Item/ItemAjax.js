$(document).ready(function () {
    $("#AnoAta").change(function () {
        var year = $(this).find("option:selected").val();
        if (year != "") {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteListCodeAta/',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: { yearAta: year },
                success: function (response) {
                    $('#CodigoAta').find('option').remove();
                    if (response.length > 0) {
                        $.each(response, function (i, d) {
                            $('<option>').val(d).text(d).appendTo($('#CodigoAta'))
                        })
                        GetCodeItemByCodeAta($("#AnoAta").val() , 1)
                    }
                    else {
                        $('<option>').val("").text("...").appendTo($('#CodigoAta'))
                    }  
                }
            })
        } else {
            $('<option>').val("").text("...").appendTo($('#CodigoAta'))
        }
    })

    $('#CodigoAta').change(function () {
        var anoAta = $('#AnoAta').val();
        var codeAta = $('#CodigoAta').val();
        GetCodeItemByCodeAta(anoAta, codeAta)
    })

    function GetCodeItemByCodeAta(yearAta, codeAta) {
        console.log(yearAta, codeAta)
        $.ajax({
            type: 'GET',
            url: '/Item/AutoCompleteCodeItem/',
            data: { yearAta: yearAta, codeAta: codeAta },
            success: function (response) {
                $('#CodigoItem').attr('value', response)
            }
        })
    }
})