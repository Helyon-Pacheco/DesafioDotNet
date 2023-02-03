using AutoMapper;
using DesafioDotNet.Domain.Models;

namespace DesafioDotNet.Application.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Products, Products>();
    }
}
