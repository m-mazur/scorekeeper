(function () {
    var scoresUri = "/api/Scores/";
    var usersUri = "/api/Users/";

    var viewModel = {
        scores: ko.observableArray(),
        users: ko.observableArray(),
        leaderBoard: ko.observableArray(),
        scoresOptions: ko.observableArray([
            { option: 1 },
            { option: 2 },
            { option: 3 },
            { option: 4 },
            { option: 5 },
            { option: 6 },
            { option: 7 },
            { option: 8 },
            { option: 9 },
            { option: 10 },
            { option: 11 },
            { option: 12 },
            { option: 13 }
        ]),
        newScore: {
            ScorePoints: ko.observable("1"),
            UserId: ko.observable()
        }
    };

    viewModel.addScore = function () {
        var score = {
            ScorePoints: parseInt(viewModel.newScore.ScorePoints()),
            UserId: parseInt(viewModel.newScore.UserId())
        };

        ajaxHelper(scoresUri, 'POST', score).done(function () {
            /* Todo */
        });
    };

   function leaderBoard (){
        var board = _.groupBy(viewModel.scores(), function(score) {
            return score.UserId;
        });
       console.log(board);
    };

    function getAllScores () {
        ajaxHelper(scoresUri, 'GET').done(function (data) {
            viewModel.scores(data);
            leaderBoard();
        });
    }

    function getAllUsers () {
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