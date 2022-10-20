$(document).ready(function () {
    //edit
    $(document).on('click', 'button[data-toggle="ajax-modal-editProgramacaoConsumo"]', function () {
        $.ajax({
            type: 'GET',
            url: '/ProgramacaoConsumo/Edit/',
            data: { participanteId: $(this).parent().data('participanteid') },
            success: function (response) {
                placeHolderHere.empty()
                placeHolderHere.html(response)
                placeHolderHere.unbind()
                placeHolderHere.data("validator", null)
                $.validator.unobtrusive.parse(placeHolderHere);
                placeHolderHere.find('.modal').modal('show');
            }
        })
    })


    //delete

    $(document).on('click', 'button[data-btnUser="delete"]', function () {
        Swal.fire({
            title: 'Confirmação de Exclusão',
            text: `Essa ação irá excluir permanentemente o usuário!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#247ba0',
            cancelButtonColor: '#6c757d',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Sim, apagar usuário!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'GET',
                    url: '/User/Delete/',
                    data: { id: $(this).parent().data('userid') },
                    success: function (response) {
                        $('#listUser').empty()
                        $('#listUser').html(response)
                        GetMessageDomain()
                    }
                })
            }
        })
    })
})