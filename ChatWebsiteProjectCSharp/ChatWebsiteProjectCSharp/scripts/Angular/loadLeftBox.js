﻿var app = angular.module('left', []);
app.controller("loadLeftBoxController", function ($scope, $http) {
    $scope.currentpage = 1;
    $scope.totalpage = 0;
    $scope.detailslist = [];
    function getdata(page) {
        debugger;
        $scope.Isloading = true;
        $http.get("/Home/getLeftChatBox?page=" + page).then(function (response) {
            angular.forEach(response.data.registerDataLeftBox, function (value) {
                $scope.detailslist.push(value);
            });
            $scope.totalpage = response.data.totalCountLeftBox;
            $scope.Isloading = false;
        }, function (error) {
            $scope.Isloading = false;
            alert('Failed');
        })
    }
    getdata($scope.currentpage);
    $scope.Nextpage = function () {
        if ($scope.currentpage < $scope.totalpage) {
            $scope.currentpage += 1;
            getdata($scope.currentpage);
        }
    };
});
app.directive('infinitescroll', function () {
    debugger;
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('scroll', function () {
                if ((element[0].scrollTop + element[0].offsetHeight) == element[0].scrollHeight) {
                    scope.$apply(attrs.infinitescroll);
                }
            })
        }
    }
})






