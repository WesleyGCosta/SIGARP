export function UpdateListParticipanteItem(yearAta, codeAta){
    $.ajax({
        type: 'GET',
        url: '/UnidadeAdministrativa/UpdateListParticipanteItem/',
        data: { yearAta, codeAta },
        success: function (response) {
            $('#orgao').empty()
            $('#orgao').html(response)
        }
    })
}