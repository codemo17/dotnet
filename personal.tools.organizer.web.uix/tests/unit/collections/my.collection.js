define('tests.my.collection.contacts',
    ['jquery','backbone','underscore','dataservices','config','my.contact','my.collection'],
    function ($,backbone,_,dataservices,config,mymodel,mycollection) {

        var getsut = function() {

                var collection = window.sut($,backbone,_,mymodel,mycollection,config),
                sut = new collection([]);
                config.mockit(true);
                config.offline=false;
                return sut;

            };


        module('my.collection get data');
        //arrange
        var sutcollection = getsut();
          
        asyncTest('get data by id from collection:options are: get it from server, update already existing item',
            function() {
           
                $.when(
                    //act
                    sutcollection.load({ 'refresh': true, 'force': false}))
                    .done(
                        function(result) {
                            //assert
                            ok(result && result.length > 0, 'result is returned');
                            ok(sutcollection.length == _.uniq(sutcollection.pluck('id')).length, 'all models are unique collections size:' + sutcollection.length + '& unique ids:'+_.uniq(sutcollection.pluck('id')).length);
                            ok( sutcollection.find(function (model) { return model.get('id') == 1; }).get('name')=='ruslan','found name is ruslan');
                            
                            
                            $.when(
                            //act
                            sutcollection.load({ 'refresh': true, 'force': false, 'url': 'api/contacts/unique' }))
                              .done(
                                  function (result) {
                                      //assert
                                      ok(result && result.length > 0, 'result is returned');
                                      ok(sutcollection.length == _.uniq(sutcollection.pluck('id')).length, 'all models are unique collections size:' + sutcollection.length + '& unique ids:' + _.uniq(sutcollection.pluck('id')).length);
                                      ok(sutcollection.find(function (model) { return model.get('id') == 1; }).get('name') == 'ruslan', 'name is ruslan');
                                        $.when(
                                          //act
                                         sutcollection.load({ 'refresh': true, 'force': true, 'url': 'api/contacts/unique' }))
                                         .done(
                                             function (result) {
                                                 //assert
                                                 ok(result && result.length > 0, 'result is returned');
                                                 ok(sutcollection.length == _.uniq(sutcollection.pluck('id')).length, 'all models are unique collections size:' + sutcollection.length + '& unique ids:' + _.uniq(sutcollection.pluck('id')).length);

                                                 var found = sutcollection.find(function(model) { return model.get('id') == 1; });

                                                 ok(found && found.get('name') == 'ruslan', 'expected name is ruslan');
                                                 start();
                                             })
                                         .fail(function () {
                                             ok(false, 'failed');
                                             start();
                                         });
                                  })
                              .fail(function () {
                                  ok(false, 'failed');
                                  start();
                              });
                    })
                    .fail(function() {
                        ok(false, 'failed');
                        start();
                    });
            });

        module('my.collection store data');

        $.when(
            sutcollection.store({ })
                .done({
                    


                })
                .fail({})
                .always({})
        );

    }
)