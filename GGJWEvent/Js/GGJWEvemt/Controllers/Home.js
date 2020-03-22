myApp.controller('HomeController', ['$scope', 'AccountService', 'storage', '$http', 'ipCookie', function ($scope, AccountService, storage, $http, ipCookie) {
    var d = new Date();
    var n = d.getTime();  //n in ms
    $scope.APIBASEURL = API_BASE_URL;
    $scope.LoginUser = storage.get(Login_User);
    $scope.LoginId = 0;
    $scope.IsAdmin = false;

    var s = "/Account/GetLoginSession";
    var promiseGet = $http.get(s);
    promiseGet.then(function (pl) {
        if (pl.data.Data === null) {
            storage.remove(Login_User);
            $http({
                url: '/Account/DestoryLoginSession',
                method: "POST",
                data: {},
                headers: { 'Content-Type': 'application/json' }
            }).then(function (data, status, headers, config) {
                window.location.href = '/';
            })
        }
        else {
            $scope.LoginUser = storage.get(Login_User);
            if ($scope.LoginUser != null && $scope.LoginUser != undefined) {
                $scope.LoginId = $scope.LoginUser.Id;
            }
        }
    });

    $scope.logOutUser = function () {
        ipCookie.remove('LoginUser', { path: '/' });
        storage.remove(Login_User);
        AccountService.AutoLogOut();
    }
}]);