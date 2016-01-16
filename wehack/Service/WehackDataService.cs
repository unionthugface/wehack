using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wehack.Models;
using wehack.Models.Requests.Incident;
using wehack.Models.Responses;

namespace wehack.Service
{
    public class WehackDataService : BaseService, IWehackDataService
    {
        public ItemsResponse<IncidentUpdateRequest> GetComplaint(IncidentAddRequest model) 
        {
            ItemsResponse<IncidentUpdateRequest> resp = new ItemsResponse<IncidentUpdateRequest>();

            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(CreateParameter("@categoryId", model.CategoryId, SqlDbType.Int, ParameterDirection.Input));
            collection.Add(CreateParameter("@lat", model.Lat, SqlDbType.BigInt, ParameterDirection.Input));
            collection.Add(CreateParameter("@lng", model.Lng, SqlDbType.BigInt, ParameterDirection.Input));

            Func<IDataRecord, IncidentUpdateRequest> complaintReader = delegate(IDataRecord record)
            {
                IncidentUpdateRequest req = new IncidentUpdateRequest();
                req.IncidentId = record.GetInt32(0);
                req.Lat = record.GetDouble(1);
                req.Lng = record.GetDouble(2);
                req.Status = (ComplaintStatusType)record.GetInt32(3);
                req.CategoryId = record.GetInt32(4);

                return req;
            };

            try
            {
                resp.Items = ExecuteReader<IncidentUpdateRequest>("DBNAME", "SP_NAME", complaintReader, collection);
                resp.IsSuccessFull = true;
            }
            catch (Exception ex) { }

            return resp;
        }

        //public void CreateComplaint(ComplaintRequestModel model) {}

        //public bool IsUserAdmin(string userHandle) {}

        //public void SendResolvedStatus(ComplaintModel model) {}
    }
}
