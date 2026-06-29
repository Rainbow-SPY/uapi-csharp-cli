using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_Translate_AI
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_text_ai_translate_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "ai-translate" });
            var opt_text_ai_translate_1_texts = new Option<string>("--texts")
            {
                Required = true, Description = "待翻译的文本内容。最大长度10,000 字符"
            };
            cmd_text_ai_translate_1.Options.Add(opt_text_ai_translate_1_texts);
            var opt_text_ai_translate_1_Language = new Option<SupportLanguages>("--language")
            {
                Required = true, Description = "目标语言代码。请从支持的语言列表中选择一个语言代码"
            };
            cmd_text_ai_translate_1.Options.Add(opt_text_ai_translate_1_Language);
            var opt_text_ai_translate_1_source_Language = new Option<string>("--source-language")
            {
                Required = false, Description = "源语言代码，可选。如果不指定，系统会自动检测源语言。", DefaultValueFactory = _ => ""
            };
            cmd_text_ai_translate_1.Options.Add(opt_text_ai_translate_1_source_Language);
            var opt_text_ai_translate_1_style = new Option<Style>("--style")
            {
                Required = false,
                Description = "翻译风格，可选。支持casual(随意口语化)、professional(专业商务，默认)、academic(学术正式)、literary(文学艺术)",
                DefaultValueFactory = _ => Style.None
            };
            cmd_text_ai_translate_1.Options.Add(opt_text_ai_translate_1_style);
            var opt_text_ai_translate_1_Context = new Option<Context>("--context")
            {
                Required = false,
                Description =
                    "翻译上下文场景，可选。支持general(通用，默认)、business(商务)、technical(技术)、medical(医疗)、legal(法律)、marketing(市场营销)、entertainment(娱乐)、education(教育)、news(新闻)",
                DefaultValueFactory = _ => Context.general
            };
            cmd_text_ai_translate_1.Options.Add(opt_text_ai_translate_1_Context);
            var opt_text_ai_translate_1_preserve_Format = new Option<bool>("--preserve-format")
            {
                Required = false, Description = "是否保留原文格式，包括换行、缩进等", DefaultValueFactory = _ => false
            };
            cmd_text_ai_translate_1.Options.Add(opt_text_ai_translate_1_preserve_Format);
            cmd_text_ai_translate_1.SetAction(parseResult =>
            {
                var texts = parseResult.GetValue(opt_text_ai_translate_1_texts);
                var Language = parseResult.GetValue(opt_text_ai_translate_1_Language);
                var source_Language = parseResult.GetValue(opt_text_ai_translate_1_source_Language);
                var style = parseResult.GetValue(opt_text_ai_translate_1_style);
                var Context = parseResult.GetValue(opt_text_ai_translate_1_Context);
                var preserve_Format = parseResult.GetValue(opt_text_ai_translate_1_preserve_Format);
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