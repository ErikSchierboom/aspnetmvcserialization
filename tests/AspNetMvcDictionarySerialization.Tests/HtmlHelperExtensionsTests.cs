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
            var html = htmlHelper.Editor("dict", inputDictionary);

            // Assert
            Assert.Equal(@"<input id=""dict"" name=""dict[0].Key"" type=""text"" value=""Id"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[0].Value"" type=""text"" value=""1"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[1].Key"" type=""text"" value=""Title"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[1].Value"" type=""text"" value=""Se7en"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[2].Key"" type=""text"" value=""Director"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[2].Value"" type=""text"" value=""David Fincher"" />",
                         html.ToHtmlString());
        }

        [Fact]
        public void EditorUsesObjectSpecifiedHtmlAttributes()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var html = htmlHelper.Editor("dict", inputDictionary, new { @readonly = "readonly" });

            // Assert
            Assert.Equal(@"<input id=""dict"" name=""dict[0].Key"" readonly=""readonly"" type=""text"" value=""Id"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[0].Value"" readonly=""readonly"" type=""text"" value=""1"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[1].Key"" readonly=""readonly"" type=""text"" value=""Title"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[1].Value"" readonly=""readonly"" type=""text"" value=""Se7en"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[2].Key"" readonly=""readonly"" type=""text"" value=""Director"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[2].Value"" readonly=""readonly"" type=""text"" value=""David Fincher"" />", 
                         html.ToHtmlString());
        }

        [Fact]
        public void EditorUsesDictionarySpecifiedHtmlAttributes()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var html = htmlHelper.Editor("dict", inputDictionary, new Dictionary<string, object> { { "disabled", "disabled" } });

            // Assert
            Assert.Equal(@"<input disabled=""disabled"" id=""dict"" name=""dict[0].Key"" type=""text"" value=""Id"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[0].Value"" type=""text"" value=""1"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[1].Key"" type=""text"" value=""Title"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[1].Value"" type=""text"" value=""Se7en"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[2].Key"" type=""text"" value=""Director"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[2].Value"" type=""text"" value=""David Fincher"" />", 
                         html.ToHtmlString());
        }

        [Fact]
        public void EditorForReturnsCorrectFormatForDictionary()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var html = htmlHelper.EditorFor(m => m.Dict);

            // Assert
            Assert.Equal(@"<input id=""Dict"" name=""Dict[0].Key"" type=""text"" value=""Id"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[0].Value"" type=""text"" value=""1"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[1].Key"" type=""text"" value=""Title"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[2].Key"" type=""text"" value=""Director"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[2].Value"" type=""text"" value=""David Fincher"" />", 
                         html.ToHtmlString());
        }

        [Fact]
        public void EditorForUsesObjectSpecifiedHtmlAttributes()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var html = htmlHelper.EditorFor(m => m.Dict, new { @readonly = "readonly" });

            // Assert
            Assert.Equal(@"<input id=""Dict"" name=""Dict[0].Key"" readonly=""readonly"" type=""text"" value=""Id"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[0].Value"" readonly=""readonly"" type=""text"" value=""1"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[1].Key"" readonly=""readonly"" type=""text"" value=""Title"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[1].Value"" readonly=""readonly"" type=""text"" value=""Se7en"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[2].Key"" readonly=""readonly"" type=""text"" value=""Director"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[2].Value"" readonly=""readonly"" type=""text"" value=""David Fincher"" />", 
                         html.ToHtmlString());
        }

        [Fact]
        public void EditorForUsesDictionarySpecifiedHtmlAttributes()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var html = htmlHelper.EditorFor(m => m.Dict, new Dictionary<string, object> { { "disabled", "disabled" } });

            // Assert
            Assert.Equal(@"<input disabled=""disabled"" id=""Dict"" name=""Dict[0].Key"" type=""text"" value=""Id"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[0].Value"" type=""text"" value=""1"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[1].Key"" type=""text"" value=""Title"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[2].Key"" type=""text"" value=""Director"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[2].Value"" type=""text"" value=""David Fincher"" />", 
                         html.ToHtmlString());
        }

        [Fact]
        public void HiddenReturnsCorrectFormatForDictionary()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var html = htmlHelper.Hidden("dict", inputDictionary);

            // Assert
            Assert.Equal(@"<input id=""dict"" name=""dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[0].Value"" type=""hidden"" value=""1"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[1].Value"" type=""hidden"" value=""Se7en"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[2].Value"" type=""hidden"" value=""David Fincher"" />", 
                         html.ToHtmlString());
        }

        [Fact]
        public void HiddenUsesObjectSpecifiedHtmlAttributes()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var html = htmlHelper.Hidden("dict", inputDictionary, new { @readonly = "readonly" });

            // Assert
            Assert.Equal(@"<input id=""dict"" name=""dict[0].Key"" readonly=""readonly"" type=""hidden"" value=""Id"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[0].Value"" readonly=""readonly"" type=""hidden"" value=""1"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[1].Key"" readonly=""readonly"" type=""hidden"" value=""Title"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[1].Value"" readonly=""readonly"" type=""hidden"" value=""Se7en"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[2].Key"" readonly=""readonly"" type=""hidden"" value=""Director"" />" + "\n" +
                         @"<input id=""dict"" name=""dict[2].Value"" readonly=""readonly"" type=""hidden"" value=""David Fincher"" />",
                         html.ToHtmlString());
        }

        [Fact]
        public void HiddenUsesDictionarySpecifiedHtmlAttributes()
        {
            // Arrange
            var inputDictionary = CreateDictionary();
            var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

            // Act
            var html = htmlHelper.Hidden("dict", inputDictionary, new Dictionary<string, object> { { "disabled", "disabled" } });

            // Assert
            Assert.Equal(@"<input disabled=""disabled"" id=""dict"" name=""dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[0].Value"" type=""hidden"" value=""1"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[1].Value"" type=""hidden"" value=""Se7en"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""dict"" name=""dict[2].Value"" type=""hidden"" value=""David Fincher"" />", 
                         html.ToHtmlString());
        }

        [Fact]
        public void HiddenForReturnsCorrectFormatForDictionary()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var html = htmlHelper.HiddenFor(m => m.Dict);

            // Assert
            Assert.Equal(@"<input id=""Dict"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[0].Value"" type=""hidden"" value=""1"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[2].Value"" type=""hidden"" value=""David Fincher"" />", 
                         html.ToHtmlString());
        }

        [Fact]
        public void HiddenForUsesObjectSpecifiedHtmlAttributes()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var html = htmlHelper.HiddenFor(m => m.Dict, new { @readonly = "readonly" });

            // Assert
            Assert.Equal(@"<input id=""Dict"" name=""Dict[0].Key"" readonly=""readonly"" type=""hidden"" value=""Id"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[0].Value"" readonly=""readonly"" type=""hidden"" value=""1"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[1].Key"" readonly=""readonly"" type=""hidden"" value=""Title"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[1].Value"" readonly=""readonly"" type=""hidden"" value=""Se7en"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[2].Key"" readonly=""readonly"" type=""hidden"" value=""Director"" />" + "\n" +
                         @"<input id=""Dict"" name=""Dict[2].Value"" readonly=""readonly"" type=""hidden"" value=""David Fincher"" />",
                         html.ToHtmlString());
        }

        [Fact]
        public void HiddenForUsesDictionarySpecifiedHtmlAttributes()
        {
            // Arrange
            var dictionaryModel = CreateDictionaryModel();
            var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

            // Act
            var html = htmlHelper.HiddenFor(m => m.Dict, new Dictionary<string, object> { { "disabled", "disabled" } });

            // Assert
            Assert.Equal(@"<input disabled=""disabled"" id=""Dict"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[0].Value"" type=""hidden"" value=""1"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                         @"<input disabled=""disabled"" id=""Dict"" name=""Dict[2].Value"" type=""hidden"" value=""David Fincher"" />", 
                         html.ToHtmlString());
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