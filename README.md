<img src="/Ressources/logo.png" width="200" /> 

Dynamic Specs is an easy to use specfication framework. It extends NUnit, Xunit.Net, MSTest or other similiar testing frameworks with a BDD style workflow.

## Table of contents
- [Why another BDD framework?](#why-another-bdd-framework)
- [How to use it with NUnit?](#how-to-use-it-with-nunit)
	- [Basic Structure](#basic-structure)
	- [Reduce boiler plate code](#reduce-boiler-plate-code)
	- [Integration tests without boiler plate code](#integration-tests-without-boiler-plate-code)
- [How to use it with MS Test?](#how-to-use-it-with-ms-test)
- [FAQ](#faq)



## Why another BDD framework?
There are many great BDD frameworks like [MSpec](https://github.com/machine/machine.specifications) or [NSpec](http://nspec.org/) out there. Unfortunatly, they need an own runner or additional tooling, which why they are not easy to integrate in every bodys tool chain. This happens espacialy in cases where 3rd party tools during builds have to be avoided and people just want to run every thing based on Microsoft software.

The idea behind Dynamic Specs is it, to use the infrastructure of widely known frameworks like MS Test and NUnit and extend these frameworks with features to run BDD like tests. The advantage of this is, that Dynamic Specs can be used where ever the host system is used and you can not only write unit tests but also integration and system test in an easy way.

The basic structure and ideas are taken from [SpecsFor](https://github.com/MattHoneycutt/SpecsFor) which has the small disatvantage that it needs a specific set of frameworks and tools to work.

## Where can I get it?
That depends on what you need, because DynamicSpecs consists of four parts:
- [DynamicSpecs Core](https://www.nuget.org/packages/DynamicSpecs.Core/) contains the actual engine for each specification as well as the plattform independent parts holding every thing together.
- [DynamicSpecs.AutoFacItEasy](https://www.nuget.org/packages/DynamicSpecs.AutoFacItEasy/) contains an implementation of the IRegisterTypes and IResolveTypes interfaces which uses [AutoFac](http://autofac.org/) and [FakeItEasy](http://fakeiteasy.github.io/) to provide an auto mocker. You don't need this if you want to use another IoC container or test isolation framework.
- [DynamicSpecs.MSTest](https://www.nuget.org/packages/DynamicSpecs.Core/) is an implementation for the .Net version of MS Test and uses DynamicSpecs.AutoFacItEasy for auto mocking.
- [DynamicSpecs.NUnit](https://www.nuget.org/packages/DynamicSpecs.NUnit/) is an implementation for the .Net version of NUnit and uses DynamicSpecs.AutoFacItEasy for auto mocking.

## How to use it with NUnit?
### Basic Structure
The NUnit version of DynamicSpecs has every thing you need to write unit tests without any boiler plate code. Therefor you just have to create a class and inherit from the *Specfies* class of DynamicSpecs. *Specifies* gets the type of the system under tests and will handle every thing neccessary to create an instance of it. During this instantiation, it will inject [FakeItEasy](http://fakeiteasy.github.io/) mock objects into the constructor. These objects can be requested with the *GetInstace* method of *Specifcies* and can than be used to configure specific behaviors.

Such a configuration should be done during the *Given* phase of a spec because the given phase is used to setup the precondition for every test run. The action you want to check is performed during the *When* phase. If you want to get access to your system under test, you can do it by simply using the SUT property.

After all this we come to the real action, because you now have to check the outcome of the when phase. Therefor you need to create a method with the *Test* attribute from NUnit and the name describing the expected result. The *Test* attribute is necessary to trigger the execution by the test runner.

```C#
    public class WhenPersonSelectionIsShown : Specifies<PersonSelectionViewModel>
    {
        public override void Given()
        {
            this.AvailablePersons = new List<Person>(){new Person()};

            var repository = this.GetInstance<IRepository>();

            A.CallTo(() => repository.GetPersons()).Returns(this.AvailablePersons);
        }

        public override void When()
        {
            this.SUT.OnShow();
        }

        [Test]
        public void ThenAllAvailablePersonsAreShown()
        {
            Assert.AreEqual(this.AvailablePersons.Count(), this.SUT.Persons.Count());
        }

        public IEnumerable<Person> AvailablePersons { get; set; }
    }
```

### Reduce boiler plate code
The more specs you create, the more code will double. You can reduce this with support classes encapsulating you preconditions.

```C#
    public class WhenPersonSelectionIsShown : Specifies<PersonSelectionViewModel>
    {
        public override void Given()
        {
            this.AvailablePersons = this.Given<WithPersons>().AvailablePersons;
        }

        public override void When()
        {
            this.SUT.OnShow();
        }

        [Test]
        public void ThenAllAvailablePersonsAreShown()
        {
            Assert.AreEqual(this.AvailablePersons.Count(), this.SUT.Persons.Count());
        }

        public IEnumerable<Person> AvailablePersons { get; set; }
    }
```

These classes are either be instanciated by you and used as a parameter for the *Given* method or you just use their type as parameter and the spec will create an instance on its own, therfor a support class must implement the *ISupport* interface.

```C#
    public class WithPersons : ISupport
    {
        public IEnumerable<Person> AvailablePersons { get; private set; }

        public void Support(ISpecify specification)
        {
            this.AvailablePersons = new List<Person>(){new Person()};

            var repository = specification.GetInstance<IRepository>();

            A.CallTo(() => repository.GetPersons()).Returns(this.AvailablePersons);
        }
    }
```

### Integration tests without boiler plate code
Dynamic Specs used internally an extendable workflow engine. The workflow has typically seven differnt steps:

 1. Register all needed types
 2. Create SUT
 3. Given
 4. When
 5. Then
 6. Clean up for each Then
 7. Clean up for the spec

You can extend each of these steps by creating a configuration class. This class must be as near as possible to the root namespace of your test suite so it is executed as early as possible during a test run ([see also](http://nunit.org/index.php?p=setupFixture&r=2.6.3)). It also gets the *SetUpFixture* attribute, derives from *Extensions* and has a public method with the *SetUp* attribute. Within this method you can extend each spec with a particular interface by using extension classes. If you want that an extensions is executed for each spec than just define an extension point for ISpecify. You also don't need to define a particular workflow position, your extension will then be executed during the given phase.

```C#
    [SetUpFixture]
    public class Configuration : Extensions
    {
        [SetUp]
        public void Setup()
        {
            Extend<INeedDataBaseContext>()
            .With<DataBaseProvider>()
            .Before(WorkflowPosition.Given | WorkflowPosition.Then);
        }
    }
```

Such an extension can be quite helpfull if you want to create specs with access to a data base. When using Entity Framework, your specs can simply use the same Context class as your production code. This might not be clean testing, because you use something in your tests as well as in the production code, but it can shorten the time for maintenance extremely.

In this case you would create a database provider as follows. This class has to implement the *IExtend* interface for a particular other interface. Within its *Extend* method you can decisde if you need to create a transaction scope (from *System.Transaction*) or if you have to clean up the acquire ressources. 

```C#
    public class DatabaseProvider : IExtend<INeedDataBaseContext>
    {
        private TransactionScope transactionScope;

        public void Extend(INeedDataBaseContext target, WorkflowPosition currentPosition)
        {
            if(currentPosition == WorkflowPosition.SUTCreation)
            {
                    this.CreateContext(target);
            }
            else if(currentPosition == WorkflowPosition.Then)
            {
                    this.Cleanup();
			}
        }

        private void CreateContext(INeedDataBaseContext target)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TransactionManager.MaximumTimeout;
            
            this.transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);

            target.Context = this.Context = new PersonContext();
        }
        
        private void Cleanup()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }

            if (this.transactionScope != null)
            {
                this.transactionScope.Dispose();
            }
        }
        
        public PersonContext Context { get; set; }
    }
```

The great thing about these extensions is, that you can save mutch time when writiting specifications because you just need to implement the configured interface and every thing else will be done automatically. 

```C#
    public class WhenPersonSelectionIsShownWithDataBase : Specifies<PersonSelectionViewModel>, INeedDataBaseContext
    {
        public override void Given()
        {

            this.AvailablePersons = this.Given<WithPersonsInDataBase>().AvailablePersons;
        }

        public override void When()
        {
            this.SUT.OnShow();
        }

        [Test]
        public void ThenAllAvailablePersonsShown()
        {
            Assert.AreEqual(this.AvailablePersons.Count(), this.SUT.Persons.Count());
        }

        public IEnumerable<Person> AvailablePersons { get; set; }

        public PersonContext Context { get; set; }
    }
```

In combination with support classes, you get tests which focus just on the things they are testing.

```C#
    public class WithPersonsInDataBase : ISupport
    {
        public IEnumerable<Person> AvailablePersons { get; set; }

        public void Support(ISpecify specification)
        {
            var databaseSpecification = specification as INeedDataBaseContext;
            if (databaseSpecification == null)
            {
                throw new InvalidOperationException("Specification must implement INeedDataBaseContext to get access to a data base.");
            }

            var context = databaseSpecification.Context;

            this.AvailablePersons = new List<Person>(){new Person()};
            context.Persons.AddRange(this.AvailablePersons);
            context.SaveChanges();
        }
    }
```

## How to use it with MS Test?
The usage with MS Test follows the same principles like it does for NUnit. The main differences are the used attributes:

```C#
    [TestClass]
    public class WhenPersonSelectionIsShown : Specifies<PersonSelectionViewModel>
    {
        public override void Given()
        {
            this.AvailablePersons = new List<Person>(){new Person()};

            var repository = this.GetInstance<IRepository>();

            A.CallTo(() => repository.GetPersons()).Returns(this.AvailablePersons);
        }

        public override void When()
        {
            this.SUT.OnShow();
        }

        [TestMethod]
        public void ThenAllAvailablePersonsAreShown()
        {
            Assert.AreEqual(this.AvailablePersons.Count(), this.SUT.Persons.Count());
        }

        public IEnumerable<Person> AvailablePersons { get; set; }
    }
```

## FAQ
### How do I register concrete types before the SUT is created?
Simply override the RegisterTypes method of your specification and use the type registration to register concrete types. This registration can handle generic types as well as class instances.
```C#
        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            typeRegistration.Register<CsvImporter, IDataImporter>();
	    typeRegistration.Register<ILogger>(new Logger());
        }
```
### How do I get the instance injected to my SUT?
Just use the GetInstance method with the type you want to get.
```C#
        [Test]
        public void Then_no_error_dialog_is_shown()
        {
            var errorHandler = this.GetInstance<IErrorHandler>();
	    
	    // This part is specific to fake it easy.
            A.CallTo(() => errorHandler.ShowErrorCollection(A<string>.Ignored, A<List<string>>.Ignored)).MustNotHaveHappened();
        }
```

### How do I get an instance within a support class?
Same as in specifications, use GetInstance on the specification you get as a parameter.
```C#
    public class Data_can_be_imported : ISupport
    {
        public ValueTable Data {get; set; }

        public void Support(ISpecify specification)
        {
            var importer = specification.GetInstance<IDataImporter>();

	    // This part is specific to fake it easy.
            ValueTable ignored;
            A.CallTo(() => importer.TryImport(A<string>.Ignored, A<string>.Ignored, out ignored))
                .Returns(true)
                .AssignsOutAndRefParameters(this.Data);
        }
    }
```

### How can I configure an extension for all of my specifications?
All specifications implement the ISpecify interface thus you can register your extension for this interface and all specifications will be covered.
```C#
    [SetUpFixture]
    public class Configuration : Extensions
    {
        [SetUp]
        public void Setup()
        {
            Extend<ISpecify>().With<DefaultSettingsProvider>().Before(WorkflowPosition.Given);
        }
    }
```

### How can I register a concrete type for an interface for all my specifications?
You need a configuration class inheriting from Extensions class. This registers your type extension for ISpecify and is triggered before the creation of the SUT.
```C#
    [SetUpFixture]
    public class Configuration : Extensions
    {
        [SetUp]
        public void Setup()
        {
            Extend<ISpecify>().With<DefaultTypeProvider>().Before(WorkflowPosition.SUTCreation);
        }
    }
```

Then you need the actual extension class which uses the TypeRegistry property of the target specification to register all types.
```C#
    public class DefaultTypeProvider : IExtend<ISpecify>
    {
        public void Extend(ISpecify target, WorkflowPosition currentPosition)
        {
            target.TypeRegistry.Register<ConcreteClass, IAbstractInterface>();
        }
    }
```
