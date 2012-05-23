
namespace Illumination.Core.Interfaces.Common
{
    public interface ICommand<in TRequest,out TResponse> : IWorkflow<TRequest, TResponse>
    {
    }

    public interface ICommand<out TResponse> : IWorkflow<TResponse>
    {
    }
}
