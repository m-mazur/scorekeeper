﻿var LeaderBoardViewModel = (function () {
    var self = this;
    var groupedScores;

    self.createLeaderboard = function (value) {
        groupedScores = _.groupBy(value, function (score) {
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

        return (_.sortBy(mappedScores, function (list) {
            return list.ScorePoints;
        })).reverse();
    };

    function get () {
        return self;
    }

    return {
        get: get
    };
}());