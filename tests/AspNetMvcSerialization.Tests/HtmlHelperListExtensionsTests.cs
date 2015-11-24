namespace AspNetMvcSerialization.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class HtmlHelperListExtensionsTests
    {
        public class UsingListOfSimplyType
        {
            [Fact]
            public void EditorReturnsCorrectFormatForList()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.Editor("List", list);

                // Assert
                Assert.Equal(@"<input id=""List_0"" name=""List"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""List_1"" name=""List"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""List_2"" name=""List"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorReturnsCorrectFormatForComplexTypeList()
            {
                // Arrange
                var list = CreateComplexTypeList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.Editor("List", list);

                // Assert
                Assert.Equal(@"<input id=""List_0_Name"" name=""List[0].Name"" type=""text"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""List_0_Age"" name=""List[0].Age"" type=""text"" value=""55"" />" + "\n" +
                             @"<input id=""List_1_Name"" name=""List[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""List_1_Age"" name=""List[1].Age"" type=""text"" value=""58"" />" + "\n" +
                             @"<input id=""List_2_Name"" name=""List[2].Name"" type=""text"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""List_2_Age"" name=""List[2].Age"" type=""text"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorUsesHtmlAttributesObject()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.Editor("List", list, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""List_0"" name=""List"" readonly=""readonly"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""List_1"" name=""List"" readonly=""readonly"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""List_2"" name=""List"" readonly=""readonly"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorUsesHtmlAttributesDictionary()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.Editor("List", list, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""List_0"" name=""List"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""List_1"" name=""List"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""List_2"" name=""List"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForReturnsCorrectFormatForList()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.List);

                // Assert
                Assert.Equal(@"<input id=""List_0"" name=""List"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""List_1"" name=""List"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""List_2"" name=""List"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForReturnsCorrectFormatForComplexTypeList()
            {
                // Arrange
                var listModel = CreateComplexTypeListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.List);

                // Assert
                Assert.Equal(@"<input id=""List_0_Name"" name=""List[0].Name"" type=""text"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""List_0_Age"" name=""List[0].Age"" type=""text"" value=""55"" />" + "\n" +
                             @"<input id=""List_1_Name"" name=""List[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""List_1_Age"" name=""List[1].Age"" type=""text"" value=""58"" />" + "\n" +
                             @"<input id=""List_2_Name"" name=""List[2].Name"" type=""text"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""List_2_Age"" name=""List[2].Age"" type=""text"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForUsesHtmlAttributesObject()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.List, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""List_0"" name=""List"" readonly=""readonly"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""List_1"" name=""List"" readonly=""readonly"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""List_2"" name=""List"" readonly=""readonly"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForUsesHtmlAttributesDictionary()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.List, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""List_0"" name=""List"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""List_1"" name=""List"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""List_2"" name=""List"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenReturnsCorrectFormatForList()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.Hidden("List", list);

                // Assert
                Assert.Equal(@"<input id=""List_0"" name=""List"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""List_1"" name=""List"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""List_2"" name=""List"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenReturnsCorrectFormatForComplexTypeList()
            {
                // Arrange
                var list = CreateComplexTypeList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.Hidden("List", list);

                // Assert
                Assert.Equal(@"<input id=""List_0_Name"" name=""List[0].Name"" type=""hidden"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""List_0_Age"" name=""List[0].Age"" type=""hidden"" value=""55"" />" + "\n" +
                             @"<input id=""List_1_Name"" name=""List[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""List_1_Age"" name=""List[1].Age"" type=""hidden"" value=""58"" />" + "\n" +
                             @"<input id=""List_2_Name"" name=""List[2].Name"" type=""hidden"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""List_2_Age"" name=""List[2].Age"" type=""hidden"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenUsesHtmlAttributesObject()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.Hidden("List", list, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""List_0"" name=""List"" readonly=""readonly"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""List_1"" name=""List"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""List_2"" name=""List"" readonly=""readonly"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenUsesHtmlAttributesDictionary()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.Hidden("List", list, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""List_0"" name=""List"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""List_1"" name=""List"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""List_2"" name=""List"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForReturnsCorrectFormatForList()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.List);

                // Assert
                Assert.Equal(@"<input id=""List_0"" name=""List"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""List_1"" name=""List"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""List_2"" name=""List"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForReturnsCorrectFormatForComplexTypeList()
            {
                // Arrange
                var listModel = CreateComplexTypeListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.List);

                // Assert
                Assert.Equal(@"<input id=""List_0_Name"" name=""List[0].Name"" type=""hidden"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""List_0_Age"" name=""List[0].Age"" type=""hidden"" value=""55"" />" + "\n" +
                             @"<input id=""List_1_Name"" name=""List[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""List_1_Age"" name=""List[1].Age"" type=""hidden"" value=""58"" />" + "\n" +
                             @"<input id=""List_2_Name"" name=""List[2].Name"" type=""hidden"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""List_2_Age"" name=""List[2].Age"" type=""hidden"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForUsesHtmlAttributesObject()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.List, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""List_0"" name=""List"" readonly=""readonly"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""List_1"" name=""List"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""List_2"" name=""List"" readonly=""readonly"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForUsesHtmlAttributesDictionary()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.List, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""List_0"" name=""List"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""List_1"" name=""List"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""List_2"" name=""List"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }
        }

        public class UsingListElement
        {
            [Fact]
            public void EditorIndexedReturnsCorrectFormatForListElement()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.EditorIndexed("List", list.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""List_1"" name=""List"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedReturnsCorrectFormatForComplexTypeListElement()
            {
                // Arrange
                var list = CreateComplexTypeList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.EditorIndexed("List", list.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""List_1_Name"" name=""List[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""List_1_Age"" name=""List[1].Age"" type=""text"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.EditorIndexed("List", list.ElementAt(1), 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""List_1"" name=""List"" readonly=""readonly"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.EditorIndexed("List", list.ElementAt(1), 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""List_1"" name=""List"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedReturnsCorrectFormatForListElement()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.List, 1);

                // Assert
                Assert.Equal(@"<input id=""List_1"" name=""List"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedReturnsCorrectFormatForComplexTypeListElement()
            {
                // Arrange
                var listModel = CreateComplexTypeListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.List, 1);

                // Assert
                Assert.Equal(@"<input id=""List_1_Name"" name=""List[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""List_1_Age"" name=""List[1].Age"" type=""text"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.List, 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""List_1"" name=""List"" readonly=""readonly"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.List, 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""List_1"" name=""List"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedReturnsCorrectFormatForListElement()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.HiddenIndexed("List", list.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""List_1"" name=""List"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedReturnsCorrectFormatForComplexTypeListElement()
            {
                // Arrange
                var list = CreateComplexTypeList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.HiddenIndexed("List", list.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""List_1_Name"" name=""List[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""List_1_Age"" name=""List[1].Age"" type=""hidden"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.HiddenIndexed("List", list.ElementAt(1), 1, (object)new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""List_1"" name=""List"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var list = CreateList();
                var htmlHelper = MvcHelper.GetHtmlHelper(list);

                // Act
                var html = htmlHelper.HiddenIndexed("List", list.ElementAt(1), 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""List_1"" name=""List"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedReturnsCorrectFormatForListElement()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.List, 1);

                // Assert
                Assert.Equal(@"<input id=""List_1"" name=""List"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedReturnsCorrectFormatForComplexTypeListElement()
            {
                // Arrange
                var listModel = CreateComplexTypeListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.List, 1);

                // Assert
                Assert.Equal(@"<input id=""List_1_Name"" name=""List[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""List_1_Age"" name=""List[1].Age"" type=""hidden"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.List, 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""List_1"" name=""List"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var listModel = CreateListModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(listModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.List, 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""List_1"" name=""List"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }
        }

        private static IList<string> CreateList()
        {
            return new List<string> { "Lakers", "Celtics", "Bulls" };
        }

        private static IList<Person> CreateComplexTypeList()
        {
            return new List<Person>
            {
                new Person { Name = "Magic Johnson", Age = 55 },
                new Person { Name = "Larry Bird", Age = 58 },
                new Person { Name = "Michael Jordan", Age = 52 }
            };
        }

        private static ListModel CreateListModel()
        {
            return new ListModel { List = CreateList() };
        }

        private static ComplexTypeListModel CreateComplexTypeListModel()
        {
            return new ComplexTypeListModel { List = CreateComplexTypeList() };
        }

        private class ListModel
        {
            public IList<string> List { get; set; }
        }

        private class ComplexTypeListModel
        {
            public IList<Person> List { get; set; }
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}