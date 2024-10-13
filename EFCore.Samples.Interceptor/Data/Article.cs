using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Samples.Interceptor.Data;

public class Article : BaseEntity
{
    [Key] public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
}