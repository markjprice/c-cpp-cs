/* Because IUnion and UnionAttribute are currently preview features in the Base Class Library, 
 * you must explicitly define them in your code. */

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public sealed class UnionAttribute : Attribute
    {
        public UnionAttribute() { }
    }

    public interface IUnion
    {
        object? Value { get; }
    }
}
