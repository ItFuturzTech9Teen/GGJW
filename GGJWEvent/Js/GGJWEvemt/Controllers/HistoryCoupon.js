myApp.controller('HistoryCouponController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.HistoryCouponList = [];

    $scope.GetCouponToExhibitor = function () {
        var datalist = HomeService.GetCouponToExhibitor();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.HistoryCouponList = data.Data;
                }
            }
            else {
                alert("Error !");
            }
        });
    }
    $scope.GetCouponToExhibitor();


    $scope.exportData = function () {
        var blob = new Blob([document.getElementById('export').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        saveAs(blob, "HistoryCoupon.xls");
    }

}]);
