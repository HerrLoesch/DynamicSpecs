﻿namespace DynamicSpecs.Core
{
    /// <summary>
    /// Basic structure of a specification for a specific type.
    /// </summary>
    /// <typeparam name="T">Specified type</typeparam>
    public interface ISpecify<T> : ISpecify
    {
        /// <summary>
        /// Gets or sets an Instance of the SUT.
        /// </summary>
        T SUT { get; }
    }

    /// <summary>
    /// Basic structure of a specification.
    /// </summary>
    public interface ISpecify
    {
        /// <summary>
        /// Gets or sets the instance of the central type registry.
        /// </summary>
        IRegisterTypes TypeRegistry { get; }

        /// <summary>
        /// Method containing all code needed during the given phase.
        /// </summary>
        void Given();

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        void When();

        /// <summary>
        /// Method containing all code needed during the given phase.
        /// </summary>
        /// <param name="supporter">
        /// Class containing support code for a test run.
        /// </param>
        /// <returns>
        /// Instance of <see cref="ISupport"/>.
        /// </returns>
        ISupport Given(ISupport supporter);

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        /// <returns>
        /// Instance of <see cref="ISupport"/>.
        /// </returns>
        TSupport Given<TSupport, T>(T supportData) where TSupport : ISupport<T>;

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        /// <param name="supporter">
        /// Class containing support code for a test run.
        /// </param>
        /// <returns>
        /// Instance of <see cref="ISupport"/>.
        /// </returns>
        ISupport When(ISupport supporter);

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        /// <returns>
        /// Instance of <see cref="ISupport"/>.
        /// </returns>
        TSupport When<TSupport, T>(T supportData) where TSupport : ISupport<T>;

        /// <summary>
        /// Resolves the instance or mock instance of a given type.
        /// </summary>
        /// <typeparam name="TInstance">Type of the instance which shall be resolved.</typeparam>
        /// <returns>Instance of the given type.</returns>
        TInstance GetInstance<TInstance>() where TInstance : class;
    }
}