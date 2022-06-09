using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.AdoService.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static Contact ToContact(this IDataRecord dataRecord)
        {
            return new Contact() { Id = (int)dataRecord["Id"], LastName = (string)dataRecord["LastName"], FirstName = (string)dataRecord["FirstName"] };
        }
    }
}
