(function () {
    var scoresUri = "/api/Scores/GetScore";
    var usersUri = "/api/Users/GetUsers";
    var latestScoreUri = "/api/Scores/GetLatestScore";
    var postScoreUri = "/api/Scores/PostScore";
    var deleteScoreUri = "/api/Scores/DeleteScore/";

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

    viewModel.addScore = function (formElement) {
        var score = {
            ScorePoints: parseInt(viewModel.newScore.ScorePoints()),
            UserId: parseInt(viewModel.newScore.UserId())
        };

        ajaxHelperWithBootBox(postScoreUri, 'POST', score,  'Vill du lägga till poäng?');
    };

    viewModel.deleteScore = function (score) {
        ajaxHelper(deleteScoreUri + score.ScoreId, 'DELETE').done(function () {
            viewModel.scores.remove(score);
            viewModel.leaderboard(createLeaderboard());
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

    function getLatestScore() {
        ajaxHelper(latestScoreUri, 'GET').done(function (data) {
            viewModel.scores.unshift(data);
        })
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

    function ajaxHelperWithBootBox(uri, method, data, message) {
        bootbox.dialog({
            title: 'Bekräfta',
            message: message,
            buttons: {
                success: {
                    label: "Ja!",
                    className: "btn-success",
                    callback: function () {
                        ajaxHelper(uri, method, data);
                        getLatestScore();
                    }
                },
                danger: {
                    label: "Nej!",
                    className: "btn-danger"
                }
            }
        });
    }

    getAllScores();
    getAllUsers();

    ko.applyBindings(viewModel);
})();