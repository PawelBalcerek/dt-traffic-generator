﻿using System.Collections.Generic;
using System.Linq;
using Data.Infrastructure.Report.Concrete;
using Data.Models;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Repositories.Abstract;

namespace Data.Repositories.Concrete
{
    public class ReportRepository : RepositoryBase, IReportRepository
    {
        public ReportRepository(EfficiencyTestDbContext dbContext) : base(dbContext) { }


        public IEnumerable<IAverageEndpointsExecutionTimes> GetAverageEndpointsExecutionTimes(long testParametersId)
        {
            return DbContext.Tests
                .Where(t => t.TestParametersId == testParametersId)
                .Include(t => t.Endpoint)
                .GroupBy(t => t.EndpointId)
                .Select(g => new AverageEndpointsExecutionTimes(g.Select(p=>p.Endpoint).FirstOrDefault(), new ExecutionTimes(
                    g.Average(p => p.DatabaseTestTime),
                    g.Average(p => p.ApplicationTestTime),
                    g.Average(p => p.ApiTestTime))));
        }

        public IEnumerable<IUserEndpointExecutionTimes> GetUsersEndpointsExecutionTimes(long testParametersId)
        {
            return DbContext.Tests
                .Where(t => t.TestParametersId == testParametersId)
                .Include(t => t.Endpoint)
                .OrderBy(t => t.TimeStamp)
                .GroupBy(t => new
                {
                    t.EndpointId,
                    t.UserId
                })
                .Select(g => new UserEndpointExecutionTimes(g.Select(p => p.UserId).FirstOrDefault(), g.Select(p => p.Endpoint).FirstOrDefault(),
                    g.Select(p => new ExecutionTimesWithStamp(p.DatabaseTestTime, p.ApplicationTestTime, p.ApiTestTime, p.TimeStamp))));
        }

        public IEnumerable<IUserEndpointExecutionTimes> GetUsersEndpointExecutionTimes(long testParametersId, long endpointId)
        {
            return DbContext.Tests
                .Where(t => t.TestParametersId == testParametersId && t.EndpointId == endpointId)
                .Include(t => t.Endpoint)
                .OrderBy(t => t.TimeStamp)
                .GroupBy(t => t.UserId)
                .Select(g => new UserEndpointExecutionTimes(g.Select(p => p.UserId).FirstOrDefault(), g.Select(p => p.Endpoint).FirstOrDefault(),
                    g.Select(p => new ExecutionTimesWithStamp(p.DatabaseTestTime, p.ApplicationTestTime, p.ApiTestTime, p.TimeStamp))));
        }
    }
}
