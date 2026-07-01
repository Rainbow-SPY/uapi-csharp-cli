using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_AES_Advanced
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "advance", "encrypt", "result" });
            o.Description = "使用AES 高级加密加密指定的文本";
            var o_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要加密的文本"
            };
            o.Options.Add(o_t);
            var o_k = new Option<string>("--key")
            {
                Required = true, Description = "加密密钥（支持任意长度）"
            };
            o.Options.Add(o_k);
            var o_m = new Option<Type.AESAdvancedType.EncryptMode>("--mode")
            {
                Required = false, Description = "加密方式, 可选 GCM 或 CBC 或 ECB 或 CTR 或 OFB 或 CFB, 默认为 GCM",
                DefaultValueFactory = _ => Type.AESAdvancedType.EncryptMode.GCM
            };
            o.Options.Add(o_m);
            var o_p = new Option<Type.AESAdvancedType.padding>("--padding")
            {
                Required = false, Description = "填充方式, 可选 PKCS7 或 ZERO 或 NONE, 默认 PKCS7",
                DefaultValueFactory = _ => Type.AESAdvancedType.padding.PKCS7
            };
            o.Options.Add(o_p);
            var o_i = new Option<string>("--iv")
            {
                Required = false, Description = "自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_i);
            var o_f = new Option<Type.AESAdvancedType.format>("--format")
            {
                Required = false, Description = "输出格式, 可选 base64 或 hex, 默认 base64",
                DefaultValueFactory = _ => Type.AESAdvancedType.format.base64
            };
            o.Options.Add(o_f);
            o.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o_t);
                var key = parseResult.GetValue(o_k);
                var mode = parseResult.GetValue(o_m);
                var padding = parseResult.GetValue(o_p);
                var iv = parseResult.GetValue(o_i);
                var format = parseResult.GetValue(o_f);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.AdvancedEncrypt(text, key, mode, padding, iv, format, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "advance", "encrypt", "text" });
            o2.Description = "使用 AES 高级加密加密指定的文本, 直接返回加密完的文本, 可等待";
            var o2_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要加密的文本"
            };
            o2.Options.Add(o2_t);
            var o2_k = new Option<string>("--key")
            {
                Required = true, Description = "加密密钥（支持任意长度）"
            };
            o2.Options.Add(o2_k);
            var o2_m = new Option<Type.AESAdvancedType.EncryptMode>("--mode")
            {
                Required = false, Description = "加密方式, 可选 GCM 或 CBC 或 ECB 或 CTR 或 OFB 或 CFB, 默认为 GCM",
                DefaultValueFactory = _ => Type.AESAdvancedType.EncryptMode.GCM
            };
            o2.Options.Add(o2_m);
            var o2_p = new Option<Type.AESAdvancedType.padding>("--padding")
            {
                Required = false, Description = "填充方式, 可选 PKCS7 或 ZERO 或 NONE, 默认 PKCS7",
                DefaultValueFactory = _ => Type.AESAdvancedType.padding.PKCS7
            };
            o2.Options.Add(o2_p);
            var o2_i = new Option<string>("--iv")
            {
                Required = false, Description = "自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数", DefaultValueFactory = _ => ""
            };
            o2.Options.Add(o2_i);
            var o2_f = new Option<Type.AESAdvancedType.format>("--format")
            {
                Required = false, Description = "输出格式, 可选 base64 或 hex, 默认 base64",
                DefaultValueFactory = _ => Type.AESAdvancedType.format.base64
            };
            o2.Options.Add(o2_f);
            o2.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o2_t);
                var key = parseResult.GetValue(o2_k);
                var mode = parseResult.GetValue(o2_m);
                var padding = parseResult.GetValue(o2_p);
                var iv = parseResult.GetValue(o2_i);
                var format = parseResult.GetValue(o2_f);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES
                    .ReturnedAdvancedEncryptedText(text, key, mode, padding, iv, format, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o3 = CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "advance", "decrypt", "result" });
            o3.Description = "使用 AES 高级加密解密指定的文本";
            var o3_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要解密的文本"
            };
            o3.Options.Add(o3_t);
            var o3_k = new Option<string>("--key")
            {
                Required = true, Description = "加密密钥（支持任意长度, 必须与加密时相同）"
            };
            o3.Options.Add(o3_k);
            var o3_m = new Option<Type.AESAdvancedType.EncryptMode>("--mode")
            {
                Required = false, Description = "加密方式, 可选, 必须与加密时相同 GCM 或 CBC 或 ECB 或 CTR 或 OFB 或 CFB, 默认为 GCM",
                DefaultValueFactory = _ => Type.AESAdvancedType.EncryptMode.GCM
            };
            o3.Options.Add(o3_m);
            var o3_p = new Option<Type.AESAdvancedType.padding>("--padding")
            {
                Required = false, Description = "填充方式, 可选, 必须与加密时相同 PKCS7 或 ZERO 或 NONE, 默认 PKCS7",
                DefaultValueFactory = _ => Type.AESAdvancedType.padding.PKCS7
            };
            o3.Options.Add(o3_p);
            var o3_i = new Option<string>("--iv")
            {
                Required = false, Description = "自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数", DefaultValueFactory = _ => ""
            };
            o3.Options.Add(o3_i);
            o3.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o3_t);
                var key = parseResult.GetValue(o3_k);
                var mode = parseResult.GetValue(o3_m);
                var padding = parseResult.GetValue(o3_p);
                var iv = parseResult.GetValue(o3_i);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.AdvancedDecrypt(text, key, mode, padding, iv, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o4 = CliCommandTree.GetOrAdd(root, new[] { "text", "aes", "advance", "decrypt", "text" });
            o4.Description = "使用 AES 高级加密解密指定的文本, 直接返回解密后的文本, 可等待";
            var o4_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要解密的文本"
            };
            o4.Options.Add(o4_t);
            var o4_k = new Option<string>("--key")
            {
                Required = true, Description = "加密密钥（支持任意长度, 必须与加密时相同）"
            };
            o4.Options.Add(o4_k);
            var o4_m = new Option<Type.AESAdvancedType.EncryptMode>("--mode")
            {
                Required = false, Description = "加密方式, 可选, 必须与加密时相同 GCM 或 CBC 或 ECB 或 CTR 或 OFB 或 CFB, 默认为 GCM",
                DefaultValueFactory = _ => Type.AESAdvancedType.EncryptMode.GCM
            };
            o4.Options.Add(o4_m);
            var o4_p = new Option<Type.AESAdvancedType.padding>("--padding")
            {
                Required = false, Description = "填充方式, 可选, 必须与加密时相同 PKCS7 或 ZERO 或 NONE, 默认 PKCS7",
                DefaultValueFactory = _ => Type.AESAdvancedType.padding.PKCS7
            };
            o4.Options.Add(o4_p);
            var o4_i = new Option<string>("--iv")
            {
                Required = false, Description = "自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数", DefaultValueFactory = _ => ""
            };
            o4.Options.Add(o4_i);
            o4.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o4_t);
                var key = parseResult.GetValue(o4_k);
                var mode = parseResult.GetValue(o4_m);
                var padding = parseResult.GetValue(o4_p);
                var iv = parseResult.GetValue(o4_i);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AES.ReturnedAdvancedDecryptText(text, key, mode, padding, iv, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}