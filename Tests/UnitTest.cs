using static Funcs.Funcs;
using static Funcs.MyFuncs;

namespace Tests
{
    public class TestHTask1
    {

        [Test]
        public void TestAEqualB_1() => Assert.That(SumAH(10, 10, 2, x => x == 0), Is.EqualTo(0));

        [Test]
        public void TestAEqualB_2() => Assert.That(SumAH(10, 10, 2, x => x == 10), Is.EqualTo(10));

        [Test]
        public void TestSimpleEven() => Assert.That(SumAH(1, 10, 0.5, x => x % 2 == 0), Is.EqualTo(30));

        [Test]
        public void TestException() => Assert.That(() => SumAH(1, 10, 0, x => x % 2 == 0), Throws.ArgumentException);
    }

    public class TestHTask2
    {
        [Test]
        public void TestEmptyString() => Assert.IsTrue(IsPalindrom(""));

        [Test]
        public void TestOneElemString() => Assert.IsTrue(IsPalindrom("☭"));

        [Test]
        public void TestPalindromes()
        {
            Assert.IsTrue(IsPalindrom("abcba"));
            Assert.IsTrue(IsPalindrom("abba"));
            Assert.IsTrue(IsPalindrom("aba"));
            Assert.IsTrue(IsPalindrom("кабак"));
        }

        [Test]
        public void TestNotPalindromes()
        {
            Assert.IsFalse(IsPalindrom("abc46ba"));
            Assert.IsFalse(IsPalindrom("bba"));
            Assert.IsFalse(IsPalindrom("выпо"));
        }
    }

    public class TestHTask4
    {
        [Test]
        public void TestEmptyArr() => Assert.That(MaxElem(new int[] { }), Is.EqualTo(int.MinValue));

        [Test]
        public void TestOnlyPos() => Assert.That(MaxElem(new int[] { 1, 2, 3 }), Is.EqualTo(3));

        [Test]
        public void TestOnlyNeg() => Assert.That(MaxElem(new int[] { -1, -2, -3 }), Is.EqualTo(-1));

        [Test]
        public void TestMixed() => Assert.That(MaxElem(new int[] { -1, 2, -3 }), Is.EqualTo(2));


        [Test]
        public void TestEqualsElem()
        {
            Assert.That(MaxElem(new int[] { 1, 1, 1 }), Is.EqualTo(1));
            Assert.That(MaxElem(new int[] { -1, -1, -1 }), Is.EqualTo(-1));
        }
    }


    public class TestHTask5
    {
        [Test]
        public void TestEmptyList() => Assert.IsNull(MaxElem(new LinkedList<double>()));

        [Test]
        public void TestOnlyPos()
        {
            var node = MaxElem(CreateDList<double>(1, 2, 3));
            Assert.That((node.Value, node.Next?.Value ?? double.MinValue), Is.EqualTo((3, double.MinValue)));
        }

        [Test]
        public void TestOnlyNeg()
        {
            var node = MaxElem(CreateDList<double>(-1, -2, -3));
            Assert.That((node.Value, node.Next?.Value ?? double.MinValue), Is.EqualTo((-1, -2)));
        }

        [Test]
        public void TestMixed()
        {
            var node = MaxElem(CreateDList<double>(-1, -2, -3));
            Assert.That((node.Value, node.Next?.Value ?? double.MinValue), Is.EqualTo((-1, -2)));
        }

        [Test]
        public void TestTwoMax()
        {
            var node = MaxElem(CreateDList<double>(0, 1, 1));
            Assert.That((node.Value, node.Next?.Value ?? double.MinValue), Is.EqualTo((1, 1)));

            node = MaxElem(CreateDList<double>(-231, -1, -1));
            Assert.That((node.Value, node.Next?.Value ?? double.MinValue), Is.EqualTo((-1, -1)));
        }
    }

    public class TestHtask6
    {
        [Test]
        public void TestEmptyList() => Assert.IsNull(FirstPredElem(new LinkedList<double>(), x => x == 2.234));

        [Test]
        public void TestZeroPredElems() => Assert.IsNull(FirstPredElem(CreateDList(1.3, 2.3), x => x < 0));

