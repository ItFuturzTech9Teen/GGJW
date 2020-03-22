myApp.controller('RequestCouponController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.RequestCouponList = [];
    $scope.ExhibitorList = [];

    $scope.Clearall = function () {
        $scope.Id = 0;
        $scope.ExhibitorName = "";
        $scope.Qty = "";
        $scope.Note = "";
    }
    $scope.Clearall();

    $scope.GetExhibitor = function () {
        var datalist = HomeService.GetExhibitor();
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
    $scope.GetExhibitor();

    $scope.DeleteRequestCoupon = function (Id) {
        var result = confirm('Do you really want to delete?');
        if (result) {
            HomeService.DeleteRequestCoupon(Id, $scope);
        }
    }

    $scope.GetRequestForCoupons = function () {
        var datalist = HomeService.GetRequestForCoupons();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.RequestCouponList = data.Data;
                }
            }
            else {
                alert("Error While Getting !");
            }
        });
    }
    $scope.GetRequestForCoupons();

    $scope.GetRequestCouponList = function (data) {
        $scope.Id = data.Id;
        $scope.ExhibitorId = data.ExhibitorId;
        $scope.Qty = data.Qty;
        $scope.SaveAssignCoupon ();
    }

}]);
