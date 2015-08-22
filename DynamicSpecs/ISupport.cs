namespace DynamicSpecs.Core
{
    public interface ISupport
    {
        /// <summary>
        /// Contains all code which supports the given specification with additional behavior.
        /// </summary>
        /// <param name="specification">Specification which needs to be supported.</param>
        void Support(ISpecify specification);
    }
}