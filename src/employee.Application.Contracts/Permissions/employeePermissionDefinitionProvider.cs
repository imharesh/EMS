using employee.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace employee.Permissions;

public class employeePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(employeePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(employeePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<employeeResource>(name);
    }
}
