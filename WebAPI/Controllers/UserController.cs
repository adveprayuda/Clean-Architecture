﻿//using Application.Contracts;
//using Domain.Entities;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class USerController : ControllerBase
//    {
//        private readonly IUser user;

//        public USerController(IUser user)
//        {
//            this.user = user;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var data = await user.GetAsync();
//            return Ok(data);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var data = await employee.GetByIdAsync(id);
//            return Ok(data);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Add([FromBody] Employee employeeDto)
//        {
//            var result = await employee.AddAsync(employeeDto);
//            return Ok(result);
//        }

//        [HttpPut]
//        public async Task<IActionResult> Update([FromBody] Employee employeeDto)
//        {
//            var result = await employee.UpdateAsync(employeeDto);
//            return Ok(result);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var result = await employee.DeleteAsync(id);
//            return Ok(result);
//        }
//    }
//}
