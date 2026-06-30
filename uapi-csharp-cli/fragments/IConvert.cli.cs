using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_IConvert
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "convert", "image", "svg-to-bit" });
            o.Description = "将 SVG 矢量图转换为位图或矢量图 (POST)";
            var o_svg = new Option<string>("--svg")
            {
                Required = true
            };
            o.Options.Add(o_svg);
            var o_f = new Option<Type.SVGConvertType.SVGFormat>("--format")
            {
                Required = false, DefaultValueFactory = _ => Type.SVGConvertType.SVGFormat.png,
                Description = "输出图片格式 (默认 png)"
            };
            o.Options.Add(o_f);
            var o_w = new Option<int?>("--width")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "输出宽度 (像素)，不传则保持 SVG 原始宽高比"
            };
            o.Options.Add(o_w);
            var o_h = new Option<int?>("--height")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "输出高度 (像素)，不传则保持 SVG 原始宽高比"
            };
            o.Options.Add(o_h);
            var o_q = new Option<int>("--quality")
            {
                Required = false, DefaultValueFactory = _ => 90,
                Description = "输出质量 (1-100，默认 90)，仅 JPEG 格式有效"
            };
            o.Options.Add(o_q);
            o.SetAction(parseResult =>
            {
                var svgPath = parseResult.GetValue(o_svg);
                var svg = File.ReadAllBytes(svgPath);
                var format = parseResult.GetValue(o_f);
                var width = parseResult.GetValue(o_w);
                var height = parseResult.GetValue(o_h);
                var quality = parseResult.GetValue(o_q);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Image
                    .PostSVGConvertToBitImage(svg, format, width, height, quality, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "converter" });
            o2.Description = "不同文本格式之间转换";
            var o2_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的源文本"
            };
            o2.Options.Add(o2_t);
            var o2_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "源格式"
            };
            o2.Options.Add(o2_f);
            var o2_to = new Option<Text.Convert.Format>("--to")
            {
                Required = true,
                Description = "目标格式"
            };
            o2.Options.Add(o2_to);
            var o_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o2.Options.Add(o_o);
            o2.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o2_t);
                var From = parseResult.GetValue(o2_f);
                var To = parseResult.GetValue(o2_to);
                var Authentication = parseResult.GetValue(authenticationOption);
                object option = parseResult.GetValue(o_o);
                var result = IConvert.Text.Converter(text, From, To, Authentication, option).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o3 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-text" });
            o3.Description = "将任意格式的数据转换为文本";
            var o3_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o3.Options.Add(o3_t);
            var o3_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o3.Options.Add(o3_f);
            var o3_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o3.Options.Add(o3_o);
            o3.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o3_t);
                var From = parseResult.GetValue(o3_f);
                object option = parseResult.GetValue(o3_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToText(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o4 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-base64" });
            o4.Description = "将任意格式的数据转换为 Base64";
            var o4_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o4.Options.Add(o4_t);
            var o4_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o4.Options.Add(o4_f);
            var o4_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o4.Options.Add(o4_o);
            o4.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o4_t);
                var From = parseResult.GetValue(o4_f);
                object option = parseResult.GetValue(o4_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToBase64(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o5 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-hex" });
            o5.Description = "将任意格式的数据转换为十六进制 (不带 - , 小写字母+数字)";
            var o5_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o5.Options.Add(o5_t);
            var o5_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o5.Options.Add(o5_f);
            var o5_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o5.Options.Add(o5_o);
            o5.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o5_t);
                var From = parseResult.GetValue(o5_f);
                object option = parseResult.GetValue(o5_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToHex(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o6 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-url" });
            var o6_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o6.Options.Add(o6_t);
            var o6_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o6.Options.Add(o6_f);
            var o6_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o6.Options.Add(o6_o);
            o6.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o6_t);
                var From = parseResult.GetValue(o6_f);
                object option = parseResult.GetValue(o6_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToURL(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o7 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-unicode" });
            var o7_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o7.Options.Add(o7_t);
            var o7_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o7.Options.Add(o7_f);
            var o7_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o7.Options.Add(o7_o);
            o7.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o7_t);
                var From = parseResult.GetValue(o7_f);
                object option = parseResult.GetValue(o7_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToUnicode(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o8 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-binary-bytes" });
            var o8_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o8.Options.Add(o8_t);
            var o8_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o8.Options.Add(o8_f);
            var o8_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o8.Options.Add(o8_o);
            o8.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o8_t);
                var From = parseResult.GetValue(o8_f);
                object option = parseResult.GetValue(o8_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToBinaryBytes(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o9 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-binary-string" });
            var o9_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o9.Options.Add(o9_t);
            var o9_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o9.Options.Add(o9_f);
            var o9_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o9.Options.Add(o9_o);
            o9.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o9_t);
                var From = parseResult.GetValue(o9_f);
                object option = parseResult.GetValue(o9_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToBinaryString(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o10 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-md5" });
            var o10_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o10.Options.Add(o10_t);
            var o10_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o10.Options.Add(o10_f);
            var o10_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o10.Options.Add(o10_o);
            o10.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o10_t);
                var From = parseResult.GetValue(o10_f);
                object option = parseResult.GetValue(o10_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToMD5(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o11 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-sha1" });
            var o11_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o11.Options.Add(o11_t);
            var o11_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o11.Options.Add(o11_f);
            var o11_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o11.Options.Add(o11_o);
            o11.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o11_t);
                var From = parseResult.GetValue(o11_f);
                object option = parseResult.GetValue(o11_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToSHA1(text, From, option, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o12 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-sha256" });
            var o12_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o12.Options.Add(o12_t);
            var o12_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o12.Options.Add(o12_f);
            var o12_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o12.Options.Add(o12_o);
            o12.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o12_t);
                var From = parseResult.GetValue(o12_f);
                object option = parseResult.GetValue(o12_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToSHA256(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o13 = CliCommandTree.GetOrAdd(root, new[] { "convert", "text", "any-to-sha512" });
            var o13_t = new Option<string>("--text")
            {
                Required = true,
                Description = "指定要转换的文本"
            };
            o13.Options.Add(o13_t);
            var o13_f = new Option<Text.Convert.Format>("--from")
            {
                Required = true,
                Description = "指定要转换的文本的原格式"
            };
            o13.Options.Add(o13_f);
            var o13_o = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null,
                Description = "预留, 未投入使用"
            };
            o13.Options.Add(o13_o);
            o13.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o13_t);
                var From = parseResult.GetValue(o13_f);
                object option = parseResult.GetValue(o13_o);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.Text.AnyToSHA512(text, From, option, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o14 = CliCommandTree.GetOrAdd(root, new[] { "convert", "web-to-markdown" });
            o14.Description = "网页转 Markdown（提交任务并等待结果）";
            var o14_u = new Option<string>("--url")
            {
                Required = true, Description = "需要转换的网页 URL"
            };
            o14.Options.Add(o14_u);
            o14.SetAction(parseResult =>
            {
                var url = parseResult.GetValue(o14_u);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.WebToMarkdown(url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o15 =
                CliCommandTree.GetOrAdd(root, new[] { "convert", "unix-to-timedate" });
            o15.Description = "Unix 时间戳转日期时间 (GET)";
            var o15_t = new Option<string>("--time")
            {
                Required = true, Description = "Unix 时间戳（10位或13位）或标准日期字符串（如 2023-10-27 10:30:00）"
            };
            o15.Options.Add(o15_t);
            o15.SetAction(parseResult =>
            {
                var time = parseResult.GetValue(o15_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.UnixToTimedate(time, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o16 = CliCommandTree.GetOrAdd(root, new[] { "convert", "format-json" });
            o16.Description = "JSON 格式化 (POST)";
            var o16_j = new Option<string>("--json")
            {
                Required = true, Description = "需要格式化的原始 JSON 字符串"
            };
            o16.Options.Add(o16_j);
            o16.SetAction(parseResult =>
            {
                var json = parseResult.GetValue(o16_j);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = IConvert.FormatJson(json, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o17 = CliCommandTree.GetOrAdd(root, new[] { "convert", "timestamp-to-date" });
            o17.Description = "将Unix时间戳转换为人类可读日期时间的旧版接口";
            var o17_ts = new Option<string>("--ts")
            {
                Required = true,
                Description = "Unix 时间戳"
            };
            o17.Options.Add(o17_ts);
            o17.SetAction(parseResult =>
            {
                var ts = parseResult.GetValue(o17_ts);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.CovertTimestamp(ts, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}