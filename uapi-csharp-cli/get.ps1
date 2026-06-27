# 运行:
#   powershell -ExecutionPolicy Bypass -File .\gen-cli.ps1
#
# 输出:
#   .\GeneratedCli.cs

$commands = @(
    @{
        Group = "image"
        Name = "bing-daily"
        Method = "UAPI.Image.GetBingDaily"
        Return = "json"
        Params = @(
            @{ Name = "date"; Type = "string"; Required = $false },
            @{ Name = "resolution"; Type = "string"; Required = $false },
            @{ Name = "format"; Type = "string"; Required = $false }
        )
    },
    @{
        Group = "image"
        Name = "ocr"
        Method = "UAPI.Image.PostImageOcr"
        Return = "json"
        Params = @(
            @{ Name = "file"; Type = "string"; Required = $false },
            @{ Name = "imageUrl"; Type = "string"; Required = $false },
            @{ Name = "needLocation"; Type = "bool"; Required = $false }
        )
    },
    @{
        Group = "network"
        Name = "ip-info"
        Method = "UAPI.Network.GetIpInfo"
        Return = "json"
        Params = @(
            @{ Name = "ip"; Type = "string"; Required = $true }
        )
    },
    @{
        Group = "random"
        Name = "number"
        Method = "UAPI.Random.GetRandomNumber"
        Return = "json"
        Params = @(
            @{ Name = "min"; Type = "int"; Required = $false },
            @{ Name = "max"; Type = "int"; Required = $false }
        )
    }
)

function To-Kebab($name) {
    return ($name -creplace '([a-z0-9])([A-Z])', '$1-$2').ToLower()
}

function Cs-Default($type) {
    switch ($type) {
        "string" { "null" }
        "int"    { "0" }
        "long"   { "0L" }
        "bool"   { "false" }
        default  { "null" }
    }
}

$out = New-Object System.Text.StringBuilder

[void]$out.AppendLine("using System;")
[void]$out.AppendLine("using System.CommandLine;")
[void]$out.AppendLine("using System.Text.Json;")
[void]$out.AppendLine("using System.Threading.Tasks;")
[void]$out.AppendLine("")
[void]$out.AppendLine("public static class GeneratedCli")
[void]$out.AppendLine("{")
[void]$out.AppendLine("    public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption)")
[void]$out.AppendLine("    {")

$groups = $commands | Group-Object Group

foreach ($group in $groups) {
    $groupVar = "cmd_" + ($group.Name -replace '[^a-zA-Z0-9]', '_')

    [void]$out.AppendLine("        var $groupVar = new Command(`"$($group.Name)`");")
    [void]$out.AppendLine("        root.Subcommands.Add($groupVar);")
    [void]$out.AppendLine("")

    foreach ($cmd in $group.Group) {
        $cmdVar = "cmd_" + (($cmd.Group + "_" + $cmd.Name) -replace '[^a-zA-Z0-9]', '_')

        [void]$out.AppendLine("        var $cmdVar = new Command(`"$($cmd.Name)`");")

        foreach ($p in $cmd.Params) {
            $optionVar = "opt_" + (($cmd.Group + "_" + $cmd.Name + "_" + $p.Name) -replace '[^a-zA-Z0-9]', '_')
            $optionName = "--" + (To-Kebab $p.Name)
            $type = $p.Type

            [void]$out.AppendLine("        var $optionVar = new Option<$type>(`"$optionName`")")
            [void]$out.AppendLine("        {")
            [void]$out.AppendLine("            Required = `$$($p.Required.ToString().ToLower())")
            [void]$out.AppendLine("        };")
            [void]$out.AppendLine("        $cmdVar.Options.Add($optionVar);")
        }

        [void]$out.AppendLine("")
        [void]$out.AppendLine("        $cmdVar.SetAction(async parseResult =>")
        [void]$out.AppendLine("        {")

        $argNames = @()

        foreach ($p in $cmd.Params) {
            $optionVar = "opt_" + (($cmd.Group + "_" + $cmd.Name + "_" + $p.Name) -replace '[^a-zA-Z0-9]', '_')
            $localName = $p.Name
            $type = $p.Type
            $default = Cs-Default $type

            [void]$out.AppendLine("            $type $localName = parseResult.GetValue($optionVar);")
            $argNames += $localName
        }

        $callArgs = $argNames -join ", "

        [void]$out.AppendLine("            var result = await $($cmd.Method)($callArgs);")
        [void]$out.AppendLine("            await CliOutput.WriteAsync(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));")
        [void]$out.AppendLine("        });")
        [void]$out.AppendLine("")
        [void]$out.AppendLine("        $groupVar.Subcommands.Add($cmdVar);")
        [void]$out.AppendLine("")
    }
}

[void]$out.AppendLine("    }")
[void]$out.AppendLine("}")
[void]$out.AppendLine("")
[void]$out.AppendLine("public static class CliOutput")
[void]$out.AppendLine("{")
[void]$out.AppendLine("    public static async Task WriteAsync(object result, string outFile, bool append)")
[void]$out.AppendLine("    {")
[void]$out.AppendLine("        var text = result is string s")
[void]$out.AppendLine("            ? s")
[void]$out.AppendLine("            : JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });")
[void]$out.AppendLine("")
[void]$out.AppendLine("        if (string.IsNullOrWhiteSpace(outFile))")
[void]$out.AppendLine("        {")
[void]$out.AppendLine("            Console.WriteLine(text);")
[void]$out.AppendLine("            return;")
[void]$out.AppendLine("        }")
[void]$out.AppendLine("")
[void]$out.AppendLine("        if (append)")
[void]$out.AppendLine("            await System.IO.File.AppendAllTextAsync(outFile, text + Environment.NewLine);")
[void]$out.AppendLine("        else")
[void]$out.AppendLine("            await System.IO.File.WriteAllTextAsync(outFile, text);")
[void]$out.AppendLine("    }")
[void]$out.AppendLine("}")

$out.ToString() | Set-Content -Path ".\GeneratedCli.cs" -Encoding UTF8

Write-Host "Generated .\GeneratedCli.cs"
