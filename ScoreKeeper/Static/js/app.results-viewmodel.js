function ResultsViewModel() {
    var allScoresUri = "/api/Scores/GetAllScores";
    var deleteScoreUri = "/api/Scores/DeleteScore/";

    var self = this;
    var helper = new Helper();

    self.getAllScores = function () {
        return helper.ajaxHelper(allScoresUri, 'GET');
    }

    self.deleteScore = function (score) {
        return helper.ajaxHelper(deleteScoreUri + score.ScoreId, 'DELETE');
    }
}