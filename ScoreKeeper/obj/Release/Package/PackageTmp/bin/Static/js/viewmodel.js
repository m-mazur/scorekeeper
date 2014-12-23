(function () {
    var scoresUri = "/api/Scores/";
    var usersUri = "/api/Users/";

    var viewModel = {
        scores: ko.observableArray(),
        users: ko.observableArray(),
        leaderboard: ko.observableArray(),
        scoresOptions: ko.observableArray([
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13
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

    function createLeaderboard() {
        var groupedScores = _.groupBy(viewModel.scores(), function (score) {
            return score.UserName;
        });

        var mappedScores = _.chain(groupedScores).map(function (board, key) {
            return {
                UserName: key,
                ScorePoints: _.reduce((_.pluck(board, "ScorePoints")), function (result, current) {
                    return result + current;
                })
            }
        }).value();

        return (_.sortBy(mappedScores, function(list) {
            return list.ScorePoints;
        })).reverse();
    };

    function getAllScores () {
        ajaxHelper(scoresUri, 'GET').done(function (data) {
            viewModel.scores(_.sortBy(data, function(list) {
                return Date.parse(list.ScoreDate);
            }).reverse());
            viewModel.leaderboard(createLeaderboard());
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