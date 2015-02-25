var ResultsViewModel = (function (helper) {
    var allScoresUri = "/api/Scores/GetAllScores";
    var deleteScoreUri = "/api/Scores/DeleteScore/";

    var self = this;

    self.getAllScores = function () {
        return helper.ajaxHelper(allScoresUri, 'GET');
    };

    self.deleteScore = function (score) {
        return helper.ajaxHelper(deleteScoreUri + score.ScoreId, 'DELETE');
    };

    self.get = function () {
        return self;
    }

    return {
        get: get
    };

}(new Helper()));