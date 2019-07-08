(function () {
    $(function () {      
        var _goodsService = abp.services.app.goods;
        //获取已有货物列表(abp约定：把首字母写成小写，去掉Async)
        //_goodsService.getPagedGoods();

        var $mgrid = $("#goods-index-main-grid");//数据表格
        $mgrid.datagrid({
            abpMethod: _goodsService.getPagedGoods,
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
                { field: 'id', title: '货物编号', width: 80 }
                
            ]],
            columns: [[
                
                { field: 'goodsName', title: '货物名称', width: 120, sortable: true },
                { field: 'goodsManufacturer', title: '生成厂家', width: 120, sortable: true },
                { field: 'goodsProuductionDate', title: '生成日期', width: 120, sortable: true },
                { field: 'goodsModel', title: '规格型号', width: 120, sortable: true },
            ]]
        });

        //按键【添加货物】 绑定点击事件
        $("#btn-add-goods").click(function () {
            $('#goods-index-dlg').dialog('open').dialog('setTitle', '添加货物');
            $('#goods-fm').form('clear');
        });

        //按键【编辑货物】 绑定点击事件
        $("#btn-edit-goods").click(function () {
            var row = $("#goods-index-main-grid").datagrid('getSelected');
            var date_time = row.goodsProuductionDate.substr(0, 10);//去掉时分秒
            row.goodsProuductionDate = date_time;
            if (row) {
                $('#goods-index-dlg').dialog('open').dialog('setTitle', '编辑货物');
                $('#goods-fm').form('load', row);
            }
        });

        //按键【删除货物】 绑定点击事件
        $("#btn-delete-goods").click(function () {
            var row = $("#goods-index-main-grid").datagrid('getSelected');
            _goodsService.deleteGoods({ id:row.id }).done(function () { location.reload();});
        });

        //按键【保存】 绑定点击事件
        $("#btn-save-goods").click(function () {
            var goodsEditDto = $('#goods-fm').serializeFormToObject();
            _goodsService.createOrUpdateGoods({ goodsEditDto }).done(function () {
                //$('#goods-index-dlg').dialog('close');//关闭模态框
                location.reload();
            });
        });
    });
})();