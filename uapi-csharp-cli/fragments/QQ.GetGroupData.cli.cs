using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_QQ_GetGroupData
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_qq_group_data_1 = CliCommandTree.GetOrAdd(root, new[] { "qq", "group-data" });
            cmd_qq_group_data_1.Description = "获取QQ群公开摘要";
            var opt_qq_group_data_1_group_id = new Option<string>("--group-id")
            {
                Required = true, Description = "QQ群组ID"
            };
            cmd_qq_group_data_1.Options.Add(opt_qq_group_data_1_group_id);
            cmd_qq_group_data_1.SetAction(async parseResult =>
            {
                var group_id = parseResult.GetValue(opt_qq_group_data_1_group_id);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await QQ.GetGroupData(group_id, AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}