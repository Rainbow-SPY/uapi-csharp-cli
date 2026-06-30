using System;
using System.Collections;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UAPI.CliGenerated
{
    public static class ReadmeGenerator
    {
        public static string Generate(Command root, string exeName)
        {
            var sb = new StringBuilder();

            sb.AppendLine("# UAPI CLI");
            sb.AppendLine();
            sb.AppendLine("UAPI 的命令行客户端。");
            sb.AppendLine();
            sb.AppendLine("## 安装");
            sb.AppendLine();
            sb.AppendLine("下载 Release 中的单文件程序，例如：");
            sb.AppendLine();
            sb.AppendLine("```powershell");
            sb.AppendLine("uapi --help");
            sb.AppendLine("```");
            sb.AppendLine();
            sb.AppendLine("## API Key");
            sb.AppendLine();
            sb.AppendLine("所有接口都可以通过全局参数传入 API Key：");
            sb.AppendLine();
            sb.AppendLine("```powershell");
            sb.AppendLine("uapi --authentication YOUR_API_KEY <command>");
            sb.AppendLine("```");
            sb.AppendLine();
            sb.AppendLine("也可以使用环境变量：");
            sb.AppendLine();
            sb.AppendLine("```powershell");
            sb.AppendLine("$env:UAPI_TOKEN = \"YOUR_API_KEY\"");
            sb.AppendLine("uapi <command>");
            sb.AppendLine("```");
            sb.AppendLine();
            sb.AppendLine("## 输出");
            sb.AppendLine();
            sb.AppendLine("```powershell");
            sb.AppendLine("uapi <command> --output result.json");
            sb.AppendLine("uapi <command> --result envelope");
            sb.AppendLine("uapi <command> --result headers");
            sb.AppendLine("uapi <command> --select Headers.RequestID");
            sb.AppendLine("```");
            sb.AppendLine();
            sb.AppendLine("## 命令列表");
            sb.AppendLine();

            WriteCommandTree(sb, root, exeName, 0);

            sb.AppendLine();
            sb.AppendLine("## 命令详情");
            sb.AppendLine();

            foreach (var command in FlattenCommands(root, exeName)) WriteCommandDetail(sb, command);

            return sb.ToString();
        }

        private sealed class CommandInfo
        {
            public object Command;
            public string FullName;
            public int Depth;
        }

        private static IEnumerable<CommandInfo> FlattenCommands(object root, string exeName) =>
            GetItems(root, "Subcommands").SelectMany(child => FlattenCommand(child, exeName, 1));

        private static IEnumerable<CommandInfo> FlattenCommand(object command, string path, int depth)
        {
            if (IsHidden(command))
                yield break;

            var name = GetString(command, "Name", "");
            if (string.IsNullOrWhiteSpace(name))
                yield break;

            var full = path + " " + name;

            yield return new CommandInfo
            {
                Command = command,
                FullName = full,
                Depth = depth
            };

            foreach (var child in GetItems(command, "Subcommands"))
            foreach (var item in FlattenCommand(child, full, depth + 1))
                yield return item;
        }

        private static void WriteCommandTree(StringBuilder sb, object root, string exeName, int depth)
        {
            foreach (var command in FlattenCommands(root, exeName))
            {
                var indent = new string(' ', Math.Max(0, command.Depth - 1) * 2);
                var desc = GetString(command.Command, "Description", "");

                sb.AppendLine(string.IsNullOrWhiteSpace(desc)
                    ? $"{indent}- `{command.FullName}`"
                    : $"{indent}- `{command.FullName}` - {desc}");
            }
        }

        private static void WriteCommandDetail(StringBuilder sb, CommandInfo info)
        {
            var command = info.Command;
            var desc = GetString(command, "Description", "");

            sb.AppendLine($"### `{info.FullName}`");
            sb.AppendLine();

            if (!string.IsNullOrWhiteSpace(desc))
            {
                sb.AppendLine(desc);
                sb.AppendLine();
            }

            var options = GetItems(command, "Options")
                .Where(x => !IsHidden(x))
                .ToList();

            if (options.Count > 0)
            {
                sb.AppendLine("| 参数 | 类型 | 必填 | 说明 |");
                sb.AppendLine("|---|---|---:|---|");

                foreach (var option in options)
                {
                    var names = GetNames(option);
                    var type = GetValueTypeName(option);
                    var required = GetBool(option, "Required") ? "是" : "否";
                    var optionDesc = EscapeTable(GetString(option, "Description", ""));

                    sb.AppendLine($"| `{names}` | `{type}` | {required} | {optionDesc} |");
                }

                sb.AppendLine();
            }

            var children = GetItems(command, "Subcommands")
                .Where(x => !IsHidden(x))
                .ToList();

            if (children.Count <= 0) return;
            sb.AppendLine("子命令：");
            sb.AppendLine();

            foreach (var child in children)
            {
                var name = GetString(child, "Name", "");
                var childDesc = GetString(child, "Description", "");

                sb.AppendLine(string.IsNullOrWhiteSpace(childDesc) ? $"- `{name}`" : $"- `{name}` - {childDesc}");
            }

            sb.AppendLine();
        }

        private static IEnumerable<object> GetItems(object obj, string propertyName)
        {
            if (obj == null)
                yield break;

            var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            if (prop == null)
                yield break;

            var value = prop.GetValue(obj, null);
            if (!(value is IEnumerable enumerable)) yield break;
            foreach (var item in enumerable)
            {
                if (item != null)
                    yield return item;
            }
        }

        private static string GetNames(object symbol)
        {
            var aliases = GetItems(symbol, "Aliases")
                .Select(x => x.ToString())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .ToList();

            if (aliases.Count > 0)
                return string.Join("`, `", aliases);

            var name = GetString(symbol, "Name", "");
            return string.IsNullOrWhiteSpace(name) ? "(unknown)" : name;
        }

        private static string GetValueTypeName(object option)
        {
            var prop = option.GetType().GetProperty("ValueType", BindingFlags.Instance | BindingFlags.Public);
            var value = prop != null ? prop.GetValue(option, null) : null;

            if (value is System.Type type)
                return ToFriendlyTypeName(type);

            var t = option.GetType();
            return t.IsGenericType ? ToFriendlyTypeName(t.GetGenericArguments()[0]) : "";
        }

        private static string ToFriendlyTypeName(System.Type type)
        {
            if (type == typeof(string)) return "string";
            if (type == typeof(int)) return "int";
            if (type == typeof(long)) return "long";
            if (type == typeof(bool)) return "bool";
            if (type == typeof(byte[])) return "file";
            if (type.IsEnum) return type.FullName ?? type.Name;
            return type.Name;
        }

        private static string GetString(object obj, string propertyName, string fallback)
        {
            if (obj == null)
                return fallback;

            var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            if (prop == null)
                return fallback;

            var value = prop.GetValue(obj, null);
            return value == null ? fallback : value.ToString();
        }

        private static bool GetBool(object obj, string propertyName)
        {
            if (obj == null)
                return false;

            var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            if (prop == null)
                return false;

            var value = prop.GetValue(obj, null);
            return value is bool b && b;
        }

        private static bool IsHidden(object obj) => GetBool(obj, "Hidden") || GetBool(obj, "IsHidden");

        private static string EscapeTable(string text) =>
            (text ?? "")
            .Replace("\r", " ")
            .Replace("\n", " ")
            .Replace("|", "\\|")
            .Trim();
    }
}