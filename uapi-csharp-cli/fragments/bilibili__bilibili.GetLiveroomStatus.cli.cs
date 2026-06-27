using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetLiveroomStatus
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_bilibili_liveroom_status_as_id_1 =
                CliCommandTree.GetOrAdd(root, new[] { "bilibili", "liveroom-status", "as-id" });
            cmd_bilibili_liveroom_status_as_id_1.Description = "使用用户 UID 作为形参请求B站直播间数据";
            var opt_bilibili_liveroom_status_as_id_1_mid = new Option<string>("--mid")
            {
                Required = true, Description = "用户的 UID"
            };
            cmd_bilibili_liveroom_status_as_id_1.Options.Add(opt_bilibili_liveroom_status_as_id_1_mid);
            cmd_bilibili_liveroom_status_as_id_1.SetAction(async parseResult =>
            {
                var mid = parseResult.GetValue(opt_bilibili_liveroom_status_as_id_1_mid);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await bilibili.GetLiveroomStatus.AsID(mid, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_bilibili_liveroom_status_as_liveroom_id_2 =
                CliCommandTree.GetOrAdd(root, new[] { "bilibili", "liveroom-status", "as-liveroom-id" });
            cmd_bilibili_liveroom_status_as_liveroom_id_2.Description = "使用直播间ID作为形参请求B站直播间的数据";
            var opt_bilibili_liveroom_status_as_liveroom_id_2_room_id = new Option<string>("--room-id")
            {
                Required = true, Description = "直播间ID"
            };
            cmd_bilibili_liveroom_status_as_liveroom_id_2.Options.Add(
                opt_bilibili_liveroom_status_as_liveroom_id_2_room_id);
            cmd_bilibili_liveroom_status_as_liveroom_id_2.SetAction(async parseResult =>
            {
                var room_id = parseResult.GetValue(opt_bilibili_liveroom_status_as_liveroom_id_2_room_id);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await bilibili.GetLiveroomStatus.AsLiveroomID(room_id, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}