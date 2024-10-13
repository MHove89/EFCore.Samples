namespace EFCore.Samples.Interceptor.Data;

public abstract class BaseEntity : IEntity
{
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}