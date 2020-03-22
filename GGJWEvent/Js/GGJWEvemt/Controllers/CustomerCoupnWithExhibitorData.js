myApp.controller('CustomerCoupnWithExhibitorDataController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {


    $scope.Id = 0;
    $scope.CouponNo = 0;
    $scope.AssignCouponList = [];
    $scope.CustomerList = [];
    $scope.ExhibitorList = [];

    $scope.GetCustomerList = function () {
        var datalist = HomeService.GetCustomerCouponWithExhibitorDetail();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.CustomerList = data.Data;
                }
            }
            else {
                alert("Error While Getting !");
            }
        });
    }
    $scope.GetCustomerList();

    $scope.GetExhibitorList = function (data) {
        var datalist = HomeService.GetExhibitorListDetail(data);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.ExhibitorList = data.Data;
                }
            }
            else {
                alert("Error While Getting !");
            }
        });
    }
    $scope.GetExhibitorList();

   
}]);
