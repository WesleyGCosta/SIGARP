$(document).ready(function () {
    $('#listUsers').DataTable()

    $(document).ajaxStop(function () {
        $('#listUsers').DataTable()
    });


    (function () {
        window.addEventListener('load', function () {
            var forms = document.getElementsByClassName('needs-validation');
            var validation = Array.prototype.filter.call(forms, function (form) {
                form.addEventListener('submit', function (event) {
                    if (form.checkValidity() === false) {
                        event.preventDefault();
                        event.stopPropagation();
                    }
                    form.classList.add('was-validated');
                }, false);
            });
        }, false);
    })();

    $('#formLogin').submit(function () {
        if ($(this).valid()) {
            var btnLogar = $("#btnLogar")
            btnLogar.empty()
            btnLogar.html(`<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>`)
        } 
    })

})