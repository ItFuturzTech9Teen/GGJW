myApp.controller('ExhibitorOfferController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.ExhibitorOfferList = [];

    $scope.DeleteExhibitorOffer = function (Id) {
        var result = confirm('Do you really want to delete state?');
        if (result) {
            HomeService.DeleteExhibitorOffer(Id, $scope);
        }
    }
    $scope.GetExhibitorBanner = function () {
        var datalist = HomeService.GetExhibitorBanner();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.ExhibitorOfferList = data.Data;
                }
            }
            else {
                alert("Error !");
            }
        });
    }
    $scope.GetExhibitorBanner();

}]);
