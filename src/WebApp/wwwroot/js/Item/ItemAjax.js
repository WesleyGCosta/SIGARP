import { GetMessageDomain } from '../site.js';
import { UpdateListDetentora } from '../Detentora/detentoraAjax.js';

$(document).ready(function () {
    const pathname = window.location.pathname.split('/');
    $("#AnoAta").change(function () {
        let year = $(this).find("option:selected").val();

        if (year != "") {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteListCodeAta/',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: { yearAta: year },
                success: function (response) {
                    $('#CodigoAta').find('option').remove();
                    $('<option>').val("").text("...").appendTo($('#CodigoAta'))
                    if (response.length > 0) {
                        $.each(response, function (i, d) {
                            $('<option>').val(d).text(d).appendTo($('#CodigoAta'))
                        })
                    }
                }
            })
        } else {
            $('#CodigoAta').find('option').remove();
            $('<option>').val("").text("...").appendTo($('#CodigoAta'))
        }
    })

    $('#CodigoAta').change(function () {
        AutoCompleteItem()
    })

    $('#CodigoItem').change(function () {
        let yearAta = $('#AnoAta').val();
        let codeAta = $('#CodigoAta').val();
        let codeItem = $(this).find("option:selected").text();

        if (pathname[1] == "ProgramacaoConsumo") {
            $.ajax({
                type: 'GET',
                url: '/Item/GetItemIncludeUnidadeAdministrativa/',
                data: { yearAta, codeAta, codeItem },
                success: function (response) {
                    $('#listProgramacao').empty()
                    $('#listProgramacao').append(response)
                }
            })
        }
    })

    function AutoCompleteItem() {

        let yearAta = $('#AnoAta').val()
        let codeAta = $('#CodigoAta').val()

        if (pathname[1] == "Item") {
            $.ajax({
                type: 'GET',
                url: '/Item/AutoCompleteCodeItem/',
                data: { yearAta, codeAta },
                success: function (response) {
                    $('#listItens').empty()
                    $('#listItens').append(response)
                    $('#CodigoItem').attr('value', $('#proxItem').val())
                },
                error: function () {
                    $('#listItens').empty()
                    $('#CodigoItem').attr('value', 1)
                }
            })

            GetListDetentoraRegistered(yearAta, codeAta)
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
        if ($(this).valid()) {
            alert('certo')
        } else {
            alert("erro")
        }
    })

    //Exclusão de Item
    $(document).on('click', '.btnDeleteItem', function () {
        const itemId = $(this).data('itemid')
        const numetoItem = $('CodigoItem').val()
        const yearAta = $('#AnoAta').val()
        const codeAta = $('#CodigoAta').val()

        Swal.fire({
            title: 'Confirmação de Exclusão',
            text: "Essa ação irá excluir tudo relacionado ao item " + numetoItem + "!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#247ba0',
            cancelButtonColor: '#6c757d',
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
                    }
                })
            }
        })

        
    })


    function GetListDetentoraRegistered(yearAta, codeAta) {
        $.ajax({
            type: 'GET',
            url: '/Item/GetListDetentoraRegistered/',
            data: { yearAta, codeAta },
            success: function (response) {
                $('#listDetentoraRegistered').empty()
                $('#listDetentoraRegistered').append(response)
            }
        })
    }
})