using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_IConvert
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_i_convert_image_svg_convert_to_bit_image_1 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "image", "svg-convert-to-bit-image" });
            var opt_i_convert_image_svg_convert_to_bit_image_1_svg = new Option<string>("--svg")
            {
                Required = true
            };
            cmd_i_convert_image_svg_convert_to_bit_image_1.Options.Add(
                opt_i_convert_image_svg_convert_to_bit_image_1_svg);
            var opt_i_convert_image_svg_convert_to_bit_image_1_format =
                new Option<Type.SVGConvertType.SVGFormat>("--format")
                {
                    Required = false, DefaultValueFactory = _ => Type.SVGConvertType.SVGFormat.png
                };
            cmd_i_convert_image_svg_convert_to_bit_image_1.Options.Add(
                opt_i_convert_image_svg_convert_to_bit_image_1_format);
            var opt_i_convert_image_svg_convert_to_bit_image_1_width = new Option<int?>("--width")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_image_svg_convert_to_bit_image_1.Options.Add(
                opt_i_convert_image_svg_convert_to_bit_image_1_width);
            var opt_i_convert_image_svg_convert_to_bit_image_1_height = new Option<int?>("--height")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_image_svg_convert_to_bit_image_1.Options.Add(
                opt_i_convert_image_svg_convert_to_bit_image_1_height);
            var opt_i_convert_image_svg_convert_to_bit_image_1_quality = new Option<int>("--quality")
            {
                Required = false, DefaultValueFactory = _ => 90
            };
            cmd_i_convert_image_svg_convert_to_bit_image_1.Options.Add(
                opt_i_convert_image_svg_convert_to_bit_image_1_quality);
            cmd_i_convert_image_svg_convert_to_bit_image_1.SetAction(async parseResult =>
            {
                var svgPath = parseResult.GetValue(opt_i_convert_image_svg_convert_to_bit_image_1_svg);
                var svg = File.ReadAllBytes(svgPath);
                var format = parseResult.GetValue(opt_i_convert_image_svg_convert_to_bit_image_1_format);
                var width = parseResult.GetValue(opt_i_convert_image_svg_convert_to_bit_image_1_width);
                var height = parseResult.GetValue(opt_i_convert_image_svg_convert_to_bit_image_1_height);
                var quality = parseResult.GetValue(opt_i_convert_image_svg_convert_to_bit_image_1_quality);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result =
                    await IConvert.Image.PostSVGConvertToBitImage(svg, format, width, height, quality, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_converter_2 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "converter" });
            var opt_i_convert_text_converter_2_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_converter_2.Options.Add(opt_i_convert_text_converter_2_text);
            var opt_i_convert_text_converter_2_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_converter_2.Options.Add(opt_i_convert_text_converter_2_From);
            var opt_i_convert_text_converter_2_To = new Option<Text.Convert.Format>("--to")
            {
                Required = true
            };
            cmd_i_convert_text_converter_2.Options.Add(opt_i_convert_text_converter_2_To);
            var opt_i_convert_text_converter_2_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_converter_2.Options.Add(opt_i_convert_text_converter_2_option);
            cmd_i_convert_text_converter_2.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_converter_2_text);
                var From = parseResult.GetValue(opt_i_convert_text_converter_2_From);
                var To = parseResult.GetValue(opt_i_convert_text_converter_2_To);
                var Authentication = parseResult.GetValue(authenticationOption);
                object option = parseResult.GetValue(opt_i_convert_text_converter_2_option);
                var result = await IConvert.Text.Converter(text, From, To, Authentication, option);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_text_3 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-text" });
            var opt_i_convert_text_any_to_text_3_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_text_3.Options.Add(opt_i_convert_text_any_to_text_3_text);
            var opt_i_convert_text_any_to_text_3_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_text_3.Options.Add(opt_i_convert_text_any_to_text_3_From);
            var opt_i_convert_text_any_to_text_3_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_text_3.Options.Add(opt_i_convert_text_any_to_text_3_option);
            cmd_i_convert_text_any_to_text_3.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_text_3_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_text_3_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_text_3_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToText(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_base64_4 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-base64" });
            var opt_i_convert_text_any_to_base64_4_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_base64_4.Options.Add(opt_i_convert_text_any_to_base64_4_text);
            var opt_i_convert_text_any_to_base64_4_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_base64_4.Options.Add(opt_i_convert_text_any_to_base64_4_From);
            var opt_i_convert_text_any_to_base64_4_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_base64_4.Options.Add(opt_i_convert_text_any_to_base64_4_option);
            cmd_i_convert_text_any_to_base64_4.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_base64_4_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_base64_4_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_base64_4_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToBase64(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_hex_5 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-hex" });
            var opt_i_convert_text_any_to_hex_5_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_hex_5.Options.Add(opt_i_convert_text_any_to_hex_5_text);
            var opt_i_convert_text_any_to_hex_5_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_hex_5.Options.Add(opt_i_convert_text_any_to_hex_5_From);
            var opt_i_convert_text_any_to_hex_5_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_hex_5.Options.Add(opt_i_convert_text_any_to_hex_5_option);
            cmd_i_convert_text_any_to_hex_5.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_hex_5_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_hex_5_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_hex_5_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToHex(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_url_6 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-url" });
            var opt_i_convert_text_any_to_url_6_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_url_6.Options.Add(opt_i_convert_text_any_to_url_6_text);
            var opt_i_convert_text_any_to_url_6_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_url_6.Options.Add(opt_i_convert_text_any_to_url_6_From);
            var opt_i_convert_text_any_to_url_6_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_url_6.Options.Add(opt_i_convert_text_any_to_url_6_option);
            cmd_i_convert_text_any_to_url_6.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_url_6_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_url_6_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_url_6_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToURL(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_unicode_7 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-unicode" });
            var opt_i_convert_text_any_to_unicode_7_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_unicode_7.Options.Add(opt_i_convert_text_any_to_unicode_7_text);
            var opt_i_convert_text_any_to_unicode_7_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_unicode_7.Options.Add(opt_i_convert_text_any_to_unicode_7_From);
            var opt_i_convert_text_any_to_unicode_7_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_unicode_7.Options.Add(opt_i_convert_text_any_to_unicode_7_option);
            cmd_i_convert_text_any_to_unicode_7.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_unicode_7_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_unicode_7_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_unicode_7_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToUnicode(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_binary_bytes_8 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-binary-bytes" });
            var opt_i_convert_text_any_to_binary_bytes_8_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_binary_bytes_8.Options.Add(opt_i_convert_text_any_to_binary_bytes_8_text);
            var opt_i_convert_text_any_to_binary_bytes_8_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_binary_bytes_8.Options.Add(opt_i_convert_text_any_to_binary_bytes_8_From);
            var opt_i_convert_text_any_to_binary_bytes_8_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_binary_bytes_8.Options.Add(opt_i_convert_text_any_to_binary_bytes_8_option);
            cmd_i_convert_text_any_to_binary_bytes_8.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_binary_bytes_8_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_binary_bytes_8_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_binary_bytes_8_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToBinaryBytes(text, From, option, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_binary_string_9 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-binary-string" });
            var opt_i_convert_text_any_to_binary_string_9_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_binary_string_9.Options.Add(opt_i_convert_text_any_to_binary_string_9_text);
            var opt_i_convert_text_any_to_binary_string_9_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_binary_string_9.Options.Add(opt_i_convert_text_any_to_binary_string_9_From);
            var opt_i_convert_text_any_to_binary_string_9_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_binary_string_9.Options.Add(opt_i_convert_text_any_to_binary_string_9_option);
            cmd_i_convert_text_any_to_binary_string_9.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_binary_string_9_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_binary_string_9_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_binary_string_9_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToBinaryString(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_md5_10 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-md5" });
            var opt_i_convert_text_any_to_md5_10_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_md5_10.Options.Add(opt_i_convert_text_any_to_md5_10_text);
            var opt_i_convert_text_any_to_md5_10_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_md5_10.Options.Add(opt_i_convert_text_any_to_md5_10_From);
            var opt_i_convert_text_any_to_md5_10_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_md5_10.Options.Add(opt_i_convert_text_any_to_md5_10_option);
            cmd_i_convert_text_any_to_md5_10.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_md5_10_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_md5_10_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_md5_10_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToMD5(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_sha1_11 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-sha1" });
            var opt_i_convert_text_any_to_sha1_11_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_sha1_11.Options.Add(opt_i_convert_text_any_to_sha1_11_text);
            var opt_i_convert_text_any_to_sha1_11_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_sha1_11.Options.Add(opt_i_convert_text_any_to_sha1_11_From);
            var opt_i_convert_text_any_to_sha1_11_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_sha1_11.Options.Add(opt_i_convert_text_any_to_sha1_11_option);
            cmd_i_convert_text_any_to_sha1_11.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_sha1_11_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_sha1_11_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_sha1_11_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToSHA1(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_sha256_12 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-sha256" });
            var opt_i_convert_text_any_to_sha256_12_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_sha256_12.Options.Add(opt_i_convert_text_any_to_sha256_12_text);
            var opt_i_convert_text_any_to_sha256_12_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_sha256_12.Options.Add(opt_i_convert_text_any_to_sha256_12_From);
            var opt_i_convert_text_any_to_sha256_12_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_sha256_12.Options.Add(opt_i_convert_text_any_to_sha256_12_option);
            cmd_i_convert_text_any_to_sha256_12.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_sha256_12_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_sha256_12_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_sha256_12_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToSHA256(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_text_any_to_sha512_13 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "text", "any-to-sha512" });
            var opt_i_convert_text_any_to_sha512_13_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_sha512_13.Options.Add(opt_i_convert_text_any_to_sha512_13_text);
            var opt_i_convert_text_any_to_sha512_13_From = new Option<Text.Convert.Format>("--from")
            {
                Required = true
            };
            cmd_i_convert_text_any_to_sha512_13.Options.Add(opt_i_convert_text_any_to_sha512_13_From);
            var opt_i_convert_text_any_to_sha512_13_option = new Option<string>("--option")
            {
                Required = false, DefaultValueFactory = _ => null
            };
            cmd_i_convert_text_any_to_sha512_13.Options.Add(opt_i_convert_text_any_to_sha512_13_option);
            cmd_i_convert_text_any_to_sha512_13.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_i_convert_text_any_to_sha512_13_text);
                var From = parseResult.GetValue(opt_i_convert_text_any_to_sha512_13_From);
                object option = parseResult.GetValue(opt_i_convert_text_any_to_sha512_13_option);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.Text.AnyToSHA512(text, From, option, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_web_to_markdown_14 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "web-to-markdown" });
            cmd_i_convert_web_to_markdown_14.Description = "网页转 Markdown（提交任务并等待结果）";
            var opt_i_convert_web_to_markdown_14_url = new Option<string>("--url")
            {
                Required = true, Description = "需要转换的网页 URL"
            };
            cmd_i_convert_web_to_markdown_14.Options.Add(opt_i_convert_web_to_markdown_14_url);
            cmd_i_convert_web_to_markdown_14.SetAction(async parseResult =>
            {
                var url = parseResult.GetValue(opt_i_convert_web_to_markdown_14_url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.WebToMarkdown(url, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_unix_to_timedate_15 =
                CliCommandTree.GetOrAdd(root, new[] { "i-convert", "unix-to-timedate" });
            cmd_i_convert_unix_to_timedate_15.Description = "Unix 时间戳转日期时间 (GET)";
            var opt_i_convert_unix_to_timedate_15_time = new Option<string>("--time")
            {
                Required = true, Description = "Unix 时间戳（10位或13位）或标准日期字符串（如 2023-10-27 10:30:00）"
            };
            cmd_i_convert_unix_to_timedate_15.Options.Add(opt_i_convert_unix_to_timedate_15_time);
            cmd_i_convert_unix_to_timedate_15.SetAction(async parseResult =>
            {
                var time = parseResult.GetValue(opt_i_convert_unix_to_timedate_15_time);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.UnixToTimedate(time, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_i_convert_format_json_16 = CliCommandTree.GetOrAdd(root, new[] { "i-convert", "format-json" });
            cmd_i_convert_format_json_16.Description = "JSON 格式化 (POST)";
            var opt_i_convert_format_json_16_json = new Option<string>("--json")
            {
                Required = true, Description = "需要格式化的原始 JSON 字符串"
            };
            cmd_i_convert_format_json_16.Options.Add(opt_i_convert_format_json_16_json);
            cmd_i_convert_format_json_16.SetAction(async parseResult =>
            {
                var json = parseResult.GetValue(opt_i_convert_format_json_16_json);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await IConvert.FormatJson(json, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}