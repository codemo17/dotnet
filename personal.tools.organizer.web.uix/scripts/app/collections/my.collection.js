define('my.collection',
    ['jquery', 'backbone', 'underscore','amplify','config'],
    function ($, Backbone, _,amplify,config) {

        var my = my||{};
        
        my.collection = Backbone.Collection.extend ({
           
            initialize:function(options) {

                config.mockit(true);
                config.offline = false;

                this.url = (options||{}).url || this.url;
                this.name = (options || {}).name || this.name;
                
                
                
                amplify.request.define(my.collection.url + '/get', 'ajax', {
                    url: my.collection.url,
                    data: 'json',
                    type: 'GET'
                });
            },

            ///
            load : function(options) {
                var that = this;
                return $.Deferred(function(def) {
                    
                    that.url = (options||{}).url || that.url;
                    if (options.refresh) {
                    
                        if (!config.offline) {
                            return amplify.request({
                                
                                resourceId: that.url + '/get',
                                success: function(result) {
                                    that.insert(result, options);
                                    def.resolve(result);

                                },
                                error: function() {
                                    def.reject();
                                }
                            });
                        } else {

                            var result = JSON.parse(amplify.store(that.url) || "null");
                            that.insert(result, options);
                            def.resolve(result);
                        }
                  }else {

                        def.resolve();
                    }

                }).promise();

            },
            
            ///
            insert: function (result, options) {

                options.silent = true;
                var data = [];
                     _.each(result, function (item) {

                         var index = _.indexOf(data, _.find(data, function (dataitem) { return dataitem.id == item.id;}));

                        if ( _.isUndefined(this.get(item.id))) {
                           
                            if (index > -1) {
                                data.splice(index, 1);
                            }
                                data.push(item);
                        }else {
                            
                            if(this.get(item.id) && options.force) {
                                this.remove(this.get(item.id), options);
                                if (index > -1) {
                                    data.splice(index, 1);
                                }
                                data.push(item);
                            }
                        }
                    }, this);

                return Backbone.Collection.prototype.add.call(this, data, options);
             
            },

           
        });

        
        return my.collection;

    })