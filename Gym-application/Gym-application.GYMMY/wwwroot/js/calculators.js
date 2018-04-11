
angular.module('myApp', [])
    .controller('calculatorAng', function($scope) {
    $scope.Aim; // 0 Reduction, 1 Mass, 2 Keep
    $scope.Height;
    $scope.Weight;
    $scope.Somatotyp; //0 Ektomorfik 800, 1 Mezomorfik 450, 2 Endomorfik 300 
    $scope.Age;
    $scope.Sex; //Woman true;
    $scope.BMR;
    $scope.BMR_Activ;
    $scope.BMR_Activ_Somatotyp;
    $scope.BMR_Activ_Somatotyp_Aim;
    $scope.Calculator_Type;
    $scope.Activity;
    $scope.Calories_oper;
    $scope.Protein;
    $scope.Fat;
    $scope.Carbo;

    $scope.myFunc = function () {
        $scope.BMR = BMR_func();
        $scope.BMR_Activ = BMR_Activ_func();
        $scope.BMR_Activ_Somatotyp = BMR_Activ_Somatotyp_func();
        $scope.BMR_Activ_Somatotyp_Aim = BMR_Activ_Somatotyp_Aim_func();
    };

    function BMR_func() {
        switch ($scope.Calculator_Type)
        {
            case "0":
                BMR =  $scope.Weight * 24.0;
                break;
            case "1":
                if ($scope.Sex=="True") {
                    BMR = 655 + (9.6 * $scope.Weight) + (1.85 * $scope.Height) - (4.7 * $scope.Age);
                }
                else {
                    BMR = 66.5 + (13.7 * $scope.Weight) + (5 * $scope.Height) - (6.8 * $scope.Age);
                }
                break;
            case "2":
                if ($scope.Sex == "True") {
                    BMR = (9.99 * $scope.Weight) + (6.25 * $scope.Height) - (4.92 * $scope.Age) - 161
                }
                else {
                    BMR = (9.99 * $scope.Weight) + (6.25 * $scope.Height) - (4.92 * $scope.Age) + 5;
                }
                break;
            case "2":
                //(mass_muscle != null) ? 655 + 370 + (21.6 * (double)mass_muscle):1
                //break;        
                }
            return Math.round(BMR);
    };
    function BMR_Activ_func() {
        return Math.round($scope.BMR * ($scope.Activity / 100));
    }
    function BMR_Activ_Somatotyp_func() {
        var bufor;
        if ($scope.Somatotyp == 0) {
            bufor = $scope.BMR_Activ + 800;
        } else if ($scope.Somatotyp == 1) {
            bufor = $scope.BMR_Activ + 450;
        } else if ($scope.Somatotyp == 2) {
            bufor = $scope.BMR_Activ + 300;
        } else {
            bufor = "Choose somatotyp"
        }
        return Math.round(bufor);
    }
    function BMR_Activ_Somatotyp_Aim_func(){
        var bufor;
        if ($scope.BMR_Activ_Somatotyp != "Choose somatotyp" & $scope.Calories_oper != undefined) {
            if ($scope.Aim == 0) {
                bufor = $scope.BMR_Activ_Somatotyp - $scope.Calories_oper;
            } else if ($scope.Aim == 1) {
                bufor = $scope.BMR_Activ_Somatotyp + $scope.Calories_oper;
            } else {
                bufor = $scope.BMR_Activ_Somatotyp;
            }
        } else {
            bufor = "Fill calculator data";
        }
        return Math.round(bufor);
    }
});




//Esiest[0]
        //          BMR= Mnożymy wagę × 24 godziny 
        //Harrisa-Benedicta[1]
        //          Wzór dla mężczyzn: [A] = 66,5 + (13,7 x WAGA) + (5 x WZROST) – (6,8 x WIEK)
        //          Wzór dla kobiet:     [A] = 655 + (9,6 x WAGA) + (1,85 x WZROST) – (4,7 x WIEK)
        //Mifflin-St Jeor[2]
        //          Wzór dla mężczyzn: [A] = (9,99 x WAGA) + (6,25 x WZROST) – (4,92 x WIEK) +5
        //          Wzór dla kobiet:     [A] = (9,99 x WAGA) + (6,25 x WZROST) – (4,92 x WIEK) - 161
        //Katch-McArdle[3]
        //          Wzór dla mężczyzn: [A] = 370 + (21,6 x masa mięśniowa ciała w kg)
        //          Wzór dla kobiet:     [A] = 370 + (21,6 x masa mięśniowa ciała w kg)