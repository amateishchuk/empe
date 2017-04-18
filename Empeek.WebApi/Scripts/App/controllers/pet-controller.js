zooApp.controller("PetController", ["$scope", "$http", '$routeParams', '$location', '$window',
    function ($scope, $http, $routeParams, $location, $window) {
        $scope.sortType = 'Name';
        $scope.sortReverse = false;

        $scope.currentPage = 1;
        $scope.itemsPerPage = 3;

        $scope.updatePageIndexes = function () {
            $scope.firstIndex = ($scope.currentPage - 1) * $scope.itemsPerPage;
            $scope.lastIndex = $scope.currentPage * $scope.itemsPerPage;
        };

        $scope.getUserPets = function () {
            $http.get('/api/Pets/' + $routeParams.id).then(function (response) {
                $scope.userName = response.data.Name;
                $scope.userPets = response.data.Pets;
                $scope.userId = response.data.Id;
                $scope.updatePageIndexes();
            });
        }
        $scope.getUserPets();
        $scope.deletePet = function (id, name) {
            if (confirm('Do you want to remove ' + name + ' from database?')) {
                $http.delete('/api/Pets/' + id).then(function (response) {
                    $location.path('/pets/' + $scope.userId + '/');
                }).error(function (response) {
                    alert("An error has occured while deleting employee! " + response.data);
                });
            }
        };
        $scope.addPet = function () {
            var pet = {
                Name: $scope.newPetName,
                UserId: $scope.userId
            };
            $http.post('/api/Pets/', pet).then(function (response) {
                $location.path('/pets/' + $scope.userId + '/');
            }).error(function (response) {
                alert("You have pet with such name. (" + pet.name + ")");
            });

        }

    }
]);