using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_bilibili_user_data_1 = CliCommandTree.GetOrAdd(root, new[] { "bilibili", "user-data" });
            cmd_bilibili_user_data_1.Description = "获取bilibili用户的相关公开数据";
            var opt_bilibili_user_data_1_uid = new Option<string>("--uid")
            {
                Required = true, Description = "bilibili UUID"
            };
            cmd_bilibili_user_data_1.Options.Add(opt_bilibili_user_data_1_uid);
            cmd_bilibili_user_data_1.SetAction(parseResult =>
            {
                var uid = parseResult.GetValue(opt_bilibili_user_data_1_uid);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = bilibili.GetUserData(uid, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}