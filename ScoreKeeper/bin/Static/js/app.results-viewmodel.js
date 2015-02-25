var ResultsViewModel = (function (helper) {
    var self = this;

    var allScoresUri = "/api/Scores/GetAllScores";
    var deleteScoreUri = "/api/Scores/DeleteScore/";

    self.getAllScores = function () {
        return helper.ajaxHelper(allScoresUri, 'GET');
    };

    self.deleteScore = function (score) {
        return helper.ajaxHelper(deleteScoreUri + score.ScoreId, 'DELETE');
    };

    function get() {
        return self;
    };

    return {
        get: get
    };

}(new Helper()));