using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Hotboard_NeteaseMusic
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_hotboard_netease_music_hotboard_1 =
                CliCommandTree.GetOrAdd(root, new[] { "hotboard", "netease-music-hotboard" });
            cmd_hotboard_netease_music_hotboard_1.Description = "获取网易云音乐歌曲的热榜";
            cmd_hotboard_netease_music_hotboard_1.SetAction(parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Hotboard.GetNeteaseMusicHotboard(Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}