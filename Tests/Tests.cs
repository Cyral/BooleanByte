using System;
using BoolByte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoolByte.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestState()
        {
            //Arrange
            BooleanByte data = new BooleanByte();
            bool[] array = new bool[8]; //Actual

            //Act
            for (int i = 0; i < 8; i++) //Assign 10101010
                data[i] = array[i] = (i % 1) == 0;

            //Assert
            for (int i = 0; i < 8; i++)
                Assert.AreEqual(array[i], data[i]);
        }

        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            BooleanByte data = new BooleanByte();

            //Act
            data[0] = true;
            data[7] = false;

            //Assert
            Assert.IsTrue(data[0]);
            Assert.IsFalse(data[7]);
        }

        [TestMethod]
        public void TestFunction()
        {
            //Arrange
            BooleanByte data = new BooleanByte();

            //Act
            data.SetBit(0, true);
            data.SetBit(7, false);

            //Assert
            Assert.IsTrue(data.GetBit(0));
            Assert.IsFalse(data.GetBit(7));
        }

        [TestMethod]
        public void TestRaw()
        {
            //Arrange
            BooleanByte data = new BooleanByte();

            //Act
            data[0] = true; //   1
            data[1] = true; //   2
            data[2] = true; //   4
            data[3] = true; // + 8
                            // ---
                            // = 15 (11110000)
            //Assert
            Assert.AreEqual(15, data.Raw);
        }


        [TestMethod]
        public void TestComparison()
        {
            //Arrange
            BooleanByte foo = new BooleanByte();
            BooleanByte bar = new BooleanByte();

            //Act
            foo[0] = true;
            bar[0] = true;

            //Assert
            Assert.AreEqual(foo, bar);
        }
    }
}
