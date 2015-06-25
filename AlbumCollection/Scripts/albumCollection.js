(function () {

    angular.module('albumCollection', ['ngRoute'])
        .config(AlbumCollectionConfig);

    function AlbumCollectionConfig($routeProvider, $locationProvider) {

        // configure routes
        $routeProvider
            .when('/', { templateUrl: '/Static/Albums/Details.html' });
        
        // use HTML History API
        $locationProvider.html5Mode(true);

    }

})();