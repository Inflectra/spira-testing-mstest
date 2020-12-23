using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inflectra.SpiraTest.AddOns.SpiraTestMSTestExtension.SampleMSTest
{
    /// <summary>
    /// Sample test fixture that tests the SpiraTest integration
    /// </summary>
    /// <remarks>
    /// Updated on 12/22/2020 to support TLS 1.2
    /// </remarks>
    [
    TestClass
    ]
    public class SampleTestCase2 : MSTestExtensionsTestFixture
    {
        /// <summary>
        /// Test fixture state
        /// </summary>
        protected static int testFixtureState = 1;

        /// <summary>
        /// Constructor method
        /// </summary>
        public SampleTestCase2()
        {
            //Delegates to base

            //Set the state to 2
            testFixtureState = 2;
        }

        /// <summary>
        /// Sample test that asserts a failure and overrides the default configuration
        /// </summary>
        [
        TestMethod,
        TestCategory("Samples"),
        SpiraTestCase(5),
        SpiraTestConfiguration("https://demo-us.spiraservice.net/tv-test-ams1", "fredbloggs", "PleaseChange", 1, 1, 2)
        ]
        public void SampleTestCase2_SampleFail()
        {
            //Verify the state
            Assert.AreEqual(2, testFixtureState, "*Real Error*: State not persisted");

            //Thread.Sleep(65000);

            // If you are debugging this, the debugger will halt 
            // and display the exeception, so press F5 to continue

            //Failure Assertion
            Assert.AreEqual(1, 0, "Failed as Expected");
        }

        /// <summary>
        /// Sample test that succeeds - uses the default configuration
        /// </summary>
        [
        TestMethod,
        TestCategory("Samples"),
        SpiraTestCase(6)
        ]
        public void SampleTestCase2_SamplePass()
        {
            //Verify the state
            Assert.AreEqual(2, testFixtureState, "*Real Error*: State not persisted");

            //Successful assertion
            Assert.AreEqual(1, 1, "Passed as Expected");
        }

        /// <summary>
        /// Sample test that does not log to SpiraTest
        /// </summary>
        [
        TestMethod,
        ExpectedException(typeof(AssertFailedException))
        ]
        public void SampleTestCase2_SampleIgnore()
        {
            //Verify the state
            Assert.AreEqual(2, testFixtureState, "*Real Error*: State not persisted");

            // If you are debugging this, the debugger will halt 
            // and display the exeception, so press F5 to continue

            //Failure Assertion
            Assert.AreEqual(1, 0, "Failed as Expected");
        }

    }
}
