# PrimeTable
Calculation of multiplication of the N prime numbers in a
table output.

## Solution
This is a Visual Studio 2015 Solution. The solution contains
three projects:
 
- **PrimeTable.CLI**: The Command Line Interface application.
This project is the StartUp project. When run, it opens a
console application that displays the multiplication table
of the 10 first numbers in a text-based format.

- **PrimeTable.Lib**: The business objects and interfaces.
This project contains the generators and validators of prime
number arrays and multiplication tables.

- **PrimeTable.Tests**: The unit tests for the other two
projects. The unit tests are written with the [nunit.org](NUnit)
framework.

## How to run it
1. Open the Solution in Visual Studio 2015.
 - Note that the application is written using C# 6.0 language
features. Visual Studio 2015 ships with a compiler that can
make use of these features. Earlier versions of the compiler may
throw exceptions.
2. Make sure that the **PrimeTable.CLI** project is marked as
the "StartUp Project".
3. In the *Properties* editor, in the *Debug* section, set the
*Command Line Arguments* value to an **integer between 1 and 10**.
The default value is 10.
 - The application only generates tables for the first 10 prime
numbers as per the specification. It can be modified to print
larger tables if needed, but they won't look good in a console
application.
4. Press the *Start* button in Visual Studio. The application
will run in a console, print the appropriate table, and wait for
input. Any input will close the application.

You may also compile the application and run the generated
executable directly, passing an integer between 1 and 10 as
a parameter.

### NuGet dependencies
Note the following NuGet package dependencies:

- Moq.4.2.1510.2205
- NUnit.2.6.4

The `packages` folder has been added to GIT for safety, but when
running on Visual Studio, make sure that the option *Allow NuGet to
download missing packages* is enabled.

## What I am pleased with
- **Testability**: Almost every class has been abstracted to an
appropriate interface in order to enhance testability and enable
mocking.
 -  For example, the `Console` is not used directly, but it is
enveloped in an implementation of the `IOutputWriter` interface.
This allows tests to mock the interface and retrieve the output,
therefore allowing for the testability of that output.
- **SOLID**: The application doesn't run directly on the `Program`
class as most small console applications do. Its logic is mostly
transported to the `PrimeNumbersAppController`.
 - Although this is not abstracted, an interface `IAppController`
can easily be extracted and even a base class could be generated.
This would enable the application to be extended with new commands
to generate a more versatile calculator. A factory would have to 
be implemented if that was the case to wire the correct command to
the correct input parameters in the `Program` class.
 - This also enhances testability and scalability, as each 
`IAppController` could be tested independently.
- **Test cases**: Instead of creating a new unit test for every
different scenario in each tested method, where possible, the
`TestCaseAttribute` has been used. In NUnit this allows for a single
implementation of the test (with parameters and/or return value) to
test several scenarios (like edge scenarios, or situations where an
exception is expected).
 - Extending these test cases is simple, as it only involves adding a
new `TestCaseAttribute` with the new parameters and expected
behavior. This makes it easier (and cheaper in time-effort) to
enhance already existing functionality in the future when the system
needs to be extended.
- **Elastic output**: Notice that squares in the array printed are
calculated to have the same width. It is not just printing what is
in the result, but it is aligned to the right too. That's just
to present the information in a readable, user-friendly manner.
 - To see the difference, run the application with parameters `3`,
`4`, and `10`. Notice how when the numbers in the array are
single-digit, the cells' width is smaller than when the numbers
have two or three digits. Note also that in these cases, all numbers
are aligned to the right.
- **Error messaging**: If you try to run the application with a bad
input, the application will run but show error messages in red. The
messages are humanly readable so that the user can know what is wrong
with the input.
- **Yield enumeration**: Note the use of the `yield` C# keyword in
the `PrimeNumberGenerator.Generate` method. This was added as a late
revision on the code, to improve the performance for the generation
of very large arrays of prime numbers. With this, only the requested
elements in the enumerable will be generated, saving execution time
when the number of elements is very large.

## What I would do if I had more time
- **Edge cases**: One of my last additions to the code was to
improve the enumeration of prime numbers with a `yield` keyword to
improve performance of generations of very large arrays. I would
like to investigate more on caching the numbers so that multiple
generations in the same thread (for example) would only compute once.

- **Web interface**: I would have liked to provide a web interface
too, and consume the array via asynchronous JavaScript through an API.

- **More generalization**: The `IPrimeNumberGenerator` and
`IPrimeTableGenerator` interfaces have a similar method `Generate`.
There is a possible generalization there for an `IGenerator{TIn, TOut}`
interface and possible base classes. This would allow for a generator
of other than prime numbers (say "Fibonacci", "Triangular", "Even",
"Odd" or the simplest "Natural" number generators).
 - The same goes for the `PrimeNumbersAppController`. An
`IAppController` can be extracted and a base class generated. Then
an `AppControllerFactory` could bring up and execute the correct
implementation for the commands in the input and have several
tools in the same application.
 - Another generalization can be done in the operation that the
`PrimeTableGenerator` uses. If a more generic `TableGenerator` is
created instead, it can be injected an operation to perform with
the operands of the table (say "Multiply", "Add", "Subtract",
"Divide", "Power", etc.).

- **Dependency Injection (IoC)**: The classes in the application
already have the constructors ready for dependency injection. A
framework for DI can be used here, particularly if the
`AppControllerFactory` is created, to reduce coupling. 