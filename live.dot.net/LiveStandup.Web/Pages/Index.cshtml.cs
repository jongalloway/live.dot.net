using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiveStandup.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> ShowNames { get; } = new List<string>();


        public void OnGet()
        {
            ShowNames.Add("ASP.NET Community Standup with the gRPC Team!");
            ShowNames.Add("Xamarin: AndroidX with Jon Dick");
            ShowNames.Add("Visual Studio: Unity with John Miller");
            ShowNames.Add("Desktop: .NET Core for Desktop");
            ShowNames.Add("ASP.NET Community Standup with the gRPC Team!");
            ShowNames.Add("Xamarin: AndroidX with Jon Dick");
            ShowNames.Add("Visual Studio: Unity with John Miller");
            ShowNames.Add("Desktop: .NET Core for Desktop");
            ShowNames.Add("ASP.NET Community Standup with the gRPC Team!");
            ShowNames.Add("Xamarin: AndroidX with Jon Dick");
            ShowNames.Add("Visual Studio: Unity with John Miller");
            ShowNames.Add("Desktop: .NET Core for Desktop");
        }
    }
}
