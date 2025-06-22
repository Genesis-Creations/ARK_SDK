namespace ARK.SDK.Models.Session
{
    public class Results
    {
        public ModuleResultData Module { get; set; }

        public Results(ModuleResultData module)
        {
            Module = module;
        }
    }
}