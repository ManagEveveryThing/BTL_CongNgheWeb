$(document).ready(function () {
    $(".ajax_editRow").click(function (e) {
        e.preventDefault();
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
            url: '/Admin/TableTab/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: key1, key2: key2, actionName:"ModifyRow"},
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
        });
        
    });
    $(".ajax_deleteRow").click(function (e) {
        e.preventDefault();
        var dataModel = $('#myModal');
        var nameTable = $(".ajax_selected_click option:selected").text();
        var key1 = $(this).closest("tr").find(".key1").text();
        var key2 = $(this).closest("tr").find(".key2").text();
        $.ajax({
            url: '/Admin/TableTab/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: key1, key2: key2, actionName: 'DeleteRow' },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
        });
    });
    $(".ajax_add_item").click(function (e) {
        e.preventDefault();
        var nameTable = $(".ajax_selected_click option:selected").text();
        var dataModel = $('#myModal');
        
        $.ajax({
            url: '/Admin/TableTab/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: null, key2: null, actionName: 'AddRow'},
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
        });
    });
    $(".ajax_selected_click").change(function (e) {
        e.preventDefault();
        var nameTb = $(".ajax_selected_click option:selected").text();
        var page = $('.cur_page').text();
        var dataModel = $('#dataTable');
        $.ajax({
            url: '/Admin/TableTab/getTableData/',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTb, page: page },
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
        ///
        


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
            if ($('#imageUploadForm').length)         
            {
                var totalFiles = document.getElementById("imageUploadForm").files.length;
                for (var i = 0; i < totalFiles; i++) {
                    var file = document.getElementById("imageUploadForm").files[i];
                    formdata.append("imageUploadForm", file);
                } 
            }
            $.ajax({
                url: '/Admin/TableTab/AddRow/' + nameTb,
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
                if ($('#imageUploadForm').length) {
                    var totalFiles = document.getElementById("imageUploadForm").files.length;
                    for (var i = 0; i < totalFiles; i++) {
                        var file = document.getElementById("imageUploadForm").files[i];
                        formdata.append("imageUploadForm", file);
                    }
                }
                $.ajax({
                    url: '/Admin/TableTab/ModifyRow/' + nameTb,
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
                    url: '/Admin/TableTab/DeleteRow/' + nameTb,
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
    $(".chose_Role").change(function (e) {
        e.preventDefault();
        var ussername = $(this).closest("tr").find(".username_fied").text();
        var quyen = $(this).closest("tr").find(".chose_Role option:selected").text();
        $.ajax({
            url: '/Admin/TableTab/changeRole',
            contentType: 'application/html ; charset:utf-8',
            data: { username: ussername, role: quyen },
            type: 'GET',
            dataType: 'html',
            success: function () {  }
        });
    });
    // 
    $(".numb_page").click(function (e) {
        e.preventDefault();
        var thisPage = $(this);
        var page = $(this).text();
        var nameTb = $(".ajax_selected_click option:selected").text();
        var dataModel = $('#dataTable');
        $(".pading_contain").find('li').each(function () {
            $(this).removeClass('active');
        });
        $.ajax({
            url: '/Admin/TableTab/getTableData',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTb, Curpage: page },
            type: 'Get',
            dataType: 'html',
            success: function (result) {
                dataModel.empty().append(result);
                thisPage.addClass('active');
            }
        });
    });

    $(".pre_page1").click(function (e) {
        e.preventDefault();
        var thisPage = $(".pading_contain").find('li.active');
        var page = thisPage.text();
        if (page != "1") {
            page = (parseInt(page) - 1).toString();
            var dataModel = $('#dataTable'); 
            $(".pading_contain").find('li').each(function () {
                $(this).removeClass('active');
            });
            var activePage = $('#' + page)
            $.ajax({
                url: '/Admin/TableTab/getTableData',
                contentType: 'application/html ; charset:utf-8',
                data: { tableName: nameTb, Curpage: page },
                type: 'Get',
                dataType: 'html',
                success: function (result) {
                    dataModel.empty().append(result);
                    activePage.addClass('active');
                }
            });
        }
    });

    $(".next_page1").click(function (e) {
        e.preventDefault();
        var thisPage = $(".pading_contain").find('li.active');
        var page = thisPage.text();
        var sumpage = $('.sun_page').text();
        if (page != sumpage) {
            page = (parseInt(page) + 1).toString();
            var dataModel = $('#dataTable');
            $(".pading_contain").find('li').each(function () {
                $(this).removeClass('active');
            });
            var activePage = $('#' + page)
            $.ajax({
                url: '/Admin/TableTab/getTableData',
                contentType: 'application/html ; charset:utf-8',
                data: { tableName: nameTb, Curpage: page },
                type: 'Get',
                dataType: 'html',
                success: function (result) {
                    dataModel.empty().append(result);
                    activePage.addClass('active');
                }
            });
        }
    });
});
//$('#myModal').modal({
//    remote: url,
//    refresh: false
//});