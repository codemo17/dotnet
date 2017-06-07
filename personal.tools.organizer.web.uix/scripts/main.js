(function () {

    var root = this;

    loadthirdparties();
    loadpluginsandboot();

    function loadthirdparties() {

        define("jquery", [], function () { return root.jQuery; });
        define("jqueryui", [], function () { return root.jQueryUI; });
        define("underscore", [], function() { return root._; });
        define("backbone", [], function () { return root.Backbone; });
        define("amplify", [], function () { return root.amplify; });
  
    }

    function loadpluginsandboot() {

        requirejs([], boot);

    }

    function boot() {
        require(['my.app'], function(app) { app.run(); });
    }



})();
