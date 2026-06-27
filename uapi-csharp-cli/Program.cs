using System;
using System.CommandLine;
using UAPI.CliGenerated;

internal static class Program
{
    public static int Main(string[] args)
    {
        var root = new RootCommand("UAPI CLI");

        var outOption = new Option<string>("--output", "-output")
        {
            Description = "输出到文件",
            Recursive = true
        };
        var appendOption = new Option<bool>("--append", "-a")
        {
            Description = "追加写入输出文件",
            Recursive = true
        };
        var resultOption = new Option<string>("--result")
        {
            Description = "输出内容: data, envelope, headers, headers-text"
        };
        var authenticationOption = new Option<string>("--authentication", "--auth", "-k")
        {
            Description = "UAPI API Key，可选；也可使用环境变量 UAPI_TOKEN",
            DefaultValueFactory = _ => Environment.GetEnvironmentVariable("UAPI_TOKEN") ?? "",
            // 如果你的 System.CommandLine 版本支持 Recursive，建议打开。
            // 这样可以写：uapi bilibili archives --mid 123 --authentication xxx
            // 否则可能只能写：uapi --authentication xxx bilibili archives --mid 123
            Recursive = true
        };


        root.Options.Add(outOption);
        root.Options.Add(appendOption);
        root.Options.Add(authenticationOption);
        root.Options.Add(resultOption);

        GeneratedCliAll.AddCommands(root, outOption, appendOption, authenticationOption);

        return root.Parse(args).Invoke();
    }
}