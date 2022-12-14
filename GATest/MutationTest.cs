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

        [Test]
        public void SwitchByMaskTest()
        {
            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 4, 1, 7, 5, 8, 2, 6, 9, 3 };
            var mask = new int[] { 0, 1, 0, 0, 1, 1, 0, 1, 1 };
            var size = expected.Length;

            var actual = Mutation.SwitchByMask(values, size, mask);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertByMaskTest()
        {
            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 4, 1, 5, 6, 7, 8, 2, 9, 3 };
            var mask = new int[] { -1, 0, -1, -1, 2, 4, -1, 3, 7 };
            var size = expected.Length;

            var actual = Mutation.InsertByMask(values, size, mask);

            Assert.AreEqual(expected, actual);
        }
    }
}