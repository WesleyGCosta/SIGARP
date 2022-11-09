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

            $.ajax({
                type: 'GET',
                url: '/ProgramacaoConsumo/GetProgramacaoConsumo/',
                data: { unidadeAdministrativaId: $('#UnidadeAdministrativaa').find("option:selected").val(), yearAta: $('#AnoAta').val() },
                success: function (response) {
                    $('#result').empty()
                    $('#result').html(response)
                }
            })
        }
    })

    $(document).on('click', '.liberarFornecimento', function() {
        alert($(this).data('id'))
    })

})