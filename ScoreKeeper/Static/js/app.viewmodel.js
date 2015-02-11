﻿(function () {
    var ViewModel = function (resultsViewModel, leaderBoardViewModel, addScoreViewModel) {
        var self = this;

        self.scores = ko.observableArray();
        self.users = ko.observableArray();
        self.leaderboard = ko.observableArray();

        resultsViewModel.getAllScores().done(function (data) {
            self.scores(data);
        }).then(function (data){
            self.leaderboard(leaderBoardViewModel.createLeaderboard(data));
        });;

        addScoreViewModel.getAllUsers().done(function (data) {
           self.users(data);
        });

        self.deleteScore = function (score) {
            resultsViewModel.deleteScore(score).done(function () {
                self.scores.remove(score);
            });
        }
    }

    ko.applyBindings(ViewModel(new ResultsViewModel(), new LeaderBoardViewModel(), new AddScoreViewModel()));
}());