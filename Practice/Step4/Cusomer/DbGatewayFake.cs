using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Step4.Cusomer
{
    public class DbGatewayFake : IDbGateway
    {
        private Dictionary<int, WorkingStatistics> _store = new Dictionary<int, WorkingStatistics>()
        {
            {1, new WorkingStatistics() { PayHourly = true, WorkingHours = 5,HourSalary = 100} },
            {2, new WorkingStatistics() { PayHourly = false, MonthSalary = 3000} },
            {3, new WorkingStatistics() { PayHourly = true, WorkingHours = 8,HourSalary = 250} }
        };

        public bool Connected { get; }

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return _store[id];
        }
    }
}
