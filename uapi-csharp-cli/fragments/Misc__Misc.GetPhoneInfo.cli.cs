using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetPhoneInfo
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_misc_phone_info_1 = CliCommandTree.GetOrAdd(root, new[] { "misc", "phone-info" });
            cmd_misc_phone_info_1.Description = "查询中国大陆手机号码的归属地";
            var opt_misc_phone_info_1_phoneNumber = new Option<string>("--phone-number")
            {
                Required = true, Description = "指定要查询的手机号码"
            };
            cmd_misc_phone_info_1.Options.Add(opt_misc_phone_info_1_phoneNumber);
            cmd_misc_phone_info_1.SetAction(parseResult =>
            {
                var phoneNumber = parseResult.GetValue(opt_misc_phone_info_1_phoneNumber);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.GetPhoneInfo(phoneNumber, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}