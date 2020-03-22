myApp.controller('RequestAssignContoller', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.RequestCouponList = [];
    $scope.ExhibitorList = [];
    $scope.RequestAssign = [];

    $scope.GetRequestForCoupons = function () {
        var datalist = HomeService.GetRequestForCoupons();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.RequestCouponList = data.Data;
                    console.log($scope.RequestCouponList);
                }
            }
            else {
                alert("Error While Getting !");
            }
        });
    }
    $scope.GetRequestForCoupons();


    $scope.GetAssignedCoupons = function () {
        var datalist = HomeService.GetAssignedCoupons();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.RequestAssign = data.Data;
                    console.log($scope.RequestAssign);
                }
            }
            else {
                alert("Error While Getting !");
            }
        });
    }
    $scope.GetAssignedCoupons();

    $scope.UpdateRequest = function(data)
    {
        var a = confirm("Do You Want To Approve");
        if(a)
        {
            console.log(data.Id);

            var datalist = HomeService.UpdateRequest(data.Id);
            datalist.then(function (pl) {
                var data = pl.data;
                if (data.IsSuccess === true) {
                    if (data.Data !== null && data.Data !== undefined) {
                        alert("Coupon Assigned");
                        $scope.GetAssignedCoupons();
                        $scope.GetRequestForCoupons();
                    }
                }
                else {
                    alert("Error While Getting !");
                }
            });
        }
    }
    $scope.pendingCoupons = function()
    {
        $scope.GetRequestForCoupons();
    }
    $scope.assignCoupons = function()
    {
        $scope.GetAssignedCoupons();
    }
}]);