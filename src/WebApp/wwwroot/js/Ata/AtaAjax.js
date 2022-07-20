$(document).ready(function () {
    $("#AnoAta").change(function () {
        var year = $(this).find("option:selected").val();
        if (year != "") {
            $.ajax({
                type: 'GET',
                url: '/Ata/AutoCompleteNumberAta/',
                data: { yearAta: year },
                success: function (response) {
                    $('#NumeroAta').attr('value', response)
                }
            })
        } else {
            $('#NumeroAta').attr('value', '')
        }

    })
})