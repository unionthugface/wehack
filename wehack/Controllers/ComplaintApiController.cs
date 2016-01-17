using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wehack.Models.Requests.Incident;

namespace wehack.Controllers
{
    [RoutePrefix("api/complaint")]
    public class ComplaintApiController : ApiController
    {
        [Route("send")]
        [HttpPost]
        public HttpResponseMessage SendComplaint(IncidentAddRequest model)
        {
            HttpResponseMessage resp = null;
            try 
            {
                ComplaintStatusType status = ComplaintStatusType.NotSet;

                //Check location and category of tweet to see if complaint already exists

                //ComplaintModel existingComplaint = WehackDataService.GetComplaint(model);

                //if(existingComplaint == null) { WehackDataService.CreateComplaint(model); }
                //  else { 
                        //bool userIsAdmin = WehackDataService.CheckIfUserAdmin(model.userId);
                        //if(userisAdmin) 
                        //{
                        //      status = model.Message.ParseStatus();
                        //      if(status == ComplaintStatusType.Resolved) { WehackDataService.SendResolve(existingComplaint); }
                        //}
                        //else
                            //TwitterService.Retweet(existingComplaint); 
                //}

                resp = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                resp = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return resp;
        }
    }
}
