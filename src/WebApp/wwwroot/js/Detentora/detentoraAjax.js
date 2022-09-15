$(document).ready(function () {
    $(document).on('click', '.btnDeleteDetentora', function () {

        $.ajax({
            type: 'GET',
            url: '/Detentora/DeleteDetentoraItem/',
            data: { detentoraId: $(this).data('detentoraid'), itemId: $(this).data('detentoraid') },
            success: function (response) {
                $('#detentora').empty()
                $('#detentora').html(response)
            }
        })
    })
})

export function UpdateListDetentora(yearAta, codeAta) {
        $.ajax({
            type: 'GET',
            url: '/Detentora/UpdateListDetentora/',
            data: { yearAta, codeAta },
            success: function (response) {
                $('#detentora').empty()
                $('#detentora').html(response)
            }
        })
    }