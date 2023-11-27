namespace Dotnet8ModuleSubmodule.Entities.Tagging
{
    public class ModuleSubModuleTagging
    {
        public int SubModuleId { get; set; }
        public virtual SubModule SubModule { get; set; }

        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }
    }
}
