import { UpdateListParticipanteItem } from '../UnidadeAdministrativa/UnidadeAdministrativaAjax.js';

$(document).ready(function () {
    let placeHolderHere = $('#PlaceHolderHere')

    $("#formProgramacaoConsumo").submit(function (e) {
        e.preventDefault();
        if ($(this).valid()) {
            $.ajax({
                type: 'POST',
                url: '/ProgramacaoConsumo/Create/',
                data: $(this).serialize(),
                success: function (response) {
                    GetMessageDomain();
                    if (response != 'Error') {
                        GetInfoItem()
                    }

                },
            })
        }
    })

    $(document).on('submit', '#formEditProgramacaoConsumo', function (e) {
        e.preventDefault()
        const yearAta = $('#AnoAta').val()
        const codeAta = $('#CodigoAta').val()

        $.ajax({
            type: 'POST',
            url: '/ProgramacaoConsumo/Edit/',
            data: $(this).serialize(),
            success: function () {
                GetMessageDomain();
                UpdateListParticipanteItem(yearAta, codeAta)
                placeHolderHere.find('.modal').modal('hide');
            }
        })
    })

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

    $('.OrderSelect').change(function () {
        if ($('#AnoAta').val() != '' && $('#UnidadeAdministrativaa').find("option:selected").val() != '') {
            const pathname = window.location.pathname.split('/');
            if (pathname[2] == "OrderOfSupply") {
                GetProgramacaoConsumo($('#UnidadeAdministrativaa').find("option:selected").val(), $('#AnoAta').val())
            } else {
                GetOrdensFornecimentos($('#UnidadeAdministrativaa').find("option:selected").val(), $('#AnoAta').val())
            }
           
        }
    })

    function GetProgramacaoConsumo(unidadeAdministrativaId, yearAta,) {
        $.ajax({
            type: 'GET',
            url: '/ProgramacaoConsumo/GetProgramacaoConsumo/',
            data: { unidadeAdministrativaId: unidadeAdministrativaId, yearAta: yearAta },
            beforeSend: function () {
                Loader()
            },
            complete: function () {
                Finish()
            },
            success: function (response) {
                $('#result').empty()
                $('#result').html(response)
            }
        })
    }

    function GetOrdensFornecimentos(unidadeAdministrativaId, yearAta,) {
        $.ajax({
            type: 'GET',
            url: '/ProgramacaoConsumo/GetOrdensFornecimentos/',
            data: { unidadeAdministrativaId: unidadeAdministrativaId, yearAta: yearAta },
            beforeSend: function () {
                Loader()
            },
            complete: function () {
                Finish()
            },
            success: function (response) {
                $('#result').empty()
                $('#result').html(response)
            }
        })
    }

    $(document).on('click', '.liberarFornecimento', function () {
        $.ajax({
            type: 'GET',
            url: '/ProgramacaoConsumo/ReleaseSupply/',
            data: { programacaoConsumoId: $(this).data('id') },
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

    $(document).on('submit', '#formFornecimento', function (e) {
        e.preventDefault()

        if ($(this).valid()) {
            $.ajax({
                type: 'POST',
                url: '/ProgramacaoConsumo/ReleaseSupply/',
                data: $(this).serialize(),
                success: function (response) {
                    if (response != 'Error') {
                        placeHolderHere.find('.modal').modal('hide');
                        GetProgramacaoConsumo($('#UnidadeAdministrativaa').find("option:selected").val(), $('#AnoAta').val())
                    }
                    GetMessageDomain();
                }
            })
        }
    })

    $(document).on('click', '.btn-reverseFornecimento', function () {
        Swal.fire({
            title: 'Confirmação de Estorno',
            text: "Deseja estornar o fornecimento?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#247ba0',
            cancelButtonColor: '#6c757d',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Sim, estornar fornecimento!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'GET',
                    url: '/ProgramacaoConsumo/DeleteFornecimento/',
                    data: { fornecimentoId: $(this).data('fornecimentoid'), programacaoId: $(this).data('programacaoid') },
                    beforeSend: function () {
                        Loader()
                    },
                    complete: function () {
                        Finish()
                    },
                    success: function () {
                        GetMessageDomain()
                        GetOrdensFornecimentos($('#UnidadeAdministrativaa').find("option:selected").val(), $('#AnoAta').val())
                    },
                    error: function () {
                        GetMessageDomain()
                    }
                })
            }
        })
    })
})