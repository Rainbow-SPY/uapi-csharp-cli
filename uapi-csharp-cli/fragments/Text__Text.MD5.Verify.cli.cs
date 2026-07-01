using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_MD5_Verify
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "verify-md5" });
            o.Description = "验证文本的哈希值是否符合预期";
            var o_h = new Option<string>("--hash")
            {
                Required = true, Description = "指定要验证的文本哈希值"
            };
            o.Options.Add(o_h);
            var o_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要验证的文本"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var hash = parseResult.GetValue(o_h);
                var text = parseResult.GetValue(o_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.VerifyMD5(hash, text, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "text", "is-md5-verify-successful" });
            o2.Description = "MD5是否验证成功";
            var o2_h = new Option<string>("--hash")
            {
                Required = true, Description = "指定要验证的文本哈希值"
            };
            o2.Options.Add(o2_h);
            var o2_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要验证的文本"
            };
            o2.Options.Add(o2_t);
            o2.SetAction(parseResult =>
            {
                var hash = parseResult.GetValue(o2_h);
                var text = parseResult.GetValue(o2_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.IsMD5VerifySuccessful(hash, text, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}