myApp.controller('SendNotificationController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.CustomerList = [];
    $scope.DataList = [];
    $scope.Type = "";
    $scope.IsAllChecked = false;

    $scope.GetDataList = function () {
        var datalist = HomeService.GetDataList($scope.Type);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.DataList = data.Data;
                }
            }
            else {
                alert("Error While Getting States !");
            }
        });
    }
    $scope.GetDataList();
    $scope.SendNotification = function()
    {
        var message = "";
        var datanotification = [];
        for (var i = 0; i < $scope.DataList.length; i++) {
            if ($scope.DataList[i].selected) {
                $scope.Id = $scope.DataList[i].Id;
                $scope.PersonName = $scope.DataList[i].Name;

                var Id = $scope.Id;
                var x = $scope.Title;
                var b = $scope.Message;
                message += "" + $scope.Type + " " + Id + ", " + x + ", " + b + "\n";
                datanotification.push({ "type": $scope.Type, "Id": Id, "title": x, "message": b });
              
            }
        }
        HomeService.SendNotification(datanotification);
        $scope.Type = "";
        $scope.Title = "";
        $scope.Message = "";
        //console.log(datanotification)
    }

    $scope.toggleSelect = function () {
        angular.forEach($scope.DataList, function (item) {
            item.selected = event.target.checked;
            $scope.DataList.push();
        });
    }

}]);
