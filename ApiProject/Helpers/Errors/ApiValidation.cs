using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Helpers.Errors
{
    public class ApiValidation
    {
        public string[] Errors { get; set; } = Array.Empty<string>();
    }
}