
namespace Illumination.Core.Interfaces.Common
{
    public interface IWorkflow<out TResponse>
    {
        TResponse Invoke();
    }


    public interface IWorkflow<in TRequest, out TResponse>
    {
        TResponse Invoke(TRequest request);
    }

    public interface IWorkflow<in TRequest, in TRequestTwo, out TResponse>
    {
        TResponse Invoke(TRequest request, TRequestTwo requestTwo);
    }
}
