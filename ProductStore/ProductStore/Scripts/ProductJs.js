var app = angular.module("myApp", []);

app.controller('productController', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var init = function () {
        $http.get('/api/products/').success(function (data) {
            $scope.products = data;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
        })

        $scope.date = new Date().toISOString();
    };

    $scope.delete = function (product) {
        var confirm = $window.confirm("Do you want Delete this Tweet?");
        if (confirm) {
            $http.delete('/api/products/' + product.Id).success(function (data) {
                $scope.products = data;
                $window.alert("Success");
                init();
            })
            .error(function () {
                $scope.error = "An Error has occured while loading posts!";
            });
        }
    };

    $scope.save = function (product) {
        var confirm = $window.confirm("Do you want to save this Tweet?");
        if (confirm) {
            if ($scope.product.Id > 0) {
                $http.put('/api/products/', product).success(function (data) {
                    $window.alert("Success");
                    init();
                })
                 .error(function () {
                     $scope.error = "An Error has occured while loading posts!";
                 });
            }
            else {
                $http.post('/api/products/', product).success(function (data) {
                    $window.alert("Success");
                    init();
                })
                 .error(function () {
                     $scope.error = "An Error has occured while loading posts!";
                 });
            }
        }
    };

    $scope.edit = function (product) {
        var confirm = $window.confirm("Do you want Edit this Tweet?");
        if (confirm) {
            $scope.product = product;
        }
    };

    init();
}]);

