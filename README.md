# ASP.NET MVC serialization

[![Build status](https://ci.appveyor.com/api/projects/status/d1e0slk8udkym49k)](https://ci.appveyor.com/project/ErikSchierboom/aspnetmvcdictionaryserialization)

## Introduction

Serializing and de-serializing collection types like `IDictionary<TIn,TOut>`, `IEnumerable<TIn>`, `ICollection<TIn>`, `IList<TIn>` instances in ASP.NET MVC is not supported by default. This library adds overloads to the `HtmlHelper` class that know how to serialize these collection types. To use them, all you need to do is install this library and add the `AspNetMvcSerialization` namespace to your view.

## IDictionary
        
The correct format in which a dictionary needs to be serialized is very specific. Say we have the following dictionary:

```c#
var dict = new Dictionary<string, string>
               {
                   { "Id", "1" },
                   { "Title", "Se7en" },
                   { "Director", "David Fincher" },
               };
```

If want the model binder to be able to deserialize this dictionary after being posted from a form, we need to input the following fields in the form:

```html
<input type="text" name="dict[0].Key" value="Id" />
<input type="text" name="dict[0].Value" value="1" />
<input type="text" name="dict[1].Key" value="Title" />
<input type="text" name="dict[1].Value" value="Se7en" />
<input type="text" name="dict[2].Key" value="Director" />
<input type="text" name="dict[2].Value" value="David Fincher" />
```

One can clear see that each element in the dictionary has two input fields: one for the key and one for the value. If we include the above HTML in our form, the default model binder will be able to correctly deserialize it in an action method:

```c#
[HttpPost]
public ActionResult HandlePost(Dictionary<string, string> dict)
{
    // dict will have the correct information here
}
```

## Usage 
Using the extensions is simple as they follow the regular usage pattern of the ASP.NET MVC HTML helpers. First you need to make sure your template has included the namespace in which the extension methods are located (which is `AspNetMvcSerialization`). Then you can simply use any of the `Editor`/`EditorFor`/`Hidden`/`HiddenFor` overloads.

```html
@Html.Editor("dict", dict)
```
    
This will output the following HTML (assuming the `dict` variable has the values we defined earlier):

```html
<input type="text" name="dict[0].Key" value="Id" />
<input type="text" name="dict[0].Value" value="1" />
<input type="text" name="dict[1].Key" value="Title" />
<input type="text" name="dict[1].Value" value="Se7en" />
<input type="text" name="dict[2].Key" value="Director" />
<input type="text" name="dict[2].Value" value="David Fincher" />
```

To serialize the dictionary to hidden fields, just do:

```html
@Html.Hidden("dict", dict)
```

This will output the following HTML (assuming the `dict` variable has the values we defined earlier):

```html
<input type="hidden" name="dict[0].Key" value="Id" />
<input type="hidden" name="dict[0].Value" value="1" />
<input type="hidden" name="dict[1].Key" value="Title" />
<input type="hidden" name="dict[1].Value" value="Se7en" />
<input type="hidden" name="dict[2].Key" value="Director" />
<input type="hidden" name="dict[2].Value" value="David Fincher" />
```
        
## IEnumerable, ICollection and IList
        
The `IEnumerable<T>`, `ICollection<T>` and `IList<T>` types all use the same serialization format, which is also quite straightforward. Say we have the following list:

```c#
var list = new List<string>
      {
         "Lakers", 
         "Celtics",
         "Bulls"
      };
```

If want the model binder to be able to deserialize this dictionary after being posted from a form, we need to input the following fields in the form:

```html
<input type="text" name="list[0]" value="Lakers" />
<input type="text" name="list[1]" value="Celtics" />
<input type="text" name="list[2]" value="Bulls" />
```

One can clear see that each element in the dictionary has one input fields, which is the name of the field and the element's index. If we include the above HTML in our form, the default model binder will be able to correctly deserialize it in an action method:

```c#
[HttpPost]
public ActionResult HandlePost(List<string> list)
{
    // list will have the correct information here
}
```

## Usage 
To correctly serialize these collection tis simple as they follow the regular usage pattern of the ASP.NET MVC HTML helpers. First you need to make sure your template has included the namespace in which the extension methods are located (which is `AspNetMvcSerialization`). Then you can simply use any of the `Editor`/`EditorFor`/`Hidden`/`HiddenFor` overloads.

```html
@Html.Editor("list", list)
```
    
This will output the following HTML (assuming the `list` variable has the values we defined earlier):

```html
<input type="text" name="list[0]" value="Lakers" />
<input type="text" name="list[1]" value="Celtics" />
<input type="text" name="list[2]" value="Bulls" />
```

To serialize the list as an hidden field, just do:

```html
@Html.Hidden("list", list)
```

This will output the following HTML (assuming the `list` variable has the values we defined earlier):

```html
<input type="hidden" name="list[0]" value="Lakers" />
<input type="hidden" name="list[1]" value="Celtics" />
<input type="hidden" name="list[2]" value="Bulls" />
```

Note that `IEnumerable<T>` and `ICollection<T>` instances are serialized in exactly the same way as lists.

### Complex types

Although our previous examples only used simple types, you can also serialize complex types. Say that we have the following list of complex types:

```c#
var persons = new List<Person>
      {
         new Person { Name = "Magic Johnson", Age = 55 },
         new Person { Name = "Larry Bird", Age = 58 },
         new Person { Name = "Michael Jordan", Age = 52 }
      };
```

If we use `@Html.Editor("persons", persons)`, the following HTML is generated:

```html
<input id="persons_0_Name" name="persons[0].Name" type="text" value="Magic Johnson" />
<input id="persons_0_Age" name="persons[0].Age" type="text" value="55" />
<input id="persons_1_Name" name="persons[1].Name" type="text" value="Larry Bird" />
<input id="persons_1_Age" name="persons[1].Age" type="text" value="58" />
<input id="persons_2_Name" name="persons[2].Name" type="text" value="Michael Jordan" />
<input id="persons_2_Age" name="persons[2].Age" type="text" value="52" />
```

If these input fields are submitted, the list will be correctly de-serialized.

## Get it on NuGet!
The library is available on NuGet package available. You can install it using the following command:

    Install-Package MvcSerialization

Note: remember that you need to include the `AspNetMvcSerialization` namespace in your views for the custom serialization code to be used.

## License
[Apache License 2.0](LICENSE.md)
