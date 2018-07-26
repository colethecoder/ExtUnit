# ExtUnit

A tiny library that provides some helpful extensions when using [XUnit](https://github.com/xunit/xunit) with [LanguageExt](https://github.com/louthy/language-ext).

## Installation

ExtUnit is available on Nuget. To setup a new test project you should install xunit.core, languageext.core and extunit.

```
PM> Install-Package xunit.core
PM> Install-Package languageext.core
PM> Install-Package extunit
```

Note: ExtUnit extends xunit.asserts so you need to use xunit.core and not the main xunit package (which would include xunit.asserts).

## Example

Without ExtUnit if you wanted to use an `Option<string>` in an Assert you might do:

```cs
var op = Optional("test"); // Create Option<string> in Some state

op.Match(
    Some: x => Assert.Equal("test", x),
    None: () => Assert.Fail("Should never get here!")
);

```

With ExtUnit you can simply do:

```cs
var op = Optional("test"); // Create Option<string> in Some state

Assert.Some("test", op);

```



