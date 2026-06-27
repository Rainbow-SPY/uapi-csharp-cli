using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetRepliesList
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_bilibili_replies_list_1 = CliCommandTree.GetOrAdd(root, new[] { "bilibili", "replies-list" });
            cmd_bilibili_replies_list_1.Description = "获取 bilibili 视频评论区";
            var opt_bilibili_replies_list_1_oid = new Option<string>("--oid")
            {
                Required = true, Description = "目标评论区的ID。对于视频，这通常就是它的 aid/bvid"
            };
            cmd_bilibili_replies_list_1.Options.Add(opt_bilibili_replies_list_1_oid);
            var opt_bilibili_replies_list_1_sort = new Option<string>("--sort")
            {
                Required = false,
                Description = "排序方式。支持 0/time(按时间)、1/like(按点赞)、2/reply(按回复数)、3/hot/hottest/最热(按最热)。默认为 0/time。",
                DefaultValueFactory = _ => "0"
            };
            cmd_bilibili_replies_list_1.Options.Add(opt_bilibili_replies_list_1_sort);
            var opt_bilibili_replies_list_1_ps = new Option<int>("--ps")
            {
                Required = false, Description = "每页获取的评论数量，范围是1到20。默认为 20。", DefaultValueFactory = _ => 20
            };
            cmd_bilibili_replies_list_1.Options.Add(opt_bilibili_replies_list_1_ps);
            var opt_bilibili_replies_list_1_pn = new Option<int>("--pn")
            {
                Required = false, Description = "要获取的页码，从1开始。默认为 1。", DefaultValueFactory = _ => 1
            };
            cmd_bilibili_replies_list_1.Options.Add(opt_bilibili_replies_list_1_pn);
            cmd_bilibili_replies_list_1.SetAction(async parseResult =>
            {
                var oid = parseResult.GetValue(opt_bilibili_replies_list_1_oid);
                var sort = parseResult.GetValue(opt_bilibili_replies_list_1_sort);
                var ps = parseResult.GetValue(opt_bilibili_replies_list_1_ps);
                var pn = parseResult.GetValue(opt_bilibili_replies_list_1_pn);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await bilibili.GetRepliesList(oid, sort, ps, pn, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}