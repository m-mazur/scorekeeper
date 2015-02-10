(function() {
    function ViewModel(resultsViewModel) {
        var self = this;

        self.scores = ko.observableArray(resultsViewModel.get());

    }
    ko.applyBindings(ViewModel(ResultsViewModel));
}());