var ScoresService = (function() {

    var self = this;
    var scoresUri = 'api/scores'

    function ajaxHelper(uri, method, data) {
        self.error(' ');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error();
        });
    }

    function getAllScores() {
        ajaxHelper(scoresUri, 'GET').done(function (data) {
            return data;
        });
    }

    function get() {
        return ScoresService;
    }

    return {
        get: get
    };
}());