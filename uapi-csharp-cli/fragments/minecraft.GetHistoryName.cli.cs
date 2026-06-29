using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_minecraft_GetHistoryName
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_minecraft_history_name_1 = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "history-name" });
            cmd_minecraft_history_name_1.Description = "查询Minecraft玩家的历史昵称";
            var opt_minecraft_history_name_1_param = new Option<string>("--param")
            {
                Required = true, Description = "昵称或UUID"
            };
            cmd_minecraft_history_name_1.Options.Add(opt_minecraft_history_name_1_param);
            var opt_minecraft_history_name_1_searchType = new Option<Minecraft.SearchType>("--search-type")
            {
                Required = true, Description = "指定以何种方式查询"
            };
            cmd_minecraft_history_name_1.Options.Add(opt_minecraft_history_name_1_searchType);
            cmd_minecraft_history_name_1.SetAction(parseResult =>
            {
                var param = parseResult.GetValue(opt_minecraft_history_name_1_param);
                var searchType = parseResult.GetValue(opt_minecraft_history_name_1_searchType);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Minecraft.GetHistoryName(param, searchType, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}