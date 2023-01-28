using System.ComponentModel.DataAnnotations;

namespace DesafioDotNet.Domain.Models;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}
