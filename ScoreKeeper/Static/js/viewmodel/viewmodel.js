(function() {
    function ViewModel(scoreService) {
        var self = this;
        self.hello = ko.observable("hello");

        self.scores = ko.observableArray(scoreService.getAllScores());
        console.log(self.scores());
    };
    ko.applyBindings(ViewModel(ScoresService.get()));
}());