$(document).ready(function () {
    $('.CodigoAtaSelect').change(function () {
        var yearAta = $('#AnoAta').find("option:selected").val();
        var codeAta = $(this).find("option:selected").val();
        if (yearAta != "" && codeAta != "") {
            $.ajax({
                type: 'GET',
                url: '/Report/GetAtaReport/',
                data: { yearAta, codeAta },
                beforeSend: function () {
                    Loader()
                },
                complete: function () {
                    Finish()
                },
                success: function (response) {
                    $('#result').empty()
                    $('#result').html(response)
                },
                error: function () {
                    $('#result').empty()
                    GetMessageDomain()
                }
            })
        }
    })
})