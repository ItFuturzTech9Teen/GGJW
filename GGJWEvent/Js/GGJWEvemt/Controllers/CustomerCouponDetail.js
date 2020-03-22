myApp.controller('CustomerCouponDetailController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.expbtn = false;
    $scope.Id = 0;
    $scope.couponId = 0;
    $scope.CustomerCouponDetailList = [];

    $scope.GetCustomerCouponList = function () {
        var datalist = HomeService.GetCustomerCouponList();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.CustomerCouponDetailList = data.Data;
                }
            }
            else {
                alert("Error While Getting!");
            }
        });
    }
    $scope.GetCustomerCouponList();

    $scope.UpdateCouponStatus = function (data) {
        var a = confirm("Do You Want To Delete");
        if (a) {

            var datalist = HomeService.UpdateCouponStatus(data.Id);
            datalist.then(function (pl) {
                var data = pl.data;
                if (data.IsSuccess === true) {
                    if (data.Data !== null && data.Data !== undefined) {
                        alert("Coupon Delete");
                        $scope.GetCustomerCouponList();
                    }
                }
                else {
                    alert("Error While Getting !");
                }
            });
        }
    }

    $scope.exportData = function () {
        var blob = new Blob([document.getElementById('export').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        saveAs(blob, "CustomerCouponexport.xls");
    }

}]);
