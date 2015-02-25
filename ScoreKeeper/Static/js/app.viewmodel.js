(function () {
    var ViewModel = function (resultsViewModel, leaderBoardViewModel, addScoreViewModel) {
        var self = this;

        self.scores = ko.observableArray();
        self.users = ko.observableArray();
        self.leaderboard = ko.observableArray();
        self.scoresOptions = ko.observableArray(addScoreViewModel.options());
        self.tempScore = {
            ScorePoints: ko.observable("1"),
            UserId: ko.observable()
        };


        resultsViewModel.getAllScores().done(function (data) {
            self.scores(data);
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
            var score = {
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

    ko.applyBindings(ViewModel(new ResultsViewModel.get(), new LeaderBoardViewModel.get(), new AddScoreViewModel.get()));
}());