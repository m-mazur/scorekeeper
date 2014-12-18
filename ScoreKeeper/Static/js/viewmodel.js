(function () {
    var uri = "/api/Scores/";

    var viewModel = {
        scores: ko.observableArray()
    };

    $.getJSON(uri)
    .done(function (data) {
        viewModel.scores(data);
    });

    ko.applyBindings(viewModel);
})();