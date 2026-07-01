using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Search
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "search" });
            o.Description = "智能搜索 (POST)";
            var o_q = new Option<string>("--query")
            {
                Required = true, Description = "搜索查询关键词，支持中英文"
            };
            o.Options.Add(o_q);
            var o_s = new Option<string>("--site")
            {
                Required = false, Description = "限制搜索特定网站，不需要 `site:` 前缀", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_s);
            var o_t = new Option<string>("--type")
            {
                Required = false, Description = "限制文件类型（如 pdf、doc、txt）", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_t);
            var o_f = new Option<bool>("--fetch-full")
            {
                Required = false, Description = "是否获取页面完整正文（会影响响应时间）", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_f);
            var o_so = new Option<Type.SearchType.SearchSort>("--sort")
            {
                Required = false, Description = "排序方式",
                DefaultValueFactory = _ => Type.SearchType.SearchSort.relevance
            };
            o.Options.Add(o_so);
            var o_r = new Option<Type.SearchType.SearchTimeRange?>("--time-range")
            {
                Required = false, Description = "时间范围过滤", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_r);
            o.SetAction(parseResult =>
            {
                var query = parseResult.GetValue(o_q);
                var site = parseResult.GetValue(o_s);
                var filetype = parseResult.GetValue(o_t);
                var fetchFull = parseResult.GetValue(o_f);
                var sort = parseResult.GetValue(o_so);
                var timeRange = parseResult.GetValue(o_r);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Search.PostSearch(query, site, filetype, fetchFull, sort, timeRange, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}