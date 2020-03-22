myApp.controller('MegaDrawsController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.MegaDrawCouponList = [];
    $scope.Image =
    $scope.MegaDrawList = [];
    $scope.CouponNod = [];
    $scope.MegaDrawComplete = 0;

    $scope.GetMegaDraw = function () {
        var datalist = HomeService.GetMegaDraw();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.MegaDrawList = data.Data;
                    console.log($scope.MegaDrawList);
                }
            }
            else {
                alert("Error While Getting Drawers !");
            }
        });
    }
    $scope.GetMegaDraw();
    $scope.DrawNotice = "";

    $scope.Search = function () {
        $scope.GetMegaDraw();

    }

    $scope.GetMegaCouponNo = function (MegaDrawId) {
        var datalist = HomeService.GetMegaCouponNo(MegaDrawId);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.MegaDrawCouponList = data.Data;
                    $scope.CouponNod = data.Data;
                    console.log($scope.CouponNod);
                    window.location = API_BASE_URL + "/Home/MegaDrawResult?Position=" + data.Data.NumberOfResult + "&CustomerId=" + data.Data.CustomerId + "&CouponNo=" + data.Data.CouponNo + "&DrawId=" + data.Data.DrawId;
                }
            }
            else {
                alert("Error While Getting Drawers !");
            }
        });
    }

    $scope.CheckMegaDrawComplete = function (MegaDrawId) {
        var datalist = HomeService.CheckMegaDrawComplete(MegaDrawId);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.MegaDrawComplete = data.Data;
                }
            }
            else {
                alert("Error While Getting Drawers !");
            }
        });
    }


    $scope.DrawChange = function () {
        $scope.DrawNotice = "";
        var data = $scope.Drawselected;
        data = $scope.Drawselected == undefined ? 0 : $scope.Drawselected;
        $scope.CheckMegaDrawComplete(data);
    }

    $scope.Draw = function () {
        $scope.GetCouponNo();
    }

    $scope.DrawNow = function () {
        if ($scope.Drawselected == undefined || $scope.Drawselected == 0 || $scope.Drawselected == "")
        { alert("Please Select Draw Name !"); }
        else if ($scope.MegaDrawComplete == 1) {
            $scope.DrawNotice = "This Draw Is Complete";
        }
        else {
            $scope.DrawNotice = "";
            var data = $scope.Drawselected;
            $scope.Drawselected = 0;
            window.location = API_BASE_URL + "Home/MegaDrawResult?MegaDrawId=" + data;
        }

    }


}]);
