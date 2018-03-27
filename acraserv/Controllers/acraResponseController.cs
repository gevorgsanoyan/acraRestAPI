using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using acraserv.Models;
using System.Data;

namespace acraserv.Controllers
{
    public class acraResponseController : ApiController
    {
        public IHttpActionResult GetResponse(string firstName, string lastName, string socCard, string clientID, int requestType, int isTest)
        {
            var resp = firstName + " " + lastName + " " + socCard + " ";
            DateTime dob;
            string passp = "";
            string cvalid = "0";
            string asClNumb = "0";
            LUISDataTableAdapters.GetClientsBySocCardTableAdapter clientAdp = new LUISDataTableAdapters.GetClientsBySocCardTableAdapter();
            DataTable clientT = clientAdp.GetData(socCard.TrimEnd());

            if (clientT.Rows.Count > 0)
            {
                dob = DateTime.Parse(clientT.Rows[0]["DOB"].ToString());
                passp = clientT.Rows[0]["passportS"].ToString().TrimEnd() + clientT.Rows[0]["passportN"].ToString().TrimEnd();

                LUISDataTableAdapters.ASDataClientNumbBySocNTableAdapter asclAdp = new LUISDataTableAdapters.ASDataClientNumbBySocNTableAdapter();
                DataTable asT = asclAdp.GetData(clientT.Rows[0]["socN"].ToString().TrimEnd());

                if (asT.Rows.Count > 0)
                    asClNumb = asT.Rows[0]["as_ClientNumb"].ToString();

                cvalid = "1";

            }
            else
            {
                dob = new DateTime(1980, 1, 1);
                passp = "AA00554425";
            }

            ACRARequestInput AcraReq = new Models.ACRARequestInput();
            if (requestType == 1)
            {
                AcraReq.ACRARequestInputNew(25, long.Parse(clientID), firstName, lastName, dob, passp, socCard, 1, 1, requestType, isTest);  
            }
            else
            {
                AcraReq.ACRARequestInputNew(25, long.Parse(clientID), firstName, lastName, dob, passp, socCard, 2, 21, requestType, isTest);   
            }


            resp += "Անձնագիր#" + passp + ", Ծննդ.ամսթ." + dob.ToString();
            resp = AcraReq.Req_Err + "_" + cvalid + "_" + resp + " #" + asClNumb;         

            if (isTest == 1)
                resp += " ##### Test";
            else
                resp += " ##### Real";

            resp += "_X" + AcraReq.req_ID.ToString();

            return Ok(resp);
        }
    }
}
