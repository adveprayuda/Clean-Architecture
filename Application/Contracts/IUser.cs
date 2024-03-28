﻿using Application.DTOs;
using Domain.Entities;

namespace Application.Contracts;

public interface IUser
{
    Task<ServiceResponse> AddAsync(User user);

    //Task<ServiceResponse> UpdateAsync(Employee employee);
    //Task<ServiceResponse> DeleteAsync(int id);
    Task<List<Employee>> GetAsync();
    Task<Employee> GetByIdAsync(int id);
}
