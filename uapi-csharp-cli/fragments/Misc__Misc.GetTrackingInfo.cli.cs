using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetTrackingInfo
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "misc", "tracking-info" });
            o.Description = "查询快递物流信息";
            var o_tn = new Option<string>("--tracking-number")
            {
                Required = true, Description = "快递单号，通常是一串10-20位的数字或字母数字组合。"
            };
            o.Options.Add(o_tn);
            var o_cc = new Option<string>("--carrier-code")
            {
                Required = false, Description = "快递公司编码(可选)。不填写时系统会自动识别，填写后可加快查询速度。", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_cc);
            var o_p = new Option<string>("--phone")
            {
                Required = false, Description = "收件人手机尾号，4位数字(可选)。部分快递公司需要验证手机尾号才能查询详细物流信息。",
                DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_p);
            o.SetAction(parseResult =>
            {
                var tracking_number = parseResult.GetValue(o_tn);
                var carrier_code = parseResult.GetValue(o_cc);
                var phone = parseResult.GetValue(o_p);
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