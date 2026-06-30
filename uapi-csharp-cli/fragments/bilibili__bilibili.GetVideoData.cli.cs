using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetVideoData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "bilibili", "video" });
            o.Description = "获取哔哩哔哩视频的详细信息";
            var o_vid = new Option<string>("--vid")
            {
                Required = true, Description = "视频AID/BVID"
            };
            o.Options.Add(o_vid);
            var o_vt = new Option<bilibili.BiliVideoIDType>("--type")
            {
                Required = true, Description = "视频ID的类型"
            };
            o.Options.Add(o_vt);
            o.SetAction(parseResult =>
            {
                var video_id = parseResult.GetValue(o_vid);
                var IDType = parseResult.GetValue(o_vt);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = bilibili.GetVideoData(video_id, IDType, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}