
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
    $(".ajax_editRow").click(function () {
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

