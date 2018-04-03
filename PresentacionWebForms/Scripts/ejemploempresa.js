$(function () {
    $('#linklogin').click(function (e) {
        e.preventDefault();

        $('#login').slideToggle();
    });

    $('.btnmas').click(function (e) {
        e.preventDefault();

        var input = $(this).parent().find('input')

        var cantidad = input.val();

        cantidad++;

        input.val(cantidad);
    });

    $('.btnmenos').click(function (e) {
        e.preventDefault();

        var input = $(this).parent().find('input')

        var cantidad = input.val();

        cantidad--;

        input.val(cantidad);
    });

    $('#empleados tbody tr').each(function () {

    });
});