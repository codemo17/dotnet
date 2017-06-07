define('my.view.info',
    ['jquery', 'backbone', 'underscore', 'my.view', 'text!scripts/app/templates/info.htm'],

    function ($, Backbone, _, view,template) {

        var my = my || {};

        my.infoview = view.extend({


            className: 'view',
            initialize: function () {
                this.template = _.template(template);
                this.render();
            },
            
            render: function () {
                $(this.el).append(this.template);

                return this;
            }

        });

        return my.infoview;

    }
)