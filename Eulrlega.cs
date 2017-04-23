using System;

public static class Eulrlega {

    public static bool HasProp(string word) {
        var last = word[word.Length - 1];

        if (last < 0xAC00)
            return true;

        return (last - 0xAC00) % 28 + 0x11a7 != 4519;
    }

    private static readonly string[][] Formats = {
        new []{"을", "를"},
        new []{"이", "가"},
        new []{"은", "는"},
        new []{"과", "와"},
        new []{"으로", "로"},
    };

    // Usage: "{0}.은 {1}.이 {2}.를 {3}마리나 먹는걸 보았다".FormatK("김기사", "피자", "치킨", 30)
    // Usage2: "<color=#FFFF00>{0}</color>.을 획득하였습니다!".FormatK("브로드 소드")
    public static string FormatK(this string str, params object[] values) {
        for (var i = 0; i < Formats.Length; i++) {
            var token1 = string.Concat(".", Formats[i][0]);
            var token2 = string.Concat(".", Formats[i][1]);
            if (str.Contains(token1) || str.Contains(token2)) {
                var l = 0;
                while ((str.Contains(token1) || str.Contains(token2)) && l++ < 10000) {
                    // .? => *?
                    str = ProcessFormat(str, Formats[i][0], Formats[i], values);
                    str = ProcessFormat(str, Formats[i][1], Formats[i], values);
                }

                // *? => ?
                str = str.Replace(string.Concat("*", Formats[i][0]), Formats[i][0])
                    .Replace(string.Concat("*", Formats[i][1]), Formats[i][1]);
            }
        }

        return string.Format(str, values);
    }

    private static string ProcessFormat(string str, string target, string[] eulrl, object[] values) {
        var token = string.Concat(".", target);
        if (str.Contains(token)) {
            var paramIdx = -1;
            var idx = str.IndexOf(token, StringComparison.CurrentCultureIgnoreCase);
            if (idx >= 2) {
                var closeIdx = -1;
                for (var i = idx; i >= 0; i--) {
                    if (str[i] == '}') {
                        closeIdx = i;
                    } else if (str[i] == '{') {
                        int.TryParse(str.Substring(i + 1, closeIdx - (i + 1)), out paramIdx);
                        break;
                    }
                }
            }

            if (paramIdx >= 0 && values.Length > paramIdx) {
                var word = values[paramIdx] as string;
                if (word != null) {
                    var hasProp = HasProp(word);

                    var charArr = str.ToCharArray();
                    charArr[idx] = '*';
                    charArr[idx + 1] = eulrl[hasProp ? 0 : 1][0];

                    var useTrashChar = false;

                    // 로/으로 같이 두 토큰의 길이가 다른 경우에 대한 처리
                    if (target.Length > 1) {
                        if (eulrl[hasProp ? 0 : 1].Length > 1) { // .으로 => 으로
                            for (var i = 0; i < target.Length - 1; i++)
                                charArr[idx + 1 + i] = eulrl[hasProp ? 0 : 1][i];
                        } else { // .으로 => 로
                            for (var i=0; i < target.Length - 1; i++)
                                charArr[idx + 1 + i] = (char) 9999;
                            useTrashChar = true;
                        }
                    } else {
                        if (eulrl[hasProp ? 0 : 1].Length > 1) { // .로 => .으로
                            var gap = eulrl[hasProp ? 0 : 1].Length - target.Length;
                            Array.Resize(ref charArr, charArr.Length + gap);
                            for (var i = charArr.Length - 1; i >= idx + 2; i--) // => 로 밀어내고
                                charArr[i] = charArr[i - gap];
                            for (var i = 0; i < gap; i++) // 생긴 공간에 옮김
                                charArr[idx + 2 + i] = eulrl[hasProp ? 0 : 1][1 + i];
                        } 
                        // .로 => .로 는 위에서 처리됨
                    }

                    str = new string(charArr);
                    if (useTrashChar)
                        str = str.Replace(new string(new[] {(char) 9999}), "");
                }
            }
        }

        return str;
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

    public static string GetGwha(string word) {
        return HasProp(word) ? "과" : "와";
    }

    public static string GetEuroro(string word) {
        return HasProp(word) ? "으로" : "로";
    }

}
