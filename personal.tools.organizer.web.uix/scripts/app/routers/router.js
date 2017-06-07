define('my.router',
     ['jquery', 'backbone', 'underscore','my.vent'],

      function ($, Backbone, _,vent) {

          var my = my || {};
          
          my.router = Backbone.Router.extend({
              routes: {

                  '': 'info',
                  'contact': 'contact',
                  'contact/:id': 'contact',
                  'all': 'contacts'
              },
              
              initialize: function () {
              },


              'info': function () {

                  vent.trigger('home:visited');
              },

              
              'contact': function (id) {
                  vent.trigger('contact:selected', id);
              },

              'contacts': function () {
                  vent.trigger('all:selected');
              }
          });

          return my.router;

    }
)