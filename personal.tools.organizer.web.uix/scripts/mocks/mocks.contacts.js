define('mocks.contacts',
    ['amplify'],
    function (amplify) {

        var defineApi = function(model) {

            amplify.request.define('api/contacts/get', function(settings) {
                settings.success(model.generatecontacts().contacts);
            });

            amplify.request.define('api/contacts/unique/get', function (settings) {
                settings.success(model.generateuniquecontacts().contacts);
            });


        };

        return {
            defineApi: defineApi
        };

    }
)