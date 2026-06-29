using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetTrackingInfo
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_misc_tracking_info_1 = CliCommandTree.GetOrAdd(root, new[] { "misc", "tracking-info" });
            cmd_misc_tracking_info_1.Description = "查询快递物流信息";
            var opt_misc_tracking_info_1_tracking_number = new Option<string>("--tracking-number")
            {
                Required = true, Description = "快递单号，通常是一串10-20位的数字或字母数字组合。"
            };
            cmd_misc_tracking_info_1.Options.Add(opt_misc_tracking_info_1_tracking_number);
            var opt_misc_tracking_info_1_carrier_code = new Option<string>("--carrier-code")
            {
                Required = false, Description = "快递公司编码(可选)。不填写时系统会自动识别，填写后可加快查询速度。", DefaultValueFactory = _ => ""
            };
            cmd_misc_tracking_info_1.Options.Add(opt_misc_tracking_info_1_carrier_code);
            var opt_misc_tracking_info_1_phone = new Option<string>("--phone")
            {
                Required = false, Description = "收件人手机尾号，4位数字(可选)。部分快递公司需要验证手机尾号才能查询详细物流信息。",
                DefaultValueFactory = _ => ""
            };
            cmd_misc_tracking_info_1.Options.Add(opt_misc_tracking_info_1_phone);
            cmd_misc_tracking_info_1.SetAction(parseResult =>
            {
                var tracking_number = parseResult.GetValue(opt_misc_tracking_info_1_tracking_number);
                var carrier_code = parseResult.GetValue(opt_misc_tracking_info_1_carrier_code);
                var phone = parseResult.GetValue(opt_misc_tracking_info_1_phone);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.GetTrackingInfo(tracking_number, carrier_code, phone, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}