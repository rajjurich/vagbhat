using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.web.Pages
{
    public class IndexBase : ComponentBase
    {
        protected string VisibilityText { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        protected void NewPatient()
        {
            NavigationManager.NavigateTo("/addpatient");
        }

        protected override Task OnInitializedAsync()
        {
            return Task.FromResult(VisibilityText = "show");
        }

        protected void ToggleVisibility()
        {
            VisibilityText = VisibilityText == "show" ? "hide" : "show";
        }
    }
}
