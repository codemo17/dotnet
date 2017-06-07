define('my.view.contacts',
    ['jquery', 'backbone', 'underscore', 'my.view.contactrow', 'my.vent','my.view','text!scripts/app/templates/contacts.htm'],

    function ($, Backbone, _, ContactRowView,vent,view,template) {

        var my = my || {};

        my.contactsview = view.extend({
            className: 'view',
            
          

            events: {
              
                'click a#edit':'edit',
                'click a#remove': 'removeit'
            },

            initialize: function (options) {

               this.collection.on('reset', this.render, this);
                this.views = [];

                this.render();
            },
            render: function() {
                var that = this;

                $(this.el).empty();
                $(this.el).html( _.template(template));
                var $contacts = this.$('.contacts');

                this.collection.each(function(contact) {

                    var view = new ContactRowView({ model: contact });
                     $contacts.append(view.el);
                     that.views.push(view);


                });

                return this;
            },
            
            'edit': function (e) {
                e.preventDefault();
                e.stopImmediatePropagation();

                var selected = this.collection.find(function(contact) {
                    return contact.get('selected') == true;
                });
                
                if(selected) {
                    vent.trigger('contact:selected', selected.get('id'));
                }

            },
            
            'removeit':function (e) {
                var that = this;
                e.preventDefault();
                e.stopImmediatePropagation();

                var selected = this.collection.find(function(contact) {
                    return contact.get('selected') == true;
                });

                if (selected) {

                    var view = _.find(that.views, function (view) { return view.model.get('id') == selected.get('id'); });

                    if(view) {
                        view.close();
                        that.views.pop(view);
                    }
                    this.collection.remove(selected);

                }
            },
                
            
            
           
            
            onclose:function () {
                this.collection.off('reset', this.render);
                this.collection.off('remove', this.render);
            }
            
        });

        return my.contactsview;

    }
)