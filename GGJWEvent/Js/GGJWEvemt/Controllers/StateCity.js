myApp.controller('StateController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {



    $scope.Id = 0;
    $scope.StateList = [];
    $scope.CitiesList = [];
    $scope.CityList = [];
    $scope.SelectedState = 0;

    $scope.Clearall = function () {
        $scope.Id = 0;
        $scope.Title = "";
    }
    $scope.Clearall();

    $scope.SaveState = function () {
        HomeService.SaveStateData($scope);
    }
    $scope.Edit = function (data) {
        $scope.Id = data.Id;
        $scope.Title = data.Title;
    }
    $scope.DeleteState = function (Id) {
        var result = confirm('Do you really want to delete state?');
        if (result) {
            HomeService.DeleteState(Id, $scope);
        }
    }
    $scope.GetState = function () {
        var datalist = HomeService.GetState();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.StateList = data.Data;
                }
            }
            else {
                alert("State", "Error While Getting States !");
            }
        });
    }
    $scope.GetState();


    $scope.GetCities = function () {
        var datalist = HomeService.GetCities();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.CitiesList = data.Data;
                }
            }
            else {
                alert("State", "Error While Getting States !");
            }
        });
    }
    $scope.GetCities();

    $scope.Edit = function (data) {
        $scope.Id = data.Id;
        $scope.stateselectbox = data.StateId;
        $scope.Title = data.Title;
    }
    $scope.DeleteCity = function (Id) {
        var a = confirm('Do You Really Want To Delete');
        if (a) {
            HomeService.DeleteCity(Id, $scope);
        }
    }
    $scope.Clearall = function () {
        $scope.Id = 0;
        $scope.stateselectbox = "";
        $scope.Title = "";
    }
    $scope.SaveCity = function () {
        $scope.SelectedState = $scope.stateselectbox;
        HomeService.SaveCityData($scope);
    }

}]);
