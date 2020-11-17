using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.web.Shared
{
    public class VisitorBase : ComponentBase
    {
        
        //public string DivCssClass { get; set; }
        [Parameter]
        public string Visible { get; set; } = "show";
        public string DivCssClass => Visible == "show" ? "collapse" : null;
    }
}
