namespace employee.Permissions;

public static class employeePermissions
{
    public const string GroupName = "employee";

    //Add your own permission names. Example:

    public static class Emps
    {
        public const string Default = GroupName + ".Emps";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class HRS
    {
        public const string Default = GroupName + ".HRS";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

}
