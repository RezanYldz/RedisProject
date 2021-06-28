using AutoMapper;
using RedisProject.Entities.Concrete;
using RedisProject.Entities.Dtos;

namespace RedisProject.Business.Mapping
{
    public class CustomerMapper:Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerListDto>();
            CreateMap<CustomerListDto, Customer>();
        }
    }
}
