zooApp.controller("UserPetsController", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.currentPage = $routeParams.page == undefined ? 1 : $routeParams.page;
        $scope.currentUserId = $routeParams.id;
        $scope.baseLink = '/api/user' + $scope.currentUserId + '/';

        $scope.getUserInfo = function (link) {
            $http.get(link).then(function (response) {
                $scope.id = response.data.Id;
                $scope.name = response.data.Name;
                $scope.petsCount = response.data.PetsCount
                $scope.pets = response.data.Pets;
                $scope.sortReverse = response.data.SortReverse;
                $scope.itemsPerPage = response.data.ItemsPerPage;
            });
        };
        $scope.getUserInfo($scope.baseLink);

        $scope.updatePageIndexes = function () {
            var newLink = $scope.generateLink();
            $scope.getUserInfo(newLink);
        };

        $scope.changeSortType = function () {
            $scope.sortReverse = !$scope.sortReverse;
            var newLink = $scope.generateLink();
            $scope.getUserInfo(newLink);
        };
        $scope.generateLink = function () {
            var newLink = $scope.baseLink + 'page' + $scope.currentPage + '/';
            if ($scope.sortReverse == true) newLink += 'reverse/';
            return newLink;
        };
        $scope.deletePet = function (id, name) {
            if (confirm('Do you want to remove ' + name + ' from database?')) {
                $http.delete('/api/pets/' + id).then(function (data) {
                    var newLink = $scope.generateLink();
                    $scope.getUserInfo(newLink);
                }).catch(function (data) {
                    alert("An error has occured while deleting pet! " + data);
                });
            }
        };
        $scope.addPet = function () {
            var pet = {
                userId : $scope.id,
                name: $scope.newPetName
            };
            $http.post('/api/pets/', pet).then(function (data) {
                var newLink = $scope.generateLink();
                $scope.newPetName = '';
                $scope.getUserInfo(newLink);
            }).catch(function (data) {
                alert($scope.newPetName + " exists");
            });
        };
    }
]);