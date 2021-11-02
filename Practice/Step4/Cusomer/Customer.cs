using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Step4.Cusomer
{
    public class Customer
    {
        private readonly IDbGateway _dbGateway;
        private readonly ILogger _logger;

        public Customer(IDbGateway dbGateway, ILogger logger)
        {
            _dbGateway = dbGateway;
            _logger = logger;
        }

        public decimal CalculateWage(int id)
        {
            //if (!_dbGateway.Connected)
            //{
            //    return 0;
            //}
            WorkingStatistics ws = null;
            try
            {
                ws = _dbGateway.GetWorkingStatistics(id);
            }
            catch (Exception ex)
            {
                return 0;
            }

            decimal wage;

            if (ws.PayHourly) 
            {
                wage = ws.WorkingHours * ws.HourSalary;
            }
            else
            {
                wage = ws.MonthSalary;
            }
            _logger.Info($"Customer ID={id}, Wage:{ wage}");

            return wage;
        }
    }

    public class WorkingStatistics
    {
        public bool PayHourly { get; set; }
        public decimal HourSalary { get; set; }
        public decimal MonthSalary { get; set; }
        public int WorkingHours { get; set; }
    }

    public interface ILogger
    {
        void Info(string s);
    }

    public interface IDbGateway
    {
        WorkingStatistics GetWorkingStatistics(int id);
        bool Connected { get; }
    }
}
