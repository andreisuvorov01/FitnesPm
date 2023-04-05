using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesPmSuvorov.DB
{
    public static class DbSingleTone
    {
        public static FitnessPmEntities Db_s = new FitnessPmEntities();
    }
}
