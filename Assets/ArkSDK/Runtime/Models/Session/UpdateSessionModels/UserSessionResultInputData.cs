namespace ARK.SDK.Models.Session
{
    public class UserSessionResultInputData
    {
        public Results Results { get; set; }

        public UserSessionResultInputData(ModuleResultData module)
        {
            Results = new Results(module);
        }
    }
}