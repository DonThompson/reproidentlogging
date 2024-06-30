namespace api_logic.Tests;

[TestClass]
public class SampleAPILogicTests
{
    [TestMethod]
    public void TestMethod1()
    {
        //Some dumb test to link .Tests to the api-logic library
        Assert.IsTrue(SampleAPILogic.ReturnAString().Length > 0);
    }
}