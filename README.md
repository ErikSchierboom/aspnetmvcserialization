# ASP.NET MVC IDictionary&lt;string,string&gt; serialization

[![Build status](https://ci.appveyor.com/api/projects/status/d1e0slk8udkym49k)](https://ci.appveyor.com/project/ErikSchierboom/aspnetmvcdictionaryserialization)

## Introduction

Serializing and de-serializing an `IDictionary<string,string>` instance in ASP.NET MVC is not supported by default. The correct format in which a dictionary needs to be serialized is very specific. Say we have the following dictionary:

```c#
var dict = new Dictionary<string, string>
               {
                   { "Id", "1" },
                   { "Title", "Se7en" },
                   { "Director", "David Fincher" },
               };
```

If want the model minder to be able to deserialize this dictionary after being posted from a form, we need to input the following fields in the form:

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

## Implementation

This project adds extensions to the `HtmlHelper` class that allows `IDictionary<string,string>` instances to be correctly serialized. The extension methods are defined in the [HtmlHelperExtensions class](AspNetMvcDictionarySerialization/Models/HtmlHelperExtensions.cs). The methods defined all work on `IDictionary<string,string>` instances and contain all the overloads the default `HtmlHelper` also defines. 

The functionality is implemented by simply iterating over all elements in the dictionary and outputting one input field for the key of each item and one input field for the value of the item.

## Usage 
Using the extensions is simple as they follow the regular usage pattern of the ASP.NET MVC HTML helpers. First you need to make sure your template has included the namespace in which the extension methods are located (which is `AspNetMvcDictionarySerialization`). Then you can simply use any of the `Editor`/`EditorFor`/`Hidden`/`HiddenFor` overloads.

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

## Get it on NuGet!
The library is available on NuGet package available. You can install it using the following command:

    Install-Package MvcDictionarySerialization

Note: remember that you need to include the `AspNetMvcDictionarySerialization` namespace in your views for the custom serialization code to be used.

## License
[Apache License 2.0](LICENSE.md)
