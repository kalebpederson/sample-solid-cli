﻿# Introduction

This project is intended to be a demonstration of Uncle Bob's SOLID
principles. As the single responsibility principle (SRP) indicates that
a class's responsibilities are based on the reasons for change the 
approach that this particular project exemplifies may be different than
those others would take.

The domain of this particular application is framework for building
command line applications, not particularly the area chose for this
example, which is that of a version control system command line 
interface.

# Core Areas

The different aspects of the application are each placed into their own
assembly. Each is isolated from the other in one way or another. The
domain, for example, references no non-standard assemblies. As it is the
core domain, it doesn't depend on any particular command line parser
or dependency injection framework.

## Domain

The domain assembly contains the core logic and structure of the
application. It introduces the abstractions that the implementations
rely on. Hence, most all of the projects have a dependency on the
domain.

## App

The App assembly contains the entry point into the application. It is
the executable that is invoked by the user. Its sole purpose is to act
as the composition root for the application (see Mark Seeman's 
*Dependency Injection in .NET* book).

## CommandLineParser

The command line parser package encapsulates the dependence on a
particular command line parsing library. It keeps the low-level 
implementation details (i.e., the reliance on the CommandLineParser
NuGet package) out of the domain. An alternative would be to create
abstractions within the domain that could be used instead of the
CommandLineParser abstractions.

## External

This package is present to demonstrate that once the dependencies
have been inverted it becomes possible to use the application as a
host for plugins. The assembly generated by this particular package,
and its corresponding config.json file, can be copied into the same
directory as the app and the new commands added by this assembly
will be picked up. Although in this case we chose to rely on Autofac
as a dependency injection container, we could have just as easily used
reflection to load assemblies and commands dynamically.