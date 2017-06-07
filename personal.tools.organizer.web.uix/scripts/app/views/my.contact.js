define('my.view.contact',
    ['jquery', 'backbone', 'underscore', 'my.model.contact','my.vent', 'my.view', 'text!scripts/app/templates/contact.htm'],

    function ($, Backbone, _, Contact, vent, view,template) {

        var my = my || {};

        my.contactview = view.extend({

            tagName: 'article',
            className: 'contact',
            
            events: {
              
                'click a#add': 'add',
                'click a#clear':'clear',
            },

            initialize: function () {
                this.model = this.model || new Contact({ 'age':null, 'name': null, 'lastname': null });
                this.model.on('change', this.render, this);
                this.render();
            },
            render: function () {
                $(this.el).empty();
                $(this.el).append(_.template(template, this.model.toJSON()));

                return this;
            },
            
            add:function (e) {
                e.preventDefault();
                e.stopImmediatePropagation();
                this.model.set({ 'name': this.$('#name').val(), 'lastname': this.$('#lastname').val(), 'age': this.$('#dob').val(),'silent': true });

                vent.trigger('contact:added', this.model);

            },
            
            clear:function (e) {
                e.preventDefault();
                e.stopImmediatePropagation();
                this.model.set({ 'name': '', 'lastname': '', 'age': '', 'silent': false });

            },
            
            onclose:function(){

                this.model.off('change', this.render);
            }



        });

        return my.contactview;

    }
)