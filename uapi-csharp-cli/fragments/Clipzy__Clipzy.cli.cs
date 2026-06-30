using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Clipzy_Clipzy
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "clipzy", "data" });
            o.Description = "获取 Clipzy 剪贴板中的加密数据 提供第一步获得的 ID，返回存储在服务器上的加密数据。需要在客户端中自行解密。";
            var o_id = new Option<string>("--id")
            {
                Required = true, Description = "片段的唯一 ID"
            };
            o.Options.Add(o_id);
            o.SetAction(parseResult =>
            {
                var id = parseResult.GetValue(o_id);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Clipzy.GetClipzyData(id, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "clipzy", "raw" });
            o2.Description = "获取 Clipzy 剪贴板中的原始解密文本 提供 ID 和 Base64 编码的 AES 密钥，服务器直接解密并返回纯文本内容。";
            var o2_id = new Option<string>("--id")
            {
                Required = true, Description = "片段的唯一 ID"
            };
            o2.Options.Add(o2_id);
            var o2_key = new Option<string>("--key")
            {
                Required = true, Description = "用于解密的 Base64 编码的 AES 密钥"
            };
            o2.Options.Add(o2_key);
            o2.SetAction(parseResult =>
            {
                var id = parseResult.GetValue(o2_id);
                var key = parseResult.GetValue(o2_key);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Clipzy.GetClipzyRaw(id, key, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o3 = CliCommandTree.GetOrAdd(root, new[] { "clipzy", "store" });
            o3.Description = "上传加密数据到 Clipzy 剪贴板 客户端需要先在本地准备好加密后的数据，上传成功后得到一个唯一 ID。";
            var o3_store = new Option<string>("--compressed-data")
            {
                Required = true, Description = "经过加密和 LZString 压缩后的 Base64 字符串"
            };
            o3.Options.Add(o3_store);
            var o3_ttl = new Option<int>("--ttl")
            {
                Required = false, Description = "片段的留存时间（秒）。正数表示秒数（最大约 30 天），-1 表示永久存储。默认为 3600。",
                DefaultValueFactory = _ => 3600
            };
            o3.Options.Add(o3_ttl);
            o3.SetAction(parseResult =>
            {
                var compressedData = parseResult.GetValue(o3_store);
                var ttl = parseResult.GetValue(o3_ttl);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Clipzy.PostClipzyStore(compressedData, ttl, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}