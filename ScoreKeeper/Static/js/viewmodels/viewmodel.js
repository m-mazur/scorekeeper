var ViewModel = function() {
    var self = this;
    self.hello = ko.observable("hello");
};

ko.applyBindings(ViewModel());