﻿using employee.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace employee.Permissions;


public class employeePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var employeeGroup = context.AddGroup(employeePermissions.GroupName, L("Permission:employee"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(employeePermissions.MyPermission1, L("Permission:MyPermission1"));
        var EmpsPermission = employeeGroup.AddPermission(employeePermissions.Emps.Default, L("Permission:Emps"));
        EmpsPermission.AddChild(employeePermissions.Emps.Create, L("Permission:Emps.Create"));
        EmpsPermission.AddChild(employeePermissions.Emps.Edit, L("Permission:Emps.Edit"));
        EmpsPermission.AddChild(employeePermissions.Emps.Delete, L("Permission:Emps.Delete"));

        var hrPermissions = employeeGroup.AddPermission(employeePermissions.HRS.Default, L("Permission:HRS"));

        hrPermissions.AddChild(employeePermissions.HRS.Create, L("Permission:HRS.Create"));
        hrPermissions.AddChild(employeePermissions.HRS.Edit, L("Permission:HRS.Edit"));
        hrPermissions.AddChild(employeePermissions.HRS.Delete, L("Permission:HRS.Delete"));
    }

    



    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<employeeResource>(name);
    }
}
