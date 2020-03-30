myApp.service('HomeService', ['$http', 'storage', 'ipCookie', function ($http, storage, ipCookie) {
    var _selfService = this;
    this.FormatDateTime = function (date) {
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'pm' : 'am';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'         
        minutes = minutes < 10 ? '0' + minutes : minutes; var strTime = hours + ':' + minutes + ' ' + ampm;
        return date.getMonth() + 1 + "/" + date.getDate() + "/" + date.getFullYear() + "  " + strTime;
    }

    this.convertdateformat =function(date)
    {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

       if (month.length < 2) month = '0' + month;
       if (day.length < 2) day = '0' + day;

       return [year, month, day].join('-');
        
    }

    //State
    this.GetState = function ()
    {
        return $http.get(API_URL + '/HomeAPI/GetState');
    }

    this.DeleteState = function (Id, scope) {
        var deletestate = $http.get(API_URL + '/HomeAPI/DeleteState?Id=' + Id);
        deletestate.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetState();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    this.SaveStateData = function (scope) {
        var jsonData = { "Id": scope.Id, "Title": scope.Title };
        $http({
            url: API_URL + '/HomeAPI/SaveState',
            method: 'post',
            data: jsonData,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                if (data.Data != null && data.Data != undefined) {
                    alert("State", "Data Saved Successfully !");
                    scope.GetState();
                    scope.Clearall();
                } else {
                    alert("State Data Not Saved !");
                }
            } else {
                alert("State Error Occured !");
            }
        });
    }

    //City
    this.SaveCityData = function (scope) {
        var jsonData = { "Id": scope.Id, "StateId": scope.SelectedState, "Title": scope.Title };
        $http({
            url: API_URL + '/HomeAPI/SaveCity',
            method: 'post',
            data: jsonData,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                if (data.Data != null && data.Data != undefined) {
                    alert("Data Saved Successfully !");
                    scope.GetCity();
                    scope.Clearall();
                } else {
                    alert("Data Not Saved !");
                }
            } else {
                alert( "Error Occured !");
            }
        });
    }

    this.GetCities = function () {
        return $http.get(API_URL + '/HomeAPI/GetCities');
    }

    this.GetCity = function (stateId) {
        return $http.get(API_URL + '/HomeAPI/GetCity?stateId=' + stateId);
    }

    this.DeleteCity = function (Id, scope) {
        var DeleteCity = $http.get(API_URL + '/HomeAPI/DeleteCity?Id=' + Id);
        DeleteCity.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetCity();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    this.CustomerDelete = function (Id, scope) {
        var DeleteCity = $http.get(API_URL + '/HomeAPI/DeleteCustomer?Id=' + Id);
        DeleteCity.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetCustomerList();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    //Exhibitor
    this.GetExhibitor = function () {
        return $http.get(API_URL + '/HomeAPI/GetExhibitor');
    }

    this.DeleteExhibitor = function (Id, scope) {
        var DeleteExhibitor = $http.get(API_URL + '/HomeAPI/DeleteExhibitor?Id=' + Id);
        DeleteExhibitor.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetExhibitor();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    this.SaveExhibitorData = function (scope) {
        var ProdImgData = new FormData();
        ProdImgData.append('Image', scope.myFile);
        ProdImgData.append('Id', scope.Id);
        ProdImgData.append('PersonName', scope.PersonName);
        ProdImgData.append('Designation', scope.Designation);
        ProdImgData.append('CompanyName', scope.CompanyName);
        ProdImgData.append('Address', scope.Address);
        ProdImgData.append('Address1', scope.Address1);
        ProdImgData.append('Address2', scope.Address2);
        ProdImgData.append('Country', scope.Country);
        ProdImgData.append('TelephoneNo', scope.TelephoneNo);
        ProdImgData.append('Email', scope.Email);
        ProdImgData.append('StateId', scope.SelectedState);
        ProdImgData.append('CityId', scope.Selectedcity);
        ProdImgData.append('GoogleLocation', scope.GoogleLocation);
        ProdImgData.append('LatLong', scope.LatLong);
        ProdImgData.append('LatLong2', scope.LatLong2);
        ProdImgData.append('LatLong3', scope.LatLong3);
        ProdImgData.append('MobileNo', scope.MobileNo);

        var xhr = new XMLHttpRequest;
        xhr.open('POST', API_URL + '/HomeAPI/SaveExhibitor', true);
        xhr.onload = function handler() {
            if (this.status === 200) {
                var data = JSON.parse(this.responseText);
                if (data.IsSuccess === true) {
                    if (data.Data !== null && data.Data !== undefined) {
                        if (data.Data == 0) {
                            alert("MobileNo Already Exists !");
                            scope.GetUser();
                            scope.Clear();
                        }
                        else {
                            alert("Data Saved Successfully !");
                            scope.GetExhibitor();
                            scope.Clearall();
                        }
                    }
                    else {
                        alert("Data Not Saved !");
                    }
                }
                else {
                    alert(" Error Occured !");
                }
            } else {
                alert(" Error Occured !");
            }
        }
        xhr.send(ProdImgData);
    }

    //ExhibitorOffer
    this.GetExhibitorBanner = function () {
        return $http.get(API_URL + '/HomeAPI/GetExhibitorBanner');
    }

    this.DeleteExhibitorOffer = function (Id, scope) {
        var DeleteExhibitorOffer = $http.get(API_URL + '/HomeAPI/DeleteExhibitorOffer?Id=' + Id);
        DeleteExhibitorOffer.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetExhibitorOffer();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    //RequestCoupon
    this.GetRequestForCoupons = function () {
        return $http.get(API_URL + '/HomeAPI/GetRequestForCoupons');
    }
    
    this.UpdateRequest = function (Id) {
        return $http.get(API_URL + '/HomeAPI/UpdateRequest?Id='+Id);
    }

    this.GetAssignedCoupons = function () {
        return $http.get(API_URL + '/HomeAPI/GetAssignedCoupons');
    }

    this.DeleteRequestCoupon = function (Id, scope) {
        var DeleteRequestCoupon = $http.get(API_URL + '/HomeAPI/DeleteRequestCoupon?Id=' + Id);
        DeleteRequestCoupon.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetRequestForCoupons();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    this.SaveRequestCouponData = function (scope) {
        var jsonData = { "Id": scope.Id, "ExhibitorId": scope.ExhibitorId, "Qty": scope.Qty, "Note": scope.Note };
        $http({
            url: API_URL + '/HomeAPI/SaveRequestCoupon',
            method: 'post',
            data: jsonData,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                if (data.Data != null && data.Data != undefined) {
                    alert("Data Saved Successfully !");
                    scope.GetRequestForCoupons();
                    scope.Clearall();
                } else {
                    alert("Data Not Saved !");
                }
            } else {
                alert(" Error Occured !");
            }
        });
    }

    //HistoryCoupon
    this.GetCouponToExhibitor = function () {
        return $http.get(API_URL + '/HomeAPI/GetCouponToExhibitor');
    }

    //AssignCoupon
    this.SaveAssignCouponData = function (scope) {
        var jsonData = { "Id": scope.Id, "CouponNo": scope.CouponNo, "ExhibitorId": scope.ExhibitorId, "Qty": scope.Qty, "Price": scope.Price, "Total": scope.Total, "Date": scope.Date };
        $http({
            url: API_URL + '/HomeAPI/SaveAssignCoupon',
            method: 'post',
            data: jsonData,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                if (data.Data != null && data.Data != undefined) {
                    alert("Data Saved Successfully !");
                    scope.GetAssignCouponToExhibitor();
                    scope.Clearall();
                } else {
                    alert("Data Not Saved !");
                }
            } else {
                alert(" Error Occured !");
            }
        });
    }

    this.GetAssignCouponToExhibitor = function () {
        return $http.get(API_URL + '/HomeAPI/GetAssignCouponToExhibitor');
    }

    this.DeleteAssignCoupon = function (Id, scope) {
        var DeleteAssignCoupon = $http.get(API_URL + '/HomeAPI/DeleteAssignCoupon?Id=' + Id);
        DeleteAssignCoupon.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetAssignCouponToExhibitor();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    //ExhibitorList
    this.GetExhibitorList = function () {
        return $http.get(API_URL + '/HomeAPI/GetExhibitorList');
    }

    //CustomerList
    this.GetCustomerList = function () {
        return $http.get(API_URL + '/HomeAPI/GetCustomerList');
    }

    //AssignCouponList
    this.GetAssignCouponList = function () {
        return $http.get(API_URL + '/HomeAPI/GetAssignCouponList');
    }

    //DailyDraw
    this.SaveDrawData = function (scope) {
        var ProdImgData = new FormData();
        ProdImgData.append('Image', scope.myFile);
        ProdImgData.append('Id', scope.Id);
        ProdImgData.append('DrawName', scope.DrawName);
        ProdImgData.append('DrawCount', scope.DrawCount);
        ProdImgData.append('Date', _selfService.FormatDateTime(scope.Date));
        ProdImgData.append('Prize', scope.Prize);

        var xhr = new XMLHttpRequest;
        xhr.open('POST', API_URL + '/HomeAPI/SaveDraw', true);
        xhr.onload = function handler() {
            if (this.status === 200) {
                var data = JSON.parse(this.responseText);
                if (data.IsSuccess === true) {
                    if (data.Data !== null && data.Data !== undefined) {
                        alert("Data Saved Successfully !");
                        scope.GetDraw();
                        scope.Clearall();
                    }
                    else {
                        alert("Data Not Saved !");
                    }
                }
                else {
                    alert(" Error Occured !");
                }
            } else {
                alert(" Error Occured !");
            }
        }
        xhr.send(ProdImgData);
    }

    this.GetDraw = function () {
        return $http.get(API_URL + '/HomeAPI/GetDraw');
    }

    this.DeleteDailyDraw = function (Id, scope) {
        var DeleteDailyDraw = $http.get(API_URL + '/HomeAPI/DeleteDailyDraw?Id=' + Id);
        DeleteDailyDraw.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetDraw();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    //AssignCouponCustomer
    this.GetAssignCouponCustomer = function () {
        return $http.get(API_URL + '/HomeAPI/GetAssignCouponCustomer');
    }

    this.GetDataList = function (type) {
        return $http.get(API_URL + '/HomeAPI/GetDataList?type=' + type);
    }

    //Draw
    this.GetDailydraw = function (Date) {
        return $http.get(API_URL + '/HomeAPI/GetDailydraw?date=' + _selfService.convertdateformat(Date));
    }

    this.GetCouponNoum = function (DrawId, Position) {
        return $http.get(API_URL + '/HomeAPI/GetCouponNo?DrawId=' + DrawId + '&Position=' + Position);
    }

    this.GetDrawCards = function (DrawId)
    {
        return $http.get(API_URL + '/HomeAPI/GetDrawCards?DrawId=' + DrawId);
    }

    this.GetWinnerCouponNo = function (DrawId)
    {
        return $http.get(API_URL + '/HomeAPI/GetWinnerCouponNo?DrawId=' + DrawId);
    }

    this.CheckDrawComplete = function (DrawId) {
        return $http.get(API_URL + '/HomeAPI/CheckDrawComplete?DrawId=' + DrawId);
    }

    this.GetDrawWinnerList = function (drawId) {
        return $http.get(API_URL + '/HomeAPI/GetDrawWinnerList?drawId=' + drawId);
    }

    //Dashboard
    this.GetDashBoard = function () {
        return $http.get(API_URL + '/HomeAPI/GetDashboardCountList');
    }

    //this.SendNotification = function (type,id,tile,message) {
    //    return $http.get(API_URL + '/HomeAPI/GetFcmToken?type=' + type + '&id=' + id + '&title=' + tile + '&messag=' + message);
    //}

    //DailyDraw
    this.SaveMegaDrawData = function (scope) {
        var ProdImgData = new FormData();
        ProdImgData.append('Image', scope.myFile);
        ProdImgData.append('Id', scope.Id);
        ProdImgData.append('DrawName', scope.DrawName);
        ProdImgData.append('DrawCount', scope.DrawCount);
        ProdImgData.append('Date', _selfService.convertdateformat(scope.Date));
        ProdImgData.append('Prize', scope.Prize);

        var xhr = new XMLHttpRequest;
        xhr.open('POST', API_URL + '/HomeAPI/SaveMegaDraw', true);
        xhr.onload = function handler() {
            if (this.status === 200) {
                var data = JSON.parse(this.responseText);
                if (data.IsSuccess === true) {
                    if (data.Data !== null && data.Data !== undefined) {
                        alert("Data Saved Successfully !");
                        scope.GetMegaDraw();
                        scope.Clearall();
                    }
                    else {
                        alert("Data Not Saved !");
                    }
                }
                else {
                    alert(" Error Occured !");
                }
            } else {
                alert(" Error Occured !");
            }
        }
        xhr.send(ProdImgData);
    }

    this.GetMegaDraw = function () {
        return $http.get(API_URL + '/HomeAPI/GetMegaDraw');
    }

    this.DeleteMegaDraw = function (Id, scope) {
        var DeleteDailyDraw = $http.get(API_URL + '/HomeAPI/DeleteMegaDraw?Id=' + Id);
        DeleteDailyDraw.then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                alert("Deleted Successfully !");
                scope.GetMegaDraw();
            } else {
                alert("Data Not Deleted !");
            }
        });
    }

    //MegaDraw
    this.GetMegaCouponNo = function (MegaDrawId, Position) {
        return $http.get(API_URL + '/HomeAPI/GetMegaCouponNo?MegaDrawId=' + MegaDrawId + '&Position=' + Position);
    }

    this.GetMegaDrawCards = function (MegaDrawId) {
        return $http.get(API_URL + '/HomeAPI/GetMegaDrawCards?MegaDrawId=' + MegaDrawId);
    }

    this.GetWinnerMegaCouponNo = function (MegaDrawId) {
        return $http.get(API_URL + '/HomeAPI/GetWinnerMegaCouponNo?MegaDrawId=' + MegaDrawId);
    }

    this.CheckMegaDrawComplete = function (MegaDrawId) {
        return $http.get(API_URL + '/HomeAPI/CheckMegaDrawComplete?MegaDrawId=' + MegaDrawId);
    }

    this.GetMegaDrawWinnerList = function () {
        return $http.get(API_URL + '/HomeAPI/GetMegaDrawWinnerList');
    }

    this.SendNotification = function (scope) {
        var jsonData = scope;
        
        $http({
            url: API_URL + '/HomeAPI/GetFcmToken',
            method: 'post',
            data: jsonData,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (data) {
            var data = data.data;
            if (data.IsSuccess === true) {
                if (data.Data != null && data.Data != undefined) {
                    alert("Data Saved Successfully !");
                } else {
                    alert("Data Not Saved !");
                }
            } else {
                alert(" Error Occured !");
            }
        });
    }

    this.GetApplyCouponList = function () {
        return $http.get(API_URL + '/HomeAPI/GetApplyCouponList');
    }
    this.GetCouponsListV1 = function (Id) {
        return $http.get(API_URL + '/HomeAPI/GetCouponsListV1?Id=' + Id);
    }

    this.GetCustomerCouponList = function () {
        return $http.get(API_URL + '/HomeAPI/GetCustomerCouponList');
    }

    this.UpdateCouponStatus = function (Id) {
        return $http.get(API_URL + '/HomeAPI/UpdateCouponStatus?Id=' + Id);
    }

    // CustomerCouponHistory

    this.GetCustomerCouponWithExhibitorDetail = function () {
        return $http.get(API_URL + '/HomeAPI/GetCustomerCouponWithExhibitorDetail');
    }

    this.GetExhibitorListDetail = function (id) {
        return $http.get(API_URL + '/HomeAPI/GetExhibitorListDetail?id='+id);
    }

}]);

