using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_Translate_AI
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "ai-translate" });
            var o_t = new Option<string>("--texts")
            {
                Required = true, Description = "待翻译的文本内容。最大长度10,000 字符"
            };
            o.Options.Add(o_t);
            var o_l = new Option<SupportLanguages>("--language")
            {
                Required = true, Description = "目标语言代码。请从支持的语言列表中选择一个语言代码"
            };
            o.Options.Add(o_l);
            var o_sl = new Option<string>("--source-language")
            {
                Required = false, Description = "源语言代码，可选。如果不指定，系统会自动检测源语言。", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_sl);
            var o_st = new Option<Style>("--style")
            {
                Required = false,
                Description = "翻译风格，可选。支持casual(随意口语化)、professional(专业商务，默认)、academic(学术正式)、literary(文学艺术)",
                DefaultValueFactory = _ => Style.None
            };
            o.Options.Add(o_st);
            var o_c = new Option<Context>("--context")
            {
                Required = false,
                Description =
                    "翻译上下文场景，可选。支持general(通用，默认)、business(商务)、technical(技术)、medical(医疗)、legal(法律)、marketing(市场营销)、entertainment(娱乐)、education(教育)、news(新闻)",
                DefaultValueFactory = _ => Context.general
            };
            o.Options.Add(o_c);
            var o_p = new Option<bool>("--preserve-format")
            {
                Required = false, Description = "是否保留原文格式，包括换行、缩进等", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_p);
            o.SetAction(parseResult =>
            {
                var texts = parseResult.GetValue(o_t);
                var Language = parseResult.GetValue(o_l);
                var source_Language = parseResult.GetValue(o_sl);
                var style = parseResult.GetValue(o_st);
                var Context = parseResult.GetValue(o_c);
                var preserve_Format = parseResult.GetValue(o_p);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.AITranslate(texts, Language, source_Language, style, Context, preserve_Format,
                    AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}