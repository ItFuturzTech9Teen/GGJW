myApp.controller('DrawWinnerListController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.drawId = 0;
    $scope.DrawWinnerList = [];
    $scope.DrawList = [];

    $scope.GetDraw = function () {
        var datalist = HomeService.GetDraw();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.DrawList = data.Data;
                }
            }
            else {
                alert("Error While Getting DrawList !");
            }
        });
    }
    $scope.GetDraw();

    $scope.GetDrawWinnerList = function () {
        if ($scope.SendDrawId == "")
        {
            $scope.DrawWinnerList = [];
        }
        else
        {
            var datalist = HomeService.GetDrawWinnerList($scope.SendDrawId);
            datalist.then(function (pl) {
                var data = pl.data;
                if (data.IsSuccess === true) {
                    if (data.Data !== null && data.Data !== undefined) {
                        $scope.DrawWinnerList = data.Data;
                    }
                }
                else {
                    alert("Error While Getting !");
                }
            });
        }
        
    }
    $scope.GetDrawWinnerList();

}]);
