using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_EpicGames_GetFreeGames
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_epic_games_data_json_1 = CliCommandTree.GetOrAdd(root, new[] { "epic-games", "data-json" });
            cmd_epic_games_data_json_1.Description = "请求Epic Games 当前免费游戏的方法";
            cmd_epic_games_data_json_1.SetAction(async parseResult =>
            {
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await EpicGames.GetDataJson(AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}