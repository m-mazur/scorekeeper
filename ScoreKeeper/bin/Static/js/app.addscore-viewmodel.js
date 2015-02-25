var AddScoreViewModel = (function (helper) {
    var postScoreUri = "/api/Scores/PostScore";
    var getAllUsersUri = "/api/Users/GetUsers";
    var latestScoreUri = "/api/Scores/GetLatestScore";

    var self = this;

    self.tempScore = {
        ScorePoints: ko.observable("1"),
        UserId: ko.observable()
    };

    self.options = function scoreOptions() {
        var options = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13];
        return options;
    };

    self.getAllUsers = function () {
        return helper.ajaxHelper(getAllUsersUri, 'GET');
    };

    self.addScore = function (score) {
        return helper.ajaxHelper(postScoreUri, 'POST', score);
    };

    self.getLatestScore = function () {
        return helper.ajaxHelper(latestScoreUri, 'GET');
    };

    self.get = function () {
        return self;
    };

    return {
        get: get
    };
}(new Helper()))
