using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLiteLogService.Models;

namespace WLiteLogService.Repository
{
    public interface IDatabaseRepository
    {
        List<LogEntryViewModel> GetDefault();
        List<string> GetApps();
    }
}
