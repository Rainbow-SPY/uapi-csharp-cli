using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "bilibili", "user" });
            o.Description = "获取bilibili用户的相关公开数据";
            var o_uid = new Option<string>("--uid")
            {
                Required = true, Description = "bilibili UUID"
            };
            o.Options.Add(o_uid);
            o.SetAction(parseResult =>
            {
                var uid = parseResult.GetValue(o_uid);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = bilibili.GetUserData(uid, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}