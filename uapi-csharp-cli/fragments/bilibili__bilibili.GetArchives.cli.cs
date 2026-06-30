using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_bilibili_bilibili_GetArchives
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "bilibili", "archives" });
            o.Description = "查询B站用户的稿件";
            var O_id = new Option<string>("--mid")
            {
                Required = true, Description = "用户的 UID"
            };
            o.Options.Add(O_id);
            var O_orderby = new Option<bilibili.ArchivesSearchType>("--orderby")
            {
                Required = false, Description = "以何种方式排列",
                DefaultValueFactory = _ => bilibili.ArchivesSearchType.Pubdate
            };
            o.Options.Add(O_orderby);
            var O_key = new Option<string>("--keywords")
            {
                Required = false, Description = "查询关键字", DefaultValueFactory = _ => ""
            };
            o.Options.Add(O_key);
            var O_ps = new Option<int>("--ps")
            {
                Required = false, Description = "每页的条数,默认20", DefaultValueFactory = _ => 20
            };
            o.Options.Add(O_ps);
            var O_pn = new Option<int>("--pn")
            {
                Required = false, Description = "页码,默认1", DefaultValueFactory = _ => 1
            };
            o.Options.Add(O_pn);
            o.SetAction(parseResult =>
            {
                var mid = parseResult.GetValue(O_id);
                var orderby = parseResult.GetValue(O_orderby);
                var keywords = parseResult.GetValue(O_key);
                var ps = parseResult.GetValue(O_ps);
                var pn = parseResult.GetValue(O_pn);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = bilibili.GetArchives(mid, orderby, keywords, ps, pn, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}