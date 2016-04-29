/**
* Utility Directives
*
* Container for re-usable directives that are not unique
* to any one page/area
* 
*/


(function () {
    'use strict';

    var app = angular.module('app');
    
    app.directive('closeModal', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                scope.$on('closeModal', function (event, data) {
                    element.click();
                });
            }
        };
    });

    app.directive('openModal', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                scope.$on('openModal', function (event, data) {
                    element.modal('show');
                });
            }
        };
    });

    // Show the Current Running Time
    app.directive('currentTime', ['dateFilter', function (dateFilter) {
        return function (scope, element, attrs) {
            var isInput = element.is('input');

            scope.$watch(attrs.currentTime, function () {
                updateTime();
            });

            function updateTime() {
                var dt = dateFilter(new Date(), "M/d/yy h:mm:ss a");
                if (isInput)
                    element.val(dt);
                else
                    element.text(dt);
            };

            function scheduleUpdate() {
                setTimeout(function () {
                    updateTime();
                    scheduleUpdate();
                }, 1000);
            }

            scheduleUpdate();
        }
    }]);

    // slide up or down the passed element (by id) when this element is clicked
    // ----------
    // optional
    //-----------
    // show/hide-class: pass a show-class and a hide-class and they will be toggled along with the 
    //                  corresponding slideToggle
    // on-child: toggle the classes on the child of the click (to support bootstrap span glyphs)
    // is-async: if is-async="true" is on the element we will not bind an id until click - because it may not be there yet.
    //-----------
    // ex: <button class="btn btn-sm btn-primary" data-slide-toggle="divPanelBody">lol</button>
    //
    // ex: <button class="btn btn-sm btn-primary" data-slide-toggle="divPanelBody" data-show-class="btn-primary" data-hide-class="btn-danger">lol</button>
    //
    // ex: <button class="btn btn-xs" data-slide-toggle="divQueueBody" data-show-class="glyphicon-chevron-up" data-hide-class="glyphicon-chevron-down" data-on-child="true">
    //          <span class="glyphicon glyphicon-chevron-up"></span>
    //     </button>
    //
    app.directive('slideToggle', [function () {
        return {
            restrict: "A",
            link: function (scope, element, attrs, ctrl) {
                var slideElement = attrs.isAsync ? null : $('#' + attrs.slideToggle);

                element.on('click', function () {
                    if (attrs.isAsync) {
                        slideElement = $('#' + attrs.slideToggle);
                    };

                    slideElement.slideToggle("fast", function () {
                        if (attrs.showClass && attrs.hideClass) {
                            if (slideElement.is(':visible')) {
                                if (attrs.onChild) {
                                    element.children().addClass(attrs.showClass).removeClass(attrs.hideClass);
                                } else {
                                    element.addClass(attrs.showClass).removeClass(attrs.hideClass);
                                };
                            }
                            else {
                                if (attrs.onChild) {
                                    element.children().addClass(attrs.hideClass).removeClass(attrs.showClass);
                                } else {
                                    element.addClass(attrs.hideClass).removeClass(attrs.showClass);
                                };
                            };
                        }
                    });
                });
            }
        };
    }]);

    // auto focus a tab on page load
    // place this as an attribute on your nav ul (ex: <ul class="nav nav-tabs" data-active-tabs>)
    // pass the id of the tab-pane as hash (ex: url.com/?id=1#MyTab)
    app.directive('activeTabs', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs, ctrl) {
                $(function () {
                    var tabId = location.hash;

                    if (!tabId || tabId.length === 0) { return; };

                    var activeTab = element.find('a[href=' + tabId + ']');

                    if (activeTab.length > 0) {
                        activeTab.tab('show');
                    };
                });
            }
        }
    });

    app.directive('hrTitle', function () {
        return {
            restrict: 'EA',
            templateUrl: '/Scripts/angular/templates/hr-title-template.html',
            scope: {
                titleText: '@'
            },
            link: function (scope, element, attrs, ctrl) {
            }
        }
    });

    app.filter('yesNo', function () {
        return function (input) {
            //the extra ifs were needed because false was returning yes
            if (input === "true") return 'Yes';
            if (input === "false") return 'No';
            return input ? 'Yes' : 'No';
        }
    });

})();

