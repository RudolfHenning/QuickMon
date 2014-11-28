using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMon
{
    [TestClass]
    public class ConfigVarsTests
    {
        [TestMethod, TestCategory("ConfigVars")]
        public void ConfigVarsFindReplaceTest()
        {
            try
            {
                ConfigVariable cv = new ConfigVariable();
                cv.FindValue = "123";
                cv.ReplaceValue = "abc";
                string someText = "This is a 123 test";
                string changedText = cv.ApplyOn(someText);
                Assert.AreEqual("This is a abc test", changedText, "Find/Replace failed");
            }
            catch (Exception ex)
            {
                Assert.Fail("ConfigVariable exception: " + ex.ToString());
            }
        }
        [TestMethod, TestCategory("ConfigVars")]
        public void ConfigVarsFindReplaceTest2()
        {
            try
            {
                ConfigVariable cv = new ConfigVariable();
                ConfigVariable cv2 = new ConfigVariable();
                cv.FindValue = "123";
                cv.ReplaceValue = "abc";
                cv2.FindValue = "abc";
                cv2.ReplaceValue = "_2!";
                string someText = "This is a 123 test with abc";
                string changedText = cv.ApplyOn(someText);
                Assert.AreEqual("This is a abc test with abc", changedText, "Find/Replace failed");
                changedText = cv2.ApplyOn(changedText);
                Assert.AreEqual("This is a _2! test with _2!", changedText, "Find/Replace failed");

            }
            catch (Exception ex)
            {
                Assert.Fail("ConfigVariable exception: " + ex.ToString());
            }
        }
    }
}
