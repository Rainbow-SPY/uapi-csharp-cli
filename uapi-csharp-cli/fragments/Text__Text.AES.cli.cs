using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_AES
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "encrypt", "result" });
            o.Description = "使用 AES 加密文本";
            var o_k = new Option<string>("--key")
            {
                Required = true, Description = "密钥，长度必须为16、24或 32 字节，对应AES-128/192/256"
            };
            o.Options.Add(o_k);
            var o_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要加密的文本"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var key = parseResult.GetValue(o_k);
                var text = parseResult.GetValue(o_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.Encrypt(key, text, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "encrypted", "text" });
            o2.Description = "使用 AES 加密文本, 直接返回加密后的文本, 可等待";
            var o2_k = new Option<string>("--key")
            {
                Required = true, Description = "密钥，长度必须为16、24或 32 字节，对应AES-128/192/256"
            };
            o2.Options.Add(o2_k);
            var o2_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要加密的文本"
            };
            o2.Options.Add(o2_t);
            o2.SetAction(parseResult =>
            {
                var key = parseResult.GetValue(o2_k);
                var text = parseResult.GetValue(o2_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.ReturnEncryptedText(key, text, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o3 = CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "decrypt", "result" });
            o3.Description = "使用 AES 解密文本";
            var o3_k = new Option<string>("--key")
            {
                Required = true, Description = "密钥，长度必须为16、24或 32 字节，对应AES-128/192/256"
            };
            o3.Options.Add(o3_k);
            var o3_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要解密的文本"
            };
            o3.Options.Add(o3_t);
            var o3_i = new Option<string>("--iv")
            {
                Required = true, Description = "16字节的IV/Nonce，必须为16个字符"
            };
            o3.Options.Add(o3_i);
            o3.SetAction(parseResult =>
            {
                var key = parseResult.GetValue(o3_k);
                var text = parseResult.GetValue(o3_t);
                var IV = parseResult.GetValue(o3_i);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.Decrypt(key, text, IV, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o4 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "decrypted", "text" });
            o4.Description = "使用 AES 解密文本, 直接返回解密后的文本, 可等待";
            var o4_k = new Option<string>("--key")
            {
                Required = true, Description = "密钥，长度必须为16、24或 32 字节，对应AES-128/192/256"
            };
            o4.Options.Add(o4_k);
            var o4_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要解密的文本"
            };
            o4.Options.Add(o4_t);
            var o4_i = new Option<string>("--iv")
            {
                Required = true, Description = "16字节的IV/Nonce，必须为16个字符"
            };
            o4.Options.Add(o4_i);
            o4.SetAction(parseResult =>
            {
                var key = parseResult.GetValue(o4_k);
                var text = parseResult.GetValue(o4_t);
                var IV = parseResult.GetValue(o4_i);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.ReturnDecryptedText(key, text, IV, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}