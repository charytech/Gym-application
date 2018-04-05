
angular.module('myApp', [])
    .controller('calculatorAng', function($scope) {
    $scope.Aim;
    $scope.Height = 187;
    $scope.Weight = 110;
    $scope.Somatotyp;
    $scope.Sex;
    $scope.Calculator_Type;
    $scope.Activity;
    $scope.BMI;
    $scope.BMR;
    $scope.Calories_oper;
    $scope.Protein;
    $scope.Fat;
    $scope.Carbo;

    $scope.myFunc = function () {
        $scope.count++;
    };
});
