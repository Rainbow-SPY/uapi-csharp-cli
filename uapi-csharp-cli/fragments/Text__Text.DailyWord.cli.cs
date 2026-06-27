using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_DailyWord
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_daily_word_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "daily-word" });
            cmd_text_daily_word_1.Description = "每日单词";
            var opt_text_daily_word_1_lang = new Option<string>("--lang")
            {
                Required = false, Description = "语种，目前支持 en，默认 en。", DefaultValueFactory = _ => "en"
            };
            cmd_text_daily_word_1.Options.Add(opt_text_daily_word_1_lang);
            var opt_text_daily_word_1_cat = new Option<Type.DailyWord.CategoryEnum>("--cat")
            {
                Required = false, Description = "词库范围：all/cet4/cet6/ielts/toefl/gre，默认 all。",
                DefaultValueFactory = _ => Type.DailyWord.CategoryEnum.all
            };
            cmd_text_daily_word_1.Options.Add(opt_text_daily_word_1_cat);
            var opt_text_daily_word_1_count = new Option<int>("--count")
            {
                Required = false, Description = "返回数量，1-20，默认 1。", DefaultValueFactory = _ => 1
            };
            cmd_text_daily_word_1.Options.Add(opt_text_daily_word_1_count);
            var opt_text_daily_word_1_date = new Option<string>("--date")
            {
                Required = false, Description = "日期，格式 YYYY-MM-DD，作为每日单词的种子基准。", DefaultValueFactory = _ => ""
            };
            cmd_text_daily_word_1.Options.Add(opt_text_daily_word_1_date);
            var opt_text_daily_word_1_seed = new Option<int>("--seed")
            {
                Required = false, Description = "固定种子，结果可复现；不可与 date 同时使用。", DefaultValueFactory = _ => 0
            };
            cmd_text_daily_word_1.Options.Add(opt_text_daily_word_1_seed);
            var opt_text_daily_word_1_example = new Option<bool>("--example")
            {
                Required = false, Description = "是否返回例句，默认 true。", DefaultValueFactory = _ => true
            };
            cmd_text_daily_word_1.Options.Add(opt_text_daily_word_1_example);
            var opt_text_daily_word_1_phonetic = new Option<bool>("--phonetic")
            {
                Required = false, Description = "是否返回音标，默认 true。", DefaultValueFactory = _ => true
            };
            cmd_text_daily_word_1.Options.Add(opt_text_daily_word_1_phonetic);
            cmd_text_daily_word_1.SetAction(async parseResult =>
            {
                var lang = parseResult.GetValue(opt_text_daily_word_1_lang);
                var cat = parseResult.GetValue(opt_text_daily_word_1_cat);
                var count = parseResult.GetValue(opt_text_daily_word_1_count);
                var date = parseResult.GetValue(opt_text_daily_word_1_date);
                var seed = parseResult.GetValue(opt_text_daily_word_1_seed);
                var example = parseResult.GetValue(opt_text_daily_word_1_example);
                var phonetic = parseResult.GetValue(opt_text_daily_word_1_phonetic);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.GetDailyWord(lang, cat, count, date, seed, example, phonetic, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}