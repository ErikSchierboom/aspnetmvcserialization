namespace AspNetMvcSerialization.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class HtmlHelperDictionaryExtensionsTests
    {
        public class UsingDictionary
        {
            [Fact]
            public void EditorReturnsCorrectFormatForDictionary()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.Editor("Dict", inputDictionary);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" type=""text"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" type=""text"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorReturnsCorrectFormatForNonStringDictionary()
            {
                // Arrange
                var inputDictionary = CreateNonStringDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.Editor("Dict", inputDictionary);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""c13d2115-d8d1-4d85-ba66-41d1447f5067"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" type=""text"" value=""3"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""728eef19-e2e6-46f7-853f-526f4bc2a88d"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""11"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""88de3b4f-6e9c-4b4b-a338-3f36b2ddad4a"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" type=""text"" value=""24"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorUsesHtmlAttributesObject()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.Editor("Dict", inputDictionary, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" readonly=""readonly"" type=""text"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" readonly=""readonly"" type=""text"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" readonly=""readonly"" type=""text"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorUsesHtmlAttributesDictionary()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.Editor("Dict", inputDictionary, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_0_Value"" name=""Dict[0].Value"" type=""text"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_2_Value"" name=""Dict[2].Value"" type=""text"" value=""David Fincher"" />",
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
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" type=""text"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" type=""text"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorForReturnsCorrectFormatForNonStringDictionary()
            {
                // Arrange
                var dictionaryModel = CreateNonStringDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Dict);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""c13d2115-d8d1-4d85-ba66-41d1447f5067"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" type=""text"" value=""3"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""728eef19-e2e6-46f7-853f-526f4bc2a88d"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""11"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""88de3b4f-6e9c-4b4b-a338-3f36b2ddad4a"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" type=""text"" value=""24"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorForUsesHtmlAttributesObject()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Dict, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" readonly=""readonly"" type=""text"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" readonly=""readonly"" type=""text"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" readonly=""readonly"" type=""text"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorForUsesHtmlAttributesDictionary()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Dict, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_0_Value"" name=""Dict[0].Value"" type=""text"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_2_Value"" name=""Dict[2].Value"" type=""text"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenReturnsCorrectFormatForDictionary()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.Hidden("Dict", inputDictionary);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" type=""hidden"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" type=""hidden"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenReturnsCorrectFormatForNonStringDictionary()
            {
                // Arrange
                var inputDictionary = CreateNonStringDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.Hidden("Dict", inputDictionary);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""c13d2115-d8d1-4d85-ba66-41d1447f5067"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" type=""hidden"" value=""3"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""728eef19-e2e6-46f7-853f-526f4bc2a88d"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""11"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""88de3b4f-6e9c-4b4b-a338-3f36b2ddad4a"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" type=""hidden"" value=""24"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenUsesHtmlAttributesObject()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.Hidden("Dict", inputDictionary, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" readonly=""readonly"" type=""hidden"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" readonly=""readonly"" type=""hidden"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" readonly=""readonly"" type=""hidden"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenUsesHtmlAttributesDictionary()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.Hidden("Dict", inputDictionary, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_0_Value"" name=""Dict[0].Value"" type=""hidden"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_2_Value"" name=""Dict[2].Value"" type=""hidden"" value=""David Fincher"" />",
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
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" type=""hidden"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" type=""hidden"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenForReturnsCorrectFormatForNonStringDictionary()
            {
                // Arrange
                var dictionaryModel = CreateNonStringDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Dict);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""c13d2115-d8d1-4d85-ba66-41d1447f5067"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" type=""hidden"" value=""3"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""728eef19-e2e6-46f7-853f-526f4bc2a88d"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""11"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""88de3b4f-6e9c-4b4b-a338-3f36b2ddad4a"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" type=""hidden"" value=""24"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenForUsesHtmlAttributesObject()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Dict, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input id=""Dict_0_Value"" name=""Dict[0].Value"" readonly=""readonly"" type=""hidden"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" readonly=""readonly"" type=""hidden"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input id=""Dict_2_Value"" name=""Dict[2].Value"" readonly=""readonly"" type=""hidden"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenForUsesHtmlAttributesDictionary()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Dict, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Key"" name=""Dict[0].Key"" type=""hidden"" value=""Id"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_0_Value"" name=""Dict[0].Value"" type=""hidden"" value=""1"" />" + "\n" +
                             @"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />" + "\n" +
                             @"<input id=""Dict_2_Key"" name=""Dict[2].Key"" type=""hidden"" value=""Director"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_2_Value"" name=""Dict[2].Value"" type=""hidden"" value=""David Fincher"" />",
                             html.ToHtmlString());
            }
        }

        public class UsingKeyValuePairInDictionary
        {
            [Fact]
            public void EditorIndexedReturnsCorrectFormatForKeyValuePair()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.EditorIndexed("Dict", inputDictionary.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedReturnsCorrectFormatForNonStringKeyValuePair()
            {
                // Arrange
                var inputDictionary = CreateNonStringDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.EditorIndexed("Dict", inputDictionary.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""728eef19-e2e6-46f7-853f-526f4bc2a88d"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""11"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.EditorIndexed("Dict", inputDictionary.ElementAt(1), 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" readonly=""readonly"" type=""text"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.EditorIndexed("Dict", inputDictionary.ElementAt(1), 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedReturnsCorrectFormatForKeyValuePair()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Dict, 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedReturnsCorrectFormatForNonStringKeyValuePair()
            {
                // Arrange
                var dictionaryModel = CreateNonStringDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Dict, 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""728eef19-e2e6-46f7-853f-526f4bc2a88d"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""11"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Dict, 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" readonly=""readonly"" type=""text"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Dict, 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1_Value"" name=""Dict[1].Value"" type=""text"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedReturnsCorrectFormatForKeyValuePair()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.HiddenIndexed("Dict", inputDictionary.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedReturnsCorrectFormatForNonStringKeyValuePair()
            {
                // Arrange
                var inputDictionary = CreateNonStringDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.HiddenIndexed("Dict", inputDictionary.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""728eef19-e2e6-46f7-853f-526f4bc2a88d"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""11"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.HiddenIndexed("Dict", inputDictionary.ElementAt(1), 1, (object)new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" readonly=""readonly"" type=""hidden"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var inputDictionary = CreateDictionary();
                var htmlHelper = MvcHelper.GetHtmlHelper(inputDictionary);

                // Act
                var html = htmlHelper.HiddenIndexed("Dict", inputDictionary.ElementAt(1), 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedReturnsCorrectFormatForKeyValuePair()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Dict, 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedReturnsCorrectFormatForNonStringKeyValuePair()
            {
                // Arrange
                var dictionaryModel = CreateNonStringDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Dict, 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""728eef19-e2e6-46f7-853f-526f4bc2a88d"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""11"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Dict, 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input id=""Dict_1_Value"" name=""Dict[1].Value"" readonly=""readonly"" type=""hidden"" value=""Se7en"" />",
                             html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var dictionaryModel = CreateDictionaryModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(dictionaryModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Dict, 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Key"" name=""Dict[1].Key"" type=""hidden"" value=""Title"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1_Value"" name=""Dict[1].Value"" type=""hidden"" value=""Se7en"" />",
                             html.ToHtmlString());
            }
        }

        private static Dictionary<string, string> CreateDictionary()
        {
            return new Dictionary<string, string> { { "Id", "1" }, { "Title", "Se7en" }, { "Director", "David Fincher" } };
        }

        private static Dictionary<Guid, int> CreateNonStringDictionary()
        {
            return new Dictionary<Guid, int>
            {
                { Guid.Parse("c13d2115-d8d1-4d85-ba66-41d1447f5067"), 3 }, 
                { Guid.Parse("728eef19-e2e6-46f7-853f-526f4bc2a88d"), 11 }, 
                { Guid.Parse("88de3b4f-6e9c-4b4b-a338-3f36b2ddad4a"), 24 }
            };
        }

        private static DictionaryModel CreateDictionaryModel()
        {
            return new DictionaryModel { Dict = CreateDictionary() };
        }

        private static NonDictionaryModel CreateNonStringDictionaryModel()
        {
            return new NonDictionaryModel { Dict = CreateNonStringDictionary() };
        }

        private class DictionaryModel
        {
            public Dictionary<string, string> Dict { get; set; }
        }

        private class NonDictionaryModel
        {
            public Dictionary<Guid, int> Dict { get; set; }
        }
    }
}