<Query Kind="Statements" />


// from c#10, you can specify GLOBAL USING DIRECTIVES by prefixing the directive with
// the global keyword

global using System;
global using System.Collections.Generic;

// these directives must precede non-global directives and can't be within a namespace;
// they can be used with 'using static'

// from .NET 6 on, project files allow for implicit global usings; if ImplicitUsings element
// is set to true in the file (the default), then several common namespaces are auto-imported