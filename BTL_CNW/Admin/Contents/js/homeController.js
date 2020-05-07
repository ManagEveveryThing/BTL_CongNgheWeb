//var user = {
//    init: function () {
//        user.registerEvents();
//    },
//    registerEvents: function () {
//        $(".ajax_selected_click").off('click').on('click', function (e) {
            
//            var selectOption = $(this);
//            var name = selectOption.data(slected_Click);
//            var dataModel = $('#dataTable');
//            $.ajax({
//                url: '/Admin/Home/GetTableData/' ,
//                contentType: 'application/html ; charset:utf-8',
//                data: { tableName: name },
//                type: 'Get',
//                dataType: 'html',
//                success: function (result) { dataModel.empty().append(result); }
//            });
//        });
//    }
//}
//user.init();

$(document).ready(function () {
    $(".ajax_selected_click").change(function () {
        var nameTb = $(".ajax_selected_click option:selected").text();
        var dataModel = $('#dataTable');
        $.ajax({
            url: '/Home/getTableData/' + nameTb,
                contentType: 'application/html ; charset:utf-8',
                data: { tableName: nameTb },
                type: 'GET',
                dataType: 'html',
                success: function (result) { dataModel.empty().append(result); }
            });
    });
});

