(function () {

    angular.module('albumCollection')
        .controller('albumDetailsCtrl', AlbumDetailsController);

    function AlbumDetailsController($http, $scope) {
        
        var vm = this;

        vm.album = {};

        $http.get("api/Albums/")
            .success(function (albumData) {
                vm.album = albumData;
            })
            .error(function (error) {
                console.log("error getting album: " + error);
            });
    }

})();