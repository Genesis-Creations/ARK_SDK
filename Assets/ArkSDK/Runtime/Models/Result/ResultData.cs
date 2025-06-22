namespace ARK.SDK.Models.Result
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