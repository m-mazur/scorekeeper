var ResultsViewModel = (function() {
    var allScoresUri = "/api/Scores/GetAllScores"
    var self = this;

    function Score (userName, scorePoints, scoreDate) {
        this.userName = userName;
        this.scorePoints = scorePoints;
        this.scoreDate = scoreDate;
    }

    function get() {
        $.getJSON(allScoresUri).done(function (data) {
            var mappedData = ko.utils.arrayMap(data, function(score) {
                return new Score(score.UserName, score.ScorePoints, score.ScoreDate);
            });
            return mappedData;
        });
    }

    return {
        get: get
    };
}());