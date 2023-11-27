﻿namespace Dotnet8ModuleSubmodule.DTOs
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubModuleDto> SubModules { get; set; }
    }
}
