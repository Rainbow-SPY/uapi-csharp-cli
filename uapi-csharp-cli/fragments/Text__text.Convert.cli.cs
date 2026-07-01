using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_text_Convert
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "converter" });
            o.Description = "不同文本格式之间转换";
            var o_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的源文本"
            };
            o.Options.Add(o_t);
            var o_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "源格式"
            };
            o.Options.Add(o_f);
            var o_to = new Option<Text.Convert.Format>("--to")
            {
                Required = true, Description = "目标格式"
            };
            o.Options.Add(o_to);
            var o_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_o);
            o.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o_t);
                var From = parseResult.GetValue(o_f);
                var To = parseResult.GetValue(o_to);
                object option = parseResult.GetValue(o_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.Converter(text, From, To, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-text" });
            o2.Description = "将任意格式的数据转换为文本";
            var o2_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o2.Options.Add(o2_t);
            var o2_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o2.Options.Add(o2_f);
            var o2_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o2.Options.Add(o2_o);
            o2.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o2_t);
                var From = parseResult.GetValue(o2_f);
                object option = parseResult.GetValue(o2_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToText(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o3 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-base64" });
            o3.Description = "将任意格式的数据转换为 Base64";
            var o3_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o3.Options.Add(o3_t);
            var o3_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o3.Options.Add(o3_f);
            var o3_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o3.Options.Add(o3_o);
            o3.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o3_t);
                var From = parseResult.GetValue(o3_f);
                object option = parseResult.GetValue(o3_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToBase64(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o4 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-hex" });
            o4.Description = "将任意格式的数据转换为十六进制 (不带 - , 小写字母+数字)";
            var o4_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o4.Options.Add(o4_t);
            var o4_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o4.Options.Add(o4_f);
            var o4_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o4.Options.Add(o4_o);
            o4.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o4_t);
                var From = parseResult.GetValue(o4_f);
                object option = parseResult.GetValue(o4_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToHex(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o5 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-url" });
            o5.Description = "将任意格式的数据转换为 URL 编码";
            var o5_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o5.Options.Add(o5_t);
            var o5_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o5.Options.Add(o5_f);
            var o5_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o5.Options.Add(o5_o);
            o5.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o5_t);
                var From = parseResult.GetValue(o5_f);
                object option = parseResult.GetValue(o5_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToURL(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o6 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-unicode" });
            o6.Description = "将任意格式的数据转换为 Unicode 转义字符";
            var o6_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o6.Options.Add(o6_t);
            var o6_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o6.Options.Add(o6_f);
            var o6_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o6.Options.Add(o6_o);
            o6.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o6_t);
                var From = parseResult.GetValue(o6_f);
                object option = parseResult.GetValue(o6_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToUnicode(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o7 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-binary-bytes" });
            o7.Description = "将任意格式的数据转换为二进制字节数据, 返回字节数组";
            var o7_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o7.Options.Add(o7_t);
            var o7_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o7.Options.Add(o7_f);
            var o7_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o7.Options.Add(o7_o);
            o7.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o7_t);
                var From = parseResult.GetValue(o7_f);
                object option = parseResult.GetValue(o7_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToBinaryBytes(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o8 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-binary-string" });
            o8.Description = "将任意格式的数据转换为二进制字节数据, 返回字符串";
            var o8_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o8.Options.Add(o8_t);
            var o8_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o8.Options.Add(o8_f);
            var o8_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o8.Options.Add(o8_o);
            o8.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o8_t);
                var From = parseResult.GetValue(o8_f);
                object option = parseResult.GetValue(o8_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToBinaryString(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o9 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-md5" });
            o9.Description = "将任意格式的数据转换为 MD5 哈希值";
            var o9_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o9.Options.Add(o9_t);
            var o9_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o9.Options.Add(o9_f);
            var o9_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o9.Options.Add(o9_o);
            o9.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o9_t);
                var From = parseResult.GetValue(o9_f);
                object option = parseResult.GetValue(o9_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToMD5(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o10 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-sha1" });
            o10.Description = "将任意格式的数据转换为 SHA1 哈希值";
            var o10_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o10.Options.Add(o10_t);
            var o10_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o10.Options.Add(o10_f);
            var o10_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o10.Options.Add(o10_o);
            o10.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o10_t);
                var From = parseResult.GetValue(o10_f);
                object option = parseResult.GetValue(o10_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToSHA1(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o11 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-sha256" });
            o11.Description = "将任意格式的数据转换为 SHA256 哈希值";
            var o11_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o11.Options.Add(o11_t);
            var o11_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o11.Options.Add(o11_f);
            var o11_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o11.Options.Add(o11_o);
            o11.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o11_t);
                var From = parseResult.GetValue(o11_f);
                object option = parseResult.GetValue(o11_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToSHA256(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o12 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "convert", "any-to-sha512" });
            o12.Description = "将任意格式的数据转换为 SHA512 哈希值";
            var o12_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要转换的文本"
            };
            o12.Options.Add(o12_t);
            var o12_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true, Description = "指定要转换的文本的原格式"
            };
            o12.Options.Add(o12_f);
            var o12_o = new Option<string>("--option")
            {
                Required = false, Description = "预留, 未投入使用", DefaultValueFactory = _ => null
            };
            o12.Options.Add(o12_o);
            o12.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o12_t);
                var From = parseResult.GetValue(o12_f);
                object option = parseResult.GetValue(o12_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Convert.AnyToSHA512(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}