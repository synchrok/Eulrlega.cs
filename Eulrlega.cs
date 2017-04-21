using System;

public static class Eulrlega {

    public static bool HasProp(string word) {
        var last = word[word.Length - 1];

        if (last < 0xAC00)
            return true;

        return (last - 0xAC00) % 28 + 0x11a7 != 4519;
    }

    public static string GetEulrl(string word) {
        return HasProp(word) ? "을" : "를";
    }

    public static string GetEga(string word) {
        return HasProp(word) ? "이" : "가";
    }

    public static string GetEunnn(string word) {
        return HasProp(word) ? "은" : "는";
    }

    private static readonly string[][] Formats = {
        new []{"을", "를"},
        new []{"이", "가"},
        new []{"은", "는"},
    };

    // Usage: "{0}.은 {1}.이 {2}.를 {3}마리나 먹는걸 보았다".FormatK("김기사", "피자", "치킨", 30)
    public static string FormatK(this string str, params object[] values) {
        for (var i = 0; i < Formats.Length; i++) {
            var token1 = string.Concat("}.", Formats[i][0]);
            var token2 = string.Concat("}.", Formats[i][1]);
            if (str.Contains(token1) || str.Contains(token2)) {
                while (str.Contains(token1) || str.Contains(token2)) {
                    // }.? => }*?
                    str = ProcessFormat(str, Formats[i][0], Formats[i], values);
                    str = ProcessFormat(str, Formats[i][1], Formats[i], values);
                }

                // }*? => }?
                str = str.Replace(string.Concat("}*", Formats[i][0]), string.Concat("}", Formats[i][0]))
                    .Replace(string.Concat("}*", Formats[i][1]), string.Concat("}", Formats[i][1]));
            }
        }

        return string.Format(str, values);
    }

    private static string ProcessFormat(string str, string target, string[] eulrl, object[] values) {
        var token = string.Concat("}.", target);
        if (str.Contains(token)) {
            var paramIdx = -1;
            var idx = str.IndexOf(token, StringComparison.CurrentCultureIgnoreCase);
            if (idx >= 2) {
                for (var i = idx; i >= 0; i--) {
                    if (str[i] == '{') {
                        int.TryParse(str.Substring(i + 1, idx - (i + 1)), out paramIdx);
                        break;
                    }
                }
            }

            if (paramIdx >= 0 && values.Length > paramIdx) {
                var word = values[paramIdx] as string;
                if (word != null) {
                    var hasProp = HasProp(word);

                    var charArr = str.ToCharArray();
                    charArr[idx + 1] = '*';
                    charArr[idx + 2] = eulrl[hasProp ? 0 : 1][0];
                    str = new string(charArr);
                }
            }
        }

        return str;
    }

}