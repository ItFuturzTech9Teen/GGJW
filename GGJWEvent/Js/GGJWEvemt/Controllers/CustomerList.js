myApp.controller('CustomerListController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.expbtn = false;
    $scope.Id = 0;
    $scope.CustomerList = [];
    $scope.CustomerDetailsList = [];
    $scope.isDisabledupdate = true;

    $scope.GetCustomerList = function () {
        $scope.expbtn = true;
        var datalist = HomeService.GetCustomerList();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.CustomerList = data.Data;
                    $scope.expbtn = false;
                }
            }
            else {
                alert("Error While Getting States !");
            }
        });
    }
    $scope.GetCustomerList();

    $scope.exportData = function () {
        var blob = new Blob([document.getElementById('export').innerHTML],{
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        saveAs(blob, "Customerexport.xls");
    }

    $scope.CustomerDetails = function (scope) {
        $('#modal').modal();
        var myjosn = [{ "Designation": scope.Designation, "TelephoneNo": scope.TelephoneNo, "Address": scope.Address, "CityName": scope.CityName, "StateName": scope.StateName, "Country": scope.Country }];
        $scope.CustomerDetailsList = myjosn;
    }

}]);
