using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Hotboard_NeteaseMusic
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_hotboard_netease_music_hotboard_1 =
                CliCommandTree.GetOrAdd(root, new[] { "hotboard", "netease-music-hotboard" });
            cmd_hotboard_netease_music_hotboard_1.Description = "获取网易云音乐歌曲的热榜";
            cmd_hotboard_netease_music_hotboard_1.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Hotboard.GetNeteaseMusicHotboard(Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}