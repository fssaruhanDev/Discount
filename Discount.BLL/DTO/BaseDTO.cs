using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.BLL.DTO
{
    public class BaseDTO<T>
    {
        public BaseDTO()
        {
            
        }
        public BaseDTO(string code,string status,T data)
        {
            Data = data;
            Code = code;
            Status = status;
        }
        public BaseDTO(string code, string status)
        {
            Code = code;
            Status = status;
        }
        public BaseDTO(string code, string status, List<T> data)
        {
            DataList = data;
            Code = code;
            Status = status;
        }

        public string Code { get; set; }
        public string Status { get; set; }
        public List<T> DataList { get; set; }
        public T Data { get; set; }

    }
}
