var app = angular.module('right', []);


app.controller("loadRightBoxController", function ($scope, $http) {
    $scope.currentpage = 1;
    $scope.totalpage = 0;
    $scope.listChatInfo = [];
    $scope.headerInfo = [];
    $scope.messid;
    function getdata(messid) {
        debugger;
        $scope.Isloading = true;
        $scope.messid = messid;
        $http.get("/Home/getRightChatBox?page=" + currentpage + "?messid=" + messid).then(function (response) {
            angular.forEach(response.data.registerDataRightBox, function (value) {
                $scope.listChatInfo.push(value);
            });
            angular.forEach(response.data.header, function (value) {
                $scope.headerInfo.push(value);
            });
            $scope.totalpage = response.data.totalCountRightBox;
            $scope.Isloading = false;
        }, function (error) {
            $scope.Isloading = false;
            alert('Failed');
        })
    }

    $scope.Nextpage = function () {
        if ($scope.currentpage < $scope.totalpage) {
            $scope.currentpage += 1;
            getdata($messid);
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