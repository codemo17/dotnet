
define('my.model.contact',
    ['jquery','backbone','underscore'],

    function ($,Backbone,_) {

        var my = my || {};
        
        my.contact = Backbone.Model.extend({
       
            defaults: {
                'selected':false
            },
            
            updateselect: function () {

                this.collection.updateselected(this);

            }
       
        });

        return my.contact;
    }
)