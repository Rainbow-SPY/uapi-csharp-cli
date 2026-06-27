using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Github_GetRepoData
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_github_repos_data_1 = CliCommandTree.GetOrAdd(root, new[] { "github", "repos-data" });
            cmd_github_repos_data_1.Description = "获取github仓库数据";
            var opt_github_repos_data_1_owner_and_repo = new Option<string>("--owner-and-repo")
            {
                Required = true, Description = "所有者+仓库(owner/repo)"
            };
            cmd_github_repos_data_1.Options.Add(opt_github_repos_data_1_owner_and_repo);
            cmd_github_repos_data_1.SetAction(async parseResult =>
            {
                var owner_and_repo = parseResult.GetValue(opt_github_repos_data_1_owner_and_repo);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Github.GetReposData(owner_and_repo, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}