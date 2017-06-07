define('my.vent',
    ['jquery','backbone','underscore'],
    
    function ($, Backbone, _) {

        var my = my || { };
        
       my.vent = _.extend({}, Backbone.Events);
       return my.vent;
    });

  
