using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_minecraft_GetHistoryName
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "history-name" });
            o.Description = "查询Minecraft玩家的历史昵称";
            var op = new Option<string>("--name")
            {
                Required = true, Description = "昵称或UUID"
            };
            o.Options.Add(op);
            var os = new Option<Minecraft.SearchType>("--search-type")
            {
                Required = true, Description = "指定以何种方式查询"
            };
            o.Options.Add(os);
            o.SetAction(parseResult =>
            {
                var param = parseResult.GetValue(op);
                var searchType = parseResult.GetValue(os);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Minecraft.GetHistoryName(param, searchType, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}