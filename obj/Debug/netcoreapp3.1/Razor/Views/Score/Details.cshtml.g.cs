#pragma checksum "E:\study\project_CSDL\Views\Score\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eec459e19173ddb3ed8d219c8300abb7e80b06d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Score_Details), @"mvc.1.0.view", @"/Views/Score/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\study\project_CSDL\Views\_ViewImports.cshtml"
using SoccerManageApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\study\project_CSDL\Views\_ViewImports.cshtml"
using SoccerManageApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eec459e19173ddb3ed8d219c8300abb7e80b06d5", @"/Views/Score/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6eeabaf9f8ad7170056c4446b96cf24acfb114dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Score_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SoccerManageApp.Models.Entities.Score>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left: 50px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Image/Mix/Ball.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\study\project_CSDL\Views\Score\Details.cshtml"
  
    ViewData["Title"]="Score Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table border=\"1\" cellpadding=\"15\">\r\n    <thead>\r\n        <th><h3>");
#nullable restore
#line 8 "E:\study\project_CSDL\Views\Score\Details.cshtml"
           Write(ViewData["HomeTeam"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "eec459e19173ddb3ed8d219c8300abb7e80b06d54242", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 251, "~/Image/", 251, 8, true);
#nullable restore
#line 9 "E:\study\project_CSDL\Views\Score\Details.cshtml"
AddHtmlAttributeValue("", 259, ViewData["HomeImage"], 259, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </th>\r\n         <th><h3>");
#nullable restore
#line 11 "E:\study\project_CSDL\Views\Score\Details.cshtml"
            Write(ViewData["AwayTeam"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "eec459e19173ddb3ed8d219c8300abb7e80b06d56036", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 393, "~/Image/", 393, 8, true);
#nullable restore
#line 12 "E:\study\project_CSDL\Views\Score\Details.cshtml"
AddHtmlAttributeValue("", 401, ViewData["AwayImage"], 401, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n         </th>\r\n\r\n    </thead>\r\n    <tbody>\r\n      \r\n           <tr>\r\n                \r\n               <td>\r\n");
#nullable restore
#line 21 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                    foreach (var goal in Model)
                   {
                       

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                        if(@goal.Team.TeamName.ToString()==@ViewData["HomeTeam"].ToString())

                     {

#line default
#line hidden
#nullable disable
            WriteLiteral("                       <h5 style=\"padding: 5;\">");
#nullable restore
#line 26 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                                          Write(goal.Player.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "eec459e19173ddb3ed8d219c8300abb7e80b06d58519", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                       </h5>\r\n");
#nullable restore
#line 29 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                     }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                      
                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 33 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                    foreach (var goal in Model)
                   {
                       

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                        if(@goal.Team.TeamName.ToString()==@ViewData["AwayTeam"].ToString())

                     {

#line default
#line hidden
#nullable disable
            WriteLiteral("                       <h5 style=\"padding: 5;\">");
#nullable restore
#line 38 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                                          Write(goal.Player.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "eec459e19173ddb3ed8d219c8300abb7e80b06d510812", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                       </h5>\r\n");
#nullable restore
#line 41 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                     }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "E:\study\project_CSDL\Views\Score\Details.cshtml"
                      
                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n  \r\n           </tr>\r\n    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SoccerManageApp.Models.Entities.Score>> Html { get; private set; }
    }
}
#pragma warning restore 1591
