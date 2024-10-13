namespace EFCore.Samples.Interceptor.Data;

public interface IEntity
{
    DateTime? CreatedDate { get; set; }
    DateTime? UpdatedDate { get; set; }
}