using System;

public static class Eulrlega {

    public static bool HasProp(string word) {
        for (int i = 1; i <= word.Length; i++) {
            var last = word[word.Length - i];
            if (last < 0xAC00)
                continue;

            return (last - 0xAC00) % 28 + 0x11a7 != 4519;
        }

        return false;
    }

    private static readonly string[][] Formats = {
        // '이'와 겹쳐서 먼저 처리함
        new []{"이시여", "시여"},  
        new []{"으로부터", "로부터"}, 
        new []{"이나마", "나마"},  
        new []{"이야말로", "야말로"},  
        new []{"이든지", "든지"}, 
        new []{"이여", "여"}, 
        new []{"이랑", "랑"},
        new []{"이라", "라"},
        new []{"이란", "란"},
        new []{"을", "를"},
        new []{"이", "가"},
        new []{"은", "는"},
        new []{"과", "와"},
        new []{"으로", "로"},
        new []{"아", "야"},
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

                    // 토큰 중 하나라도 2글자 이상인 경우에 대한 처리
                    if (target.Length > 1 || eulrl[hasProp ? 0 : 1].Length > 1) {
                        // 로/으로 같이 두 토큰의 길이가 다른 경우에 대한 처리
                        if (target.Length != eulrl[hasProp ? 0 : 1].Length) {
                            if (target.Length > eulrl[hasProp ? 0 : 1].Length) { // 줄어드는 경우
                                for (var i = 0; i < eulrl[hasProp ? 0 : 1].Length; i++) // 복사하고
                                    charArr[idx + 1 + i] = eulrl[hasProp ? 0 : 1][i];
                                var gap = target.Length - eulrl[hasProp ? 0 : 1].Length; // 남는 공간 삭제
                                for (var i = 0; i < gap; i++)
                                    charArr[idx + eulrl[hasProp ? 0 : 1].Length + 1 + i] = (char)9999;
                                useTrashChar = true;
                            } else { // 늘어나는 경우
                                var gap = eulrl[hasProp ? 0 : 1].Length - target.Length;
                                Array.Resize(ref charArr, charArr.Length + gap); // 배열 리사이징 후
                                for (var i = charArr.Length - 1; i >= idx + 2; i--) // => 로 밀어내고
                                    charArr[i] = charArr[i - gap];
                                for (var i = 0; i < gap; i++) // 생긴 공간에 옮김
                                    charArr[idx + 2 + i] = eulrl[hasProp ? 0 : 1][1 + i];
                            }
                        } else { // 길이가 같은 경우 그냥 복사
                            for (var i = 0; i < target.Length - 1; i++)
                                charArr[idx + 1 + i] = eulrl[hasProp ? 0 : 1][i];
                        }
                    }

                    str = new string(charArr);
                    if (useTrashChar)
                        str = str.Replace(new string(new[] {(char) 9999}), "");
                }
            }
        }

        return str;
    }

}
