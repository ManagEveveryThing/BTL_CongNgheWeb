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
        var dataModel = $('#myModal');
        $.ajax({
            url: '/Home/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: key1, key2: key2, actionName:"ModifyRow"},
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
        });
        
    });

    $(".ajax_deleteRow").click(function () {
        var dataModel = $('#myModal');
        var nameTable = $(".ajax_selected_click option:selected").text();
        var key1 = $(this).closest("tr").find(".key1").text();
        var key2 = $(this).closest("tr").find(".key2").text();
        $.ajax({
            url: '/Home/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: key1, key2: key2, actionName: 'DeleteRow' },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
        });
    });

    $(".ajax_add_item").click(function () {
        
        var nameTable = $(".ajax_selected_click option:selected").text();
        var dataModel = $('#myModal');
        $.ajax({
            url: '/Home/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: null, key2: null, actionName: 'AddRow'},
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
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
    $(".ajax_btn_submit").click(function (e) {
        e.preventDefault();
        var actionName = $(".ajax_btn_submit").val();
        var nameTb = $(".ajax_selected_click option:selected").text();
        var dataModel = $('#dataTable');
        var dataModal = $('#myModal');
        var formdata = new FormData();
        var count = 0;
        var tableName = $('.fied_tableName').val();
        formdata.append("TableName", tableName);
        $('.input_vaule').each(function () {
            formdata.append(count.toString(), $(this).val());
            count++;
        });
        var count = 50;
        $('.input_dataO').each(function () {
            formdata.append(count.toString(), $(this).val());
            count++;
        });
        if (actionName == "Add") {
            $.ajax({
                url: '/Home/AddRow/' + nameTb,
                contentType: 'application/html ; charset:utf-8',
                contentType: false,
                processData: false, // Not to process data
                data: formdata,
                async: false,
                type: 'POST',
                dataType: 'html',
                success: function (result) { dataModel.empty().append(result); dataModal.modal('hide'); }
            });
        }
        else {
            if (actionName == "Save change") {
                $.ajax({
                    url: '/Home/ModifyRow/' + nameTb,
                    contentType: 'application/html ; charset:utf-8',
                    contentType: false,
                    processData: false, // Not to process data
                    data: formdata,
                    async: false,
                    type: 'POST',
                    dataType: 'html',
                    success: function (result) { dataModel.empty().append(result); dataModal.modal('hide'); }
                });
            }
            else {
                $.ajax({
                    url: '/Home/DeleteRow/' + nameTb,
                    contentType: 'application/html ; charset:utf-8',
                    contentType: false,
                    processData: false, // Not to process data
                    data: formdata,
                    async: false,
                    type: 'POST',
                    dataType: 'html',
                    success: function (result) { dataModel.empty().append(result); dataModal.modal('hide'); }
                });
            }
        }
        
    });
    
});
//$('#myModal').modal({
//    remote: url,
//    refresh: false
//});