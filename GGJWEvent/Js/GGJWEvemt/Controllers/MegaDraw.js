myApp.controller('MegaDrawController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.MegaDrawList = [];

    $scope.Clearall = function () {
        $scope.Id = 0;
        $scope.DrawName = "";
        $scope.Date = "";
        $scope.DrawCount = "";
        $scope.Prize = "";
        $scope.Image = "";
    }
    $scope.Clearall();

    $scope.SaveMegaDraw = function () {
        HomeService.SaveMegaDrawData($scope);
    }
    $scope.Edit = function (data) {
        $scope.Id = data.Id;
        $scope.DrawName = data.DrawName;
        $scope.Date = new Date(data.Date);
        $scope.DrawCount = data.DrawCount;
        $scope.Prize = data.Prize;
        $scope.Image = data.Image;
    }
    $scope.DeleteMegaDraw = function (Id) {
        var result = confirm('Do you really want to delete ?');
        if (result) {
            HomeService.DeleteMegaDraw(Id, $scope);
        }
    }
    $scope.GetMegaDraw = function () {
        var datalist = HomeService.GetMegaDraw();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.MegaDrawList = data.Data;
                }
            }
            else {
                alert("Error While Getting DrawList !");
            }
        });
    }
    $scope.GetMegaDraw();


}]);
