(function () {
    $(function () {
        var _customerService = abp.services.app.customer;
        //获取已有客户列表(abp约定：把首字母写成小写，去掉Async)
        //_customerService.getPagedcustomer();

        var $mgrid = $("#customer-index-main-grid");//数据表格
        $mgrid.datagrid({
            abpMethod: _customerService.getPagedCustomer,
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
                { field: 'id', title: '客户编号', width: 80 }

            ]],
            columns: [[

                { field: 'customerName', title: '客户名称', width: 120, sortable: true },
            ]]
        });

        //按键【添加客户】 绑定点击事件
        $("#btn-add-customer").click(function () {
            $('#customer-index-dlg').dialog('open').dialog('setTitle', '添加客户');
            $('#customer-fm').form('clear');
        });

        //按键【编辑客户】 绑定点击事件
        $("#btn-edit-customer").click(function () {
            var row = $("#customer-index-main-grid").datagrid('getSelected');
            if (row) {
                $('#customer-index-dlg').dialog('open').dialog('setTitle', '编辑客户');
                $('#customer-fm').form('load', row);
            }
        });

        //按键【删除客户】 绑定点击事件
        $("#btn-delete-customer").click(function () {
            var row = $("#customer-index-main-grid").datagrid('getSelected');
            _customerService.deleteCustomer({ id: row.id }).done(function () { location.reload(); });
        });

        //按键【保存】 绑定点击事件
        $("#btn-save-customer").click(function () {
            var customerEditDto = $('#customer-fm').serializeFormToObject();
            _customerService.createOrUpdateCustomer({ customerEditDto }).done(function () {
                //$('#customer-index-dlg').dialog('close');//关闭模态框
                location.reload();
            });
        });
    });
})();