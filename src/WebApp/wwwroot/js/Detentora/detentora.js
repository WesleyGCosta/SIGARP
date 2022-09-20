$(document).ready(function () {
    $('#listDetentoraTable').DataTable();

    $(document).ajaxStop(function () {
        $('#listDetentoraTable').DataTable();
    })
})
