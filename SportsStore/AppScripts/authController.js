"use strict";

(function() {
    angular.module("SportsStoreApp").controller("authController", function (authService) {
        var vm = this;

        vm.user = {
            username: "",
            password: "",
            isAuthenticated: false
        };

        vm.authenticate = function() {
            console.log("calling authentication");
           authService.authenticate(vm.user.username, vm.user.password).then(function(response) {
               var data = response.data;
               if (data.access_token) {
                   vm.access_token = data.access_token;
                   vm.token_type = data.token_type;
               }
           });
        }
    });
}())