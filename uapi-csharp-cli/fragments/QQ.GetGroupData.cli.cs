using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_QQ_GetGroupData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "qq", "group-data" });
            o.Description = "获取QQ群公开摘要";
            var og = new Option<string>("--group-id")
            {
                Required = true, Description = "QQ群组ID"
            };
            o.Options.Add(og);
            o.SetAction(parseResult =>
            {
                var group_id = parseResult.GetValue(og);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = QQ.GetGroupData(group_id, AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}