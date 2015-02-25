var Helper = function () {
    var self = this;

    self.ajaxHelper = function (uri, method, data) {
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        });
    };
}