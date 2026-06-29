using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_EpicGames_GetFreeGames
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_epic_games_data_json_1 = CliCommandTree.GetOrAdd(root, new[] { "epic-games", "data-json" });
            cmd_epic_games_data_json_1.Description = "请求Epic Games 当前免费游戏的方法";
            cmd_epic_games_data_json_1.SetAction(parseResult =>
            {
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = EpicGames.GetDataJson(AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}