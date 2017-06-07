define('config',
       ['mocks'],
       function (mocks) {

           var

               offline = true,
               _mocked = true,
               
               mockit=function (value) {
                   if(value) {
                       _mocked = value;
                       init();
                   }
                   return _mocked;
               },

               dataservicesinit = function() {
               },
               init = function() {

                   if (_mocked) {
                       dataservicesinit = mocks.init;
                   }

                   dataservicesinit();

               };
           init();

           return {
               offline:offline,
               mockit:mockit,
               dataservicesinit: dataservicesinit
           };
               

       }
)