zooApp.config(function ($routeProvider) {
    $routeProvider
    .when("/users", {
        templateUrl: "Views/AngularViews/users.html",
        controller: "UserController"
    })
    .when("/pets/:id", {
        templateUrl: "Views/AngularViews/pets.html",
        controller: "PetController"
    })
    .otherwise(
    {
        redirectTo: "/users"
    });
});

zooApp.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);