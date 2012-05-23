
namespace Illumination.Core.Interfaces.Common
{
    public interface IQuery<out TResponse> : IWorkflow<TResponse> { }
    public interface IQuery<in TRequest, out TResponse> : IWorkflow<TRequest, TResponse> { }
    public interface IQuery<in TRequest, in TRequestTwo, out TResponse> : IWorkflow<TRequest, TRequestTwo, TResponse >{}
}