        [Test]
        public void TestOnePredElem()
        {
            var node1 = FirstPredElem(CreateDList(0, -2, -3), x => x >= 0);
            Assert.That((node1.Value, node1.Next?.Value ?? int.MinValue), Is.EqualTo((0, -2)));

            var node2 = FirstPredElem(CreateDList("25", "aba", "*@D"), x => x.First() == '*');
            Assert.That((node2.Value, node2.Next?.Value ?? ""), Is.EqualTo(("*@D", "")));
        }

        [Test]
        public void TestMultiplePredElems()
        {
            var node1 = FirstPredElem(CreateDList(1, 0, -2, -3), x => x >= 0);
            Assert.That((node1.Value, node1.Next?.Value ?? int.MinValue), Is.EqualTo((1, 0)));

            var node2 = FirstPredElem(CreateDList("*25", "aba", "*@D"), x => x.First() == '*');
            Assert.That((node2.Value, node2.Next?.Value ?? ""), Is.EqualTo(("*25", "aba")));
        }
    }


    public class TestHTask7
    {
        [Test]
        public void TestEmptyList() => Assert.That(CountPredElems(new LinkedList<double>(), x => x == 2.234), Is.EqualTo(0));

        [Test]
        public void TestZeroPredElems() => Assert.That(CountPredElems(CreateDList(1.3, 2.3), x => x < 0), Is.EqualTo(0));

        [Test]
        public void Tests()
        {
            Assert.That(CountPredElems(CreateDList(1.3, 2.3, 0.2, 10, 3.2), x => (int)x % 2 == 0), Is.EqualTo(3));
            Assert.That(CountPredElems(CreateDList('a', '3', ' ', 'Ъ'), char.IsLetter), Is.EqualTo(2));
            Assert.That(CountPredElems(CreateDList("Eins,", "hier", "kommt", "die", "Sonne",
                                                   "Zwei,", "hier", "kommt", "die", "Sonne",
                                                   "Drei,", "sie", "ist", "der", "hellste", "Stern", "von", "allen",
                                                   "Vier,", "hier", "kommt", "die", "Sonne"), x => x.All(char.IsLetter)), Is.EqualTo(19));
            Assert.That(CountPredElems(CreateDList("", " d"), x => x == ""), Is.EqualTo(1));
        }
    }


    public class TestHTask8
    {
        [Test]
        public void TestLst1NullLst2Not() => Assert.IsFalse(StartWith(CreateDList<int>(), CreateDList(1, 2)));

        [Test]
        public void TestLst2NullLst1Not() => Assert.IsTrue(StartWith(CreateDList(1, 2), CreateDList<int>()));

        [Test]
        public void TestLst2NullLst1Null() => Assert.IsTrue(StartWith(CreateDList<int>(), CreateDList<int>()));

        [Test]
        public void TestSimple()
        {
            Assert.IsTrue(StartWith(CreateDList(3, -4, 15, 0, -246, 85), CreateDList(3, -4, 15)));
            Assert.IsFalse(StartWith(CreateDList(3, -4, 15, 0, -246, 85), CreateDList(-4, 15, 0)));
            Assert.IsFalse(StartWith(CreateDList(3, -4, 15, 0, -246, 85), CreateDList(1, 2, 3)));
            Assert.IsFalse(StartWith(CreateDList(1, 2), CreateDList(1, 2, 3)));
            Assert.IsTrue(StartWith(CreateDList("Купил", "мужик", "шляпу", "а", "она", "ему", "как", "раз"), CreateDList("Купил", "мужик", "шляпу")));
        }
    }


    public class TestHtask9
    {
        [Test]
        public void TestNZero() => Assert.IsNull(FibList(0));

        [Test]
        public void TestException() => Assert.That(() => FibList(-1), Throws.ArgumentException);

        [Test]
        public void TestSimple()
        {
            Assert.That(FibList(1), Is.EqualTo(CreateDList(0)));
            Assert.That(FibList(2), Is.EqualTo(CreateDList(0, 1)));
            Assert.That(FibList(3), Is.EqualTo(CreateDList(0, 1, 1)));
            Assert.That(FibList(4), Is.EqualTo(CreateDList(0, 1, 1, 2)));
            Assert.That(FibList(5), Is.EqualTo(CreateDList(0, 1, 1, 2, 3)));
            Assert.That(FibList(10), Is.EqualTo(CreateDList(0, 1, 1, 2, 3, 5, 8, 13, 21, 34)));
        }
    }
}