using Lib.Genetics.Operators;
using NUnit.Framework;

namespace GATest
{
    public class MutationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SwapTest()
        {
            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 1, 4, 6, 3, 8, 5, 2, 7, 9 };

            var point1 = 2;
            var point2 = 7;
            var size = expected.Length;

            var actual = Mutation.Swap(values, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SwitchTest()
        {
            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 1, 4, 7, 2, 5, 8, 3, 9, 6 };

            var point1 = 7;
            var size = expected.Length;

            var actual = Mutation.Switch(values, size, point1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertPoint1AfterPoint2Test()
        {
            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 1, 4, 6, 7, 2, 5, 8, 3, 9 };
            var point1 = 7;
            var point2 = 2;
            var size = expected.Length;

            var actual = Mutation.Insert(values, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertPoint1BeforePoint2Test()
        {
            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 1, 4, 2, 5, 8, 3, 6, 7, 9 };
            var point1 = 2;
            var point2 = 7;
            var size = expected.Length;

            var actual = Mutation.Insert(values, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }
    }
}