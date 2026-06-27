using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_text_Convert
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_convert_er_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "er" });
            cmd_text_convert_er_1.Description = "不同文本格式之间转换";
            var opt_text_convert_er_1_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的源文本"
            };
            cmd_text_convert_er_1.Options.Add(opt_text_convert_er_1_text);
            var opt_text_convert_er_1_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "源格式"
            };
            cmd_text_convert_er_1.Options.Add(opt_text_convert_er_1_From);
            var opt_text_convert_er_1_To = new Option<Text.Convert.Format>("--to")
            {
                Required = true, Description = "目标格式"
            };
            cmd_text_convert_er_1.Options.Add(opt_text_convert_er_1_To);
            var opt_text_convert_er_1_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_er_1.Options.Add(opt_text_convert_er_1_option);
            cmd_text_convert_er_1.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_er_1_text);
                var From = parseResult.GetValue(opt_text_convert_er_1_From);
                var To = parseResult.GetValue(opt_text_convert_er_1_To);
                object option = parseResult.GetValue(opt_text_convert_er_1_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.Converter(text, From, To, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_text_2 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-text" });
            cmd_text_convert_any_to_text_2.Description = "将任意格式的数据转换为文本";
            var opt_text_convert_any_to_text_2_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_text_2.Options.Add(opt_text_convert_any_to_text_2_text);
            var opt_text_convert_any_to_text_2_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_text_2.Options.Add(opt_text_convert_any_to_text_2_From);
            var opt_text_convert_any_to_text_2_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_text_2.Options.Add(opt_text_convert_any_to_text_2_option);
            cmd_text_convert_any_to_text_2.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_text_2_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_text_2_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_text_2_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToText(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_base64_3 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-base64" });
            cmd_text_convert_any_to_base64_3.Description = "将任意格式的数据转换为 Base64";
            var opt_text_convert_any_to_base64_3_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_base64_3.Options.Add(opt_text_convert_any_to_base64_3_text);
            var opt_text_convert_any_to_base64_3_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_base64_3.Options.Add(opt_text_convert_any_to_base64_3_From);
            var opt_text_convert_any_to_base64_3_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_base64_3.Options.Add(opt_text_convert_any_to_base64_3_option);
            cmd_text_convert_any_to_base64_3.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_base64_3_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_base64_3_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_base64_3_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToBase64(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_hex_4 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-hex" });
            cmd_text_convert_any_to_hex_4.Description = "将任意格式的数据转换为十六进制 (不带 - , 小写字母+数字)";
            var opt_text_convert_any_to_hex_4_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_hex_4.Options.Add(opt_text_convert_any_to_hex_4_text);
            var opt_text_convert_any_to_hex_4_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_hex_4.Options.Add(opt_text_convert_any_to_hex_4_From);
            var opt_text_convert_any_to_hex_4_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_hex_4.Options.Add(opt_text_convert_any_to_hex_4_option);
            cmd_text_convert_any_to_hex_4.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_hex_4_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_hex_4_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_hex_4_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToHex(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_url_5 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-url" });
            cmd_text_convert_any_to_url_5.Description = "将任意格式的数据转换为 URL 编码";
            var opt_text_convert_any_to_url_5_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_url_5.Options.Add(opt_text_convert_any_to_url_5_text);
            var opt_text_convert_any_to_url_5_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_url_5.Options.Add(opt_text_convert_any_to_url_5_From);
            var opt_text_convert_any_to_url_5_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_url_5.Options.Add(opt_text_convert_any_to_url_5_option);
            cmd_text_convert_any_to_url_5.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_url_5_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_url_5_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_url_5_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToURL(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_unicode_6 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-unicode" });
            cmd_text_convert_any_to_unicode_6.Description = "将任意格式的数据转换为 Unicode 转义字符";
            var opt_text_convert_any_to_unicode_6_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_unicode_6.Options.Add(opt_text_convert_any_to_unicode_6_text);
            var opt_text_convert_any_to_unicode_6_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_unicode_6.Options.Add(opt_text_convert_any_to_unicode_6_From);
            var opt_text_convert_any_to_unicode_6_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_unicode_6.Options.Add(opt_text_convert_any_to_unicode_6_option);
            cmd_text_convert_any_to_unicode_6.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_unicode_6_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_unicode_6_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_unicode_6_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToUnicode(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_binary_bytes_7 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-binary-bytes" });
            cmd_text_convert_any_to_binary_bytes_7.Description = "将任意格式的数据转换为二进制字节数据, 返回字节数组";
            var opt_text_convert_any_to_binary_bytes_7_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_binary_bytes_7.Options.Add(opt_text_convert_any_to_binary_bytes_7_text);
            var opt_text_convert_any_to_binary_bytes_7_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_binary_bytes_7.Options.Add(opt_text_convert_any_to_binary_bytes_7_From);
            var opt_text_convert_any_to_binary_bytes_7_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_binary_bytes_7.Options.Add(opt_text_convert_any_to_binary_bytes_7_option);
            cmd_text_convert_any_to_binary_bytes_7.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_binary_bytes_7_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_binary_bytes_7_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_binary_bytes_7_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToBinaryBytes(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_binary_string_8 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-binary-string" });
            cmd_text_convert_any_to_binary_string_8.Description = "将任意格式的数据转换为二进制字节数据, 返回字符串";
            var opt_text_convert_any_to_binary_string_8_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_binary_string_8.Options.Add(opt_text_convert_any_to_binary_string_8_text);
            var opt_text_convert_any_to_binary_string_8_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_binary_string_8.Options.Add(opt_text_convert_any_to_binary_string_8_From);
            var opt_text_convert_any_to_binary_string_8_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_binary_string_8.Options.Add(opt_text_convert_any_to_binary_string_8_option);
            cmd_text_convert_any_to_binary_string_8.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_binary_string_8_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_binary_string_8_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_binary_string_8_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToBinaryString(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_md5_9 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-md5" });
            cmd_text_convert_any_to_md5_9.Description = "将任意格式的数据转换为 MD5 哈希值";
            var opt_text_convert_any_to_md5_9_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_md5_9.Options.Add(opt_text_convert_any_to_md5_9_text);
            var opt_text_convert_any_to_md5_9_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_md5_9.Options.Add(opt_text_convert_any_to_md5_9_From);
            var opt_text_convert_any_to_md5_9_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_md5_9.Options.Add(opt_text_convert_any_to_md5_9_option);
            cmd_text_convert_any_to_md5_9.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_md5_9_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_md5_9_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_md5_9_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToMD5(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_sha1_10 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-sha1" });
            cmd_text_convert_any_to_sha1_10.Description = "将任意格式的数据转换为 SHA1 哈希值";
            var opt_text_convert_any_to_sha1_10_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_sha1_10.Options.Add(opt_text_convert_any_to_sha1_10_text);
            var opt_text_convert_any_to_sha1_10_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_sha1_10.Options.Add(opt_text_convert_any_to_sha1_10_From);
            var opt_text_convert_any_to_sha1_10_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_sha1_10.Options.Add(opt_text_convert_any_to_sha1_10_option);
            cmd_text_convert_any_to_sha1_10.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_sha1_10_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_sha1_10_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_sha1_10_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToSHA1(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_sha256_11 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-sha256" });
            cmd_text_convert_any_to_sha256_11.Description = "将任意格式的数据转换为 SHA256 哈希值";
            var opt_text_convert_any_to_sha256_11_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_sha256_11.Options.Add(opt_text_convert_any_to_sha256_11_text);
            var opt_text_convert_any_to_sha256_11_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_sha256_11.Options.Add(opt_text_convert_any_to_sha256_11_From);
            var opt_text_convert_any_to_sha256_11_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_sha256_11.Options.Add(opt_text_convert_any_to_sha256_11_option);
            cmd_text_convert_any_to_sha256_11.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_sha256_11_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_sha256_11_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_sha256_11_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToSHA256(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_convert_any_to_sha512_12 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-sha512" });
            cmd_text_convert_any_to_sha512_12.Description = "将任意格式的数据转换为 SHA512 哈希值";
            var opt_text_convert_any_to_sha512_12_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            cmd_text_convert_any_to_sha512_12.Options.Add(opt_text_convert_any_to_sha512_12_text);
            var opt_text_convert_any_to_sha512_12_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            cmd_text_convert_any_to_sha512_12.Options.Add(opt_text_convert_any_to_sha512_12_From);
            var opt_text_convert_any_to_sha512_12_option = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            cmd_text_convert_any_to_sha512_12.Options.Add(opt_text_convert_any_to_sha512_12_option);
            cmd_text_convert_any_to_sha512_12.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_convert_any_to_sha512_12_text);
                var From = parseResult.GetValue(opt_text_convert_any_to_sha512_12_From);
                object option = parseResult.GetValue(opt_text_convert_any_to_sha512_12_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Convert.AnyToSHA512(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}