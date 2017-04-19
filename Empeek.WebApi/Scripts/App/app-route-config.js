zooApp.config(function ($routeProvider) {
    $routeProvider
    .when("/users/page:page", {
        templateUrl: "Views/AngularViews/users.html",
        controller: "UsersController"
    })
    .when("/users", {
        templateUrl: "Views/AngularViews/users.html",
        controller: "UsersController"
    })
    .when("/user:id/page:page", {
        templateUrl: "Views/AngularViews/userpets.html",
        controller: "UserPetsController"
    })
    .when("/user:id", {
        templateUrl: "Views/AngularViews/userpets.html",
        controller: "UserPetsController"
    })
    .otherwise(
    {
        redirectTo: "/users"
    });
});

zooApp.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);