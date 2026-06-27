using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_Base64
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_encrypt_base64_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "encrypt-base64" });
            cmd_text_encrypt_base64_1.Description = "获取加密后的 Base 64 编码文本";
            var opt_text_encrypt_base64_1_texts = new Option<string>("--texts")
            {
                Required = true
            };
            cmd_text_encrypt_base64_1.Options.Add(opt_text_encrypt_base64_1_texts);
            cmd_text_encrypt_base64_1.SetAction(async parseResult =>
            {
                var texts = parseResult.GetValue(opt_text_encrypt_base64_1_texts);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await Text.EncryptBase64(texts, AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_decrypt_base64_2 = CliCommandTree.GetOrAdd(root, new[] { "text", "decrypt-base64" });
            cmd_text_decrypt_base64_2.Description = "获取解密后的 Base 64 编码文本";
            var opt_text_decrypt_base64_2_texts = new Option<string>("--texts")
            {
                Required = true, Description = "指定要解密的 Bas64"
            };
            cmd_text_decrypt_base64_2.Options.Add(opt_text_decrypt_base64_2_texts);
            cmd_text_decrypt_base64_2.SetAction(async parseResult =>
            {
                var texts = parseResult.GetValue(opt_text_decrypt_base64_2_texts);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await Text.DecryptBase64(texts, AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}