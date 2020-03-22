myApp.controller('ApplyCouponListController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.ApplyCouponList = [];
    $scope.CouponList = [];
    $scope.CouponDetailsList = [];
    $scope.RequestedList = [];
    $scope.FulList = [];
    $scope.GetApplyCouponList = function () {
        var datalist = HomeService.GetApplyCouponList();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.ApplyCouponList = data.Data;
                }
            }
            else {
                alert("Error While Getting!");
            }
        });
    }
    $scope.GetApplyCouponList();
    $scope.GetCouponsListV1 = function () {
        var datalist = HomeService.GetCouponsListV1($scope.Id);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.FulList = [];
                    $scope.CouponList = data.Data[0].cup_assignlist;
                    $scope.RequestedList = data.Data[0].coup_list;
                    
                    if ($scope.CouponList.length > 0)
                    {
                        $scope.FulList = [];
                            for (var i = 0; i < $scope.CouponList.length; i++) {
                                $scope.FulList.push({ "Id": $scope.CouponList[i].Id, "AssginBy": $scope.CouponList[i].AssginBy, "ExhibitorId": $scope.CouponList[i].ExhibitorId, "Price": $scope.CouponList[i].Price, "Qty": $scope.CouponList[i].Qty, "Total": $scope.CouponList[i].Total, "Date": $scope.CouponList[i].Date, "PersonName": $scope.CouponList[i].PersonName, });
                            }
                        for (var i = 0; i < $scope.RequestedList.length; i++) {
                            $scope.FulList.push({ "Id": $scope.RequestedList[i].Id, "AssginBy": $scope.RequestedList[i].AssginBy, "ExhibitorId": $scope.RequestedList[i].ExhibitorId, "Price": $scope.RequestedList[i].Price, "Qty": $scope.RequestedList[i].Qty, "Total": $scope.RequestedList[i].Total, "Date": $scope.RequestedList[i].Date, "PersonName": $scope.RequestedList[i].PersonName, });
                        }
                        console.log($scope.FulList);
                    }
                    else
                    {
                        $scope.FulList = [];
                    }
                    

                }

            }
            else {
                alert("Error While Getting!");
            }
        });
    }
    $scope.GetCouponsListV1();

    $scope.GetCoupon = function (data) {
        $scope.Id = data;
        $scope.GetCouponsListV1();

    }

    $scope.exportData = function () {
        var blob = new Blob([document.getElementById('export').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        saveAs(blob, "AssignCouponList.xls");
    }

    $scope.CouponDetails = function (scope) {
        $('#collapse-3').collapse();
        var myjosn = [{ "Id": scope.Id, "ExhibitorId": scope.ExhibitorId, "PersonName": scope.PersonName, "Qty": scope.Qty, "CouponNo": scope.CouponNo, "Date": scope.Date }];
        $scope.CouponDetailsList = myjosn;
    }


}]);
