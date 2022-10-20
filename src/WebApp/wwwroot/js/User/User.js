$(document).ready(function () {
    $('#listUsers').DataTable()

    $(document).ajaxStop(function () {
        $('#listUsers').DataTable()
    })
})