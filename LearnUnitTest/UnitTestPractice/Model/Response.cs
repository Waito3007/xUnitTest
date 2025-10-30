namespace LearnUnitTest.UnitTestPractice.Model;
public class Response
{
    public bool Success { get; set; }
    public string Code { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public Response()
    {
    }

    public Response(object _data)
    {
        this.Success = true;
        this.Data = _data;
    }

    public Response(Exception ex)
    {
        try
        {
            this.Success = false;
            this.Code = ResponceEnum.Exception.ToString();
            this.Message = ResponceEnum.Exception.GetDescriptionOfEnum();
        }
        catch
        {
            this.Message = ResponceEnum.Exception.GetDescriptionOfEnum();
        }
    }

    public Response(ExceptionProject ex)
    {
        try
        {
            this.Success = false;
            this.Code = ex.ReturnCode.ToString();
            var message = ex.Message;
            if (ex.ExData != null)
            {
                this.Message = message.ToString().TemplateFormat(ex.ExData);
            }
            else
            {
                this.Message = message;
            }
        }
        catch
        {
            this.Message = "An error has occurred.";
        }
    }
}