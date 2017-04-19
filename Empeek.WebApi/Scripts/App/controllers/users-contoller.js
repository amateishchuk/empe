zooApp.controller("UsersController", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.currentPage = $routeParams.page == undefined ? 1 : $routeParams.page;
        $scope.baseLink = '/api/users/';

        $scope.getUsers = function (link) {
            $http.get(link).then(function (response) {
                $scope.users = response.data.UsersArray;
                $scope.usersCount = response.data.UsersCount;
                $scope.itemsPerPage = response.data.ItemsPerPage;
                $scope.sortReverse = response.data.SortReverse;
            });
        };
        $scope.getUsers($scope.baseLink);

        $scope.updatePageIndexes = function () {
            var newLink = $scope.generateLink();
            $scope.getUsers(newLink);
        };

        $scope.changeSortType = function () {
            $scope.sortReverse = !$scope.sortReverse;
            var newLink = $scope.generateLink();
            $scope.getUsers(newLink);
        };
        $scope.generateLink = function () {
            var newLink = $scope.baseLink + 'page' + $scope.currentPage + '/';
            if ($scope.sortReverse == true) newLink += 'reverse/';
            return newLink;
        };
        $scope.deleteUser = function (id, name) {
            if (confirm('Do you want to remove ' + name + ' from database?')) {
                $http.delete($scope.baseLink + 'delete/' + id).then(function (data) {
                    var newLink = $scope.generateLink();
                    $scope.getUsers(newLink);
                }).catch(function (data) {
                    alert("An error has occured while deleting user! " + data);
                });
            }
        };
        $scope.addUser = function () {
            var user = {
                name: $scope.newUserName,
            };
            $http.post($scope.baseLink, user).then(function (data) {
                var newLink = $scope.generateLink();
                $scope.newUserName = '';
                $scope.getUsers(newLink);
            }).catch(function (data) {
                alert($scope.newUserName + " exists");
            });
        };
    }
]);