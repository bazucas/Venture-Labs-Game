﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VL.Taskio.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddDbContext<HrDatabaseContext>(options => {
        //    options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
        //});

        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        //services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        //services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

        return services;
    }
}