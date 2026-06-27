using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_WhyDontSayAnything
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_image_why_dont_say_anything_1 =
                CliCommandTree.GetOrAdd(root, new[] { "image", "why-dont-say-anything" });
            cmd_image_why_dont_say_anything_1.Description =
                "生成\"你们怎么不说话了\"表情包 (POST) 上方描述某个行为，下方通常以「们」开头表示劝阻，形成戏谑的对比效果。";
            var opt_image_why_dont_say_anything_1_topText = new Option<string>("--top-text")
            {
                Required = true, Description = "表情包上方的文字内容，例如 \"玩Uapi\""
            };
            cmd_image_why_dont_say_anything_1.Options.Add(opt_image_why_dont_say_anything_1_topText);
            var opt_image_why_dont_say_anything_1_bottomText = new Option<string>("--bottom-text")
            {
                Required = false, Description = "表情包下方的文字内容，例如 \"们不要玩Uapi了\"", DefaultValueFactory = _ => ""
            };
            cmd_image_why_dont_say_anything_1.Options.Add(opt_image_why_dont_say_anything_1_bottomText);
            cmd_image_why_dont_say_anything_1.SetAction(async parseResult =>
            {
                var topText = parseResult.GetValue(opt_image_why_dont_say_anything_1_topText);
                var bottomText = parseResult.GetValue(opt_image_why_dont_say_anything_1_bottomText);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.PostWhyDontSayAnything(topText, bottomText, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}