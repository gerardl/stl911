

(function () {
    'use strict';

    var app = angular.module('app');

    // for formatting a json date in angular
    app.filter("jsDate", [function () {
        return function (x) {
            if (!x) { return ''; }

            // already a date
            if (typeof x.getMonth === 'function') { return x; }

            // not something we are handling
            if (typeof x !== 'string') { return ''; }
                // "/Date(1422424800000)/" "sales co && operations dates?" meh
            else if (/(\/).+\1/.test(x)) {
                return new Date(parseInt(x.substr(6)));
            }
                // "2015-02-11T15:38:04.23" causes problems for angular filter
            else {
                return new Date(x);
            }
        };
    }]);
    
    app.filter("removeDomain", [function () {
        return function (x) {
            if (!x) { return ''; }

            var splitX = x.split("\\");
            if (splitX.length === 2) {
                return splitX[1];
            } else {
                return x;
            }
        };
    }]);

    app.filter('telephone', [function () {
        return function (tel) {
            if (!tel) { return ''; }

            var value = tel.toString().trim().replace(/^\+/, '');

            if (value.match(/[^0-9]/)) {
                return tel;
            }

            var country, city, number;

            switch (value.length) {
                case 10: // +1PPP####### -> C (PPP) ###-####
                    country = 1;
                    city = value.slice(0, 3);
                    number = value.slice(3);
                    break;

                case 11: // +CPPP####### -> CCC (PP) ###-####
                    country = value[0];
                    city = value.slice(1, 4);
                    number = value.slice(4);
                    break;

                case 12: // +CCCPP####### -> CCC (PP) ###-####
                    country = value.slice(0, 3);
                    city = value.slice(3, 5);
                    number = value.slice(5);
                    break;

                default:
                    return tel;
            }

            if (country == 1) {
                country = "";
            }

            number = number.slice(0, 3) + '-' + number.slice(3);

            return (country + " (" + city + ") " + number).trim();
        };
    }]);

    app.filter('percentage', ['$filter', function ($filter) {
        return function (input) {
            var decimals = 2;
            return $filter('number')(input, decimals) + '%';
        };
    }]);

    app.filter('shortenString', [function () {
        return function (value, wordwise, max, tail) {
            if (!value) return '';

            max = parseInt(max, 10);
            if (!max) return value;
            if (value.length <= max) return value;

            value = value.substr(0, max);
            if (wordwise) {
                var lastspace = value.lastIndexOf(' ');
                if (lastspace != -1) {
                    value = value.substr(0, lastspace);
                }
            }

            return value + (tail || ' …');
        };
    }]);

})();