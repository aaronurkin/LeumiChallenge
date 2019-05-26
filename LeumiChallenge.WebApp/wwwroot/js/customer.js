$(document).on('click', '#customers-list tr', function (event) {
    var id = $(event.currentTarget).attr('id').replace(/\D/g, '');
    window.location = 'customer/details/' + id;
});