using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_DetectTrackingCarrier
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_misc_detect_tracking_carrier_1 =
                CliCommandTree.GetOrAdd(root, new[] { "misc", "detect-tracking-carrier" });
            cmd_misc_detect_tracking_carrier_1.Description = "识别快递公司 不确定手里的快递单号属于哪家快递公司？这个接口专门做识别，不查物流。";
            var opt_misc_detect_tracking_carrier_1_tracking_number = new Option<string>("--tracking-number")
            {
                Required = true, Description = "快递单号"
            };
            cmd_misc_detect_tracking_carrier_1.Options.Add(opt_misc_detect_tracking_carrier_1_tracking_number);
            cmd_misc_detect_tracking_carrier_1.SetAction(async parseResult =>
            {
                var tracking_number = parseResult.GetValue(opt_misc_detect_tracking_carrier_1_tracking_number);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Misc.DetectTrackingCarrier(tracking_number, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}