﻿(function () {
    var ViewModel = function (resultsViewModel, leaderBoardViewModel, addScoreViewModel) {
        var self = this;
        var tempScore = addScoreViewModel.tempScore;
        var score = {
            ScorePoints: ko.observable("1"),
            UserId: ko.observable()
        };

        self.scores = ko.observableArray();
        self.users = ko.observableArray();
        self.leaderboard = ko.observableArray();
        self.scoresOptions = ko.observableArray(addScoreViewModel.options());

        resultsViewModel.getAllScores().done(function (data) {
            self.scores(data);
        }).then(function (data){
            self.leaderboard(leaderBoardViewModel.createLeaderboard(data));
        });

        addScoreViewModel.getAllUsers().done(function (data) {
           self.users(data);
        });

        self.removeScore = function (score) {
            resultsViewModel.deleteScore(score).done(function () {
                self.scores.remove(score);
            });
        };

        self.addScore = function (formElement) {
            score = {
                ScorePoints: Number(self.tempScore.ScorePoints()),
                UserId: Number(self.tempScore.UserId())
            }

            addScoreViewModel.postScore(score).then(function () {
                addScoreViewModel.getLatestScore().done(function (data) {
                    self.scores.unshift(data);
                });
            });
        };

        self.scores.subscribe(function (value) {
            self.leaderboard(leaderBoardViewModel.createLeaderboard(value));
        });
    }

    ko.applyBindings(ViewModel(ResultsViewModel.get(), LeaderBoardViewModel.get(), AddScoreViewModel.get()));
}());