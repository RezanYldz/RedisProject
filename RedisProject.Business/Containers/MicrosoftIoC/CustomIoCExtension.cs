using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RedisProject.Business.Concrete;
using RedisProject.Business.Interfaces;
using RedisProject.Business.Mapping;
using RedisProject.DAL.Concrete.EntityFrameworkCore.Repositories;
using RedisProject.DAL.Interfaces;

namespace RedisProject.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
