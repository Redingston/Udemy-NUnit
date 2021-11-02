using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Step4.Cusomer
{
    public class DbGatewaySpy : IDbGateway
    {
        private WorkingStatistics _ws;
        public bool Connected { get; }

        public int Id { get; private set; }

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            Id = id;
            return _ws;
        }

        public void SetWorkingStatistics(WorkingStatistics ws)
        {
            _ws = ws;
        }
    }
}
