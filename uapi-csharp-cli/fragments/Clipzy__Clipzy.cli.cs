using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Clipzy_Clipzy
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_clipzy_data_1 = CliCommandTree.GetOrAdd(root, new[] { "clipzy", "data" });
            cmd_clipzy_data_1.Description = "获取 Clipzy 剪贴板中的加密数据 提供第一步获得的 ID，返回存储在服务器上的加密数据。需要在客户端中自行解密。";
            var opt_clipzy_data_1_id = new Option<string>("--id")
            {
                Required = true, Description = "片段的唯一 ID"
            };
            cmd_clipzy_data_1.Options.Add(opt_clipzy_data_1_id);
            cmd_clipzy_data_1.SetAction(parseResult =>
            {
                var id = parseResult.GetValue(opt_clipzy_data_1_id);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Clipzy.GetClipzyData(id, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_clipzy_raw_2 = CliCommandTree.GetOrAdd(root, new[] { "clipzy", "raw" });
            cmd_clipzy_raw_2.Description = "获取 Clipzy 剪贴板中的原始解密文本 提供 ID 和 Base64 编码的 AES 密钥，服务器直接解密并返回纯文本内容。";
            var opt_clipzy_raw_2_id = new Option<string>("--id")
            {
                Required = true, Description = "片段的唯一 ID"
            };
            cmd_clipzy_raw_2.Options.Add(opt_clipzy_raw_2_id);
            var opt_clipzy_raw_2_key = new Option<string>("--key")
            {
                Required = true, Description = "用于解密的 Base64 编码的 AES 密钥"
            };
            cmd_clipzy_raw_2.Options.Add(opt_clipzy_raw_2_key);
            cmd_clipzy_raw_2.SetAction(parseResult =>
            {
                var id = parseResult.GetValue(opt_clipzy_raw_2_id);
                var key = parseResult.GetValue(opt_clipzy_raw_2_key);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Clipzy.GetClipzyRaw(id, key, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_clipzy_store_3 = CliCommandTree.GetOrAdd(root, new[] { "clipzy", "store" });
            cmd_clipzy_store_3.Description = "上传加密数据到 Clipzy 剪贴板 客户端需要先在本地准备好加密后的数据，上传成功后得到一个唯一 ID。";
            var opt_clipzy_store_3_compressedData = new Option<string>("--compressed-data")
            {
                Required = true, Description = "经过加密和 LZString 压缩后的 Base64 字符串"
            };
            cmd_clipzy_store_3.Options.Add(opt_clipzy_store_3_compressedData);
            var opt_clipzy_store_3_ttl = new Option<int>("--ttl")
            {
                Required = false, Description = "片段的留存时间（秒）。正数表示秒数（最大约 30 天），-1 表示永久存储。默认为 3600。",
                DefaultValueFactory = _ => 3600
            };
            cmd_clipzy_store_3.Options.Add(opt_clipzy_store_3_ttl);
            cmd_clipzy_store_3.SetAction(parseResult =>
            {
                var compressedData = parseResult.GetValue(opt_clipzy_store_3_compressedData);
                var ttl = parseResult.GetValue(opt_clipzy_store_3_ttl);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Clipzy.PostClipzyStore(compressedData, ttl, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}