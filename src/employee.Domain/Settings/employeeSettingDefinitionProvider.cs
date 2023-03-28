using Volo.Abp.Settings;

namespace employee.Settings;

public class employeeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(employeeSettings.MySetting1));
    }
}
