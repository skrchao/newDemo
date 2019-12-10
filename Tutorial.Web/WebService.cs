namespace Tutorial.Web
{
    public class WebService : IWebService
    {
        public string GetMessage()
        {
            return "Hello Message";
        }
    }
}