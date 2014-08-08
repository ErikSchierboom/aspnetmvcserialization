namespace AspNetMvcDictionarySerialization.Tests
{
    using System.Collections.Generic;

    using Xunit;

    public class HtmlHelperExtensionsTests
    {
        [Fact]
        public void EditorReturnsCorrectFormatForDictionary()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var actualHtmlString = htmlHelper.Editor("dict", inputDictionary).ToHtmlString();

            // Assert
            Assert.Equal(@"<input id=""dict"" name=""dict[0].Key"" type=""text"" value=""Id"" />
<input id=""dict"" name=""dict[0].Value"" type=""text"" value=""1"" />
<input id=""dict"" name=""dict[1].Key"" type=""text"" value=""Title"" />
<input id=""dict"" name=""dict[1].Value"" type=""text"" value=""Se7en"" />
<input id=""dict"" name=""dict[2].Key"" type=""text"" value=""Director"" />
<input id=""dict"" name=""dict[2].Value"" type=""text"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void EditorUsesObjectSpecifiedHtmlAttributes()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var actualHtmlString = htmlHelper.Editor("dict", inputDictionary, new { @readonly = "readonly" }).ToHtmlString();

            // Assert
            Assert.Equal(@"<input id=""dict"" name=""dict[0].Key"" readonly=""readonly"" type=""text"" value=""Id"" />
<input id=""dict"" name=""dict[0].Value"" readonly=""readonly"" type=""text"" value=""1"" />
<input id=""dict"" name=""dict[1].Key"" readonly=""readonly"" type=""text"" value=""Title"" />
<input id=""dict"" name=""dict[1].Value"" readonly=""readonly"" type=""text"" value=""Se7en"" />
<input id=""dict"" name=""dict[2].Key"" readonly=""readonly"" type=""text"" value=""Director"" />
<input id=""dict"" name=""dict[2].Value"" readonly=""readonly"" type=""text"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void EditorUsesDictionarySpecifiedHtmlAttributes()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var actualHtmlString = htmlHelper.Editor("dict", inputDictionary, new Dictionary<string, object> { { "disabled", "disabled" } }).ToHtmlString();

            // Assert
            Assert.Equal(@"<input disabled=""disabled"" id=""dict"" name=""dict[0].Key"" type=""text"" value=""Id"" />
<input disabled=""disabled"" id=""dict"" name=""dict[0].Value"" type=""text"" value=""1"" />
<input disabled=""disabled"" id=""dict"" name=""dict[1].Key"" type=""text"" value=""Title"" />
<input disabled=""disabled"" id=""dict"" name=""dict[1].Value"" type=""text"" value=""Se7en"" />
<input disabled=""disabled"" id=""dict"" name=""dict[2].Key"" type=""text"" value=""Director"" />
<input disabled=""disabled"" id=""dict"" name=""dict[2].Value"" type=""text"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void EditorForReturnsCorrectFormatForDictionary()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var actualHtmlString = htmlHelper.EditorFor(m => m.Dict).ToHtmlString();

            // Assert
            Assert.Equal(@"<input id=""Dict"" name=""Dict[0].Key"" type=""text"" value=""Id"" />
<input id=""Dict"" name=""Dict[0].Value"" type=""text"" value=""1"" />
<input id=""Dict"" name=""Dict[1].Key"" type=""text"" value=""Title"" />
<input id=""Dict"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />
<input id=""Dict"" name=""Dict[2].Key"" type=""text"" value=""Director"" />
<input id=""Dict"" name=""Dict[2].Value"" type=""text"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void EditorForUsesObjectSpecifiedHtmlAttributes()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var actualHtmlString = htmlHelper.EditorFor(m => m.Dict, new { @readonly = "readonly" }).ToHtmlString();

            // Assert
            Assert.Equal(@"<input id=""Dict"" name=""Dict[0].Key"" readonly=""readonly"" type=""text"" value=""Id"" />
<input id=""Dict"" name=""Dict[0].Value"" readonly=""readonly"" type=""text"" value=""1"" />
<input id=""Dict"" name=""Dict[1].Key"" readonly=""readonly"" type=""text"" value=""Title"" />
<input id=""Dict"" name=""Dict[1].Value"" readonly=""readonly"" type=""text"" value=""Se7en"" />
<input id=""Dict"" name=""Dict[2].Key"" readonly=""readonly"" type=""text"" value=""Director"" />
<input id=""Dict"" name=""Dict[2].Value"" readonly=""readonly"" type=""text"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void EditorForUsesDictionarySpecifiedHtmlAttributes()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var actualHtmlString = htmlHelper.EditorFor(m => m.Dict, new Dictionary<string, object> { { "disabled", "disabled" } }).ToHtmlString();

            // Assert
            Assert.Equal(@"<input disabled=""disabled"" id=""Dict"" name=""Dict[0].Key"" type=""text"" value=""Id"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[0].Value"" type=""text"" value=""1"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[1].Key"" type=""text"" value=""Title"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[2].Key"" type=""text"" value=""Director"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[2].Value"" type=""text"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void HiddenReturnsCorrectFormatForDictionary()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var actualHtmlString = htmlHelper.Hidden("dict", inputDictionary).ToHtmlString();

            // Assert
            Assert.Equal(@"<input id=""dict"" name=""dict[0].Key"" type=""hidden"" value=""Id"" />
<input id=""dict"" name=""dict[0].Value"" type=""hidden"" value=""1"" />
<input id=""dict"" name=""dict[1].Key"" type=""hidden"" value=""Title"" />
<input id=""dict"" name=""dict[1].Value"" type=""hidden"" value=""Se7en"" />
<input id=""dict"" name=""dict[2].Key"" type=""hidden"" value=""Director"" />
<input id=""dict"" name=""dict[2].Value"" type=""hidden"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void HiddenUsesObjectSpecifiedHtmlAttributes()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var actualHtmlString = htmlHelper.Hidden("dict", inputDictionary, new { @readonly = "readonly" }).ToHtmlString();

            // Assert
            Assert.Equal(@"<input id=""dict"" name=""dict[0].Key"" readonly=""readonly"" type=""hidden"" value=""Id"" />
<input id=""dict"" name=""dict[0].Value"" readonly=""readonly"" type=""hidden"" value=""1"" />
<input id=""dict"" name=""dict[1].Key"" readonly=""readonly"" type=""hidden"" value=""Title"" />
<input id=""dict"" name=""dict[1].Value"" readonly=""readonly"" type=""hidden"" value=""Se7en"" />
<input id=""dict"" name=""dict[2].Key"" readonly=""readonly"" type=""hidden"" value=""Director"" />
<input id=""dict"" name=""dict[2].Value"" readonly=""readonly"" type=""hidden"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void HiddenUsesDictionarySpecifiedHtmlAttributes()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var actualHtmlString = htmlHelper.Hidden("dict", inputDictionary, new Dictionary<string, object> { { "disabled", "disabled" } }).ToHtmlString();

            // Assert
            Assert.Equal(@"<input disabled=""disabled"" id=""dict"" name=""dict[0].Key"" type=""hidden"" value=""Id"" />
<input disabled=""disabled"" id=""dict"" name=""dict[0].Value"" type=""hidden"" value=""1"" />
<input disabled=""disabled"" id=""dict"" name=""dict[1].Key"" type=""hidden"" value=""Title"" />
<input disabled=""disabled"" id=""dict"" name=""dict[1].Value"" type=""hidden"" value=""Se7en"" />
<input disabled=""disabled"" id=""dict"" name=""dict[2].Key"" type=""hidden"" value=""Director"" />
<input disabled=""disabled"" id=""dict"" name=""dict[2].Value"" type=""hidden"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void HiddenForReturnsCorrectFormatForDictionary()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var actualHtmlString = htmlHelper.HiddenFor(m => m.Dict).ToHtmlString();

            // Assert
            Assert.Equal(@"<input id=""Dict"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />
<input id=""Dict"" name=""Dict[0].Value"" type=""hidden"" value=""1"" />
<input id=""Dict"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />
<input id=""Dict"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />
<input id=""Dict"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />
<input id=""Dict"" name=""Dict[2].Value"" type=""hidden"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void HiddenForUsesObjectSpecifiedHtmlAttributes()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var actualHtmlString = htmlHelper.HiddenFor(m => m.Dict, new { @readonly = "readonly" }).ToHtmlString();

            // Assert
            Assert.Equal(@"<input id=""Dict"" name=""Dict[0].Key"" readonly=""readonly"" type=""hidden"" value=""Id"" />
<input id=""Dict"" name=""Dict[0].Value"" readonly=""readonly"" type=""hidden"" value=""1"" />
<input id=""Dict"" name=""Dict[1].Key"" readonly=""readonly"" type=""hidden"" value=""Title"" />
<input id=""Dict"" name=""Dict[1].Value"" readonly=""readonly"" type=""hidden"" value=""Se7en"" />
<input id=""Dict"" name=""Dict[2].Key"" readonly=""readonly"" type=""hidden"" value=""Director"" />
<input id=""Dict"" name=""Dict[2].Value"" readonly=""readonly"" type=""hidden"" value=""David Fincher"" />", actualHtmlString);
        }

        [Fact]
        public void HiddenForUsesDictionarySpecifiedHtmlAttributes()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var actualHtmlString = htmlHelper.HiddenFor(m => m.Dict, new Dictionary<string, object> { { "disabled", "disabled" } }).ToHtmlString();

            // Assert
            Assert.Equal(@"<input disabled=""disabled"" id=""Dict"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[0].Value"" type=""hidden"" value=""1"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />
<input disabled=""disabled"" id=""Dict"" name=""Dict[2].Value"" type=""hidden"" value=""David Fincher"" />", actualHtmlString);
        }

        private static Dictionary<string, string> CreateDictionary()
        {
            return new Dictionary<string, string> { { "Id", "1" }, { "Title", "Se7en" }, { "Director", "David Fincher" }, };
        }

        private static DictionaryModel CreateDictionaryModel()
        {
            return new DictionaryModel { Dict = CreateDictionary() };
        }

        private class DictionaryModel
        {
            public Dictionary<string, string> Dict { get; set; }
        }
    }
}