using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_MD5
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "md5", "result" });
            o.Description = "获取指定文本的MD5";
            var o_t = new Option<string>("--texts")
            {
                Required = true, Description = "指定要计算MD5的文本"
            };
            o.Options.Add(o_t);
            var o_r = new Option<Interface.SendRequestType>("--request-type")
            {
                Required = false,
                Description =
                    "请求方式, Interface.SendRequestType.POST/Interface.SendRequestType.GET, 默认为 Interface.SendRequestType.POST",
                DefaultValueFactory = _ => Interface.SendRequestType.POST
            };
            o.Options.Add(o_r);
            o.SetAction(parseResult =>
            {
                var texts = parseResult.GetValue(o_t);
                var requestType = parseResult.GetValue(o_r);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.CreateMD5(texts, requestType, AuthenticationAPITokenKey).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "text", "md5", "text" });
            o2.Description = "获取指定文本的MD5, 直接返回 string, 可等待";
            var o2_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要计算MD5的文本"
            };
            o2.Options.Add(o2_t);
            var o2_rt = new Option<Interface.SendRequestType>("--request-type")
            {
                Required = false, Description = "请求方式", DefaultValueFactory = _ => Interface.SendRequestType.POST
            };
            o2.Options.Add(o2_rt);
            o2.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o2_t);
                var requestType = parseResult.GetValue(o2_rt);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.ReturnCreatedMD5(text, requestType, AuthenticationAPITokenKey).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}