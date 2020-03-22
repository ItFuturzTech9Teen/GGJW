////Local Connection
var API_BASE_URL = "http://localhost:52316/";
var API_URL = "http://localhost:52316/api";


//Server Connection
////var API_BASE_URL = "http://ggjw.itfuturz.com/";
////var API_URL = "http://ggjw.itfuturz.com/api";

var myApp = angular.module('GGJWEventModule', ['ngTagsInput', 'datatables', 'angular.filter', 'ngTouch', 'angularLocalStorage', 'ipCookie', 'dndLists', 'ui.select', 'bw.paging']);
var Login_User = "login_user";

function encrypt(string, key) {
    var result = "";
    for (i = 0; i < string.length; i++) {
        result += String.fromCharCode(key ^ string.charCodeAt(i));
    }
    return result;
}

function decrypt(string, key) {
    var result = "";
    for (i = 0; i < string.length; i++) {
        result += String.fromCharCode(key ^ string.charCodeAt(i));
    }
    return result;
}
var encryptKey = 'sf2018';
