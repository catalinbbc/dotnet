using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using iClockEx;

namespace unitTests
{
        [TestClass]
        public class UnitTest1
        {

            [TestMethod]
            public static void ConstructedAsSpecified()
            {
                var date = new BusinessDate(28, 3, 2014);
                date.Day.Should().Be(28);
                date.Month.Should().Be(3);
                date.Year.Should().Be(2014);
            }


            [TestMethod]
            public void BusinessDateIsEqualToItself()
            {
                var date = new BusinessDate(06, 10, 2015);
                Equality(date, date, true);
            }

            [TestMethod]
            public void CanBeParsedFromIso8601DateString()
            {
                BusinessDate.ParseFromIso8601String("2015-06-10").Should().Be(new BusinessDate(10, 6, 2015));
            }

            public static void Equality(BusinessDate left, BusinessDate right, bool areEqual)
            {
                left.Equals(right).Should().Be(areEqual);
                (left == right).Should().Be(areEqual);
                (left != right).Should().Be(!areEqual);
                (left.GetHashCode() == right.GetHashCode()).Should().Be(areEqual);
            }
        }
}
