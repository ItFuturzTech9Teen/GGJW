myApp.controller('AssignCouponListController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.AssignCouponList = [];
    $scope.ExhibitorList = [];

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

    $scope.GetAssignCouponList = function () {
        var datalist = HomeService.GetAssignCouponList();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.AssignCouponList = data.Data;
                }
            }
            else {
                alert("Error While Getting States !");
            }
        });
    }
    $scope.GetAssignCouponList();




}]);
