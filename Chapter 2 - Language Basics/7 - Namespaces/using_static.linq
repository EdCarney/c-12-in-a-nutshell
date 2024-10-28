<Query Kind="Statements" />


// USING STATIC directive imports a type, instead of a namespace; all static members of the
// type are then available to use without qualification

// all accessible static members of the type will be imported (fields, properties, and nested
// types)

using static System.Console;
using static System.Windows.Visibility;

WriteLine("unqualified writeline");

var textVis = Hidden;