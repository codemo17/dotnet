define('my.region',
    ['jquery'],
    function ($) {

        var my = my || { };

        my.region =  function (element) {
            var activeview,
                elm = element;

            this.close = function (view) {
                if (view ) {
                    view.close();

                }


            };

            this.open = function (root, view, options, mode) {
                if (root && view) {

                    $(activeview.el).detach();

                    var direction = (options ||{}).direction || { direction: 'left' },
                        mode = mode || 'slide';

                    root.$(elm).hide('highlight', 1500, function() {

                        root.$(elm).show('blind', 1500);
                        root.$(elm).html(view.el);
                        if (view.onshow) {
                            view.onshow();
                        }
                    });

                }
            };

            this.show = function (root, view, direction, mode) {

                this.close(activeview);
                activeview = view;
                this.open(root, view, direction, mode);


            };
        };
        
        return my.region;

    });
