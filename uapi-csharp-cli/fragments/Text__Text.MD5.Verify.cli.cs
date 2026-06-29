using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_MD5_Verify
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_text_verify_md5_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "verify-md5" });
            cmd_text_verify_md5_1.Description = "验证文本的哈希值是否符合预期";
            var opt_text_verify_md5_1_hash = new Option<string>("--hash")
            {
                Required = true, Description = "指定要验证的文本哈希值"
            };
            cmd_text_verify_md5_1.Options.Add(opt_text_verify_md5_1_hash);
            var opt_text_verify_md5_1_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要验证的文本"
            };
            cmd_text_verify_md5_1.Options.Add(opt_text_verify_md5_1_text);
            cmd_text_verify_md5_1.SetAction(parseResult =>
            {
                var hash = parseResult.GetValue(opt_text_verify_md5_1_hash);
                var text = parseResult.GetValue(opt_text_verify_md5_1_text);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.VerifyMD5(hash, text, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_text_is_md5_verify_successful_2 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "is-md5-verify-successful" });
            cmd_text_is_md5_verify_successful_2.Description = "MD5是否验证成功";
            var opt_text_is_md5_verify_successful_2_hash = new Option<string>("--hash")
            {
                Required = true, Description = "指定要验证的文本哈希值"
            };
            cmd_text_is_md5_verify_successful_2.Options.Add(opt_text_is_md5_verify_successful_2_hash);
            var opt_text_is_md5_verify_successful_2_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要验证的文本"
            };
            cmd_text_is_md5_verify_successful_2.Options.Add(opt_text_is_md5_verify_successful_2_text);
            cmd_text_is_md5_verify_successful_2.SetAction(parseResult =>
            {
                var hash = parseResult.GetValue(opt_text_is_md5_verify_successful_2_hash);
                var text = parseResult.GetValue(opt_text_is_md5_verify_successful_2_text);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.IsMD5VerifySuccessful(hash, text, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}