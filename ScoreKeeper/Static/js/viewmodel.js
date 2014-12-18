(function () {
    var scoresUri = "/api/Scores/";
    var usersUri = "/api/Users/";

    var viewModel = {
        scores: ko.observableArray(),
        users: ko.observableArray(),
        newScore: {
            ScorePoints: ko.observable(),
            UserId: ko.observable()
        }
    };

    viewModel.addScore = function (formElement) {
        var score = {
            ScorePoints: parseInt(viewModel.newScore.ScorePoints()),
            UserId: parseInt(viewModel.newScore.UserId())
        };

        ajaxHelper(scoresUri, 'POST', score).done(function () {
            /* Todo */
        });
    };

    function getAllScores () {
        ajaxHelper(scoresUri, 'GET').done(function (data) {
            viewModel.scores(data);
        });
    }

    function getAllUsers() {
        ajaxHelper(usersUri, 'GET').done(function (data) {
            viewModel.users(data);
        });
    }

    function ajaxHelper(uri, method, data) {
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function () {
            /* Todo */
        });
    }

    getAllScores();
    getAllUsers();

    ko.applyBindings(viewModel);
})();