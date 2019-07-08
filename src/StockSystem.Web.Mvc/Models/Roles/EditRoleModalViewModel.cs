using Abp.AutoMapper;
using StockSystem.Roles.Dto;
using StockSystem.Web.Models.Common;

namespace StockSystem.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public EditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }

        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
