var AddScoreViewModel = (function (helper) {
    var self = this;

    var postScoreUri = "/api/Scores/PostScore";
    var getAllUsersUri = "/api/Users/GetUsers";
    var latestScoreUri = "/api/Scores/GetLatestScore";

    self.options = function scoreOptions() {
        var options = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13];
        return options;
    };

    self.getAllUsers = function () {
        return helper.ajaxHelper(getAllUsersUri, 'GET');
    };

    self.postScore = function (score) {
        return helper.ajaxHelper(postScoreUri, 'POST', score);
    };

    self.getLatestScore = function () {
        return helper.ajaxHelper(latestScoreUri, 'GET');
    };

    function get () {
        return self;
    };

    return {
        get: get
    };
}(new Helper()))
