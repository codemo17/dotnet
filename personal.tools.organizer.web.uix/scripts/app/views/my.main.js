define('my.view.main',
    ['jquery', 'backbone', 'underscore','my.view.navigator','my.region', 'my.view','text!scripts/app/templates/main.htm'],

    function ($, Backbone, _, NavigatorView,Region,view,template) {

        var my = my || {};

        my.mainview = view.extend({

            el: '.page',
            initialize: function () {
                this.template = _.template(template);
                this.render();
                this.main = new Region('.main');
                this.navigator = new NavigatorView();
        

            },
            render: function () {
                $(this.el).append(this.template);

            },

            show: function (view) {
                this.main.show(this,view);
            }


        });

        return my.mainview;

    }
)