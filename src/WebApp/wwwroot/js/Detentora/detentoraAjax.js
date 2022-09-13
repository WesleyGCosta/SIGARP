$(document).ready(function () {
    $(document).on('click', '.btnDeleteDetentora', function () {
        

        $.ajax({
            type: 'GET',
            url: '/Detentora/DeleteDetentoraItem/',
            data: { detentoraId: $(this).data('detentoraid'), itemId: $(this).data('detentoraid') },
            success: function (response) {
                $('#detentora').empty()
                $('#detentora').html(response)
                $('.modal-backdrop').remove();
                $('body').removeAttr('class')
                $('body').removeAttr('style');
            }
        })
    })
})