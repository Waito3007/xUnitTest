using System.ComponentModel;

namespace LearnUnitTest.UnitTestPractice.Model;

public enum ResponceEnum
{
    [Description("Id not found")]
    Exception = -1,
}

public class ExceptionProject : Exception
{
    public string ReturnCode { get; set; }
    public object ExData { get; set; }

    public ExceptionProject()
    {
    }

    public ExceptionProject(ResponceEnum _returnCode, object _exData = null):
        base(_returnCode.GetDescriptionOfEnum())
    {
        this.ReturnCode = _returnCode.ToString("f");
        this.ExData = _exData;
    }
    
}

public class _returnCode
{
}