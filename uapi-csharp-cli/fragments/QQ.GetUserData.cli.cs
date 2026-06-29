using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_QQ_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_qq_user_data_1 = CliCommandTree.GetOrAdd(root, new[] { "qq", "user-data" });
            cmd_qq_user_data_1.Description = "获取QQ用户公开摘要";
            var opt_qq_user_data_1_qq = new Option<string>("--qq")
            {
                Required = true, Description = "QQ号"
            };
            cmd_qq_user_data_1.Options.Add(opt_qq_user_data_1_qq);
            cmd_qq_user_data_1.SetAction(parseResult =>
            {
                var qq = parseResult.GetValue(opt_qq_user_data_1_qq);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = QQ.GetUserData(qq, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}