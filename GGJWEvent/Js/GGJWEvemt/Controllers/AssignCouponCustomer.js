myApp.controller('AssignCustomerCouponController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.AssignCouponCustomerList = [];

    $scope.GetAssignCouponCustomer = function () {
        var datalist = HomeService.GetAssignCouponCustomer();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.AssignCouponCustomerList = data.Data;
                }
            }
            else {
                alert("Error !");
            }
        });
    }
    $scope.GetAssignCouponCustomer();

}]);
