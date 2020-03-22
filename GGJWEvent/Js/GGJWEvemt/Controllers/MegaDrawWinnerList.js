myApp.controller('MegaDrawWinnerListController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.drawId = 0;
    $scope.MegaDrawWinnerList = [];
    $scope.DrawList = [];

    $scope.GetMegaDrawWinnerList = function () {
        var datalist = HomeService.GetMegaDrawWinnerList();
            datalist.then(function (pl) {
                var data = pl.data;
                if (data.IsSuccess === true) {
                    if (data.Data !== null && data.Data !== undefined) {
                        $scope.MegaDrawWinnerList = data.Data;
                    }
                }
                else {
                    alert("Error While Getting !");
                }
            });

    }
    $scope.GetMegaDrawWinnerList();

}]);
