myApp.controller('AssignCouponController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.CouponNo = 0;
    $scope.AssignCouponList = [];
    $scope.ExhibitorList = [];

    $scope.Clearall = function () {
        $scope.Id = 0;
        $scope.ExhibitorId = 0;
        $scope.Qty = "";
        $scope.Price = "";
        $scope.Total = "";
        $scope.Date = "";
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
                alert("Error While Getting !");
            }
        });
    }
    $scope.GetExhibitor();

    $scope.SaveAssignCoupon = function () {
        HomeService.SaveAssignCouponData($scope);
    }

    $scope.Edit = function (data) {
        $('#modal').modal();
        $scope.Id = data.Id;
        $scope.ExhibitorId = data.ExhibitorId;
        $scope.Qty = data.Qty;
        $scope.Price = "1000";
        $scope.Total = data.Total;
        $scope.Date = data.Date;
        $scope.CouponNo = data.CouponNo;
    }

    $scope.DeleteAssignCoupon = function (Id) {
        var result = confirm('Do you really want to delete?');
        if (result) {
            HomeService.DeleteAssignCoupon(Id, $scope);
        }
    }

    $scope.GetAssignCouponToExhibitor = function () {
        var datalist = HomeService.GetAssignCouponToExhibitor();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.AssignCouponList = data.Data;

                }
            }
            else {
                alert("Error While Getting !");
            }
        });
    }
    $scope.GetAssignCouponToExhibitor();

    $scope.mykeyupfun = function () {
        $scope.Total = $scope.Price * $scope.Qty;
    }

}]);
