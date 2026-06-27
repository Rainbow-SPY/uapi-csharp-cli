using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetTrackingCarriers
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_misc_tracking_carriers_1 = CliCommandTree.GetOrAdd(root, new[] { "misc", "tracking-carriers" });
            cmd_misc_tracking_carriers_1.Description = "获取支持的快递公司列表";
            cmd_misc_tracking_carriers_1.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Misc.GetTrackingCarriers(Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}