
var app = angular.module('myApp', []);
app.service('DataService', function ($http) {
    //**********----Get All Record----***************
    var url_api = '/api/Meal__Nutritional_Value';//all exist Nutritional_values in database
    this.get_all_values = function () {
        return $http.get(url_api);
    };
    var urlGet2 = '/meal/Mealdata/'; //meal data what is in the meal
    this.get_all_values2 = function (model_id) {
        return $http.get(urlGet2 + model_id);
    };
    this.send_post_data = function (urll, datalist, modelId) {
        $http({
            method: "post",
            url: urll,
            data: JSON.stringify({
                values: datalist,
                meal: {
                    id: modelId
                }
            }),
            dataType: "json"
        }).then(function (response) {
            this.show_messages(response);
        });
    };
    show_messages = function (datalist) {
        var esc = new Date().getTime() + 15000;
        document.getElementById('mealmessages').innerHTML = '<div id="div' + esc + '" class="alert alert-success" role="alert">' + datalist.data[0].value + '</div>';
        var x = setInterval(function () {
            var now = new Date().getTime();
            var distance = esc - now;
            if (distance < 12001) {
                var element = document.getElementById('div' + esc);
                element.classList.add("hidden");
            }
            if (distance < 0) {
                clearInterval(x);
                var element2 = document.getElementById('div' + esc);
                element2.parentNode.removeChild(element2);
            }
        }, 1000);

    };
});
app.filter('filtername', function () {
    return function (x, search) {
        if (search === undefined) {
            search = '';
        }
        var log = [];
        angular.forEach(x, function (value) {
            if (value.name.toLowerCase().includes(search.toLowerCase())) {
                this.push(value);
            }
        }, log);
        return log;
    };
});
app.controller('NutritionalValuesCtrl', ['$scope', '$http', 'DataService', function ($scope, $http, DataService) {
    $scope.list = [];
    
    $scope.init = function (Model_Id) {
        $scope.Model_Meal_Id = Model_Id;
        var _values = DataService.get_all_values();
        _values.then(function (response) {
            $scope.myData = response.data;
        },
            function (error) {
                console.log("Error: " + error);
            });

        var _values2 = DataService.get_all_values2(Model_Id);
        _values2.then(function (response) {
            $scope.list = response.data.values;
        }, function (error) {
            console.log("Error: " + error);
        });
    };
    $scope.Calculate_per_grams = function (param, grams) {
        return Calculate_per_grams_function(param, grams);
    };
    function Calculate_per_grams_function(param, grams) {
        return Math.round((param * (grams / 100)) * 100) / 100;
    };
    $scope.$watchCollection('list', function () {
        Calculate_all();
    });
    $scope.calcall = function () {
        Calculate_all();
    };
    function Calculate_all() {
        var cal = 0, carbo = 0, fat = 0, protein = 0;
        angular.forEach($scope.list, function (value) {
            cal += Calculate_per_grams_function(value.calorie, value.grams);
            carbo += Calculate_per_grams_function(value.carbohydrates, value.grams);
            fat += Calculate_per_grams_function(value.fat, value.grams);
            protein += Calculate_per_grams_function(value.protein, value.grams);
        });
        $scope.calories_all = Math.round(cal * 100) / 100;
        $scope.carbos_all = Math.round(carbo * 100) / 100;
        $scope.fats_all = Math.round(fat * 100) / 100;
        $scope.proteins_all = Math.round(protein * 100) / 100;
    };
    $scope.Add_Prod = function (prod) {
        $scope.list.push({
            value_id: prod.id,
            name: prod.name,
            calorie: prod.calorie,
            protein: prod.protein,
            fat: prod.fat,
            carbohydrates: prod.carbohydrates,
            grams: 100
        })
    };
    $scope.Remove_Prod = function (prodkey) {
        $scope.list.splice(prodkey, 1);
    };
    $scope.Save_Data_post_method = function () {
        //$http.post("https://localhost:44393/api/Meal__Nutritional_Value", JSON.stringify({
        //    modeloVenta: $scope.list
        //})).then(function () {
        //    toastr.info('Elemento insertado correctamente');
        //    });
        DataService.send_post_data('/api/Meal__Nutritional_Value', $scope.list, Model_Meal_Id);

    };

}]);