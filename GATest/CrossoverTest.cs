﻿using Lib.Genetics.Operators;
using NUnit.Framework;

namespace GATest
{
    public class CrossoverTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PPXFirstParentToSecondParentTest()
        {
            var mask = new int[] { 1, 0, 0, 0, 1, 1, 0, 1, 1 };
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 1, 5, 4, 6, 2, 3, 9, 7, 8 };
            var size = expected.Length;

            var actual = Crossover.PPX(parent1, parent2, size, mask);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PPXSecondParentToFirstParentTest()
        {
            var mask = new int[] { 1, 0, 0, 0, 1, 1, 0, 1, 1 };
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 5, 1, 2, 3, 4, 6, 7, 9, 8 };
            var size = expected.Length;

            var actual = Crossover.PPX(parent2, parent1, size, mask);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OBXFirstParentToSecondParentTest()
        {
            var mask = new int[] { 1, 0, 0, 0, 1, 1, 0, 1, 1 };
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 1, 4, 3, 2, 5, 6, 7, 8, 9 };
            var size = expected.Length;

            var actual = Crossover.OBX(parent1, parent2, size, mask);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void OBXSecondParentToFirstParentTest()
        {
            var mask = new int[] { 1, 0, 0, 0, 1, 1, 0, 1, 1 };
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 5, 2, 3, 4, 1, 9, 6, 7, 8 };
            var size = expected.Length;

            var actual = Crossover.OBX(parent2, parent1, size, mask);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OBX2FirstParentToSecondParentTest()
        {
            var mask = new int[] { 1, 0, 0, 0, 1, 1, 0, 1, 1 };
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 1, 4, 7, 3, 5, 6, 2, 8, 9 };
            var size = expected.Length;

            var actual = Crossover.OBX2(parent1, parent2, size, mask);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OBX2SecondParentToFirstParentTest()
        {
            var mask = new int[] { 1, 0, 0, 0, 1, 1, 0, 1, 1 };
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 5, 2, 3, 4, 1, 9, 6, 7, 8 };
            var size = expected.Length;

            var actual = Crossover.OBX2(parent2, parent1, size, mask);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TPXFirstParentToSecondParentTest()
        {
            var point1 = 3;
            var point2 = 7;
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var size = expected.Length;

            var actual = Crossover.TPX(parent1, parent2, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TPXSecondParentToFirstParentTest()
        {
            var point1 = 3;
            var point2 = 7;
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 5, 4, 6, 3, 1, 2, 9, 7, 8 };
            var size = expected.Length;

            var actual = Crossover.TPX(parent2, parent1, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OSXFirstParentToSecondParentTest()
        {
            var point1 = 3;
            var point2 = 7;
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 1, 2, 3, 4, 5, 6, 9, 7, 8 };
            var size = expected.Length;

            var actual = Crossover.OSX(parent1, parent2, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OSXSecondParentToFristParentTest()
        {
            var point1 = 3;
            var point2 = 7;
            var parent1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parent2 = new double[] { 5, 4, 6, 3, 1, 9, 2, 7, 8 };
            var expected = new double[] { 5, 4, 6, 3, 1, 2, 7, 8, 9 };
            var size = expected.Length;

            var actual = Crossover.OSX(parent2, parent1, size, point1, point2);

            Assert.AreEqual(expected, actual);
        }
    }
}