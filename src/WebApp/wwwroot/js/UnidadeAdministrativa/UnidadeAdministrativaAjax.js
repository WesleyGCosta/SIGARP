export function UpdateListParticipanteItem(yearAta, codeAta) {
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

$(document).ready(function () {
    let placeHolderHere = $('#PlaceHolderHere')

    //Detalhes da Unidade Administrativa
    $(document).on('click', 'button[data-toggle="ajax-modal-infoUnidadeAdministrativa"]', function () {
        $.ajax({
            type: 'GET',
            url: '/UnidadeAdministrativa/Details/',
            data: { id: $(this).parent().data('unidadeadministrativaid') },
            success: function (response) {
                placeHolderHere.empty()
                placeHolderHere.html(response)
                placeHolderHere.find('.modal').modal('show');
            },
            error: function () {
                GetMessageDomain()
            }
        })
    })

    //Editar Detentora (GET)
    $(document).on('click', 'button[data-toggle="ajax-modal-editUnidadeAdministrativa"]', function () {
        $.ajax({
            type: 'GET',
            url: '/UnidadeAdministrativa/Edit/',
            data: { id: $(this).parent().data('unidadeadministrativaid') },
            success: function (response) {
                placeHolderHere.empty()
                placeHolderHere.html(response)
                placeHolderHere.find('.modal').modal('show');
            }
        })
    })

    //Editar Detentora (POST)
    $(document).on('submit', '#formEditUnidadeAdministrativa', function (e) {
        e.preventDefault()

        if ($(this).valid()) {
            $.ajax({
                type: 'POST',
                url: '/UnidadeAdministrativa/Edit/',
                data: $(this).serialize(),
                success: function (response) {
                    GetMessageDomain()
                    $('#listUnidadeAministrativa').empty()
                    $('#listUnidadeAministrativa').append(response)
                    GetMessageDomain()
                    placeHolderHere.find('.modal').modal('hide');
                }
            })
        }

    })
})