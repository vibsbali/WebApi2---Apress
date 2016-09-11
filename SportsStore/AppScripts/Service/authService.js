"use strict";

(function() {
    var app = angular.module("SportsStoreApp");

    app.factory("authService", function($http) {
        var factory = {};

        factory.authenticate = function(username, password) {
           return $http({
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
                    username: username,
                    password: password
                }
            }).then(function success(response) {
                console.log(response);
                return response;
            }, function error(response) {
                console.log(response);
                return response;
            });
        };


        return factory;
    });
}())