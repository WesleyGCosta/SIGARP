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
                    GetInfoItem()
                },
                error: function () {
                    GetMessageDomain();
                }
            })
        }
    })

    $('#CodigoItem').change(function () {
        GetInfoItem();
    })

    function GetInfoItem() {
        let yearAta = $('#AnoAta').val();
        let codeAta = $('#CodigoAta').val();
        let codeItem = $('#CodigoItem').find("option:selected").text();

        GetInfoItemAjax(yearAta, codeAta, codeItem);
    }

    function GetInfoItemAjax(yearAta, codeAta, codeItem) {
        $.ajax({
            type: 'GET',
            url: '/ProgramacaoConsumo/GetItemIncludeUnidadeAdministrativa/',
            data: { yearAta, codeAta, codeItem },
            success: function (response) {
                $('#listProgramacao').empty()
                $('#listProgramacao').append(response)
            }
        })
    }

    
})