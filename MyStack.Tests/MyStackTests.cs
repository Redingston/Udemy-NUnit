using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace MyStack.Tests
{
    [TestFixture]
    public class MyStackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var result = new MyStack<int>();

            result.IsEmpty.Should().Be(true);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            var result = new MyStack<int>();
            result.Push(1);

            result.Count.Should().Be(1);
            result.IsEmpty.Should().Be(false);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var result = new MyStack<int>();

            Action act = () => result.Pop();
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            var result = new MyStack<int>();
            result.Push(1);
            result.Push(5);

            result.Peek().Should().Be(5);
            
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadItem()
        {
            var result = new MyStack<int>();
            result.Push(1);
            result.Push(5);

            result.Pop();

            result.Peek().Should().Be(1);

        }
    }
}
