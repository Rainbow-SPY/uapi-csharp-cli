using System;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace UAPI.CliGenerated
{
    public static class CliCommandTree
    {
        public static Command GetOrAdd(Command parent, string[] path)
        {
            var current = parent;
            foreach (var name in path)
            {
                var next = current.Subcommands.FirstOrDefault(child => string.Equals(child.Name, name, StringComparison.OrdinalIgnoreCase));

                if (next == null)
                {
                    next = new Command(name);
                    current.Subcommands.Add(next);
                }

                current = next;
            }

            return current;
        }
    }

    public static class CliOutput
    {
        public static void WriteObject(object result, string outputFile, bool append, string resultMode = "data", string select = null)
        {
            if (!string.IsNullOrWhiteSpace(select))
            {
                WriteJson(SelectValue(result, select), outputFile, append);
                return;
            }

            switch ((resultMode ?? "data").Trim().ToLowerInvariant())
            {
                case "":
                case "data":
                case "result":
                case "raw":
                    WriteJson(result, outputFile, append);
                    return;

                case "envelope":
                    WriteJson(new
                    {
                        success = true,
                        resultType = result?.GetType().FullName,
                        data = result,
                        headers = GetHeadersOrNull(result)
                    }, outputFile, append);
                    return;

                case "headers":
                    var headers = GetHeadersOrNull(result);
                    if (headers == null)
                        throw new InvalidOperationException(
                            "当前 API 返回值不包含 Headers。byte[]/string 等原始响应在 SDK wrapper 中通常已经被拆包，无法从 CLI 侧再取响应头。");
                    WriteJson(headers, outputFile, append);
                    return;

                case "headers-text":
                    WriteText(GetHeadersText(result), outputFile, append);
                    return;

                default:
                    throw new ArgumentException("未知的 --result 值: " + resultMode +
                                                "。可用值: data, envelope, headers, headers-text。");
            }
        }

        public static void WriteBytes(byte[] result, string outputFile, bool append, string resultMode = "data", string select = null)
        {
            if (!string.IsNullOrWhiteSpace(select))
                throw new InvalidOperationException("byte[] 结果不支持 --select。");

            var mode = (resultMode ?? "data").Trim().ToLowerInvariant();
            if (!(mode == "" || mode == "data" || mode == "result" || mode == "raw"))
                throw new InvalidOperationException("byte[] 结果不支持 --result " + resultMode + "。二进制接口只能写入文件。");

            if (string.IsNullOrWhiteSpace(outputFile))
                throw new InvalidOperationException("Binary result requires --output <file>.");

            if (append && File.Exists(outputFile))
                using (var stream = new FileStream(outputFile, FileMode.Append, FileAccess.Write))
                    stream.Write(result, 0, result.Length);
            else
                File.WriteAllBytes(outputFile, result);
        }

        public static void WriteError(Exception ex, string outputFile, bool append, string resultMode)
        {
            var mode = (resultMode ?? "envelope").Trim().ToLowerInvariant();
            if (mode == "raw" || mode == "data" || mode == "result")
            {
                WriteText(ex.ToString(), outputFile, append);
                return;
            }

            WriteJson(new
            {
                success = false,
                error = new
                {
                    type = ex.GetType().FullName,
                    message = ex.Message,
                    statusCode = GetExceptionData(ex, "UAPI.StatusCode"),
                    failedReason = GetExceptionData(ex, "UAPI.FailedReason"),
                    responseCode = GetExceptionData(ex, "UAPI.ResponseCode"),
                    responseError = GetExceptionData(ex, "UAPI.ResponseError"),
                    responseMessage = GetExceptionData(ex, "UAPI.ResponseMessage"),
                    responseDetails = GetExceptionData(ex, "UAPI.ResponseDetails"),
                    diagnosticReportPath = GetExceptionData(ex, "UAPI.DiagnosticReportPath")
                }
            }, outputFile, append);
        }

        private static object GetExceptionData(Exception ex, string key)
        {
            if (ex?.Data == null || !ex.Data.Contains(key))
                return null;
            return ex.Data[key];
        }

        private static object GetHeadersOrNull(object result)
        {
            switch (result)
            {
                case null:
                    return null;
                case Type.TypeInterface typeInterface:
                    return typeInterface.Headers;
                default:
                {
                    var prop = result.GetType().GetProperty("Headers",
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                    return prop != null ? prop.GetValue(result, null) : null;
                }
            }
        }

        private static string GetHeadersText(object result)
        {
            if (!(result is Type.TypeInterface typeInterface) || typeInterface.Headers == null)
                throw new InvalidOperationException("当前 API 返回值不包含 Headers。");

            return Type.Response.Headers.OutputRequestHeadersInfo(typeInterface);
        }

        private static object SelectValue(object source, string path)
        {
            var current = source;
            foreach (var part in path.Split('.'))
            {
                if (current == null)
                    return null;

                var prop = current.GetType().GetProperty(part,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (prop == null)
                    throw new ArgumentException("Property not found: " + part + " in " + current.GetType().FullName);

                current = prop.GetValue(current, null);
            }

            return current;
        }

        private static void WriteJson(object value, string outputFile, bool append)
        {
            if (value is string s)
            {
                WriteText(s, outputFile, append);
                return;
            }

            WriteText(JsonConvert.SerializeObject(value, Formatting.Indented), outputFile, append);
        }

        private static void WriteText(string text, string outputFile, bool append)
        {
            if (string.IsNullOrWhiteSpace(outputFile))
            {
                Console.WriteLine(text);
                return;
            }

            if (append)
                File.AppendAllText(outputFile, text + Environment.NewLine);
            else
                File.WriteAllText(outputFile, text);
        }
    }
}