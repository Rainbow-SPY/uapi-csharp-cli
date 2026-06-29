using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Search
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_search_1 = CliCommandTree.GetOrAdd(root, new[] { "search" });
            cmd_search_1.Description = "智能搜索 (POST)";
            var opt_search_1_query = new Option<string>("--query")
            {
                Required = true, Description = "搜索查询关键词，支持中英文"
            };
            cmd_search_1.Options.Add(opt_search_1_query);
            var opt_search_1_site = new Option<string>("--site")
            {
                Required = false, Description = "限制搜索特定网站，不需要 `site:` 前缀", DefaultValueFactory = _ => ""
            };
            cmd_search_1.Options.Add(opt_search_1_site);
            var opt_search_1_filetype = new Option<string>("--filetype")
            {
                Required = false, Description = "限制文件类型（如 pdf、doc、txt）", DefaultValueFactory = _ => ""
            };
            cmd_search_1.Options.Add(opt_search_1_filetype);
            var opt_search_1_fetchFull = new Option<bool>("--fetch-full")
            {
                Required = false, Description = "是否获取页面完整正文（会影响响应时间）", DefaultValueFactory = _ => false
            };
            cmd_search_1.Options.Add(opt_search_1_fetchFull);
            var opt_search_1_sort = new Option<Type.SearchType.SearchSort>("--sort")
            {
                Required = false, Description = "排序方式",
                DefaultValueFactory = _ => Type.SearchType.SearchSort.relevance
            };
            cmd_search_1.Options.Add(opt_search_1_sort);
            var opt_search_1_timeRange = new Option<Type.SearchType.SearchTimeRange?>("--time-range")
            {
                Required = false, Description = "时间范围过滤", DefaultValueFactory = _ => null
            };
            cmd_search_1.Options.Add(opt_search_1_timeRange);
            cmd_search_1.SetAction(parseResult =>
            {
                var query = parseResult.GetValue(opt_search_1_query);
                var site = parseResult.GetValue(opt_search_1_site);
                var filetype = parseResult.GetValue(opt_search_1_filetype);
                var fetchFull = parseResult.GetValue(opt_search_1_fetchFull);
                var sort = parseResult.GetValue(opt_search_1_sort);
                var timeRange = parseResult.GetValue(opt_search_1_timeRange);
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