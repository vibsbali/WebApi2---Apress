"use strict";

(function() {
    angular.module("SportsStoreApp").controller("authController", function($http) {
        var vm = this;

        vm.user = {
            username: "Admin",
            password: "secret",
            isAuthenticated: false
        };

        vm.authenticate = function() {
            console.log("calling authentication");
            $http({
                method: "POST",
                url: "http://localhost:7130/authenticate",
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                data: {
                    grant_type: "password",
                    username: "Admin",
                    password: "secret"
                }
            }).then(function success(response) {
                console.log(response);
                vm.user.isAuthenticated = true;
            }, function error(response) {
                console.log(response);
            });
        };
    });
}())