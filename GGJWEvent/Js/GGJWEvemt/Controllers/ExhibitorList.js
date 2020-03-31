myApp.controller('ExhibitorListController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.ExhibitorList = [];
    $scope.ExhibitorDetailsList = [];
    $scope.StateList = [];
    $scope.CitiesList = [];
    $scope.SelectedState = 0;
    $scope.Selectedcity = 0;
    $scope.addressList = [];
    $scope.AddressListNew = [];

    $scope.GetExhibitor = function () {
        var datalist = HomeService.GetExhibitor();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.ExhibitorList = data.Data;
                    console.log($scope.ExhibitorList);
                }
            }
            else {
                alert("Error While Getting  !");
            }
        });
    }
    $scope.GetExhibitor();

    $scope.ExhibitorDetails = function (scope) {
        $('#modal').modal();
        var myjosn = [{ "Image":scope.Image,"Email": scope.Email, "Designation": scope.Designation, "TelephoneNo": scope.TelephoneNo, "Address": scope.Address, "CityName": scope.CityName, "StateName": scope.StateName, "Country": scope.Country }];
        $scope.ExhibitorDetailsList = myjosn;

        $scope.AddressListNew = scope.AddressList;
    }
}]);
