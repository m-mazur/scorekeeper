function AddScoreViewModel() {
    var postScoreUri = "/api/Scores/PostScore";
    var getAllUsersUri = "/api/Users/GetUsers";

    var self = this;
    var helper = new Helper();

    self.getAllUsers = function () {
        return helper.ajaxHelper(getAllUsersUri, 'GET');
    }
}
