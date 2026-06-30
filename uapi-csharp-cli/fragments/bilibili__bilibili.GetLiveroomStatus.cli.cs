using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetLiveroomStatus
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "bilibili", "liveroom", "mid" });
            o.Description = "使用用户 UID 作为形参请求B站直播间数据";
            var o_mid = new Option<string>("--mid")
            {
                Required = true, Description = "用户的 UID"
            };
            o.Options.Add(o_mid);
            o.SetAction(parseResult =>
            {
                var mid = parseResult.GetValue(o_mid);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = bilibili.GetLiveroomStatus.AsID(mid, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 =
                CliCommandTree.GetOrAdd(root, new[] { "bilibili", "liveroom", "lid" });
            o2.Description = "使用直播间ID作为形参请求B站直播间的数据";
            var o2_id = new Option<string>("--lid")
            {
                Required = true, Description = "直播间ID"
            };
            o2.Options.Add(o2_id);
            o2.SetAction(parseResult =>
            {
                var room_id = parseResult.GetValue(o2_id);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = bilibili.GetLiveroomStatus.AsLiveroomID(room_id, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}