using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ResponseModels
{
    public class PaginatedResponse<T>
    {
        public PaginatedResponse(T data)
        {
            Data = data;
        }
        public string Draw { get; set; }
        public string RecordsTotal { get; set; }
        public string RecordsFiltered { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
        public T Data { get; }
    }
}
