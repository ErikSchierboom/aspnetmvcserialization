namespace AspNetMvcSerialization.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class HtmlHelperEnumerableExtensionsTests
    {
        public class UsingEnumerableOfSimplyType
        {
            [Fact]
            public void EditorReturnsCorrectFormatForEnumerable()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.Editor("Dict", enumerable);

                // Assert
                Assert.Equal(@"<input id=""Dict_0"" name=""Dict[0]"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Dict_1"" name=""Dict[1]"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Dict_2"" name=""Dict[2]"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorReturnsCorrectFormatForComplexTypeEnumerable()
            {
                // Arrange
                var enumerable = CreateComplexTypeEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.Editor("Dict", enumerable);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Name"" name=""Dict[0].Name"" type=""text"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""Dict_0_Age"" name=""Dict[0].Age"" type=""text"" value=""55"" />" + "\n" +
                             @"<input id=""Dict_1_Name"" name=""Dict[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Dict_1_Age"" name=""Dict[1].Age"" type=""text"" value=""58"" />" + "\n" +
                             @"<input id=""Dict_2_Name"" name=""Dict[2].Name"" type=""text"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""Dict_2_Age"" name=""Dict[2].Age"" type=""text"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorUsesHtmlAttributesObject()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.Editor("Dict", enumerable, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_0"" name=""Dict[0]"" readonly=""readonly"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Dict_1"" name=""Dict[1]"" readonly=""readonly"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Dict_2"" name=""Dict[2]"" readonly=""readonly"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorUsesHtmlAttributesDictionary()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.Editor("Dict", enumerable, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Dict_0"" name=""Dict[0]"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1"" name=""Dict[1]"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_2"" name=""Dict[2]"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForReturnsCorrectFormatForEnumerable()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Dict);

                // Assert
                Assert.Equal(@"<input id=""Dict_0"" name=""Dict[0]"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Dict_1"" name=""Dict[1]"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Dict_2"" name=""Dict[2]"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForReturnsCorrectFormatForComplexTypeEnumerable()
            {
                // Arrange
                var enumerableModel = CreateComplexTypeEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Dict);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Name"" name=""Dict[0].Name"" type=""text"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""Dict_0_Age"" name=""Dict[0].Age"" type=""text"" value=""55"" />" + "\n" +
                             @"<input id=""Dict_1_Name"" name=""Dict[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Dict_1_Age"" name=""Dict[1].Age"" type=""text"" value=""58"" />" + "\n" +
                             @"<input id=""Dict_2_Name"" name=""Dict[2].Name"" type=""text"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""Dict_2_Age"" name=""Dict[2].Age"" type=""text"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForUsesHtmlAttributesObject()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Dict, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_0"" name=""Dict[0]"" readonly=""readonly"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Dict_1"" name=""Dict[1]"" readonly=""readonly"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Dict_2"" name=""Dict[2]"" readonly=""readonly"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForUsesHtmlAttributesDictionary()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Dict, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Dict_0"" name=""Dict[0]"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1"" name=""Dict[1]"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_2"" name=""Dict[2]"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenReturnsCorrectFormatForEnumerable()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.Hidden("Dict", enumerable);

                // Assert
                Assert.Equal(@"<input id=""Dict_0"" name=""Dict[0]"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Dict_1"" name=""Dict[1]"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Dict_2"" name=""Dict[2]"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenReturnsCorrectFormatForComplexTypeEnumerable()
            {
                // Arrange
                var enumerable = CreateComplexTypeEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.Hidden("Dict", enumerable);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Name"" name=""Dict[0].Name"" type=""hidden"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""Dict_0_Age"" name=""Dict[0].Age"" type=""hidden"" value=""55"" />" + "\n" +
                             @"<input id=""Dict_1_Name"" name=""Dict[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Dict_1_Age"" name=""Dict[1].Age"" type=""hidden"" value=""58"" />" + "\n" +
                             @"<input id=""Dict_2_Name"" name=""Dict[2].Name"" type=""hidden"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""Dict_2_Age"" name=""Dict[2].Age"" type=""hidden"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenUsesHtmlAttributesObject()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.Hidden("Dict", enumerable, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_0"" name=""Dict[0]"" readonly=""readonly"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Dict_1"" name=""Dict[1]"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Dict_2"" name=""Dict[2]"" readonly=""readonly"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenUsesHtmlAttributesDictionary()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.Hidden("Dict", enumerable, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Dict_0"" name=""Dict[0]"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1"" name=""Dict[1]"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_2"" name=""Dict[2]"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForReturnsCorrectFormatForEnumerable()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Dict);

                // Assert
                Assert.Equal(@"<input id=""Dict_0"" name=""Dict[0]"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Dict_1"" name=""Dict[1]"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Dict_2"" name=""Dict[2]"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForReturnsCorrectFormatForComplexTypeEnumerable()
            {
                // Arrange
                var enumerableModel = CreateComplexTypeEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Dict);

                // Assert
                Assert.Equal(@"<input id=""Dict_0_Name"" name=""Dict[0].Name"" type=""hidden"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""Dict_0_Age"" name=""Dict[0].Age"" type=""hidden"" value=""55"" />" + "\n" +
                             @"<input id=""Dict_1_Name"" name=""Dict[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Dict_1_Age"" name=""Dict[1].Age"" type=""hidden"" value=""58"" />" + "\n" +
                             @"<input id=""Dict_2_Name"" name=""Dict[2].Name"" type=""hidden"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""Dict_2_Age"" name=""Dict[2].Age"" type=""hidden"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForUsesHtmlAttributesObject()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Dict, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_0"" name=""Dict[0]"" readonly=""readonly"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Dict_1"" name=""Dict[1]"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Dict_2"" name=""Dict[2]"" readonly=""readonly"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForUsesHtmlAttributesDictionary()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Dict, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Dict_0"" name=""Dict[0]"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_1"" name=""Dict[1]"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Dict_2"" name=""Dict[2]"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }
        }

        public class UsingEnumerableElement
        {
            [Fact]
            public void EditorIndexedReturnsCorrectFormatForEnumerableElement()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.EditorIndexed("Dict", enumerable.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1"" name=""Dict[1]"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedReturnsCorrectFormatForComplexTypeEnumerableElement()
            {
                // Arrange
                var enumerable = CreateComplexTypeEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.EditorIndexed("Dict", enumerable.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Name"" name=""Dict[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Dict_1_Age"" name=""Dict[1].Age"" type=""text"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.EditorIndexed("Dict", enumerable.ElementAt(1), 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_1"" name=""Dict[1]"" readonly=""readonly"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.EditorIndexed("Dict", enumerable.ElementAt(1), 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Dict_1"" name=""Dict[1]"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedReturnsCorrectFormatForEnumerableElement()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Dict, 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1"" name=""Dict[1]"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedReturnsCorrectFormatForComplexTypeEnumerableElement()
            {
                // Arrange
                var enumerableModel = CreateComplexTypeEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Dict, 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Name"" name=""Dict[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Dict_1_Age"" name=""Dict[1].Age"" type=""text"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Dict, 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_1"" name=""Dict[1]"" readonly=""readonly"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Dict, 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Dict_1"" name=""Dict[1]"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedReturnsCorrectFormatForEnumerableElement()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.HiddenIndexed("Dict", enumerable.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1"" name=""Dict[1]"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedReturnsCorrectFormatForComplexTypeEnumerableElement()
            {
                // Arrange
                var enumerable = CreateComplexTypeEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.HiddenIndexed("Dict", enumerable.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Name"" name=""Dict[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Dict_1_Age"" name=""Dict[1].Age"" type=""hidden"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.HiddenIndexed("Dict", enumerable.ElementAt(1), 1, (object)new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_1"" name=""Dict[1]"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var enumerable = CreateEnumerable();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerable);

                // Act
                var html = htmlHelper.HiddenIndexed("Dict", enumerable.ElementAt(1), 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Dict_1"" name=""Dict[1]"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedReturnsCorrectFormatForEnumerableElement()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Dict, 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1"" name=""Dict[1]"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedReturnsCorrectFormatForComplexTypeEnumerableElement()
            {
                // Arrange
                var enumerableModel = CreateComplexTypeEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Dict, 1);

                // Assert
                Assert.Equal(@"<input id=""Dict_1_Name"" name=""Dict[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Dict_1_Age"" name=""Dict[1].Age"" type=""hidden"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Dict, 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Dict_1"" name=""Dict[1]"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var enumerableModel = CreateEnumerableModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(enumerableModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Dict, 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Dict_1"" name=""Dict[1]"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }
        }

        private static IEnumerable<string> CreateEnumerable()
        {
            return new List<string> { "Lakers", "Celtics", "Bulls" };
        }

        private static IEnumerable<Person> CreateComplexTypeEnumerable()
        {
            return new List<Person> { new Person { Name = "Magic Johnson", Age = 55 }, new Person { Name = "Larry Bird", Age = 58 }, new Person { Name = "Michael Jordan", Age = 52 } };
        }

        private static EnumerableModel CreateEnumerableModel()
        {
            return new EnumerableModel { Dict = CreateEnumerable() };
        }

        private static ComplexTypeEnumerableModel CreateComplexTypeEnumerableModel()
        {
            return new ComplexTypeEnumerableModel { Dict = CreateComplexTypeEnumerable() };
        }

        private class EnumerableModel
        {
            public IEnumerable<string> Dict { get; set; }
        }

        private class ComplexTypeEnumerableModel
        {
            public IEnumerable<Person> Dict { get; set; }
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}