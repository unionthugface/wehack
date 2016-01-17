using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wehack.Domain;
using wehack.Models;
using wehack.Models.Requests.Incident;
using wehack.Models.Responses;

namespace wehack.Service
{
    public class WehackDataService : BaseService, IWehackDataService
    {
        //public ItemsResponse<Incident> GetComplaint(IncidentAddRequest model)
        //{
        //    ItemsResponse<Incident> resp = new ItemsResponse<Incident>();

        //    List<SqlParameter> collection = new List<SqlParameter>();
        //    collection.Add(CreateParameter("@categoryId", model.CategoryId, SqlDbType.Int, ParameterDirection.Input));
        //    collection.Add(CreateParameter("@lat", model.Lat, SqlDbType.BigInt, ParameterDirection.Input));
        //    collection.Add(CreateParameter("@lng", model.Lng, SqlDbType.BigInt, ParameterDirection.Input));

        //    Func<IDataRecord, Incident> complaintReader = delegate (IDataRecord record)
        //    {
        //        Incident req = new Incident();
        //        req.Id = record.GetInt32(0);
        //        req.Lat = record.GetDouble(1);
        //        req.Lng = record.GetDouble(2);
        //        req.Status = (ComplaintStatusType)record.GetInt32(3);
        //        req.CategoryId = record.GetInt32(4);
        //        req.TweetId = record.GetInt32(5);

        //        return req;
        //    };

        //    try
        //    {
        //        resp.Items = ExecuteReader<Incident>("DBNAME", "SP_NAME", complaintReader, collection);
        //        resp.IsSuccessFull = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return resp;
        //}

        public IncidentResponse CreateComplaint(IncidentAddRequest model)
        {
            //var id = 0;

            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(CreateParameter("@categoryId", model.categoryId, SqlDbType.Int, ParameterDirection.Input));
            collection.Add(CreateParameter("@lat", model.Lat, SqlDbType.Float, ParameterDirection.Input));
            collection.Add(CreateParameter("@lng", model.Lng, SqlDbType.Float, ParameterDirection.Input));
            collection.Add(CreateParameter("@userId", model.UserId, SqlDbType.Int, ParameterDirection.Input));
            collection.Add(CreateParameter("@TweetId", null, SqlDbType.BigInt, ParameterDirection.Output));
            collection.Add(CreateParameter("@IncidentId", null, SqlDbType.Int, ParameterDirection.Output));


            ExecuteNonQuery("wehackdb", "dbo.Incident_Insert", collection);

            //id = (int)collection.FirstOrDefault(x => x.ParameterName == "@userId").SqlValue;

            IncidentResponse resp = new IncidentResponse();
            if (collection.FirstOrDefault(x => x.ParameterName == "@TweetId").Value == DBNull.Value)
            {
                resp.TweetId = null;
            }
            else
            {
                resp.TweetId = (long?)collection.FirstOrDefault(x => x.ParameterName == "@TweetId").SqlValue;
            }
            resp.IncidentId = (int)collection.FirstOrDefault(x => x.ParameterName == "@IncidentId").Value;

            return resp;
        }

        public void UpdateComplaint(IncidentUpdateRequest model/*, long tweetId*/)
        {
            //var id = 0;

            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(CreateParameter("@Id", model.IncidentId, SqlDbType.Int, ParameterDirection.Output));
            collection.Add(CreateParameter("@tweetId", model.TweetId, SqlDbType.BigInt, ParameterDirection.Input));

            ExecuteNonQuery("wehackdb", "dbo.update_tweetId", collection);

            //id = (int)collection.FirstOrDefault(x => x.ParameterName == "@userId").SqlValue;

            //IncidentResponse resp = new IncidentResponse();
            //resp.TweetId = (long)collection.FirstOrDefault(x => x.ParameterName == "@TweetId").SqlValue;
            //resp.IncidentId = (int)collection.FirstOrDefault(x => x.ParameterName == "@IncidentId").SqlValue;

            //return resp;
        }

        //public bool IsUserAdmin(string userHandle) {}

        //public void SendResolvedStatus(ComplaintModel model) {}
    }
}
