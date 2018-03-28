$(function () {
    $('#login').hide();

    $('#btnlogin').click(function (e) {
        e.preventDefault();

        $('#login').slideToggle();
    });
});