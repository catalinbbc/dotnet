using System;
using Xunit;
using CustomLinkedList;



namespace CustomLinkedList
{
    public class LinkedListTest
    {


        DynamicList<int> target;
        const int NR_ELEMENTS = 25;

        public LinkedListTest()
        {
            target = new DynamicList<int>();
            for (int i = 0; i < NR_ELEMENTS; i++)
            {
                target.Add(i);
            }
        }

        [Fact]
        public void TestIndexOf()
        {
            var firstElement = 0;
            Assert.Equal(firstElement, target.IndexOf(0));
        }

        [Fact]
        public void TestAddOperation()
        {
            target.Add(123);
            Assert.Equal(NR_ELEMENTS + 1, target.Count);
        }

        [Fact]
        public void TestRemoveOperation()
        {

            target.Remove(0);

            Assert.Equal(NR_ELEMENTS - 1, target.Count);

            Assert.Equal(-1, target.IndexOf(0));
        }

        [Fact]
        public void TestRemoveAtOperation()
        {
            target.RemoveAt(0);
            Assert.Equal(NR_ELEMENTS - 1, target.Count);

            Assert.Equal(-1, target.IndexOf(0));
        }

        [Fact]
        public void TestContains()
        {
            var exisitingElement = 123;
            var notExisiting = 189;
            target.Add(exisitingElement);

            Assert.True(target.Contains(exisitingElement));
            Assert.False(target.Contains(notExisiting));
        }

        [Fact]
        public void TestIndex()
        {
            Assert.Equal(0, target[0]);
        }

    }
}
