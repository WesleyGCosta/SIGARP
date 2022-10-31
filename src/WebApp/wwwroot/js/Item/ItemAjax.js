import { UpdateListDetentora } from '../Detentora/detentoraAjax.js';
import { UpdateListParticipanteItem } from '../UnidadeAdministrativa/UnidadeAdministrativaAjax.js';

$(document).ready(function () {
    const pathname = window.location.pathname.split('/');

    $('#CodigoAta').change(function () {
        AutoCompleteItem()
    })

    function AutoCompleteItem() {

        let yearAta = $('#AnoAta').val()
        let codeAta = $('#CodigoAta').val()

        if (pathname[1] == "Item") {
            if (pathname[2] != "SuspendItem") {
                $.ajax({
                    type: 'GET',
                    url: '/Item/AutoCompleteCodeItem/',
                    data: { yearAta, codeAta },
                    success: function (response) {
                        if (response == "Error") {
                            $('#listItens').empty()
                            $('#CodigoItem').attr('value', 1)
                        } else {
                            $('#listItens').empty()
                            $('#listItens').append(response)
                            $('#CodigoItem').attr('value', $('#proxItem').val())
                        }
                    },
                })
            } else {
                $.ajax({
                    type: 'GET',
                    url: '/Item/GetListItemSuspend/',
                    data: { yearAta, codeAta },
                    success: function (response) {
                        FillItensSuspend(response);
                    },
                })
            }
        }
        if (pathname[1] == "ProgramacaoConsumo") {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteListCodeItem/',
                data: { yearAta, codeAta },
                success: function (response) {
                    $('#CodigoItem').find('option').remove();
                    $('<option>').val("").text("...").appendTo($('#CodigoItem'))
                    if (response.length > 0) {
                        $.each(response, function (i, d) {
                            $('<option>').val(d.id).text(d.numeroItem).appendTo($('#CodigoItem'))
                        })
                    }
                }
            })
        }
    }

    //Detalhes
    $(document).on('click', 'button[data-toggle="ajax-modal-infoItem"]', function () {
        var placeHolderHere = $('#PlaceHolderHere')
    
        $.ajax({
            type: 'GET',
            url: '/Item/Details/',
            data: { itemId: $(this).data('itemid') },
            success: function (response) {
                placeHolderHere.empty()
                placeHolderHere.html(response)
                placeHolderHere.find('.modal').modal('show');
            }
        })
    })

    //Edição
    $(document).on('click', 'button[data-toggle="ajax-modal-editItem"]', function () {
        var placeHolderHere = $('#PlaceHolderHere')

        $.ajax({
            type: 'GET',
            url: '/Item/Edit/',
            data: { itemId: $(this).data('itemid') },
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

    $(document).on('submit', '#formEditItem', function (e) {
        e.preventDefault()
        const placeHolderHere = $('#PlaceHolderHere')
        const yearAta = $('#AnoAta').val()
        const codeAta = $('#CodigoAta').val()

        if ($(this).valid()) {
            $.ajax({
                type: 'POST',
                url: '/Item/Edit/',
                data: $(this).serialize(),
                success: function (response) {
                    $('#item').empty()
                    $('#item').html(response)
                    GetMessageDomain()
                    UpdateListDetentora(yearAta, codeAta)
                    UpdateListParticipanteItem(yearAta, codeAta)
                    placeHolderHere.find('.modal').modal('hide');
                }
            })
        }
    })

    //Exclusão de Item
    $(document).on('click', '.btnDeleteItem', function () {
        const itemId = $(this).data('itemid')
        const codigoItem = $(this).data('codigoitem')
        const yearAta = $('#AnoAta').val()
        const codeAta = $('#CodigoAta').val()

        Swal.fire({
            title: 'Confirmação de Exclusão',
            text: `Essa ação irá excluir tudo relacionado ao item ${codigoItem}!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#247ba0',
            cancelButtonColor: '#6c757d',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Sim, apagar item!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'GET',
                    url: '/Item/Delete/',
                    data: { itemId },
                    success: function (response) {
                        $('#item').empty()
                        $('#item').html(response)
                        GetMessageDomain()
                        UpdateListDetentora(yearAta, codeAta)      
                        UpdateListParticipanteItem(yearAta, codeAta)
                        if ($('#theAmountItem').val() > 0) {
                            Swal.fire({
                                title: 'Item excluído com sucesso',
                                text: `Os itens foram renumerado a partir do item excluído!`,
                                icon: 'success',
                                confirmButtonColor: '#247ba0',
                                confirmButtonText: 'Ok'
                            })
                        }
                    }
                })
            }
        })      
    })

    //Ativar e desativar item
    $(document).on('click', '.checkBoxActiveInactive', function () {
        let itemId = $(this).parent().data('itemid')
        let status = $(this).data('value')
        let item = $(this).data('item')
        let textMessage = `Deseja ativar o item ${item}?`;
        let confirmButtonText = "Sim, ativar Item"

        if (status == "False") {
            textMessage = `Deseja desativar o item ${item}?`
            confirmButtonText = 'Sim, desativar Item'
        }

        Swal.fire({
            title: 'Confirmação',
            text: textMessage,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#247ba0',
            cancelButtonColor: '#6c757d',
            cancelButtonText: 'Cancelar',
            confirmButtonText: confirmButtonText
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    url: '/Item/ActiveInactiveItem/',
                    data: { itemId, status },
                    success: function (response) {
                        GetMessageDomain();
                        FillItensSuspend(response)
                    }
                })
            }
        })      
    })

    function FillItensSuspend(response) {
        if (response == "Error") {
            GetMessageDomain();
        } else {
            $('#result').empty();
            $('#result').append(response);
        }
    }
})