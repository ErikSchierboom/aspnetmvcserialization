namespace AspNetMvcSerialization.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class HtmlHelperCollectionExtensionsTests
    {
        public class UsingCollectionOfSimplyType
        {
            [Fact]
            public void EditorReturnsCorrectFormatForCollection()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.Editor("Collection", collection);

                // Assert
                Assert.Equal(@"<input id=""Collection_0"" name=""Collection"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Collection_1"" name=""Collection"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Collection_2"" name=""Collection"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorReturnsCorrectFormatForComplexTypeCollection()
            {
                // Arrange
                var collection = CreateComplexTypeCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.Editor("Collection", collection);

                // Assert
                Assert.Equal(@"<input id=""Collection_0_Name"" name=""Collection[0].Name"" type=""text"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""Collection_0_Age"" name=""Collection[0].Age"" type=""text"" value=""55"" />" + "\n" +
                             @"<input id=""Collection_1_Name"" name=""Collection[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Collection_1_Age"" name=""Collection[1].Age"" type=""text"" value=""58"" />" + "\n" +
                             @"<input id=""Collection_2_Name"" name=""Collection[2].Name"" type=""text"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""Collection_2_Age"" name=""Collection[2].Age"" type=""text"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorUsesHtmlAttributesObject()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.Editor("Collection", collection, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Collection_0"" name=""Collection"" readonly=""readonly"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Collection_1"" name=""Collection"" readonly=""readonly"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Collection_2"" name=""Collection"" readonly=""readonly"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorUsesHtmlAttributesDictionary()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.Editor("Collection", collection, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Collection_0"" name=""Collection"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Collection_1"" name=""Collection"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Collection_2"" name=""Collection"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForReturnsCorrectFormatForCollection()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Collection);

                // Assert
                Assert.Equal(@"<input id=""Collection_0"" name=""Collection"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Collection_1"" name=""Collection"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Collection_2"" name=""Collection"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForReturnsCorrectFormatForComplexTypeCollection()
            {
                // Arrange
                var collectionModel = CreateComplexTypeCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Collection);

                // Assert
                Assert.Equal(@"<input id=""Collection_0_Name"" name=""Collection[0].Name"" type=""text"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""Collection_0_Age"" name=""Collection[0].Age"" type=""text"" value=""55"" />" + "\n" +
                             @"<input id=""Collection_1_Name"" name=""Collection[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Collection_1_Age"" name=""Collection[1].Age"" type=""text"" value=""58"" />" + "\n" +
                             @"<input id=""Collection_2_Name"" name=""Collection[2].Name"" type=""text"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""Collection_2_Age"" name=""Collection[2].Age"" type=""text"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForUsesHtmlAttributesObject()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Collection, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Collection_0"" name=""Collection"" readonly=""readonly"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Collection_1"" name=""Collection"" readonly=""readonly"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Collection_2"" name=""Collection"" readonly=""readonly"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForUsesHtmlAttributesDictionary()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.EditorFor(m => m.Collection, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Collection_0"" name=""Collection"" type=""text"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Collection_1"" name=""Collection"" type=""text"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Collection_2"" name=""Collection"" type=""text"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenReturnsCorrectFormatForCollection()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.Hidden("Collection", collection);

                // Assert
                Assert.Equal(@"<input id=""Collection_0"" name=""Collection"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Collection_1"" name=""Collection"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Collection_2"" name=""Collection"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenReturnsCorrectFormatForComplexTypeCollection()
            {
                // Arrange
                var collection = CreateComplexTypeCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.Hidden("Collection", collection);

                // Assert
                Assert.Equal(@"<input id=""Collection_0_Name"" name=""Collection[0].Name"" type=""hidden"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""Collection_0_Age"" name=""Collection[0].Age"" type=""hidden"" value=""55"" />" + "\n" +
                             @"<input id=""Collection_1_Name"" name=""Collection[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Collection_1_Age"" name=""Collection[1].Age"" type=""hidden"" value=""58"" />" + "\n" +
                             @"<input id=""Collection_2_Name"" name=""Collection[2].Name"" type=""hidden"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""Collection_2_Age"" name=""Collection[2].Age"" type=""hidden"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenUsesHtmlAttributesObject()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.Hidden("Collection", collection, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Collection_0"" name=""Collection"" readonly=""readonly"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Collection_1"" name=""Collection"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Collection_2"" name=""Collection"" readonly=""readonly"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenUsesHtmlAttributesDictionary()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.Hidden("Collection", collection, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Collection_0"" name=""Collection"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Collection_1"" name=""Collection"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Collection_2"" name=""Collection"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForReturnsCorrectFormatForCollection()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Collection);

                // Assert
                Assert.Equal(@"<input id=""Collection_0"" name=""Collection"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Collection_1"" name=""Collection"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Collection_2"" name=""Collection"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForReturnsCorrectFormatForComplexTypeCollection()
            {
                // Arrange
                var collectionModel = CreateComplexTypeCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Collection);

                // Assert
                Assert.Equal(@"<input id=""Collection_0_Name"" name=""Collection[0].Name"" type=""hidden"" value=""Magic Johnson"" />" + "\n" +
                             @"<input id=""Collection_0_Age"" name=""Collection[0].Age"" type=""hidden"" value=""55"" />" + "\n" +
                             @"<input id=""Collection_1_Name"" name=""Collection[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Collection_1_Age"" name=""Collection[1].Age"" type=""hidden"" value=""58"" />" + "\n" +
                             @"<input id=""Collection_2_Name"" name=""Collection[2].Name"" type=""hidden"" value=""Michael Jordan"" />" + "\n" +
                             @"<input id=""Collection_2_Age"" name=""Collection[2].Age"" type=""hidden"" value=""52"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForUsesHtmlAttributesObject()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Collection, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Collection_0"" name=""Collection"" readonly=""readonly"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input id=""Collection_1"" name=""Collection"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input id=""Collection_2"" name=""Collection"" readonly=""readonly"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForUsesHtmlAttributesDictionary()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.HiddenFor(m => m.Collection, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Collection_0"" name=""Collection"" type=""hidden"" value=""Lakers"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Collection_1"" name=""Collection"" type=""hidden"" value=""Celtics"" />" + "\n" +
                             @"<input disabled=""disabled"" id=""Collection_2"" name=""Collection"" type=""hidden"" value=""Bulls"" />",
                    html.ToHtmlString());
            }
        }

        public class UsingCollectionElement
        {
            [Fact]
            public void EditorIndexedReturnsCorrectFormatForCollectionElement()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.EditorIndexed("Collection", collection.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Collection_1"" name=""Collection"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedReturnsCorrectFormatForComplexTypeCollectionElement()
            {
                // Arrange
                var collection = CreateComplexTypeCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.EditorIndexed("Collection", collection.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Collection_1_Name"" name=""Collection[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Collection_1_Age"" name=""Collection[1].Age"" type=""text"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.EditorIndexed("Collection", collection.ElementAt(1), 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Collection_1"" name=""Collection"" readonly=""readonly"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.EditorIndexed("Collection", collection.ElementAt(1), 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Collection_1"" name=""Collection"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedReturnsCorrectFormatForCollectionElement()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Collection, 1);

                // Assert
                Assert.Equal(@"<input id=""Collection_1"" name=""Collection"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedReturnsCorrectFormatForComplexTypeCollectionElement()
            {
                // Arrange
                var collectionModel = CreateComplexTypeCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Collection, 1);

                // Assert
                Assert.Equal(@"<input id=""Collection_1_Name"" name=""Collection[1].Name"" type=""text"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Collection_1_Age"" name=""Collection[1].Age"" type=""text"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Collection, 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Collection_1"" name=""Collection"" readonly=""readonly"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void EditorForIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.EditorForIndexed(m => m.Collection, 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Collection_1"" name=""Collection"" type=""text"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedReturnsCorrectFormatForCollectionElement()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.HiddenIndexed("Collection", collection.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Collection_1"" name=""Collection"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedReturnsCorrectFormatForComplexTypeCollectionElement()
            {
                // Arrange
                var collection = CreateComplexTypeCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.HiddenIndexed("Collection", collection.ElementAt(1), 1);

                // Assert
                Assert.Equal(@"<input id=""Collection_1_Name"" name=""Collection[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Collection_1_Age"" name=""Collection[1].Age"" type=""hidden"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.HiddenIndexed("Collection", collection.ElementAt(1), 1, (object)new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Collection_1"" name=""Collection"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var collection = CreateCollection();
                var htmlHelper = MvcHelper.GetHtmlHelper(collection);

                // Act
                var html = htmlHelper.HiddenIndexed("Collection", collection.ElementAt(1), 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Collection_1"" name=""Collection"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedReturnsCorrectFormatForCollectionElement()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Collection, 1);

                // Assert
                Assert.Equal(@"<input id=""Collection_1"" name=""Collection"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedReturnsCorrectFormatForComplexTypeCollectionElement()
            {
                // Arrange
                var collectionModel = CreateComplexTypeCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Collection, 1);

                // Assert
                Assert.Equal(@"<input id=""Collection_1_Name"" name=""Collection[1].Name"" type=""hidden"" value=""Larry Bird"" />" + "\n" +
                             @"<input id=""Collection_1_Age"" name=""Collection[1].Age"" type=""hidden"" value=""58"" />",
                    html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedUsesHtmlAttributesObject()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Collection, 1, new { @readonly = "readonly" });

                // Assert
                Assert.Equal(@"<input id=""Collection_1"" name=""Collection"" readonly=""readonly"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }

            [Fact]
            public void HiddenForIndexedUsesHtmlAttributesDictionary()
            {
                // Arrange
                var collectionModel = CreateCollectionModel();
                var htmlHelper = MvcHelper.GetHtmlHelper(collectionModel);

                // Act
                var html = htmlHelper.HiddenForIndexed(m => m.Collection, 1, new Dictionary<string, object> { { "disabled", "disabled" } });

                // Assert
                Assert.Equal(@"<input disabled=""disabled"" id=""Collection_1"" name=""Collection"" type=""hidden"" value=""Celtics"" />", html.ToHtmlString());
            }
        }

        private static ICollection<string> CreateCollection()
        {
            return new List<string> { "Lakers", "Celtics", "Bulls" };
        }

        private static ICollection<Person> CreateComplexTypeCollection()
        {
            return new List<Person> { new Person { Name = "Magic Johnson", Age = 55 }, new Person { Name = "Larry Bird", Age = 58 }, new Person { Name = "Michael Jordan", Age = 52 } };
        }

        private static CollectionModel CreateCollectionModel()
        {
            return new CollectionModel { Collection = CreateCollection() };
        }

        private static ComplexTypeCollectionModel CreateComplexTypeCollectionModel()
        {
            return new ComplexTypeCollectionModel { Collection = CreateComplexTypeCollection() };
        }

        private class CollectionModel
        {
            public ICollection<string> Collection { get; set; }
        }

        private class ComplexTypeCollectionModel
        {
            public ICollection<Person> Collection { get; set; }
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}