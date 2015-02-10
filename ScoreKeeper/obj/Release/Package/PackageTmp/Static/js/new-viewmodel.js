(function() {
    function ViewModel(resultsViewModel) {
        var self = this;

        resultsViewModel.then(function (data) {
            
        });

        self.scores = ko.observableArray(resultsViewModel);

    }
    ko.applyBindings(ViewModel(ResultsViewModel.get()));
}());