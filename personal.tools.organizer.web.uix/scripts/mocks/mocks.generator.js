define('mocks.generator',
    ['jquery'],    
    function ($) {

        var init = function () {
            
            $.mockJSON.random = false;
            $.mockJSON.log = false;
            $.mockJSON.data.CONTACT_FIRST_NAME = ['john', 'isaac', 'albert'];
            $.mockJSON.data.CONTACT_LAST_NAME = ['nash', 'newton', 'einstein'];
            $.mockJSON.data.CONTACT_AGE = ['40', '30', '55'];


            },

            generatecontacts = function() {
                var data = $.mockJSON.generateFromTemplate({
                        'contacts|5-6':[{
                            'id|+1': 1,
                            name: '@CONTACT_FIRST_NAME',
                            lastname: '@CONTACT_LAST_NAME',
                            age:'@CONTACT_AGE'
                        
                        }]
                    }

                );

                data.contacts[0].id = 1;
                data.contacts[0].name = 'stephen';
                data.contacts[0].lastname = 'hawkings';
                data.contacts[0].age = '56';

                
      
                return data;
            },
        

        generateuniquecontacts = function () {
            var data = $.mockJSON.generateFromTemplate({
                'contacts|5-6': [{
                    'id|+1': 2,
                    name: '@CONTACT_FIRST_NAME',
                    lastname: '@CONTACT_LAST_NAME',
                    age: '@CONTACT_AGE'

           
                }]
            }

            );

            data.contacts[0].id = 1;
            data.contacts[0].name = 'stephen';
            data.contacts[0].lastname = 'hawkings';
            data.contacts[0].age = '56';

       
            return data;
        };

            init();

            return {
            
                model: {
                    
                    generatecontacts: generatecontacts,
                    generateuniquecontacts:generateuniquecontacts
                }

            };

    })
