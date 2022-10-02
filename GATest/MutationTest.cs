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
            var mutop = new Mutation();

            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 1, 4, 6, 2, 5, 8, 3, 7, 9 };
            var point1 = 2;
            var point2 = 7;
            var size = expected.Length;

            var actual = mutop.Swap(values, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SwitchTest()
        {
            var mutop = new Mutation();

            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 1, 4, 6, 3, 8, 5, 2, 7, 9 };
            var point1 = 2;
            var point2 = 7;
            var size = expected.Length;

            var actual = mutop.Switch(values, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertTest()
        {
            var mutop = new Mutation();

            var values = new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 };
            var expected = new double[] { 1, 4, 7, 6, 2, 5, 8, 3, 9 };
            var point1 = 7;
            var point2 = 3;
            var size = expected.Length;

            var actual = mutop.Insert(values, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }
    }
}