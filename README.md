# DynamicSpecs
<img align="left" src="https://raw.githubusercontent.com/HerrLoesch/DynamicSpecs/master/Ressources/logo.png" alt="Logo" height="25"/>
Dynamic Specs is an easy to use specfication framework. It extends NUnit, MSTest or other similiar testing frameworks with a BDD style workflow.

##Table of contents
- [Why another BDD framework?](#why-another-bdd-framework?)
- [Where can I get it?](#Where-can-I-get-it)


##Why another BDD framework?
There are many great BDD frameworks like [MSpec](https://github.com/machine/machine.specifications) or [NSpec](http://nspec.org/) out there. but unfortunatly these often need an own runner or additional tooling which why they are not easy to integrate in every bodys tool chain. This happens espacialy in cases where 3rd party tools during builds are avoided and people just want to run every thing based on Microsoft software.

The Idea behind Dynamic Specs is it, to use the infrastructure of widely known frameworks like MS Test and NUnit and extend these frameworks with features to run BDD like tests. The advantage of this is, that Dynamic Specs can be used where ever the host system is used and the user can not only write unit tests in an easy way but also integration and system test.

##Where can I get it?
That depends on what you need, because DynamicSpecs consists of four parts:
- [DynamicSpecs Core](https://www.nuget.org/packages/DynamicSpecs.Core/) contains the actual engine for each specification as well as the plattform independent parts holding every thing together.
- [DynamicSpecs.AutoFacItEasy](https://www.nuget.org/packages/DynamicSpecs.AutoFacItEasy/) contains an implementation of the IRegisterTypes and IResolveTypes interfaces which uses [AutoFac](http://autofac.org/) and [FakeItEasy](http://fakeiteasy.github.io/) to provide an auto mocker. You don't need this if you want to use another IoC container or test isolation framework.
- [DynamicSpecs.MSTest](https://www.nuget.org/packages/DynamicSpecs.Core/) is an implementation for the .Net version of MS Test and uses DynamicSpecs.AutoFacItEasy for auto mocking.
- [DynamicSpecs.NUnit](https://www.nuget.org/packages/DynamicSpecs.NUnit/) is an implementation for the .Net version of NUnit and uses DynamicSpecs.AutoFacItEasy for auto mocking.
 
