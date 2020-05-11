$(document).ready(function () {
    $(".ajax_editRow").click(function () {
        var nameTable = $(".ajax_selected_click option:selected").text();
        var key1 = $(this).closest("tr").find(".key1").text();
        var key2 = $(this).closest("tr").find(".key2").text();
        //var $row = $(this).parent().parent();
        //var $row = $(this).closest("tr");
        //var $tds = $row.find("td");
        //var rowval = ""
        //$.each($tds, function () {
        //    rowval = rowval+($(this).text());
        //});
        var dataModel = $('#dataTable');
        $.ajax({
            url: '/Home/ShowRow/',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: key1,key2: key2 },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); }
        });
    });


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
