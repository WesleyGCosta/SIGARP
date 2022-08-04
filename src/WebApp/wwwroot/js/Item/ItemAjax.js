$(document).ready(function () {
    $("#CodigoItem").chosen();

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
        var pathname = window.location.pathname.split('/');
        if (pathname[2] == "Create") {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteCodeItem/',
                data: { yearAta: $('#AnoAta').val(), codeAta: $('#CodigoAta').val() },
                success: function (response) {
                    $('#CodigoItem').attr('value', response)
                }
            })
        } else {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteListCodeItem/',
                data: { yearAta: $('#AnoAta').val(), codeAta: $('#CodigoAta').val() },
                success: function (response) {
                    $('#CodigoItem').find('option').remove();
                    if (response.length > 0) {
                        $.each(response, function (i, d) {
                            $('<option>').val(d.id).text(d.numeroItem + " - " + d.descricao).appendTo($('#CodigoItem'))
                        })
                        $('#CodigoItem').trigger("chosen:updated");
                    }
                    else {
                        $('#CodigoItem').find('option').remove();
                    }  
                }
            })
           
        }
    })
})