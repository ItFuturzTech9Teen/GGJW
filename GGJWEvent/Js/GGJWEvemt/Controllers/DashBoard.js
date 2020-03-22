myApp.controller('DashBoardController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {
    $scope.Id = 0;
    $scope.DataList = [];
    $scope.ExhibitorCount = 0;
    $scope.CustomerCount = 0;
    $scope.DailyDrawCount = 0;
    $scope.DrawCount = 0;
    $scope.ExhibitorPer = "";
    $scope.CustomerPer = "";
    $scope.DailyDrawPer = "";
    $scope.DrawPer = "";

   

    //DashBoard 
    $scope.GetData = function () {
        var dataList = HomeService.GetDashBoard();
        dataList.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.DataList = data.Data;
                    $scope.ExhibitorCount = $scope.DataList[0].ExhibitorCount;
                    $scope.CustomerCount = $scope.DataList[0].CustomerCount;
                    $scope.DailyDrawCount = $scope.DataList[0].DailyDrawCount;
                    $scope.DrawCount = $scope.DataList[0].DrawCount;
                    $scope.ExhibitorPer = $scope.DataList[0].ExhibitorPer;
                    $scope.CustomerPer = $scope.DataList[0].CustomerPer;
                    $scope.DailyDrawPer = $scope.DataList[0].DailyDrawPer;
                    $scope.DrawPer = $scope.DataList[0].DrawPer;
                }
            }
            else {
                alert("Error While Getting Data !");
                
            }
        });
    }
    $scope.GetData();

}]);