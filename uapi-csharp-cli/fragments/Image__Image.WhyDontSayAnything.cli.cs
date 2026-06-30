using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_WhyDontSayAnything
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "image", "why-dont-say-anything" });
            o.Description =
                "生成\"你们怎么不说话了\"表情包 (POST) 上方描述某个行为，下方通常以「们」开头表示劝阻，形成戏谑的对比效果。";
            var ot = new Option<string>("--top-text")
            {
                Required = true, Description = "表情包上方的文字内容，例如 \"玩Uapi\""
            };
            o.Options.Add(ot);
            var ob = new Option<string>("--bottom-text")
            {
                Required = false, Description = "表情包下方的文字内容，例如 \"们不要玩Uapi了\"", DefaultValueFactory = _ => ""
            };
            o.Options.Add(ob);
            o.SetAction(parseResult =>
            {
                var topText = parseResult.GetValue(ot);
                var bottomText = parseResult.GetValue(ob);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostWhyDontSayAnything(topText, bottomText, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}