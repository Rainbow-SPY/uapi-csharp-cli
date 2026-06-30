using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetRepliesList
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "bilibili", "replies" });
            o.Description = "获取 bilibili 视频评论区";
            var o_id = new Option<string>("--oid")
            {
                Required = true, Description = "目标评论区的ID。对于视频，这通常就是它的 aid/bvid"
            };
            o.Options.Add(o_id);
            var o_sort = new Option<string>("--sort")
            {
                Required = false,
                Description = "排序方式。支持 0/time(按时间)、1/like(按点赞)、2/reply(按回复数)、3/hot/hottest/最热(按最热)。默认为 0/time。",
                DefaultValueFactory = _ => "0"
            };
            o.Options.Add(o_sort);
            var o_ps = new Option<int>("--ps")
            {
                Required = false, Description = "每页获取的评论数量，范围是1到20。默认为 20。", DefaultValueFactory = _ => 20
            };
            o.Options.Add(o_ps);
            var o_pn = new Option<int>("--pn")
            {
                Required = false, Description = "要获取的页码，从1开始。默认为 1。", DefaultValueFactory = _ => 1
            };
            o.Options.Add(o_pn);
            o.SetAction(parseResult =>
            {
                var oid = parseResult.GetValue(o_id);
                var sort = parseResult.GetValue(o_sort);
                var ps = parseResult.GetValue(o_ps);
                var pn = parseResult.GetValue(o_pn);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = bilibili.GetRepliesList(oid, sort, ps, pn, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}