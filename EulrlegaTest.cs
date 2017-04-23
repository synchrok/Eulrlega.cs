using UnityEngine;

public class EulrlegaTest {

    public static void Test() {
        Debug.Log("오늘은 {0}.랑 {1}.랑 놀아야지!".FormatK("김기사", "김도적"));
        Debug.Log("오늘은 {0}.이랑 {1}.이랑 놀아야지!".FormatK("김기사", "김도적"));
        Debug.Log("{0}.야 뭐해? {1}.야 뭐해?".FormatK("김기사", "김도적"));
        Debug.Log("{0}.아 뭐해? {1}.아 뭐해?".FormatK("김기사", "김도적"));
        Debug.Log("{0}.이여 이 앞으로 나아가라!".FormatK("김기사"));
        Debug.Log("{0}.여 이 앞으로 나아가라!".FormatK("김기사"));
        Debug.Log("{0}.이라는 애랑 {1}.이라는 애를 들어본 적이 있니?".FormatK("김기사", "김도적"));
        Debug.Log("{0}.라는 애랑 {1}.라는 애를 들어본 적이 있니?".FormatK("김기사", "김도적"));
        Debug.Log("너에게 {0}.이란? 그리고 {1}.이란?".FormatK("치킨", "피자"));
        Debug.Log("너에게 {0}.란? 그리고 {1}.란?".FormatK("치킨", "피자"));

        Debug.Log("{0}.과 {1}.과 {2}.은 체력을 올려준다.".FormatK("치킨", "피자", "햄버거"));
        Debug.Log("{0}.로 오실래요? 아니면 {1}.로 오실래요?".FormatK("던전", "필드"));
        Debug.Log("{0}.으로 오실래요? 아니면 {1}.로 오실래요?".FormatK("던전", "필드"));
        Debug.Log("{0}.으로 오실래요? 아니면 {1}.으로 오실래요?".FormatK("던전", "필드"));
        Debug.Log("{0}.로 오실래요? 아니면 {1}.으로 오실래요?".FormatK("던전", "필드"));

        Debug.Log("{0}.으로부터 편지가 도착했습니다!".FormatK("운영자"));
        Debug.Log("{0}.으로부터 편지가 도착했습니다!".FormatK("치느님"));
        Debug.Log("{0}.로부터 편지가 도착했습니다!".FormatK("운영자"));
        Debug.Log("{0}.로부터 편지가 도착했습니다!".FormatK("치느님"));
        
        Debug.Log("{0}.로써 이 정도는 해줘야지".FormatK("도적"));
        Debug.Log("{0}.로써 이 정도는 해줘야지".FormatK("기사"));
        Debug.Log("{0}.으로써 이 정도는 해줘야지".FormatK("도적"));
        Debug.Log("{0}.으로써 이 정도는 해줘야지".FormatK("기사"));
        
        Debug.Log("{0}.나마 몰라".FormatK("도적"));
        Debug.Log("{0}.나마 몰라".FormatK("기사"));
        Debug.Log("{0}.이나마 몰라".FormatK("도적"));
        Debug.Log("{0}.이나마 몰라".FormatK("기사"));
        
        Debug.Log("{0}.시여 빨리 제게 와주십시오!".FormatK("치느님"));
        Debug.Log("{0}.시여 빨리 제게 와주십시오!".FormatK("피자"));
        Debug.Log("{0}.이시여 빨리 제게 와주십시오!".FormatK("치느님"));
        Debug.Log("{0}.이시여 빨리 제게 와주십시오!".FormatK("피자"));
        
        Debug.Log("{0}.이야말로 콜라와 잘 어울리지".FormatK("피자"));
        Debug.Log("{0}.이야말로 콜라와 잘 어울리지".FormatK("치킨"));
        Debug.Log("{0}.야말로 콜라와 잘 어울리지".FormatK("피자"));
        Debug.Log("{0}.야말로 콜라와 잘 어울리지".FormatK("치킨"));
        
        Debug.Log("{0}.든지 {1}.든지 빨리 좀 시키자".FormatK("치킨", "피자"));
        Debug.Log("{0}.이든지 {1}.이든지 빨리 좀 시키자".FormatK("치킨", "피자"));
    }

}
