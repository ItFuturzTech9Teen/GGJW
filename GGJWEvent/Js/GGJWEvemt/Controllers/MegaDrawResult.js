﻿myApp.controller('MegaDrawResultController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {
    $scope.MegaDrawId = 0;
    $scope.MegaDrawCardList = [];
    $scope.MegaDrawDetails = [];
    $scope.FinalScope = [];
    $scope.CustomerName = "";
    $scope.CustomerImage = "";

    $scope.ExecuteFirst = function () {
        var CurrentUrl = window.location.href;
        var url = new URL(CurrentUrl);
        var c = url.searchParams.get("MegaDrawId");
        $scope.MegaDrawId = parseInt(c);
    };
    $scope.ExecuteFirst();

    $scope.GetWinnerCards = function () {
        var datalist = HomeService.GetMegaDrawCards($scope.MegaDrawId);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    var length = data.Data;
                    console.log(length);
                    $scope.MegaDrawCardList = [];
                    for (var i = 1; i <= length; i++) {
                        $scope.MegaDrawCardList.push({ "Id": i, "NumberOfResult": i, "CouponNo": "0000", "CapImage": "images/user.png", "PersonName": "", "Image": "" });
                    }
                }
            }
            else {
                alert("Error While Getting States !");
            }
        });
    }
    $scope.GetWinnerCards();

    $scope.OpenTheDraw = function (Position) {
        console.log(Position);
        $scope.GetMegaCouponNo($scope.MegaDrawId, Position);
    }

    $scope.GetMegaCouponNo = function (MegaDrawId, Position) {
        var datalist = HomeService.GetMegaCouponNo(MegaDrawId, Position);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    if (data.Data == 0) {
                        alert("No More Draws Avalilable !");
                    }
                    else {
                        $scope.CustomerName = "";
                        $scope.CustomerImage = "";
                        $scope.MegaDrawCardList[Position - 1].CouponNo = data.Data.CouponNo;
                        $scope.MegaDrawCardList[Position - 1].CapImage = "images/cup.png";
                        $scope.CustomerName = data.Data.PersonName;
                        $scope.CustomerImage = API_BASE_URL + data.Data.Image;
                        if ($scope.CustomerImage == "" || $scope.CustomerImage == undefined || $scope.CustomerImage == null || $scope.CustomerImage == API_BASE_URL) {
                            $scope.CustomerImage = API_BASE_URL + "assets/images/user.png";
                        }
                        $('#modal').modal();
                    }
                }
            }
            else {
                alert("Error While Getting Drawers !");
            }
        });
    }

}]);
