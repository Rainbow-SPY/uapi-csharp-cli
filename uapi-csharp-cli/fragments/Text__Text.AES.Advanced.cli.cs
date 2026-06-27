using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_AES_Advanced
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_aes_advanced_encrypt_1 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "advanced-encrypt" });
            cmd_text_aes_advanced_encrypt_1.Description = "使用AES 高级加密加密指定的文本";
            var opt_text_aes_advanced_encrypt_1_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要加密的文本"
            };
            cmd_text_aes_advanced_encrypt_1.Options.Add(opt_text_aes_advanced_encrypt_1_text);
            var opt_text_aes_advanced_encrypt_1_key = new Option<string>("--key")
            {
                Required = true, Description = "加密密钥（支持任意长度）"
            };
            cmd_text_aes_advanced_encrypt_1.Options.Add(opt_text_aes_advanced_encrypt_1_key);
            var opt_text_aes_advanced_encrypt_1_mode = new Option<Type.AESAdvancedType.EncryptMode>("--mode")
            {
                Required = false, Description = "加密方式, 可选 GCM 或 CBC 或 ECB 或 CTR 或 OFB 或 CFB, 默认为 GCM",
                DefaultValueFactory = _ => Type.AESAdvancedType.EncryptMode.GCM
            };
            cmd_text_aes_advanced_encrypt_1.Options.Add(opt_text_aes_advanced_encrypt_1_mode);
            var opt_text_aes_advanced_encrypt_1_padding = new Option<Type.AESAdvancedType.padding>("--padding")
            {
                Required = false, Description = "填充方式, 可选 PKCS7 或 ZERO 或 NONE, 默认 PKCS7",
                DefaultValueFactory = _ => Type.AESAdvancedType.padding.PKCS7
            };
            cmd_text_aes_advanced_encrypt_1.Options.Add(opt_text_aes_advanced_encrypt_1_padding);
            var opt_text_aes_advanced_encrypt_1_iv = new Option<string>("--iv")
            {
                Required = false, Description = "自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数", DefaultValueFactory = _ => ""
            };
            cmd_text_aes_advanced_encrypt_1.Options.Add(opt_text_aes_advanced_encrypt_1_iv);
            var opt_text_aes_advanced_encrypt_1_format = new Option<Type.AESAdvancedType.format>("--format")
            {
                Required = false, Description = "输出格式, 可选 base64 或 hex, 默认 base64",
                DefaultValueFactory = _ => Type.AESAdvancedType.format.base64
            };
            cmd_text_aes_advanced_encrypt_1.Options.Add(opt_text_aes_advanced_encrypt_1_format);
            cmd_text_aes_advanced_encrypt_1.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_aes_advanced_encrypt_1_text);
                var key = parseResult.GetValue(opt_text_aes_advanced_encrypt_1_key);
                var mode = parseResult.GetValue(opt_text_aes_advanced_encrypt_1_mode);
                var padding = parseResult.GetValue(opt_text_aes_advanced_encrypt_1_padding);
                var iv = parseResult.GetValue(opt_text_aes_advanced_encrypt_1_iv);
                var format = parseResult.GetValue(opt_text_aes_advanced_encrypt_1_format);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.AES.AdvancedEncrypt(text, key, mode, padding, iv, format, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_aes_ed_advanced_encrypted_text_2 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "ed-advanced-encrypted-text" });
            cmd_text_aes_ed_advanced_encrypted_text_2.Description = "使用 AES 高级加密加密指定的文本, 直接返回加密完的文本, 可等待";
            var opt_text_aes_ed_advanced_encrypted_text_2_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要加密的文本"
            };
            cmd_text_aes_ed_advanced_encrypted_text_2.Options.Add(opt_text_aes_ed_advanced_encrypted_text_2_text);
            var opt_text_aes_ed_advanced_encrypted_text_2_key = new Option<string>("--key")
            {
                Required = true, Description = "加密密钥（支持任意长度）"
            };
            cmd_text_aes_ed_advanced_encrypted_text_2.Options.Add(opt_text_aes_ed_advanced_encrypted_text_2_key);
            var opt_text_aes_ed_advanced_encrypted_text_2_mode = new Option<Type.AESAdvancedType.EncryptMode>("--mode")
            {
                Required = false, Description = "加密方式, 可选 GCM 或 CBC 或 ECB 或 CTR 或 OFB 或 CFB, 默认为 GCM",
                DefaultValueFactory = _ => Type.AESAdvancedType.EncryptMode.GCM
            };
            cmd_text_aes_ed_advanced_encrypted_text_2.Options.Add(opt_text_aes_ed_advanced_encrypted_text_2_mode);
            var opt_text_aes_ed_advanced_encrypted_text_2_padding =
                new Option<Type.AESAdvancedType.padding>("--padding")
                {
                    Required = false, Description = "填充方式, 可选 PKCS7 或 ZERO 或 NONE, 默认 PKCS7",
                    DefaultValueFactory = _ => Type.AESAdvancedType.padding.PKCS7
                };
            cmd_text_aes_ed_advanced_encrypted_text_2.Options.Add(opt_text_aes_ed_advanced_encrypted_text_2_padding);
            var opt_text_aes_ed_advanced_encrypted_text_2_iv = new Option<string>("--iv")
            {
                Required = false, Description = "自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数", DefaultValueFactory = _ => ""
            };
            cmd_text_aes_ed_advanced_encrypted_text_2.Options.Add(opt_text_aes_ed_advanced_encrypted_text_2_iv);
            var opt_text_aes_ed_advanced_encrypted_text_2_format = new Option<Type.AESAdvancedType.format>("--format")
            {
                Required = false, Description = "输出格式, 可选 base64 或 hex, 默认 base64",
                DefaultValueFactory = _ => Type.AESAdvancedType.format.base64
            };
            cmd_text_aes_ed_advanced_encrypted_text_2.Options.Add(opt_text_aes_ed_advanced_encrypted_text_2_format);
            cmd_text_aes_ed_advanced_encrypted_text_2.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_aes_ed_advanced_encrypted_text_2_text);
                var key = parseResult.GetValue(opt_text_aes_ed_advanced_encrypted_text_2_key);
                var mode = parseResult.GetValue(opt_text_aes_ed_advanced_encrypted_text_2_mode);
                var padding = parseResult.GetValue(opt_text_aes_ed_advanced_encrypted_text_2_padding);
                var iv = parseResult.GetValue(opt_text_aes_ed_advanced_encrypted_text_2_iv);
                var format = parseResult.GetValue(opt_text_aes_ed_advanced_encrypted_text_2_format);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result =
                    await Text.AES.ReturnedAdvancedEncryptedText(text, key, mode, padding, iv, format, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_aes_advanced_decrypt_3 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "advanced-decrypt" });
            cmd_text_aes_advanced_decrypt_3.Description = "使用 AES 高级加密解密指定的文本";
            var opt_text_aes_advanced_decrypt_3_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要解密的文本"
            };
            cmd_text_aes_advanced_decrypt_3.Options.Add(opt_text_aes_advanced_decrypt_3_text);
            var opt_text_aes_advanced_decrypt_3_key = new Option<string>("--key")
            {
                Required = true, Description = "加密密钥（支持任意长度, 必须与加密时相同）"
            };
            cmd_text_aes_advanced_decrypt_3.Options.Add(opt_text_aes_advanced_decrypt_3_key);
            var opt_text_aes_advanced_decrypt_3_mode = new Option<Type.AESAdvancedType.EncryptMode>("--mode")
            {
                Required = false, Description = "加密方式, 可选, 必须与加密时相同 GCM 或 CBC 或 ECB 或 CTR 或 OFB 或 CFB, 默认为 GCM",
                DefaultValueFactory = _ => Type.AESAdvancedType.EncryptMode.GCM
            };
            cmd_text_aes_advanced_decrypt_3.Options.Add(opt_text_aes_advanced_decrypt_3_mode);
            var opt_text_aes_advanced_decrypt_3_padding = new Option<Type.AESAdvancedType.padding>("--padding")
            {
                Required = false, Description = "填充方式, 可选, 必须与加密时相同 PKCS7 或 ZERO 或 NONE, 默认 PKCS7",
                DefaultValueFactory = _ => Type.AESAdvancedType.padding.PKCS7
            };
            cmd_text_aes_advanced_decrypt_3.Options.Add(opt_text_aes_advanced_decrypt_3_padding);
            var opt_text_aes_advanced_decrypt_3_iv = new Option<string>("--iv")
            {
                Required = false, Description = "自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数", DefaultValueFactory = _ => ""
            };
            cmd_text_aes_advanced_decrypt_3.Options.Add(opt_text_aes_advanced_decrypt_3_iv);
            cmd_text_aes_advanced_decrypt_3.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_aes_advanced_decrypt_3_text);
                var key = parseResult.GetValue(opt_text_aes_advanced_decrypt_3_key);
                var mode = parseResult.GetValue(opt_text_aes_advanced_decrypt_3_mode);
                var padding = parseResult.GetValue(opt_text_aes_advanced_decrypt_3_padding);
                var iv = parseResult.GetValue(opt_text_aes_advanced_decrypt_3_iv);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.AES.AdvancedDecrypt(text, key, mode, padding, iv, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_aes_ed_advanced_decrypt_text_4 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "ed-advanced-decrypt-text" });
            cmd_text_aes_ed_advanced_decrypt_text_4.Description = "使用 AES 高级加密解密指定的文本, 直接返回解密后的文本, 可等待";
            var opt_text_aes_ed_advanced_decrypt_text_4_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要解密的文本"
            };
            cmd_text_aes_ed_advanced_decrypt_text_4.Options.Add(opt_text_aes_ed_advanced_decrypt_text_4_text);
            var opt_text_aes_ed_advanced_decrypt_text_4_key = new Option<string>("--key")
            {
                Required = true, Description = "加密密钥（支持任意长度, 必须与加密时相同）"
            };
            cmd_text_aes_ed_advanced_decrypt_text_4.Options.Add(opt_text_aes_ed_advanced_decrypt_text_4_key);
            var opt_text_aes_ed_advanced_decrypt_text_4_mode = new Option<Type.AESAdvancedType.EncryptMode>("--mode")
            {
                Required = false, Description = "加密方式, 可选, 必须与加密时相同 GCM 或 CBC 或 ECB 或 CTR 或 OFB 或 CFB, 默认为 GCM",
                DefaultValueFactory = _ => Type.AESAdvancedType.EncryptMode.GCM
            };
            cmd_text_aes_ed_advanced_decrypt_text_4.Options.Add(opt_text_aes_ed_advanced_decrypt_text_4_mode);
            var opt_text_aes_ed_advanced_decrypt_text_4_padding = new Option<Type.AESAdvancedType.padding>("--padding")
            {
                Required = false, Description = "填充方式, 可选, 必须与加密时相同 PKCS7 或 ZERO 或 NONE, 默认 PKCS7",
                DefaultValueFactory = _ => Type.AESAdvancedType.padding.PKCS7
            };
            cmd_text_aes_ed_advanced_decrypt_text_4.Options.Add(opt_text_aes_ed_advanced_decrypt_text_4_padding);
            var opt_text_aes_ed_advanced_decrypt_text_4_iv = new Option<string>("--iv")
            {
                Required = false, Description = "自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数", DefaultValueFactory = _ => ""
            };
            cmd_text_aes_ed_advanced_decrypt_text_4.Options.Add(opt_text_aes_ed_advanced_decrypt_text_4_iv);
            cmd_text_aes_ed_advanced_decrypt_text_4.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_aes_ed_advanced_decrypt_text_4_text);
                var key = parseResult.GetValue(opt_text_aes_ed_advanced_decrypt_text_4_key);
                var mode = parseResult.GetValue(opt_text_aes_ed_advanced_decrypt_text_4_mode);
                var padding = parseResult.GetValue(opt_text_aes_ed_advanced_decrypt_text_4_padding);
                var iv = parseResult.GetValue(opt_text_aes_ed_advanced_decrypt_text_4_iv);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.AES.ReturnedAdvancedDecryptText(text, key, mode, padding, iv, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}