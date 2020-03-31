myApp.controller('ExhibitorController', ['$scope', 'HomeService', 'storage', '$http', 'ipCookie', function ($scope, HomeService, storage, $http, ipCookie) {

    $scope.Id = 0;
    $scope.ExhibitorList = [];
    $scope.ExhibitorDetailsList = [];
    $scope.StateList = [];
    $scope.CitiesList = [];
    $scope.SelectedState = 0;
    $scope.Selectedcity = 0;
    $scope.addressList = [];
    $scope.AddressListNew = [];

    $scope.Clearall = function () {
        $scope.Id = 0;
        $scope.PersonName = "";
        $scope.MobileNo = "";
        $scope.TelephoneNo = "";
        $scope.Designation = "";
        $scope.CompanyName = "";
        $scope.Address = "";
        $scope.Address1 = "";
        $scope.Address2 = "";
        $scope.stateselectbox = "";
        $scope.cityselectbox = "";
        $scope.Country = "";
        $scope.GoolgeLocation = "";
        $scope.LatLong = "";
        $scope.LatLong2 = "";
        $scope.LatLong3 = "";
        $scope.Email = "";
    }
    $scope.Clearall();

    $scope.SaveExhibitor = function () {
        $scope.SelectedState = $scope.stateselectbox;
        $scope.Selectedcity = $scope.cityselectbox;
        HomeService.SaveExhibitorData($scope);
    }
    $scope.Edit = function (data) {
        $scope.Id = data.Id;
        $scope.PersonName = data.PersonName;
        $scope.MobileNo = data.MobileNo;
        $scope.TelephoneNo = data.TelephoneNo;
        $scope.Designation = data.Designation;
        $scope.CompanyName = data.CompanyName;
        $scope.Email = data.Email;
        $scope.addressList = data.AddressList;
        $scope.Country = data.Country;
        $scope.Image = data.Image;
    }
    $scope.DeleteExhibitor = function (Id) {
        var result = confirm('Do you really want to delete?');
        if (result) {
            HomeService.DeleteExhibitor(Id, $scope);
        }
    }
    $scope.GetExhibitor = function () {
        var datalist = HomeService.GetExhibitor();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.ExhibitorList = data.Data;
                    console.log($scope.ExhibitorList);
                }
            }
            else {
                alert("Error While Getting  !");
            }
        });
    }
    $scope.GetExhibitor();

    $scope.GetCities = function () {
        var datalist = HomeService.GetCity($scope.stateselectbox);
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.CitiesList = data.Data;
                }
            }
            else {
                alert("Error While Getting !");
            }
        });
    }
    $scope.GetCities();

    $scope.GetState = function () {
        var datalist = HomeService.GetState();
        datalist.then(function (pl) {
            var data = pl.data;
            if (data.IsSuccess === true) {
                if (data.Data !== null && data.Data !== undefined) {
                    $scope.StateList = data.Data;
                }
            }
            else {
                alert("State", "Error While Getting States !");
            }
        });
    }
    $scope.GetState();

    $scope.ExhibitorDetails = function (scope) {
        $('#modal').modal();
        var myjosn = [{ "Email":scope.Email,"Designation": scope.Designation, "TelephoneNo": scope.TelephoneNo, "Address": scope.Address, "CityName": scope.CityName, "StateName": scope.StateName, "Country": scope.Country }];
        $scope.ExhibitorDetailsList = myjosn;

        $scope.AddressListNew = scope.AddressList;
    }

    $scope.AddAddress = function () {
        if($scope.addressmodel != "" || $scope.latlongmodel!="" || $scope.stateselectbox!="" || $scope.cityselectbox!="")
        {
            for (var i = 0; i < $scope.StateList.length; i++)
            {
                if($scope.stateselectbox == $scope.StateList[i].Id)
                {
                    for (var j = 0; j < $scope.CitiesList.length; j++)
                    {
                        if($scope.CitiesList[j].Id == $scope.cityselectbox)
                        {
                            $scope.addressList.push({ "Id": 0, "Address": $scope.addressmodel, "Latlong": $scope.latlongmodel, "StateName": $scope.StateList[i].Title, "StateId": $scope.stateselectbox, "CityName": $scope.CitiesList[j].Title, "CityId": $scope.cityselectbox,"ExhibitorId":0 });
                            $scope.addressmodel = "";
                            $scope.latlongmodel = "";
                            $scope.stateselectbox = "";
                            $scope.cityselectbox = "";
                        }
                    }
                }
            }
        }
    }

    $scope.deleteAddressRow = function (i) {
        $scope.addressList.splice(i, 1);
    }
}]);
