using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InputMask.TagHelpers
{
    public enum PreDefinedMask
    {
        email = 1,
        ip = 2,
        date = 3,
        datetime = 4
    }

    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("jquery-inputmask")]
    public class InputMaskTagHelper : TagHelper
    {
        private readonly IHtmlHelper htmlHelper = null;

        private const string IdAttributeName = "id";
        private const string TypeAttributeName = "type";
        private const string ClassAttributeName = "class";
        private const string ForAttributeName = "for";
        private const string PlaceholderAttributeName = "placeholder";
        private const string MaskAttributeName = "mask";
        private const string MaskPlaceHolderAttributeName = "mask-placeholder";
        private const string PreDefinedMaskAttributeName = "pre-defined-mask";

        public InputMaskTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        [HtmlAttributeName(IdAttributeName)]
        public String Id { get; set; }

        [HtmlAttributeName(TypeAttributeName)]
        public String Type { get; set; }

        [HtmlAttributeName(ClassAttributeName)]
        public String Class { get; set; }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(PlaceholderAttributeName)]
        public String PlaceHolderName { get; set; }

        [HtmlAttributeName(MaskAttributeName)]
        public String Mask { get; set; }

        [HtmlAttributeName(MaskPlaceHolderAttributeName)]
        public String MaskPlaceHolderName { get; set; }

        [HtmlAttributeName(PreDefinedMaskAttributeName)]
        public PreDefinedMask PreDefineMasks { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var content = await htmlHelper?.PartialAsync("~/TagHelpers/_InputMaskPartialView.cshtml", this);

            output.Content.SetHtmlContent(content);
        }
    }
}