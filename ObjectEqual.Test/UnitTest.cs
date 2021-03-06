using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ObjectEquality.Test
{
    [TestClass]
    public class UnitTest
    {
        private ObjectEquality _objectEquality = null;



        [TestInitialize]
        public void SetEquality()
        {
            _objectEquality = new ObjectEquality();
        }

        [TestMethod]
        public void TestValueType()
        {
            var a = 1;
            var b = 1;

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestValueTypeError()
        {
            var a = 1;
            var b = 2;

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestArray()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 2, 3 };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestArrayError()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 2, 4 };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestSimpleClass()
        {
            var a = new SimpleClass
            {
                Id = 1,
                Name = "A"
            };

            var b = new SimpleClass
            {
                Id = 1,
                Name = "A"
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestClassWithNullValue()
        {
            var a = new SimpleClass
            {
                Id = 1,
                Name = null
            };

            var b = new SimpleClass
            {
                Id = 1,
                Name = null
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestSimpleClassError()
        {
            var a = new SimpleClass
            {
                Id = 1,
                Name = "A"
            };

            var b = new SimpleClass
            {
                Id = 1,
                Name = "B"
            };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestComplexClass()
        {
            var a = new ComplexClass
            {
                Id = 1,
                Strs = new System.Collections.Generic.List<string> { "A", "B" }
            };

            var b = new ComplexClass
            {
                Id = 1,
                Strs = new System.Collections.Generic.List<string> { "A", "B" }
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestComplexClassError()
        {
            var a = new ComplexClass
            {
                Id = 1,
                Strs = new System.Collections.Generic.List<string> { "A", "B" }
            };

            var b = new ComplexClass
            {
                Id = 1,
                Strs = new System.Collections.Generic.List<string> { "A", "C" }
            };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestEnumInClass()
        {
            var a = new EnumClass
            {
                Test = TestEnum.A
            };

            var b = new EnumClass
            {
                Test = TestEnum.A
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestEnumInClassError()
        {
            var a = new EnumClass
            {
                Test = TestEnum.A
            };

            var b = new EnumClass
            {
                Test = TestEnum.B
            };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestEnumValue()
        {
            var a = TestEnum.A;

            var b = TestEnum.A;

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestEnumValueError()
        {
            var a = TestEnum.A;

            var b = TestEnum.B;

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStruct()
        {
            var a = new DemoStruct();
            a.Id = 1;
            a.Name = "Test";

            var b = new DemoStruct();
            b.Id = 1;
            b.Name = "Test";

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStructError()
        {
            var a = new DemoStruct();
            a.Id = 1;
            a.Name = "Test";

            var b = new DemoStruct();
            b.Id = 2;
            b.Name = "Test";

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestNullStruct()
        {
            var a = new DemoStruct();
            a.Id = 1;
            a.Name = null;

            var b = new DemoStruct();
            b.Id = 2;
            b.Name = null;

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStructWithClass()
        {
            var a = new StructWithClass();
            a.SimpleClass = new SimpleClass
            {
                Id = 1,
                Name = "Test"
            };

            var b = new StructWithClass();
            b.SimpleClass = new SimpleClass
            {
                Id = 1,
                Name = "Test"
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStructWithClassError()
        {
            var a = new StructWithClass();
            a.SimpleClass = new SimpleClass
            {
                Id = 1,
                Name = "Test"
            };

            var b = new StructWithClass();
            b.SimpleClass = new SimpleClass
            {
                Id = 2,
                Name = "Test"
            };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestLooseArray()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 2, 1, 3 };

            ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Loose;
            var objectEquality = new ObjectEquality();
            Assert.IsTrue(objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestLooseArrayError()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 1, 3 };

            ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Loose;
            var objectEquality = new ObjectEquality();
            Assert.IsTrue(!objectEquality.IsEqual(a, b));
        }


        [TestMethod]
        public void TestStrictArray()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 2, 1, 3 };

            ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Strict;
            var objectEquality = new ObjectEquality();
            Assert.IsTrue(!objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStrictArrayError()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 1, 3 };

            ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Strict;
            var objectEquality = new ObjectEquality();
            Assert.IsTrue(!objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestString()
        {
            var a = "a";
            var b = "a";

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStringError()
        {
            var a = "a";
            var b = "b";

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestCycleReferenceException()
        {
            Assert.ThrowsException<CycleReferenceException>(() =>
            {
                var wrappedClassA = new WrappedClass
                {
                    Field = "A"
                };

                wrappedClassA.Inner = wrappedClassA;


                var wrappedClassB = new WrappedClass
                {
                    Field = "A"
                };

                wrappedClassB.Inner = wrappedClassB;

                _objectEquality.IsEqual(wrappedClassA, wrappedClassB);
            });

        }

        [TestMethod]
        public void TestTwoDimensionalArray()
        {
            var arrayA = new int[2, 3] { { 1, 1, 1 }, { 2, 2, 2 } };
            var arrayB = new int[2, 3] { { 1, 1, 1 }, { 2, 2, 2 } };

            Assert.IsTrue(_objectEquality.IsEqual(arrayA, arrayB));
        }

        [TestMethod]
        public void TestTwoDimensionalWrong()
        {
            var arrayA = new int[2, 3] { { 1, 2, 3 }, { 2, 2, 3 } };
            var arrayB = new int[2, 3] { { 1, 1, 3 }, { 2, 2, 3 } };

            Assert.IsFalse(_objectEquality.IsEqual(arrayA, arrayB));
        }

        [TestMethod]
        public void TestTuple()
        {
            var tupleA = new Tuple<int, int, int>(1, 2, 3);
            var tupleB = new Tuple<int, int, int>(1, 2, 3);

            Assert.IsTrue(_objectEquality.IsEqual(tupleA, tupleB));
        }

        [TestMethod]
        public void TestTupleError()
        {
            var tupleA = new Tuple<int, int, int>(1, 2, 3);
            var tupleB = new Tuple<int, int, int>(1, 2, 4);

            Assert.IsFalse(_objectEquality.IsEqual(tupleA, tupleB));
        }

        [TestMethod]
        public void TestValueTypeCollection()
        {
            var collectionA = new List<int> { 1, 2, 3 };
            var collectionB = new List<int> { 1, 2, 3 };

            Assert.IsTrue(_objectEquality.IsEqual(collectionA, collectionB));
        }

        [TestMethod]
        public void TestValueTypeCollectionError()
        {
            var collectionA = new List<int> { 1, 2, 3 };
            var collectionB = new List<int> { 1, 2, 4 };

            Assert.IsFalse(_objectEquality.IsEqual(collectionA, collectionB));
        }

        [TestMethod]
        public void TestClassCollection()
        {
            var collectionA = new List<SimpleClass> { new SimpleClass { Id = 1, Name = "Lamond Lu" } };
            var collectionB = new List<SimpleClass> { new SimpleClass { Id = 1, Name = "Lamond Lu" } };

            Assert.IsTrue(_objectEquality.IsEqual(collectionA, collectionB));
        }

        [TestMethod]
        public void TestClassCollectionError()
        {
            var collectionA = new List<SimpleClass> { new SimpleClass { Id = 1, Name = "Lamond Lu" } };
            var collectionB = new List<SimpleClass> { new SimpleClass { Id = 2, Name = "Lamond Lu" } };

            Assert.IsFalse(_objectEquality.IsEqual(collectionA, collectionB));
        }
    }


}
