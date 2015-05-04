namespace AspNetMvcSerialization.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Routing;
    using Xunit;

    public class RouteValueDictionaryExtensionsTests
    {
        [Fact]
        public void ToExtendedRouteValueDictionarySerializesPrimitiveTypes()
        {
            // Arrange
            var model = CreateModel();
            var routeValueDictionary = new RouteValueDictionary(model);

            // Act
            var extendedRouteValueDictionary = routeValueDictionary.ToExtendedRouteValueDictionary();

            // Assert
            Assert.Equal(model.Name, extendedRouteValueDictionary["Name"]);
            Assert.Equal(model.Age, extendedRouteValueDictionary["Age"]);
            Assert.Equal(model.Gender, extendedRouteValueDictionary["Gender"]);
        }

        [Fact]
        public void ToExtendedRouteValueDictionarySerializesComplexTypes()
        {
            // Arrange
            var model = CreateModel();
            var routeValueDictionary = new RouteValueDictionary(model);

            // Act
            var extendedRouteValueDictionary = routeValueDictionary.ToExtendedRouteValueDictionary();

            // Assert
            Assert.Equal(model.FirstChild.Name, extendedRouteValueDictionary["FirstChild.Name"]);
            Assert.Equal(model.FirstChild.Age, extendedRouteValueDictionary["FirstChild.Age"]);
            Assert.Equal(model.FirstChild.Gender, extendedRouteValueDictionary["FirstChild.Gender"]);
        }

        [Fact]
        public void ToExtendedRouteValueDictionarySerializesNestedComplexTypes()
        {
            // Arrange
            var model = CreateModel();
            var routeValueDictionary = new RouteValueDictionary(model);

            // Act
            var extendedRouteValueDictionary = routeValueDictionary.ToExtendedRouteValueDictionary();

            // Assert
            Assert.Equal(model.FirstChild.FirstChild.Name, extendedRouteValueDictionary["FirstChild.FirstChild.Name"]);
            Assert.Equal(model.FirstChild.FirstChild.Age, extendedRouteValueDictionary["FirstChild.FirstChild.Age"]);
            Assert.Equal(model.FirstChild.FirstChild.Gender, extendedRouteValueDictionary["FirstChild.FirstChild.Gender"]);

            Assert.Equal(model.FirstChild.FirstChild.FirstChild.Name, extendedRouteValueDictionary["FirstChild.FirstChild.FirstChild.Name"]);
            Assert.Equal(model.FirstChild.FirstChild.FirstChild.Age, extendedRouteValueDictionary["FirstChild.FirstChild.FirstChild.Age"]);
            Assert.Equal(model.FirstChild.FirstChild.FirstChild.Gender, extendedRouteValueDictionary["FirstChild.FirstChild.FirstChild.Gender"]);
        }

        [Fact]
        public void ToExtendedRouteValueDictionarySerializesEnumerableOfPrimitiveType()
        {
            // Arrange
            var model = CreateModel();
            var routeValueDictionary = new RouteValueDictionary(model);

            // Act
            var extendedRouteValueDictionary = routeValueDictionary.ToExtendedRouteValueDictionary();

            // Assert
            Assert.Equal(model.ChildAges[0], extendedRouteValueDictionary["ChildAges[0]"]);
            Assert.Equal(model.ChildAges[1], extendedRouteValueDictionary["ChildAges[1]"]);

            Assert.False(extendedRouteValueDictionary.ContainsKey("ChildAges[2]"));
        }

        [Fact]
        public void ToExtendedRouteValueDictionarySerializesEnumerableOfComplexType()
        {
            // Arrange
            var model = CreateModel();
            var routeValueDictionary = new RouteValueDictionary(model);

            // Act
            var extendedRouteValueDictionary = routeValueDictionary.ToExtendedRouteValueDictionary();

            // Assert
            Assert.Equal(model.Children[0].Name, extendedRouteValueDictionary["Children[0].Name"]);
            Assert.Equal(model.Children[0].Age, extendedRouteValueDictionary["Children[0].Age"]);
            Assert.Equal(model.Children[1].Name, extendedRouteValueDictionary["Children[1].Name"]);
            Assert.Equal(model.Children[1].Age, extendedRouteValueDictionary["Children[1].Age"]);

            Assert.False(extendedRouteValueDictionary.ContainsKey("Children[2].Name"));
            Assert.False(extendedRouteValueDictionary.ContainsKey("Children[2].Age"));
        }

        [Fact]
        public void ToExtendedRouteValueDictionarySerializesDictionary()
        {
            // Arrange
            var model = CreateModel();
            var routeValueDictionary = new RouteValueDictionary(model);

            // Act
            var extendedRouteValueDictionary = routeValueDictionary.ToExtendedRouteValueDictionary();

            // Assert
            Assert.Equal(model.ChildNameAndAge.Keys.ElementAt(0), extendedRouteValueDictionary["ChildNameAndAge[0].Key"]);
            Assert.Equal(model.ChildNameAndAge.Values.ElementAt(0), extendedRouteValueDictionary["ChildNameAndAge[0].Value"]);

            Assert.Equal(model.ChildNameAndAge.Keys.ElementAt(1), extendedRouteValueDictionary["ChildNameAndAge[1].Key"]);
            Assert.Equal(model.ChildNameAndAge.Values.ElementAt(1), extendedRouteValueDictionary["ChildNameAndAge[1].Value"]);
        }

        [Fact]
        public void ToExtendedRouteValueDictionaryWithNullRouteValueDictionaryThrowsArgumentNullException()
        {
            // Arrange
            RouteValueDictionary nullRouteValueDictionary = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => nullRouteValueDictionary.ToExtendedRouteValueDictionary());
        }

        private static Person CreateModel()
        {
            return new Person
            {
                Name = "John",
                Age = 81,
                Gender = Gender.Male,
                Children = new[]
                {
                    new Person
                    {
                        Name = "Jane",
                        Age = 52,
                        Gender = Gender.Female,
                        Children = new []
                        {
                            new Person
                            {
                                Name = "Peter",
                                Age = 27,
                                Gender = Gender.Female,
                                Children = new []
                                {
                                    new Person
                                    {
                                        Name = "Laura",
                                        Age = 3,
                                        Gender = Gender.Female
                                    }
                                }
                            }
                        }
                    },
                    
                    new Person
                    {
                        Name = "Mark",
                        Age = 55,
                        Gender = Gender.Male
                    }
                },

            };
        }

        private enum Gender
        {
            Male,
            Female
        }

        private class Person
        {
            public Person()
            {
                this.Children = new List<Person>();
            }

            public string Name { get; set; }
            public int Age { get; set; }
            public Gender Gender { get; set; }
            public IList<Person> Children { get; set; }
            
            public Person FirstChild { get { return this.Children.FirstOrDefault(); } }
            public IList<int> ChildAges { get { return this.Children.Select(c => c.Age).ToList(); } } 
            public IDictionary<string, int> ChildNameAndAge { get { return this.Children.ToDictionary(c => c.Name, c => c.Age); } }
        }
    }
}