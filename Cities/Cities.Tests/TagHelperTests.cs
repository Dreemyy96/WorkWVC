using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cities.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Tests
{
    public class TagHelperTests
    {
        [Fact]
        public void TestTagHelper()
        {
            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "myuniqueid");
            var output = new TagHelperOutput("button", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            var tagHelper = new ButtonTagHelper() { BsButtonColor = "testValue" };
            tagHelper.Process(context, output);

            Assert.Equal($"btn btn-{tagHelper.BsButtonColor}", output.Attributes["class"].Value);
        }
    }
}
