define('my.view',
    ['jquery','backbone','underscore'],

    function ($,Backbone,_) {

        var my = my || {};
        
        my.view = Backbone.View.extend({
           
        });


        my.view.prototype.close = function() {
            this.remove();
            this.unbind();
            if(this.onclose) {
                this.onclose();
            }
        };

        return  my.view;

    }
)