define('mocks',
    ['mocks.generator','mocks.contacts'],
    function(generator,contacts) {

        var model = generator.model,
            init = function() {

                contacts.defineApi(model);
            };


        return {
            init:init  
        };

    })