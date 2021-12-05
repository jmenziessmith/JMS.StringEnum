# JMS.StringEnum
DotNet package to manage enum-like string constants. 

Allows a defined set of enum values to be defined and verified, but also supports parsing of undefined string values without thorwing exceptions. Handy for avoiding JSON serialization errors typically experienced when using enums in service contracts.


## Creating a StringEnum

```csharp
public class MyEnum : StringEnum<MyEnum>
{
    public const string Foo = "Foo";
    public const string Bar = "Bar";

    public MyEnum(string value)
     : base(value)
    {
    }

    public static implicit operator MyEnum(string val) => new MyEnum(val);
}

```

### Referencing enum values
```csharp
var foo = MyEnum.Foo; // note foo = string
MyEnum bar = MyEnum.Bar; 
bar.Value // access the underlying string value
```

### Parsing and verifying enum values
```csharp
var foo = "FOO"; // foo = "Foo" (it matched the string constant)
foo.IsKnownValue() // returns true

var another = "ANOTHER" // another = "ANOTHER"
another.IsKnownValue() // returns false

var bar = new MyEnum("Bar");
bar.IsKnownValue() // returns true

MyEnum.IsKnownValue("Something") // allows checking against the list of string constants
```


### Comparison of enum values
```csharp
"Foo" == new MyEnum("Foo") // returns true
new MyEnum("Bar") == "Bar" // returns true

"Foo".Equals(new MyEnum("Foo")) // returns true
new MyEnum("Bar").Equals("Bar") // returns true

```


## Serialization
The `JMS.StringEnum.Serialization.NewtonsoftJson` project provides a Newtonsoft.Json converter that ensures StringEnum<> based types are always serialized as strings, and strings are deserialized to the StringEnum.

```csharp
var jsonSettings = new JsonSerializerSettings().ConfigureStringEnum();

```



## Swagger / OpenApi
The `JMS.StringEnum.OpenApi.Swashbuckle` project provides a SchemaFilter to override the schema generation for the StringEnum type, so that it is treated as an enum type. The schema will define all StringEnums as strings and generate the enum list of known values.

```csharp
services.AddSwaggerGen(o =>
{
    o.UseStringEnum(); // o.SchemaFilter<StringEnumSchemaFilter>();
});
```