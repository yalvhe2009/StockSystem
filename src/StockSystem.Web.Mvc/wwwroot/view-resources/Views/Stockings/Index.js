(function () {
    $(function () {
        var _goodsService = abp.services.app.stocking;

        var $mgrid = $("#stockings-index-main-grid");//数据表格
        var param = { 'maxResultCount': 10, 'skipCount': 0, 'sorting':'id'};
        
        _goodsService.getPagedStocking(param).done(function (d) {
            var data4grid = [];
            for (var i = 0; i < d.totalCount; i++) {
                var ele = d.items[i];
                var res = ele.goods;
                res['stockingNumber'] = ele.stockingNumber;
                data4grid.push(res);
            }

            $mgrid.datagrid({
                data: data4grid,
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
                //toolbar: '#toolbar',
                singleSelect: true,
                frozenColumns: [[
                    { field: 'id', title: '货物编号', width: 80 }

                ]],
                columns: [[

                    { field: 'goodsName', title: '货物名称', width: 120, sortable: true },
                    { field: 'goodsManufacturer', title: '生成厂家', width: 120, sortable: true },
                    { field: 'goodsProuductionDate', title: '生成日期', width: 120, sortable: true },
                    { field: 'goodsModel', title: '规格型号', width: 120, sortable: true },
                    { field: 'stockingNumber', title: '库存数量', width: 120, sortable: true },
                ]]
            });


        });
        
        
        
    });
})();