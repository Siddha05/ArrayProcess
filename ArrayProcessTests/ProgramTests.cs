using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcess.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        private static IEnumerable<object[]> ArraySource()
        {
            yield return new object[]
            {
                new int[,]{ { 1, 2 }, { 3, 4 } },
                1,
                4,
                new double[] { 1.5, 3.5 }
            };

            yield return new object[]
            {
                new int[,]{ { 1, 2 }, { 3, 4 }, { 13, 1} },
                1,
                13,
                new double[] { 1.5, 3.5, 7d }
            };
            yield return new object[]
            {
                new int[,]{ { 10, 2 }, { -3, 4 }, { 13, 11} },
                -3,
                13,
                new double[] { 6, 0.5, 12d }
            };
        }
        
        [TestMethod()]
        [DynamicData(nameof(ArraySource), DynamicDataSourceType.Method)]
        public void ProcessTest(int[,] data, int exp_min, int exp_max, double[] exp_avg)
        {
            var res = new Program().Process(data);

            Assert.AreEqual(exp_min, res.min);
            Assert.AreEqual(exp_max, res.max);
            CollectionAssert.AreEqual(exp_avg, res.avgs);
        }
    }
}