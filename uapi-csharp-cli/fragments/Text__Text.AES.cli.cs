using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_AES
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_text_aes_encrypt_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "encrypt" });
            cmd_text_aes_encrypt_1.Description = "使用 AES 加密文本";
            var opt_text_aes_encrypt_1_key = new Option<string>("--key")
            {
                Required = true, Description = "密钥，长度必须为16、24或 32 字节，对应AES-128/192/256"
            };
            cmd_text_aes_encrypt_1.Options.Add(opt_text_aes_encrypt_1_key);
            var opt_text_aes_encrypt_1_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要加密的文本"
            };
            cmd_text_aes_encrypt_1.Options.Add(opt_text_aes_encrypt_1_text);
            cmd_text_aes_encrypt_1.SetAction(parseResult =>
            {
                var key = parseResult.GetValue(opt_text_aes_encrypt_1_key);
                var text = parseResult.GetValue(opt_text_aes_encrypt_1_text);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.Encrypt(key, text, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_text_aes_encrypted_text_2 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "encrypted-text" });
            cmd_text_aes_encrypted_text_2.Description = "使用 AES 加密文本, 直接返回加密后的文本, 可等待";
            var opt_text_aes_encrypted_text_2_key = new Option<string>("--key")
            {
                Required = true, Description = "密钥，长度必须为16、24或 32 字节，对应AES-128/192/256"
            };
            cmd_text_aes_encrypted_text_2.Options.Add(opt_text_aes_encrypted_text_2_key);
            var opt_text_aes_encrypted_text_2_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要加密的文本"
            };
            cmd_text_aes_encrypted_text_2.Options.Add(opt_text_aes_encrypted_text_2_text);
            cmd_text_aes_encrypted_text_2.SetAction(parseResult =>
            {
                var key = parseResult.GetValue(opt_text_aes_encrypted_text_2_key);
                var text = parseResult.GetValue(opt_text_aes_encrypted_text_2_text);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.ReturnEncryptedText(key, text, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_text_aes_decrypt_3 = CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "decrypt" });
            cmd_text_aes_decrypt_3.Description = "使用 AES 解密文本";
            var opt_text_aes_decrypt_3_key = new Option<string>("--key")
            {
                Required = true, Description = "密钥，长度必须为16、24或 32 字节，对应AES-128/192/256"
            };
            cmd_text_aes_decrypt_3.Options.Add(opt_text_aes_decrypt_3_key);
            var opt_text_aes_decrypt_3_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要解密的文本"
            };
            cmd_text_aes_decrypt_3.Options.Add(opt_text_aes_decrypt_3_text);
            var opt_text_aes_decrypt_3_IV = new Option<string>("--iv")
            {
                Required = true, Description = "16字节的IV/Nonce，必须为16个字符"
            };
            cmd_text_aes_decrypt_3.Options.Add(opt_text_aes_decrypt_3_IV);
            cmd_text_aes_decrypt_3.SetAction(parseResult =>
            {
                var key = parseResult.GetValue(opt_text_aes_decrypt_3_key);
                var text = parseResult.GetValue(opt_text_aes_decrypt_3_text);
                var IV = parseResult.GetValue(opt_text_aes_decrypt_3_IV);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.Decrypt(key, text, IV, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_text_aes_decrypted_text_4 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "decrypted-text" });
            cmd_text_aes_decrypted_text_4.Description = "使用 AES 解密文本, 直接返回解密后的文本, 可等待";
            var opt_text_aes_decrypted_text_4_key = new Option<string>("--key")
            {
                Required = true, Description = "密钥，长度必须为16、24或 32 字节，对应AES-128/192/256"
            };
            cmd_text_aes_decrypted_text_4.Options.Add(opt_text_aes_decrypted_text_4_key);
            var opt_text_aes_decrypted_text_4_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要解密的文本"
            };
            cmd_text_aes_decrypted_text_4.Options.Add(opt_text_aes_decrypted_text_4_text);
            var opt_text_aes_decrypted_text_4_IV = new Option<string>("--iv")
            {
                Required = true, Description = "16字节的IV/Nonce，必须为16个字符"
            };
            cmd_text_aes_decrypted_text_4.Options.Add(opt_text_aes_decrypted_text_4_IV);
            cmd_text_aes_decrypted_text_4.SetAction(parseResult =>
            {
                var key = parseResult.GetValue(opt_text_aes_decrypted_text_4_key);
                var text = parseResult.GetValue(opt_text_aes_decrypted_text_4_text);
                var IV = parseResult.GetValue(opt_text_aes_decrypted_text_4_IV);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.ReturnDecryptedText(key, text, IV, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}