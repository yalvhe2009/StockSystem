(function () {
    $(function () {
        var _supplierService = abp.services.app.supplier;
        //获取已有供应商列表(abp约定：把首字母写成小写，去掉Async)
        //_supplierService.getPagedsupplier();

        var $mgrid = $("#supplier-index-main-grid");//数据表格
        $mgrid.datagrid({
            abpMethod: _supplierService.getPagedSupplier,
            //queryParams:,
            method: 'post',
            idField: 'id',
            fit: false,
            sortName: 'id',
            sortOrder: 'asc',
            pageSize: 10,
            pageList: [10, 20, 30, 40, 50],
            pagination: true,
            rownumbers: true,
            fitColumns: true,
            toolbar: '#toolbar',
            singleSelect: true,
            frozenColumns: [[
                { field: 'id', title: '供应商编号', width: 80 }

            ]],
            columns: [[

                { field: 'supplierName', title: '供应商名称', width: 120, sortable: true },
            ]]
        });

        //按键【添加供应商】 绑定点击事件
        $("#btn-add-supplier").click(function () {
            $('#supplier-index-dlg').dialog('open').dialog('setTitle', '添加供应商');
            $('#supplier-fm').form('clear');
        });

        //按键【编辑供应商】 绑定点击事件
        $("#btn-edit-supplier").click(function () {
            var row = $("#supplier-index-main-grid").datagrid('getSelected');
            if (row) {
                $('#supplier-index-dlg').dialog('open').dialog('setTitle', '编辑供应商');
                $('#supplier-fm').form('load', row);
            }
        });

        //按键【删除供应商】 绑定点击事件
        $("#btn-delete-supplier").click(function () {
            var row = $("#supplier-index-main-grid").datagrid('getSelected');
            _supplierService.deleteSupplier({ id: row.id }).done(function () { location.reload(); });
        });

        //按键【保存】 绑定点击事件
        $("#btn-save-supplier").click(function () {
            var supplierEditDto = $('#supplier-fm').serializeFormToObject();
            _supplierService.createOrUpdateSupplier({ supplierEditDto }).done(function () {
                //$('#supplier-index-dlg').dialog('close');//关闭模态框
                location.reload();
            });
        });
    });
})();