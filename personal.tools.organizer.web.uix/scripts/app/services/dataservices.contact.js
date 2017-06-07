define('dataservices.contact',
    ['amplify'],
    function(amplify) {

        var init = function() {

            amplify.request.define('contacts', 'ajax', {
                    url: 'api/contacts',
                    data: 'json',
                    type: 'GET'
                }
            );

        },
            
        getcontacts = function(callbacks,data) {

            return amplify.request({
                resourceId: 'contacts',
                data: data,
                success: callbacks.success,
                error:callbacks.error
                
            });


        };
        init();

        return {
            contacts: getcontacts
        };



    });