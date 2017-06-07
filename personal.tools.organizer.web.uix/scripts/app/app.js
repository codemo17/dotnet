define('my.app',
        ['jquery', 'backbone', 'underscore',
          'my.model.contact',
          'my.collection.contacts',
          'my.view.main', 'my.view.contact', 'my.view.contacts', 'my.view.info',
          'my.router', 'my.vent','jqueryui'],
        function ($,Backbone,_,Contact,Contacts,MainView,ContactView,ContactsView,InfoView,Router,vent) {

            var run = function () {
           
               
                this.router = new Router(),
                this.apiurl = 'http://localhost:2949/',
                this.mainview = new MainView();
                this.contacts = new Contacts();
                this.contacts.load({ 'refresh': true, 'force': true });

                var that = this;

                vent.on('home:visited', function () {

                    that.mainview.show(new InfoView());

                });

                vent.on('contact:selected', function (id) {

                    var another = that;
                    var contact = id ? that.contacts.get(id) :new Contact({id:that.contacts.length>0? _.max(that.contacts,function(contact){return contact.get('id')})+1:99,'name':null,'lastname':null,'age':null});

                    that.mainview.show(new ContactView({ model: contact }));
                    that.router.navigate('#contact'+ (contact.get('id')?'/'+contact.get('id'):''), false);
                });


                vent.on('all:selected', function () {

                    that.mainview.show(new ContactsView({ collection: that.contacts }));
                    that.router.navigate('#all', false);

                });


                vent.on('contact:added', function(contact) {

                    if(contact) {

                        if (!that.contacts.get(contact.get('id'))) {
                            that.contacts.add(contact);
                        }
                       
                        that.mainview.show(new ContactsView({ collection: that.contacts }));
                        that.router.navigate('#all', false);


                    }

                });

                Backbone.history.start({ pushState: false });


            };

            return {
                run: run
            };
        })