using GGJWEvent.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GGJWEvent.Controllers
{
    public class AccountAPIController : ApiController
    {
        GGJWEventEntities db = new GGJWEventEntities();
        StudyField sf = new StudyField();

        [HttpGet]
        public ResultData ValidateAdmin(string userName, string password)
        {
            ResultData resultData = new ResultData();
            try
            {
                Admin admin = db.Admins.Where(a => a.Username == userName && a.Password == password).FirstOrDefault();
                if (admin != null)
                {
                    User user = new User();
                    user.Id = admin.Id;
                    user.Name = admin.Name;
                    user.UserName = admin.Username;
                    user.Password = admin.Password;
                    user.Role = "Admin";

                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = admin;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Login Detail";
                    resultData.IsSuccess = true;
                    resultData.Data = 0;
                    return resultData;
                }
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

    }
}
