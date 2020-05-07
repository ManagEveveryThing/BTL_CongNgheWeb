var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.ajax_selected_click').off('select').on('select', function (e) {
            e.preventDefault();
        });
    }
}
user.init();

