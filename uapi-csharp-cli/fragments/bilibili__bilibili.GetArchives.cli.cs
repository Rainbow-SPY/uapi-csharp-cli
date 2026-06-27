using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetArchives
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_bilibili_archives_1 = CliCommandTree.GetOrAdd(root, new[] { "bilibili", "archives" });
            cmd_bilibili_archives_1.Description = "查询B站用户的稿件";
            var opt_bilibili_archives_1_mid = new Option<string>("--mid")
            {
                Required = true, Description = "用户的 UID"
            };
            cmd_bilibili_archives_1.Options.Add(opt_bilibili_archives_1_mid);
            var opt_bilibili_archives_1_orderby = new Option<bilibili.ArchivesSearchType>("--orderby")
            {
                Required = false, Description = "以何种方式排列",
                DefaultValueFactory = _ => bilibili.ArchivesSearchType.Pubdate
            };
            cmd_bilibili_archives_1.Options.Add(opt_bilibili_archives_1_orderby);
            var opt_bilibili_archives_1_keywords = new Option<string>("--keywords")
            {
                Required = false, Description = "查询关键字", DefaultValueFactory = _ => ""
            };
            cmd_bilibili_archives_1.Options.Add(opt_bilibili_archives_1_keywords);
            var opt_bilibili_archives_1_ps = new Option<int>("--ps")
            {
                Required = false, Description = "每页的条数,默认20", DefaultValueFactory = _ => 20
            };
            cmd_bilibili_archives_1.Options.Add(opt_bilibili_archives_1_ps);
            var opt_bilibili_archives_1_pn = new Option<int>("--pn")
            {
                Required = false, Description = "页码,默认1", DefaultValueFactory = _ => 1
            };
            cmd_bilibili_archives_1.Options.Add(opt_bilibili_archives_1_pn);
            cmd_bilibili_archives_1.SetAction(async parseResult =>
            {
                var mid = parseResult.GetValue(opt_bilibili_archives_1_mid);
                var orderby = parseResult.GetValue(opt_bilibili_archives_1_orderby);
                var keywords = parseResult.GetValue(opt_bilibili_archives_1_keywords);
                var ps = parseResult.GetValue(opt_bilibili_archives_1_ps);
                var pn = parseResult.GetValue(opt_bilibili_archives_1_pn);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await bilibili.GetArchives(mid, orderby, keywords, ps, pn, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}