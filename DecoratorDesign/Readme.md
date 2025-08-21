When we have simple/base object and want to add functionality or behavioir above it then it is used.
Let's suppose we have coffee as base class
If we have to add sugar milk and may more thing so using different combinations we have to make
child class for deciding price for each combination which exploits the number of child classes

To avoid above problem we have to add decorator for each functionality that we want to add here
Like milk and sugar etc. and use wrapper around object to make final product

Virtual Keyword
The virtual keyword in C# is used in a base class to indicate that a method, property, indexer, or event can be overridden in a derived class.

virtual keyword must be used in runtime polymorphism to happen
otherwise by default c# compile uses reference type for method calling
