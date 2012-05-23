namespace Illumination.Core.Interfaces.Common
{
    public interface IFactoryBase<in TInput,out TOutput>
    {
        TOutput CreateInstance(TInput input);
    }

    public interface IFactoryBase<out TOutput>
    {
        
    }
}
