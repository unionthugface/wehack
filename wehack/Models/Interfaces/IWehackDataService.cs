using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wehack.Domain;
using wehack.Models.Requests.Incident;
using wehack.Models.Responses;

namespace wehack.Models
{
    public interface IWehackDataService
    {
        IncidentResponse CreateComplaint(IncidentAddRequest model);

        IncidentResponse UpdateComplaint(IncidentUpdateRequest model);

        //IncidentResponse CreateComplaint(ComplaintRequestModel model) { get; set; }

        //bool IsUserAdmin(string userHandle) { get; set; }

        //void SendResolvedStatus(ComplaintModel model) { get; set; }
    }
}
