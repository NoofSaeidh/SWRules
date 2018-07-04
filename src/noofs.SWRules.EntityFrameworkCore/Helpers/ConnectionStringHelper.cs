using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noofs.SWRules.Helpers
{
    public static class ConnectionStringHelper
    {
        private static readonly Func<string, string>[] _connectionStringAdjustments = new Func<string, string>[]
        {
            cs => cs.Replace("{base-directory}", DirectoryHelper.GetBaseFolder())
        };

        public static string AdjustConnectionString(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));

            foreach (var adj in _connectionStringAdjustments)
            {
                connectionString = adj(connectionString);
            }

            return connectionString;
        }
    }
}
