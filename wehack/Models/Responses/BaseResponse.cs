using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Models.Responses
{
    public abstract class BaseResponse
    {
        public bool IsSuccessFull { get; set; }

        public string TransactionId { get; set; }

        public BaseResponse()
        {
            //Sabio: This TxId we are just faking to demo the purpose
            this.TransactionId = Guid.NewGuid().ToString();
        }
    }
}