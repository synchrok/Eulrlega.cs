using NUnit.Framework;

public class EulrlegaUnitTest {

	[Test]
	public void EulrlegaAllUnitTest() {

        Assert.AreEqual("오늘은 {0}.랑 {1}.랑 놀아야지!".FormatK("김기사", "김도적"), "오늘은 김기사랑 김도적이랑 놀아야지!");

        Assert.AreEqual("{0}.야 뭐해? {1}.야 뭐해?".FormatK("김기사", "김도적"), "김기사야 뭐해? 김도적아 뭐해?");
        Assert.AreEqual("{0}.아 뭐해? {1}.아 뭐해?".FormatK("김기사", "김도적"), "김기사야 뭐해? 김도적아 뭐해?");

        Assert.AreEqual("{0}.이여 이 앞으로 나아가라!".FormatK("김기사"), "김기사여 이 앞으로 나아가라!");
        Assert.AreEqual("{0}.이여 이 앞으로 나아가라!".FormatK("김도적"), "김도적이여 이 앞으로 나아가라!");

        Assert.AreEqual("{0}.이라는 애랑 {1}.이라는 애를 들어본 적이 있니?".FormatK("김기사", "김도적"), "김기사라는 애랑 김도적이라는 애를 들어본 적이 있니?");
        Assert.AreEqual("{0}.라는 애랑 {1}.라는 애를 들어본 적이 있니?".FormatK("김기사", "김도적"), "김기사라는 애랑 김도적이라는 애를 들어본 적이 있니?");

        Assert.AreEqual("너에게 {0}.이란? 그리고 {1}.이란?".FormatK("치킨", "피자"), "너에게 치킨이란? 그리고 피자란?");
        Assert.AreEqual("너에게 {0}.란? 그리고 {1}.란?".FormatK("치킨", "피자"), "너에게 치킨이란? 그리고 피자란?");

        Assert.AreEqual("{0}.과 {1}.과 {2}.은 체력을 올려준다.".FormatK("치킨", "피자", "햄버거"), "치킨과 피자와 햄버거는 체력을 올려준다.");
        Assert.AreEqual("{0}.와 {1}.와 {2}.는 체력을 올려준다.".FormatK("치킨", "피자", "햄버거"), "치킨과 피자와 햄버거는 체력을 올려준다.");

        Assert.AreEqual("{0}.로 오실래요? 아니면 {1}.로 오실래요?".FormatK("던전", "필드"), "던전으로 오실래요? 아니면 필드로 오실래요?");
        Assert.AreEqual("{0}.으로 오실래요? 아니면 {1}.으로 오실래요?".FormatK("던전", "필드"), "던전으로 오실래요? 아니면 필드로 오실래요?");

        Assert.AreEqual("{0}.으로부터 편지가 도착했습니다!".FormatK("운영자"), "운영자로부터 편지가 도착했습니다!");
        Assert.AreEqual("{0}.으로부터 편지가 도착했습니다!".FormatK("치느님"), "치느님으로부터 편지가 도착했습니다!");
        Assert.AreEqual("{0}.로부터 편지가 도착했습니다!".FormatK("운영자"), "운영자로부터 편지가 도착했습니다!");
        Assert.AreEqual("{0}.로부터 편지가 도착했습니다!".FormatK("치느님"), "치느님으로부터 편지가 도착했습니다!");

        Assert.AreEqual("{0}.로써 이 정도는 해줘야지".FormatK("도적"), "도적으로써 이 정도는 해줘야지");
        Assert.AreEqual("{0}.로써 이 정도는 해줘야지".FormatK("기사"), "기사로써 이 정도는 해줘야지");
        Assert.AreEqual("{0}.으로써 이 정도는 해줘야지".FormatK("도적"), "도적으로써 이 정도는 해줘야지");
        Assert.AreEqual("{0}.으로써 이 정도는 해줘야지".FormatK("기사"), "기사로써 이 정도는 해줘야지");

        Assert.AreEqual("{0}.나마 몰라".FormatK("도적"), "도적이나마 몰라");
        Assert.AreEqual("{0}.나마 몰라".FormatK("기사"), "기사나마 몰라");
        Assert.AreEqual("{0}.이나마 몰라".FormatK("도적"), "도적이나마 몰라");
        Assert.AreEqual("{0}.이나마 몰라".FormatK("기사"), "기사나마 몰라");

        Assert.AreEqual("{0}.시여 빨리 제게 와주십시오!".FormatK("치느님"), "치느님이시여 빨리 제게 와주십시오!");
        Assert.AreEqual("{0}.시여 빨리 제게 와주십시오!".FormatK("피자"), "피자시여 빨리 제게 와주십시오!");
        Assert.AreEqual("{0}.이시여 빨리 제게 와주십시오!".FormatK("치느님"), "치느님이시여 빨리 제게 와주십시오!");
        Assert.AreEqual("{0}.이시여 빨리 제게 와주십시오!".FormatK("피자"), "피자시여 빨리 제게 와주십시오!");

        Assert.AreEqual("{0}.이야말로 콜라와 잘 어울리지".FormatK("피자"), "피자야말로 콜라와 잘 어울리지");
        Assert.AreEqual("{0}.이야말로 콜라와 잘 어울리지".FormatK("치킨"), "치킨이야말로 콜라와 잘 어울리지");
        Assert.AreEqual("{0}.야말로 콜라와 잘 어울리지".FormatK("피자"), "피자야말로 콜라와 잘 어울리지");
        Assert.AreEqual("{0}.야말로 콜라와 잘 어울리지".FormatK("치킨"), "치킨이야말로 콜라와 잘 어울리지");

        Assert.AreEqual("{0}.든지 {1}.든지 빨리 좀 시키자".FormatK("치킨", "피자"), "치킨이든지 피자든지 빨리 좀 시키자");
        Assert.AreEqual("{0}.든지 {1}.든지 빨리 좀 시키자".FormatK("치킨", "피자"), "치킨이든지 피자든지 빨리 좀 시키자");
    }
}
