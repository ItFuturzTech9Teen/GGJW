myApp.controller('DrawController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.DrawList = [];

    $scope.Clearall = function () {
        $scope.Id = 0;
        $scope.DrawName = "";
        $scope.Date = "";
        $scope.DrawCount = "";
        $scope.Prize = "";
        $scope.Image = "";
    }
    $scope.Clearall();

    $scope.SaveDraw = function () {
        HomeService.SaveDrawData($scope);
    }
    $scope.Edit = function (data) {
        $scope.Id = data.Id;
        $scope.DrawName = data.DrawName;
        $scope.Date = new Date(data.Date);
        $scope.DrawCount = data.DrawCount;
        $scope.Prize = data.Prize;
        $scope.Image = data.Image;
    }
    $scope.DeleteDailyDraw = function (Id) {
        var result = confirm('Do you really want to delete ?');
        if (result) {
            HomeService.DeleteDailyDraw(Id, $scope);
        }
    }
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


}]);
