﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wehack.Models;
using wehack.Models.Requests.Incident;
using wehack.Models.Responses;
using wehack.Service;

namespace wehack.Controllers
{
    [RoutePrefix("api/complaint")]
    public class ComplaintApiController : ApiController
    {
        private IWehackDataService _wehackDataService;

        public ComplaintApiController()
        {
            _wehackDataService = new WehackDataService();

        }

        [Route("send")]
        [HttpPost]
        public HttpResponseMessage SendComplaint(IncidentAddRequest model)
        {
            HttpResponseMessage resp = null;
            try 
            {
                //ComplaintStatusType status = ComplaintStatusType.NotSet;

                //Check location and category of tweet to see if complaint already exists
                //WehackDataService service = new WehackDataService();
                IncidentResponse incident = /*service*/_wehackDataService.CreateComplaint(model);

                if (incident == null || incident.TweetId == null)
                {
                    //get auth context

                    //create tweet
                    //assign tweetId back to database
                    //template: @riadosaband Issue #93 Pothole! 33.940109, -118.133159 #lahasissues
                    var categoryString = model.categoryId == 1 ? "Pothole" : "Streetlight";
                    var tweet = "@riadosaband " + categoryString + " #" + incident.IncidentId.ToString() + " " + model.Lat + ", " + model.Lng + " #lahasissues";

                    TwitterActionController contrlr = new TwitterActionController();

                    contrlr.Send(tweet);

                    incident.TweetId = 688120489823186944;  //<--- this is for testing!!

                    //assign tweetId back to database; update tweet; use UPDATE stored proc
                    IncidentUpdateRequest iur = new IncidentUpdateRequest();
                    iur.TweetId = (long)incident.TweetId; //3333333333;
                    iur.IncidentId = incident.IncidentId;
                    _wehackDataService.UpdateComplaint(iur);
                }
                else 
                {
                    //retweet existing tweet
                }
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
