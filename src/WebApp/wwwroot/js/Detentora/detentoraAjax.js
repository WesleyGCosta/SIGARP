﻿$(document).ready(function () {
    $(document).on('click', '.btnDeleteDetentora', function () {
        const yearAta = $('#AnoAta').val()
        const codeAta = $('#CodigoAta').val()

        Swal.fire({
            title: 'Confirmação de Exclusão',
            text: "Deseja excluir a Detentora do Item?!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#247ba0',
            cancelButtonColor: '#6c757d',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Sim, apagar Detentoda do Item!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'GET',
                    url: '/Detentora/DeleteDetentoraItem/',
                    data: { detentoraId: $(this).data('detentoraid'), yearAta, codeAta },
                    success: function (response) {
                        $('#detentora').empty()
                        $('#detentora').html(response)
                    }
                })
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