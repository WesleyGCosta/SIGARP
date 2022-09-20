$(document).ready(function () {
    $('#unidadeAdministrativaTable').DataTable()

    $(document).ajaxStop(function () {
        $('#unidadeAdministrativaTable').DataTable()
    })
})