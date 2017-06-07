define('dataservices.test.contact',

    ['jquery','amplify','config'],
    function($,amplify,config) {

        var expected=1;

        var getsut = function() {
            var sut = window.sut(amplify);
            config.mockit(true);

            return sut;

        };

        module('dataservices.data.contact.query');

        asyncTest('get(contactid) brings a correct contact',
            function() {

                //arrange
                var dataservice = getsut();
                    
                //act
                dataservice.contacts({ 'refresh': true },{
                    //assert
                    success: function(result) {
                        ok(result && result.length > 0, 'contact returned');
                        start();

                    },

                    error: function() {
                        ok(false, 'problems occurred');
                    }
                }, expected);


            }
        );

    }
)