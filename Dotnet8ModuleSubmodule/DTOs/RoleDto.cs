﻿namespace Dotnet8ModuleSubmodule.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<ModuleDto> Modules { get; set; }
    }
}
