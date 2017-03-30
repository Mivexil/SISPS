var StartController = function ($scope, $http) {
    $scope.models = {
        helloAngular: 'I work!',
        whitePlayer: '',
        blackPlayer: ''
    };

    $scope.add = function () {
        var f = document.getElementById('file')["files"][0];
        var r = new FileReader();
        r.onloadend = function (e) {
            var data = e.target["result"].match(/,(.*)$/)[1];
            $http.post('/parser', { d: data }).then(function (r) {
                $scope.models.whitePlayer = r.data.white;
                $scope.models.blackPlayer = r.data.black;
            });
        }
        r.readAsDataURL(f);
    }
}

StartController.$inject = ['$scope', '$http'];