$(document).on('click', '#messages-list tr', function (event) {
    var id = $(event.currentTarget).attr('id').replace(/\D/g, '');
    console.log('message #' + id + ' has been clicked');
    var $modal = $('#messageModal'); //.modal('show')

    $.ajax({
        url: '/message/modal-details/' + id,
        beforeSend: function () {
            console.log('Getting message #' + id);
            $modal.find('.modal-content').empty();
        },
        success: function (data, textStatus) {
            console.log('Message #' + id + ' successfully loaded');
            $modal.find('.modal-content').replaceWith(data);
            $modal.modal('show');
        }
    });
});