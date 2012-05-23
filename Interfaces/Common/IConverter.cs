
namespace Illumination.Core.Interfaces.Common
{
    public interface IConverter<in TInput, out TOutput> { TOutput Convert(TInput input); }
    public interface IConverter<in TInput, in TInput2, out TOutput> { TOutput Convert(TInput input, TInput2 input2); }
    public interface IConverter<in TInput, in TInput2, in TInput3, out TOutput> { TOutput Convert(TInput input, TInput2 input2, TInput3 input3); }
    public interface IConverter<in TInput, in TInput2, in TInput3, in TInput4, out TOutput> { TOutput Convert(TInput input, TInput2 input2, TInput3 input3, TInput4 input4); }
}
