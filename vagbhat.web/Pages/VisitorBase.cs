using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.web.Pages
{
    public class VisitorBase : ComponentBase
    {
        [Parameter]
        public string Visible { get; set; } = "show";
        public string DivCssClass => Visible == "show" ? "collapse" : null;
    }
}
