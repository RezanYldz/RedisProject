using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedisProject.Business.CacheManager.Redis;
using RedisProject.Business.Interfaces;
using RedisProject.Entities.Concrete;
using RedisProject.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisController : ControllerBase
    {
        private IGenericService<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public RedisController(
            IGenericService<Customer> customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<CustomerListDto>> GetAll()
        {
            var redisManager = new RedisCacheManager();
            var customerListRedisKey = "customerListRedis";

            List<CustomerListDto> customerList = redisManager.Get<List<CustomerListDto>>(customerListRedisKey);

            if (customerList == null)
            {
                customerList = (from customers in await _customerRepository.GetAllAsync()
                             select (_mapper.Map<CustomerListDto>(customers))).ToList();

                redisManager.Set(customerListRedisKey, customerList, 60);
            }

            return customerList;
        }
    }
}
