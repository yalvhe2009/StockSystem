﻿using System.Collections.Generic;
using StockSystem.Roles.Dto;

namespace StockSystem.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}