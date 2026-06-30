using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetPhoneInfo
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "misc", "phone-info" });
            o.Description = "查询中国大陆手机号码的归属地";
            var o_n = new Option<string>("--phone-number")
            {
                Required = true, Description = "指定要查询的手机号码"
            };
            o.Options.Add(o_n);
            o.SetAction(parseResult =>
            {
                var phoneNumber = parseResult.GetValue(o_n);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.GetPhoneInfo(phoneNumber, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}