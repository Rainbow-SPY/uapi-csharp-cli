using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_DetectTrackingCarrier
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "misc", "detect-tracking-carrier" });
            o.Description = "识别快递公司 不确定手里的快递单号属于哪家快递公司？这个接口专门做识别，不查物流。";
            var o_t = new Option<string>("--tracking-number")
            {
                Required = true, Description = "快递单号"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var tracking_number = parseResult.GetValue(o_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.DetectTrackingCarrier(tracking_number, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}