$(document).ready(function () {
    $('#ListDetentoraTable').DataTable();

    $(document).ajaxStop(function () {
        $('#ListDetentoraTable').DataTable();
    })
})
