using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Tests.Runtime
{
    public class TypewriterTests
    {
        [SetUp]
        public void Setup() { }

        [TearDown]
        public void Teardown() { }

        [UnityTest]
        public IEnumerator TestMethod_TestingHow_TestResult()
        {
            // Arrange

            // Act
            yield return null;

            // Assert
            Assert.AreEqual(1, 1);
        }
    }
}
