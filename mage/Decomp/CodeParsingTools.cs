using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mage.Decomp;

public static class CodeParsingTools
{
    public static void Include(this StringBuilder sb, string file) => sb.AppendLine($"#include \"{file}\"");

    public static void ConstU8Array<T>(this StringBuilder sb, string labelName, IEnumerable<T> data, string arraySize = "")
    {
        sb.AppendLine($"const u8 {labelName}[{arraySize}] = {{");
        sb.AppendJoin(',', data);
        sb.AppendLine("};");
    }

    public static void ExternConstU8Array(this StringBuilder sb, string labelName)
    {
        sb.AppendLine($"extern const u8 {labelName};");
    }
}
