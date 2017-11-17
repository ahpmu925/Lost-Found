(function () {

    angular.module(APP.NAME)
        .factory('foundService', FoundService);

    FoundService.$inject = ["$http"];

    function FoundService($http) {



        var svc = {};
        svc.addItem = _addItem;
        svc.getItems = _getItems;
        return svc;

        function _addItem(data, onSuccess, onError) {

            var settings = {
                url: '/api/founditems',
                method: 'POST',
                headers: {},
                cache: false,
                contentType: 'application/json; charset=UTF-8',
                data: JSON.stringify(data),
                withCredentials: true,
            };

            return $http(settings)
                .then(onSuccess, onError)

        }

     function _getItems(onSuccess, onError) {

            var settings = {
                url: '/api/founditems',
                method: 'GET',
                headers: {},
                cache: false,
                contentType: 'application/json; charset=UTF-8',
                withCredentials: true,
            };

            return $http(settings)
                .then(onSuccess, onError)

        }
        
    };
})();
