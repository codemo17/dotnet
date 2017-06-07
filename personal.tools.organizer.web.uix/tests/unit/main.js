(function () {

    var root = this;

    

    loadthirdparties();
    loadpluginsandboot();

    function loadthirdparties() {

        define("jquery", [], function () { return root.jQuery; });
        define("underscore", [], function() { return root._; });
        define("backbone", [], function () { return root.Backbone; });
        define("amplify", [], function () { return root.amplify; });
        define("moment", [], function () { return root.moment; });


    }

    function loadpluginsandboot() {

        requirejs([], boot);

    }

    function boot() {
        }



})();