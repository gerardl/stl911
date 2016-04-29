(function () {
    'use strict';

    angular
        .module('app')
        .factory('urlFactory', urlFactory);
    
    function urlFactory() {

        var service = {
            getUrlParameter: getUrlParam
        };

        return service;

        function getUrlParam(name) {
            return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)', 'i').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null;
        };
    }
})();