using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_DailyWord
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "daily-word" });
            o.Description = "每日单词";
            var o_l = new Option<string>("--lang")
            {
                Required = false, Description = "语种，目前支持 en，默认 en。", DefaultValueFactory = _ => "en"
            };
            o.Options.Add(o_l);
            var o_c = new Option<Type.DailyWord.CategoryEnum>("--cat")
            {
                Required = false, Description = "词库范围：all/cet4/cet6/ielts/toefl/gre，默认 all。",
                DefaultValueFactory = _ => Type.DailyWord.CategoryEnum.all
            };
            o.Options.Add(o_c);
            var o_co = new Option<int>("--count")
            {
                Required = false, Description = "返回数量，1-20，默认 1。", DefaultValueFactory = _ => 1
            };
            o.Options.Add(o_co);
            var o_d = new Option<string>("--date")
            {
                Required = false, Description = "日期，格式 YYYY-MM-DD，作为每日单词的种子基准。", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_d);
            var o_s = new Option<int>("--seed")
            {
                Required = false, Description = "固定种子，结果可复现；不可与 date 同时使用。", DefaultValueFactory = _ => 0
            };
            o.Options.Add(o_s);
            var o_e = new Option<bool>("--example")
            {
                Required = false, Description = "是否返回例句，默认 true。", DefaultValueFactory = _ => true
            };
            o.Options.Add(o_e);
            var o_p = new Option<bool>("--phonetic")
            {
                Required = false, Description = "是否返回音标，默认 true。", DefaultValueFactory = _ => true
            };
            o.Options.Add(o_p);
            o.SetAction(parseResult =>
            {
                var lang = parseResult.GetValue(o_l);
                var cat = parseResult.GetValue(o_c);
                var count = parseResult.GetValue(o_co);
                var date = parseResult.GetValue(o_d);
                var seed = parseResult.GetValue(o_s);
                var example = parseResult.GetValue(o_e);
                var phonetic = parseResult.GetValue(o_p);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.GetDailyWord(lang, cat, count, date, seed, example, phonetic, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}