using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetVideoData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_bilibili_video_data_1 = CliCommandTree.GetOrAdd(root, new[] { "bilibili", "video-data" });
            cmd_bilibili_video_data_1.Description = "获取哔哩哔哩视频的详细信息";
            var opt_bilibili_video_data_1_video_id = new Option<string>("--video-id")
            {
                Required = true, Description = "视频AID/BVID"
            };
            cmd_bilibili_video_data_1.Options.Add(opt_bilibili_video_data_1_video_id);
            var opt_bilibili_video_data_1_IDType = new Option<bilibili.BiliVideoIDType>("--id-type")
            {
                Required = true, Description = "视频ID的类型"
            };
            cmd_bilibili_video_data_1.Options.Add(opt_bilibili_video_data_1_IDType);
            cmd_bilibili_video_data_1.SetAction(parseResult =>
            {
                var video_id = parseResult.GetValue(opt_bilibili_video_data_1_video_id);
                var IDType = parseResult.GetValue(opt_bilibili_video_data_1_IDType);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = bilibili.GetVideoData(video_id, IDType, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}