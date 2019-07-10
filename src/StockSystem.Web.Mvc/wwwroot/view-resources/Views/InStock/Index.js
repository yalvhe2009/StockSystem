(function () {
    $(function () {      
        var _inStockSummaryService = abp.services.app.inStockSummary;
        var _supplierService = abp.services.app.supplier;
        var param = { 'maxResultCount': 500, 'skipCount': 0, 'sorting': 'id' };

        
        
        var $mgrid = $("#in-stock-index-main-grid");//数据表格
        $mgrid.datagrid({
            abpMethod: _inStockSummaryService.getPaged,
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
                { field: 'id', title: '入库单号', width: 80 }
                
            ]],
            columns: [[                
                { field: 'supplier', title: '供应商', width: 120},
                { field: 'user', title: '操作人', width: 120},
                { field: 'operatingTime', title: '操作时间', width: 120 },
                { field: 'totalAmount', title: '总金额', width: 120},
            ]]
        });
        var lastRowIndex = -1;
        var goodsList = [];
        //按键【新建入库单】 绑定点击事件
        $("#btn-new-in-stock").click(function () {
            $('#in-stock-index-dlg').dialog('open').dialog('setTitle', '新建入库单');
            $('#in-stock-fm').form('clear');//清空表单
            //从服务端查询数据并创建供应商的下拉框
            _supplierService.getPagedSupplier(param).done(function (d) {
                var supplierList = [];
                for (var i = 0; i < d.totalCount; i++) {
                    var ele = d.items[i];
                    supplierList.push(ele);
                }
                $('#supplier').combobox({
                    data: supplierList,
                    valueField: 'id',
                    textField: 'supplierName'
                });
            });
            
            $("#in-stock-index-sub-grid").datagrid({
                data: goodsList,
                method: 'post',
                idField: 'id',
                fit: false,
                sortName: 'id',
                sortOrder: 'asc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50],
                pagination: false,
                rownumbers: false,
                fitColumns: true,
                toolbar: '#sub-toolbar',
                singleSelect: true,
                frozenColumns: [[
                    { field: 'id', title: '货物编号', width: 80 }
                ]],
                columns: [[

                    { field: 'goodsName', title: '货物名称', width: 120, sortable: true },
                    { field: 'goodsManufacturer', title: '生成厂家', width: 120, sortable: true },
                    { field: 'goodsProuductionDate', title: '生成日期', width: 120, sortable: true },
                    { field: 'goodsModel', title: '规格型号', width: 120, sortable: true },
                    {field: 'inStockPrice', title: '单价', width: 120,editor: { type: 'numberbox', options: { required: true, precision: 2 } } },
                    { field: 'inStockAmount', title: '数量', width: 120, editor: { type: 'numberbox', options: { required: true, precision: 0 } }  },
                    { field: 'price', title: '金额', width: 120, sortable: true },
                ]],
                onClickRow: function (rowIndex) {//点击一行时触发
                    if (lastRowIndex != rowIndex) {
                        $(this).datagrid('endEdit', lastRowIndex);//结束上行编辑
                        $(this).datagrid('beginEdit', rowIndex);//开始本行编辑
                        lastRowIndex = rowIndex;
                    }
                    
                },

            });
        });

        // 对【追加货物】按钮绑定事件
        $("#btn-append-goods-in-stock").click(function () {
            $("#in-stock-add-goods-dlg").dialog('open').dialog('setTitle', '追加货物');
            var _goodsService = abp.services.app.goods;//货物服务

            $("#in-stock-append-goods-grid").datagrid({
                abpMethod: _goodsService.getPagedGoods,
                method: 'post',
                idField: 'id',
                fit: false,
                sortName: 'id',
                sortOrder: 'asc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50],
                pagination: false,
                rownumbers: false,
                fitColumns: true,
                //toolbar: '#sub-toolbar',
                //singleSelect: true,
                frozenColumns: [[
                    { field: 'id', title: '货物编号', width: 80 }

                ]],
                columns: [[

                    { field: 'goodsName', title: '货物名称', width: 120, sortable: false },
                    { field: 'goodsManufacturer', title: '生成厂家', width: 120, sortable: false },
                    { field: 'goodsProuductionDate', title: '生成日期', width: 120, sortable: false },
                    { field: 'goodsModel', title: '规格型号', width: 120, sortable: false },
                ]]
            });
            
            $("#in-stock-append-goods-grid").datagrid('unselectAll');//取消所有已经选中项

        });
        //对【删除货物】按钮绑定事件
        $("#btn-del-goods-in-stock").click(function () {
            var rows = $("#in-stock-index-sub-grid").datagrid('getSelections');
            for (var i = 0; i < rows.length; i++) {
                var index = $('#in-stock-index-sub-grid').datagrid('getRowIndex', rows[i]);
                $("#in-stock-index-sub-grid").datagrid("deleteRow",index);
            }
            console.log(goodsList);
        });
        //对【保存追加】按钮绑定事件
        $("#btn-save-goods-append").click(function () {
            var rows = $("#in-stock-append-goods-grid").datagrid('getSelections');
            for (var i = 0; i < rows.length; i++) {
                //TODO 去重复
                $("#in-stock-index-sub-grid").datagrid("appendRow", rows[i]);
            }
            $("#in-stock-add-goods-dlg").dialog('close');//关闭对话框

            
        });
    });
})();