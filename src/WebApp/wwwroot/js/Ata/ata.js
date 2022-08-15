$(document).ready(function () {
    var cardConsult = $('#card-consult');

    $('#btnInfo').click(function () {
        cardConsult.empty()
        cardConsult.append($("#infoAta").html())
    })

    $('#btnEdit').click(function () {
        cardConsult.empty()
        cardConsult.append($("#editAta").html())
    })

    $('#btnDelete').click(function () {
        cardConsult.empty()
        cardConsult.append($("#deleteAta").html())
    })
})