using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_Base64
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "encrypt-base64" });
            o.Description = "获取加密后的 Base 64 编码文本";
            var o_t = new Option<string>("--texts")
            {
                Required = true
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var texts = parseResult.GetValue(o_t);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.EncryptBase64(texts, AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "text", "decrypt-base64" });
            o2.Description = "获取解密后的 Base 64 编码文本";
            var o2_t = new Option<string>("--texts")
            {
                Required = true, Description = "指定要解密的 Bas64"
            };
            o2.Options.Add(o2_t);
            o2.SetAction(parseResult =>
            {
                var texts = parseResult.GetValue(o2_t);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.DecryptBase64(texts, AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}