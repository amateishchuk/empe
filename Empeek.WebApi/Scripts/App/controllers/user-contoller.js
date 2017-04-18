zooApp.controller("UserController", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {
        $scope.sortType = 'Name';
        $scope.sortReverse = false;

        $scope.currentPage = 1;
        $scope.itemsPerPage = 3;

        $scope.updatePageIndexes = function () {
            $scope.firstIndex = ($scope.currentPage - 1) * $scope.itemsPerPage;
            $scope.lastIndex = $scope.currentPage * $scope.itemsPerPage;
        };


        $scope.getUsers = function () {
            $http.get('/api/users').then(function (response) {
                $scope.users = response.data;
                $scope.updatePageIndexes();
            });
        };
        $scope.getUsers();
        $scope.deleteUser = function (id, name) {
            if (confirm('Do you want to remove ' + name + ' from database?')) {
                $http.delete('/api/Users/' + id).then(function (data) {
                    $location.path('/users/');
                }).error(function (data) {
                    alert("An error has occured while deleting employee! " + data);
                });
            }
        };
        $scope.addUser = function () {
            var user = {
                name: $scope.newUserName,
            };
            $http.post('/api/Users/', user).then(function (data) {
                $location.path('/users/');
            }).error(function (data) {
                alert($scope.newUserName + " exists");
            });
        };
    }
]);