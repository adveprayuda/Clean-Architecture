using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation;

public class EmployeeRepo : IEmployee
{
    private readonly AppDBContext appDBContext;

    public EmployeeRepo(AppDBContext appDBContext)
    {
        this.appDBContext = appDBContext;
    }
    public async Task<ServiceResponse> AddAsync(Employee employee)
    {
        appDBContext.Employees.Add(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Added");
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var employee = await appDBContext.Employees.FindAsync(id);
        if (employee == null) return new ServiceResponse(false, "User not Found");

        appDBContext.Employees.Remove(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Deleted");
    }

    public async Task<List<Employee>> GetAsync() => await appDBContext.Employees.AsNoTracking().ToListAsync();

    public async Task<Employee> GetByIdAsync(int id) => await appDBContext.Employees.FindAsync(id);

    public async Task<ServiceResponse> UpdateAsync(Employee employee)
    {
        appDBContext.Update(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Updated");
    }
    private async Task SaveChangesAsync() => await appDBContext.SaveChangesAsync();
}
