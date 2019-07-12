(function () {
    $(function () {
        var _inStockSummaryService = abp.services.app.inStockSummary;
        var _supplierService = abp.services.app.supplier;
        var _userService = abp.services.app.user;
        var param = { 'maxResultCount': 500, 'skipCount': 0, 'sorting': 'id' };
   
        var $mgrid = $("#in-stock-index-main-grid");//数据表格
        $mgrid.datagrid({
            abpMethod: _inStockSummaryService.getPagedInStockSummary,
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
                { field: 'inStockCode', title: '入库单号', width: 80 }
                
            ]],
            columns: [[                
                { field: 'supplierName', title: '供应商', width: 120},
                { field: 'operatingUser', title: '操作人', width: 120},
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
            //获取当前登录用户并展示到页面中
            _userService.getNowLoginUser().done(function (d) {
                //console.log(d)
                $("#op_user").val(d.surname+d.name+" ("+d.userName+")");
                $("#op_user_id").val(d.id);
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
                onAfterEdit: function (rowIndex, rowData, changes) {
                    if (rowData.inStockAmount == undefined || rowData.inStockPrice == undefined) {
                        alert("当前行您还有没填写的信息呢~，请继续填写！")
                    } else {
                        rowData.price = rowData.inStockPrice * rowData.inStockAmount;//计算金额
                        $("#in-stock-index-sub-grid").datagrid("refreshRow", rowIndex);//刷新当前行

                        var _goodsDetailGrid = $("#in-stock-index-sub-grid");
                        var _goodsFromRead = _goodsDetailGrid.datagrid('getData').rows;
                        var totalAmount = 0.0;
                        for (var i = 0; i < _goodsFromRead.length; i++) {
                            if (_goodsFromRead[i].inStockAmount == undefined
                                || _goodsFromRead[i].inStockPrice == undefined
                                || _goodsFromRead[i].price == undefined
                            ) {
                                continue;
                            } else {
                                totalAmount += _goodsFromRead[i].price;
                            }
                            
                        }//计算当前已填写的总金额
                        $("#totalAmount").val(totalAmount);
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
            //console.log(goodsList);
        });
        //对【保存追加】按钮绑定事件
        $("#btn-save-goods-append").click(function () {
            
            var rows = $("#in-stock-append-goods-grid").datagrid('getSelections');
            for (var i = 0; i < rows.length; i++) {
                //去重复
                if (isRepeat(goodsList, rows[i])) {
                continue;
                }else {
                    $("#in-stock-index-sub-grid").datagrid("appendRow", rows[i]);
                }
                
            }
            $("#in-stock-add-goods-dlg").dialog('close');//关闭对话框

            
        });

        //传入goodsList和一个数据，判断这个数据是否在这个list中
        function isRepeat(gList,row) {            
            for (var i = 0; i < gList.length; i++) {
                if (gList[i]['id'] == row['id']) {
                    return true;
                }
            }
            return false;
        }

        //对【完成编辑】按钮绑定事件
        $("#btn-finish-edit-in-stock").click(function () {
            var _goodsDetailGrid = $("#in-stock-index-sub-grid");
            //结束编辑后，填写的金额和数量信息才会展示出来
            _goodsDetailGrid.datagrid('endEdit', lastRowIndex);
        });

        //对【保存】按钮绑定事件(提交入库单)
        $("#btn-submit-in-stock").click(function () {
            var _$form = $("#in-stock-fm");//获取form对象
            //校验表单是否合法
            if (!_$form.valid()) {
                alert("请填写必填项！");
                return;
            }
            //判断货物明细是否为0
            if (goodsList == undefined || goodsList.length == 0) {
                alert("请追加货物！");
                return;
            }
            //判断货物明细中的单价/数量是否填写
            var _goodsDetailGrid = $("#in-stock-index-sub-grid");
            //结束编辑后，填写的金额和数量信息才会展示出来
            _goodsDetailGrid.datagrid('endEdit', lastRowIndex);

            var _goodsFromRead = _goodsDetailGrid.datagrid('getData').rows;
            var totalAmount = 0;
            for (var i = 0; i < _goodsFromRead.length; i++) {
                if (_goodsFromRead[i].inStockAmount == undefined
                    || _goodsFromRead[i].inStockPrice == undefined
                    || _goodsFromRead[i].price == undefined
                ) {
                    alert("请添加货物明细中的单价和金额！");
                    return;
                }
                totalAmount += _goodsFromRead[i].price;
            }
            
            $("#totalAmount").val(totalAmount);
            //获取数据
            var formDat = _$form.serializeFormToObject();
            //console.log(formDat);
            //console.log(_goodsFromRead);

            //调用提交服务
            var inStockSummaryEditDto = formDat;
            inStockSummaryEditDto['user'] = { id: inStockSummaryEditDto.user }
            inStockSummaryEditDto['supplier'] = { id: inStockSummaryEditDto.supplier }
            var inStockDetails = _goodsFromRead;
            for (var i = 0; i < inStockDetails.length; i++) {
                inStockDetails[i]['goodsId'] = inStockDetails[i]['id'];
            }
            inStockSummaryEditDto['inStockDetails'] = inStockDetails;
            _inStockSummaryService.doInStock({ inStockSummaryEditDto: inStockSummaryEditDto }).done(function () { });
            console.log(inStockSummaryEditDto);
            //刷新页面
            location.reload();
        });

    });
})();