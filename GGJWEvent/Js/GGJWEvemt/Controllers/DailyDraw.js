myApp.controller('DailyDrawController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.DrawCouponList = [];
    $scope.Image=
    $scope.DrawList = [];
    $scope.CouponNod = [];
    $scope.CompleteDraw = 0;
    $scope.Date = new Date();

    $scope.GetDailydraw = function () {
        var datalist = HomeService.GetDailydraw($scope.Date);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.DrawList = data.Data;
                    console.log($scope.DrawList);
                }
            }
            else {
                alert("Error While Getting Drawers !");
            }
        });
    }
    $scope.GetDailydraw();
    $scope.DrawNotice = "";

    $scope.Search = function () {
        $scope.GetDailydraw();

    }

    $scope.GetCouponNo = function (DrawId) {
        var datalist = HomeService.GetCouponNoum(DrawId);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.DrawCouponList = data.Data;
                    $scope.CouponNod = data.Data;
                    console.log($scope.CouponNod);
                    window.location = API_BASE_URL + "/Home/DrawResult?Position=" + data.Data.NumberOfResult + "&CustomerId=" + data.Data.CustomerId + "&CouponNo=" + data.Data.CouponNo + "&DrawId=" + data.Data.DrawId;
                }
            }
            else {
                alert("Error While Getting Drawers !");
            }
        });
    }

    $scope.CheckDrawComplete = function (DrawId) {
        var datalist = HomeService.CheckDrawComplete(DrawId);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.CompleteDraw = data.Data;
                }
            }
            else {
                alert("Error While Getting Drawers !");
            }
        });
    }
    

    $scope.DrawChange = function()
    {
        $scope.DrawNotice = "";
        var data = $scope.Drawselected;
        data = $scope.Drawselected == undefined ? 0 : $scope.Drawselected;
        $scope.CheckDrawComplete(data);
    }

    $scope.Draw = function () {
        $scope.GetCouponNo();
    }

    $scope.DrawNow = function()
    {
        if ($scope.Drawselected == undefined || $scope.Drawselected == 0 || $scope.Drawselected == "")
        { alert("Please Select Draw Name !"); }
        else if ($scope.CompleteDraw == 1) {
            $scope.DrawNotice = "This Draw Is Complete";
        }
        else {
            $scope.DrawNotice = "";
            var data = $scope.Drawselected;
            $scope.Drawselected = 0;
            window.location = API_BASE_URL + "Home/DrawResult?DrawId=" + data;
        }
        
    }


}]);
