$(document).ready(function () {
    //edit
    $(document).on('click', 'button[data-btnUser="edit"]', function () {
        var placeHolderHere = $('#PlaceHolderHere')
        $.ajax({
            type: 'GET',
            url: '/User/Edit/',
            data: { id: $(this).parent().data('userid') },
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

    $(document).on('submit', '#formEditUser', function (e) {
        e.preventDefault()

        $.ajax({
            type: 'POST',
            url: '/User/Edit/',
            data: $(this).serialize(),
            success: function (response) {
                $('#listUser').empty()
                $('#listUser').html(response)
                $('#PlaceHolderHere').find('.modal').modal('hide');
                GetMessageDomain()
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