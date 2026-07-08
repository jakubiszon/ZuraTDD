# ZuraTDD
This project is a testing library for .NET

It is packaged and distributed as ZuraTDD nuget package.

Please refer to the [Readme](./README.md) in the root of the project for more details.

Project structure:
- `ZuraTDD`: The top directory and namespace should only contain classes directly used by the users to mark code to generate.
- `ZuraTDD/BuildingBlocks`: parts of the code used by the generated code but not intended for direct use.
- `ZuraTDD/Exceptions`: runtime exceptions used by the generated code.
- `ZuraTDD/Generator`: classes used to output auto-generated *TestCase* and *Mock* code.
- `ZuraTDD/Generator/DataModel`: classes used internally by the generator to represent parts of the compiled code.
- `ZuraTDD/TestGenerator`: classes used to output auto-generated test code for specific testing frameworks.
