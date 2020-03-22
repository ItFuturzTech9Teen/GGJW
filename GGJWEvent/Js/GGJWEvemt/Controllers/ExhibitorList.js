myApp.controller('ExhibitorListController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.ExhibitorList = [];
    $scope.ExhibitorDetailsList = [];

    $scope.GetExhibitorList = function () {
        var datalist = HomeService.GetExhibitorList();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.ExhibitorList = data.Data;
                }
            }
            else {
                alert("Error While Getting States !");
            }
        });
    }
    $scope.GetExhibitorList();

    $scope.exportData = function () {
        var blob = new Blob([document.getElementById('export').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        saveAs(blob, "Exhibitorreport.xls");
    }

    $scope.ExhibitorDetails = function (scope) {
        $('#modal').modal();
        var myjosn = [{ "Designation": scope.Designation, "TelephoneNo": scope.TelephoneNo, "Address": scope.Address, "CityName": scope.CityName, "StateName": scope.StateName, "Country": scope.Country }];
        $scope.ExhibitorDetailsList = myjosn;
    }


}]);
