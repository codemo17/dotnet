define('my.view.contactrow',
    ['jquery', 'backbone', 'underscore', 'my.model.contact', 'my.view', 'text!scripts/app/templates/contactrow.htm'],

    function ($, Backbone, _,Contact,view,template) {

        var my = my || {};

        my.contactrowview = view.extend({
            tagName:'li',
            className: 'row','click a#edit':'edit',

            events: {
              
                'click .tick':'select'
            },

            initialize: function () {
                this.model = this.model || new Contact({});
                this.model.on('change', this.render, this);
                this.render();
            },
            render: function () {
                $(this.el).empty();
                $(this.el).append(_.template(template, this.model.toJSON()));


                return this;
            },
            
            'select':function(e) {
                e.preventDefault();
                this.model.updateselect();
                e.stopImmediatePropagation();

            },
            
            onclose:function () {
                this.model.off('change',this.render);
            }

        });

        return my.contactrowview;

    }
)