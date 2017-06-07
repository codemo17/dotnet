define('my.collection.contacts',
    ['jquery','backbone','underscore','my.model.contact','my.collection'],

    function ($,Backbone,_,Contact,collection) {

        var my = my|| { };
    	
        my.contacts = collection.extend({
           
            
        	model: Contact,
        	url: 'api/contacts',
        	
        	
        	updateselected: function (contact) {
        	    var selected = this.find(function (contact) {
        	        return contact.get('selected') == true;
        	    });
        	    
                if(selected && (selected.get('id')!=contact.get('id'))) {
                    selected.set({ 'selected': false });
                }
                contact.set({'selected': contact.get('selected') ? false : true });

        	}
        	
        });

        return my.contacts;

    }
)