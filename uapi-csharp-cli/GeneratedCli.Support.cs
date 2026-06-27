using System;
using System.CommandLine;
using System.IO;
using System.Linq;
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
                var next = current.Subcommands.FirstOrDefault(child =>
                    string.Equals(child.Name, name, StringComparison.OrdinalIgnoreCase));

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
        public static void WriteObject(object result, string outFile, bool append)
        {
            var text = result as string ?? JsonConvert.SerializeObject(result, Formatting.Indented);

            if (string.IsNullOrWhiteSpace(outFile))
            {
                Console.WriteLine(text);
                return;
            }

            if (append)
                File.AppendAllText(outFile, text + Environment.NewLine);
            else
                File.WriteAllText(outFile, text);
        }

        public static void WriteBytes(byte[] result, string outFile, bool append)
        {
            if (string.IsNullOrWhiteSpace(outFile))
                throw new InvalidOperationException("Binary result requires --out <file>.");

            if (append && File.Exists(outFile))
                using (var stream = new FileStream(outFile, FileMode.Append, FileAccess.Write))
                    stream.Write(result, 0, result.Length);
            else
                File.WriteAllBytes(outFile, result);
        }
    }
}