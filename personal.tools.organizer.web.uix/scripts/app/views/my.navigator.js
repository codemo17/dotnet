define('my.view.navigator',
    ['jquery', 'backbone', 'underscore','my.vent' ,'my.view', 'text!scripts/app/templates/navigator.htm'],

    function ($, Backbone, _, vent,view,template) {

        var my = my || {};

        my.navigatorview = view.extend({

         
                el:'nav',
                
                events: {
                  
                    'click a#new': 'add',
                    'click a#all':'all'
                },

                initialize: function () {
                    this.template = _.template(template);
                    this.render();
                },
                render: function () {
                    $(this.el).append(this.template);
                },
                
                add: function (e) {
                    e.preventDefault();
                    e.stopImmediatePropagation();
                    vent.trigger('contact:selected');
                 
                },
                
                all: function (e) {
                    e.preventDefault();
                    e.stopImmediatePropagation();
                    vent.trigger('all:selected');

                }



        });

        return my.navigatorview;

    }
)