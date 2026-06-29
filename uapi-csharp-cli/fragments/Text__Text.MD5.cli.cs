using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_MD5
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_text_md5_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "md5" });
            cmd_text_md5_1.Description = "获取指定文本的MD5";
            var opt_text_md5_1_texts = new Option<string>("--texts")
            {
                Required = true, Description = "指定要计算MD5的文本"
            };
            cmd_text_md5_1.Options.Add(opt_text_md5_1_texts);
            var opt_text_md5_1_requestType = new Option<Interface.SendRequestType>("--request-type")
            {
                Required = false,
                Description =
                    "请求方式, Interface.SendRequestType.POST/Interface.SendRequestType.GET, 默认为 Interface.SendRequestType.POST",
                DefaultValueFactory = _ => Interface.SendRequestType.POST
            };
            cmd_text_md5_1.Options.Add(opt_text_md5_1_requestType);
            cmd_text_md5_1.SetAction(parseResult =>
            {
                var texts = parseResult.GetValue(opt_text_md5_1_texts);
                var requestType = parseResult.GetValue(opt_text_md5_1_requestType);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.CreateMD5(texts, requestType, AuthenticationAPITokenKey).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_text_created_md5_2 = CliCommandTree.GetOrAdd(root, new[] { "text", "created-md5" });
            cmd_text_created_md5_2.Description = "获取指定文本的MD5, 直接返回 string, 可等待";
            var opt_text_created_md5_2_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要计算MD5的文本"
            };
            cmd_text_created_md5_2.Options.Add(opt_text_created_md5_2_text);
            var opt_text_created_md5_2_requestType = new Option<Interface.SendRequestType>("--request-type")
            {
                Required = false, Description = "请求方式", DefaultValueFactory = _ => Interface.SendRequestType.POST
            };
            cmd_text_created_md5_2.Options.Add(opt_text_created_md5_2_requestType);
            cmd_text_created_md5_2.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(opt_text_created_md5_2_text);
                var requestType = parseResult.GetValue(opt_text_created_md5_2_requestType);
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