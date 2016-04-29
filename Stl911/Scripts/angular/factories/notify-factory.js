
(function () {
    'use strict';

    angular
        .module('app')
        .factory('notifyFactory', notifyFactory);

    function notifyFactory() {

        var footerOffset = 75;
        var defaultOffset = 20;

        var service = {
            // text: the message text
            // type: decides the style, like bootstrap (success, info, warning, danger)
            // icon: (optional) comes before the text, can use any bootstrap icon (ex: glyphicon glyphicon-ok)
            // footerPresent: is our default footer on the page? if so, raise offset to avoid the notification covering it
            //example: notifyFactory.notify('Quantity must be at least one.', 'warning', 'glyphicon glyphicon-warning-sign', true);
            notify: showNotification,
            showSuccess: showSuccess,
            showError: showError
        };

        return service;

        function showNotification(text, type, icon, footerPresent) {
            $.notify({
                // options
                message: text,
                icon: icon
            }, {
                // settings
                type: type,
                placement: {
                    from: "bottom",
                    align: "right"
                },
                z_index: 9999,
                allow_dismiss: true,
                delay: 3000,
                offset: footerPresent ? footerOffset : defaultOffset
            });
        };

        function showSuccess(text, footerPresent) {
            $.notify({
                // options
                message: text,
                icon: ""
            }, {
                // settings
                type: "success",
                placement: {
                    from: "bottom",
                    align: "right"
                },
                z_index: 9999,
                allow_dismiss: true,
                delay: 3000,
                offset: footerPresent ? footerOffset : defaultOffset
            });
        };

        function showError(text, footerPresent) {
            $.notify({
                // options
                message: text,
                icon: ""
            }, {
                // settings
                type: "danger",
                placement: {
                    from: "bottom",
                    align: "right"
                },
                z_index: 9999,
                allow_dismiss: true,
                delay: 3000,
                offset: footerPresent ? footerOffset : defaultOffset
            });
        };
    }
})();