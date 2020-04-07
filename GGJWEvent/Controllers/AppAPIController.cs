using GGJWEvent.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace GGJWEvent.Controllers
{
    public class AppAPIController : ApiController
    {
        GGJWEventEntities db = new GGJWEventEntities();
        StudyField sf = new StudyField();

        [HttpGet]
        public ResultData Login(string mobile, string type)
        {
            ResultData resultData = new ResultData();
            try
            {
                if (type == "Exhibitor")
                {
                    List<GetExhibitorDatalists> exhibitorList = new List<GetExhibitorDatalists>();
                    string a = string.Format("SELECT * FROM Exhibitor WHERE MobileNo='{0}'", mobile);
                    DataTable der = sf.GetData(a);
                    foreach (DataRow item in der.Rows)
                    {
                        GetExhibitorDatalists exhibitor = new GetExhibitorDatalists();
                        exhibitor.Id = Convert.ToInt64(item["Id"]);
                        exhibitor.PersonName = Convert.ToString(item["PersonName"]);
                        exhibitor.Designation = Convert.ToString(item["Designation"]);
                        exhibitor.CompanyName = Convert.ToString(item["CompanyName"]);
                        exhibitor.Country = Convert.ToString(item["Country"]);
                        exhibitor.TelephoneNo = Convert.ToString(item["TelephoneNo"]);
                        exhibitor.MobileNo = Convert.ToString(item["MobileNo"]);
                        exhibitor.Email = Convert.ToString(item["Email"]);
                        exhibitor.FCMToken = Convert.ToString(item["FCMToken"]);
                        exhibitor.IsVerified = item["IsVerified"] == DBNull.Value ? false : Convert.ToBoolean(item["IsVerified"]);
                        exhibitor.Image = Convert.ToString(item["Image"]);

                        List<GetExhibitorAddresses> addlist = new List<GetExhibitorAddresses>();
                        string b = string.Format("SELECT * FROM ExhibitorAddress WHERE ExhibitorId='{0}'", Convert.ToInt32(item["Id"]));
                        DataTable dte = sf.GetData(b);
                        foreach (DataRow items in dte.Rows)
                        {
                            GetExhibitorAddresses add = new GetExhibitorAddresses();
                            add.Id = Convert.ToInt64(items["Id"]);
                            add.Latlong = Convert.ToString(items["Latlong"]);
                            add.Address = Convert.ToString(items["Address"]);
                            add.StateId = Convert.ToInt64(items["StateId"]);
                            DataTable StateNa = sf.GetData(string.Format("SELECT * FROM State WHERE Id='{0}'", add.StateId));
                            add.StateName = StateNa.Rows[0]["Title"].ToString();
                            add.CityId = Convert.ToInt64(items["CityId"]);
                            DataTable CityNa = sf.GetData(string.Format("SELECT * FROM City WHERE Id='{0}'", add.CityId));
                            add.CityName = CityNa.Rows[0]["Title"].ToString();
                            add.ExhibitorId = Convert.ToInt64(items["ExhibitorId"]);
                            addlist.Add(add);
                        }
                        exhibitor.AddressList = addlist;
                        exhibitorList.Add(exhibitor);
                    }
                    if (exhibitorList != null)
                    {
                        resultData.Message = "Data Get Successfully";
                        resultData.IsSuccess = true;
                        resultData.Data = exhibitorList;
                        return resultData;
                    }
                    else
                    {
                        resultData.Message = "Invalid Exhibitor Detail";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                else if (type == "Visitor")
                {
                    List<GetVisitorLoginData_Result> customer = new List<GetVisitorLoginData_Result>();
                    customer = db.GetVisitorLoginData(mobile).ToList();
                    if (customer != null)
                    {
                        resultData.Message = "Data Get Successfully !";
                        resultData.IsSuccess = true;
                        resultData.Data = customer;
                        return resultData;
                    }
                    else
                    {
                        resultData.Message = "Invalid Login Detail !";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                else
                {
                    resultData.Message = "Invalid Login Detail !";
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

        #region otp

        [HttpGet]
        public ResultData SendVerificationCode(string mobileNo, string code)
        {
            ResultData resultData = new ResultData();
            try
            {
                SendSMS sms = new SendSMS();
                string res = sms.sendotp("you Verification Code is " + code, mobileNo);

                if (res.Equals("ok"))
                {

                    resultData.Message = "Data Get Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = 1;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Failed !";
                    resultData.IsSuccess = false;
                    resultData.Data = 0;
                    return resultData;
                }
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData VisitorOTPVerification(Int64 id)
        {
            ResultData resultData = new ResultData();
            try
            {
                db.UpdateVisitoreVerficationStatus(1, id);
                resultData.Message = "Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 1;
                return resultData;

            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData ExhibitorOTPVerification(Int64 id)
        {
            ResultData resultData = new ResultData();
            try
            {
                db.UpdateExhibitorVerficationStatus(1, id);
                resultData.Message = "Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 1;
                return resultData;

            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        #endregion

        #region Exhibitor

        [ActionName("UpdateExhibitorPhoto")]
        public ResultData UpdateExhibitorPhoto()
        {
            ResultData resultData = new ResultData();
            try
            {
                var properties = Request.Properties as Dictionary<string, object>;
                var requestObject = ((System.Web.HttpContextWrapper)(properties["MS_HttpContext"])).Request;

                string[] paths = sf.Upload(requestObject, Constants.FileTypeExhibitor);
                long Id = Convert.ToInt64(requestObject.Form["Id"]);

                string Image = "";
                if (requestObject.Files.AllKeys.Any())
                    Image = paths[0];

                if (Id != null && Id != 0)
                {
                    Exhibitor exhibitor = db.Exhibitors.Where(m => m.Id == Id).FirstOrDefault();
                    if (exhibitor != null && Image != "")
                    {
                        exhibitor.Image = Image;
                        db.SaveChanges();
                    }

                    resultData.Data = Image;
                    resultData.Message = "Data Updated Successfully !";
                    resultData.IsSuccess = true;
                }
                else
                {
                    resultData.Data = 0;
                    resultData.Message = "Exhibitor Data Not Match";
                    resultData.IsSuccess = false;
                }

                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData GetExhibitor()
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetExhibitorDatalists> exhibitorList = new List<GetExhibitorDatalists>();
                string a = string.Format("SELECT * FROM Exhibitor");
                DataTable der = sf.GetData(a);
                foreach (DataRow item in der.Rows)
                {
                    GetExhibitorDatalists exhibitor = new GetExhibitorDatalists();
                    exhibitor.Id = Convert.ToInt64(item["Id"]);
                    exhibitor.PersonName = Convert.ToString(item["PersonName"]);
                    exhibitor.Designation = Convert.ToString(item["Designation"]);
                    exhibitor.CompanyName = Convert.ToString(item["CompanyName"]);
                    exhibitor.Country = Convert.ToString(item["Country"]);
                    exhibitor.TelephoneNo = Convert.ToString(item["TelephoneNo"]);
                    exhibitor.MobileNo = Convert.ToString(item["MobileNo"]);
                    exhibitor.Email = Convert.ToString(item["Email"]);
                    exhibitor.FCMToken = Convert.ToString(item["FCMToken"]);
                    exhibitor.IsVerified = item["IsVerified"] == DBNull.Value ? false : Convert.ToBoolean(item["IsVerified"]);
                    exhibitor.Image = Convert.ToString(item["Image"]);

                    List<GetExhibitorAddresses> addlist = new List<GetExhibitorAddresses>();
                    string b = string.Format("SELECT * FROM ExhibitorAddress WHERE ExhibitorId='{0}'", Convert.ToInt32(item["Id"]));
                    DataTable dte = sf.GetData(b);
                    foreach (DataRow items in dte.Rows)
                    {
                        GetExhibitorAddresses add = new GetExhibitorAddresses();
                        add.Id = Convert.ToInt64(items["Id"]);
                        add.Latlong = Convert.ToString(items["Latlong"]);
                        add.Address = Convert.ToString(items["Address"]);
                        add.StateId = Convert.ToInt64(items["StateId"]);
                        DataTable StateNa = sf.GetData(string.Format("SELECT * FROM State WHERE Id='{0}'", add.StateId));
                        add.StateName = StateNa.Rows[0]["Title"].ToString();
                        add.CityId = Convert.ToInt64(items["CityId"]);
                        DataTable CityNa = sf.GetData(string.Format("SELECT * FROM City WHERE Id='{0}'", add.CityId));
                        add.CityName = CityNa.Rows[0]["Title"].ToString();
                        add.ExhibitorId = Convert.ToInt64(items["ExhibitorId"]);
                        addlist.Add(add);
                    }
                    exhibitor.AddressList = addlist;
                    exhibitorList.Add(exhibitor);
                }
                if (exhibitorList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = exhibitorList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Exhibitor Detail";
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

        [HttpGet]
        public ResultData GetMyPendingCoupon(long exhibitorId)
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetTotalCouponData_Result> totalcouponList = new List<GetTotalCouponData_Result>();

                totalcouponList = db.GetTotalCouponData(exhibitorId).ToList();
                if (totalcouponList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = totalcouponList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Data Detail";
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

        [HttpGet]
        public ResultData GetcustomerCouponByExhibitorIdDataList(long exhibitorId)
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetcustomerCouponByExhibitorIdData_Result> customerList = new List<GetcustomerCouponByExhibitorIdData_Result>();
                customerList = db.GetcustomerCouponByExhibitorIdData(exhibitorId).ToList();
                if (customerList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = customerList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Customer Detail";
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

        [HttpPost]
        public ResultData UpdateExhibitorProfile(Exhibitor profiledata)
        {
            ResultData responseData = new ResultData();
            try
            {
                Exhibitor dbExhibitor = db.Exhibitors.Where(m => m.Id == profiledata.Id).FirstOrDefault();
                if (dbExhibitor != null && dbExhibitor.Id > 0)
                {
                    dbExhibitor.PersonName = profiledata.PersonName;
                    dbExhibitor.MobileNo = profiledata.MobileNo;
                    dbExhibitor.Designation = profiledata.Designation;
                    dbExhibitor.CompanyName = profiledata.CompanyName;
                    dbExhibitor.Designation = profiledata.Designation;
                    dbExhibitor.Country = profiledata.Country;
                    dbExhibitor.TelephoneNo = profiledata.TelephoneNo;
                    dbExhibitor.Email = profiledata.Email;
                    db.SaveChanges();
                }

                responseData.Message = "Data Updated Successfully";
                responseData.IsSuccess = true;
                responseData.Data = profiledata.Id;
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Message = ex.Message.ToString();
                responseData.IsSuccess = false;
                responseData.Data = 0;
                return responseData;
            }
        }

        [HttpGet]
        public ResultData GetMyCustomerAssignCoupon(long exhibitorId)
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetMyCustomerAssignCouponData_Result> customerList = new List<GetMyCustomerAssignCouponData_Result>();
                customerList = db.GetMyCustomerAssignCouponData(exhibitorId).ToList();
                if (customerList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = customerList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Customer Detail";
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

        #endregion

        #region ExhibitorBanner

        [HttpPost]
        [ActionName("SaveExhibitorBanner")]
        public ResultData SaveExhibitorBanner()
        {
            ResultData resultData = new ResultData();
            try
            {
                var properties = Request.Properties as Dictionary<string, object>;
                var requestObject = ((System.Web.HttpContextWrapper)(properties["MS_HttpContext"])).Request;
                long Id = Convert.ToInt64(requestObject.Form["Id"]);

                string[] paths = sf.Upload(requestObject, Constants.FileTypeExhibitorBanner);

                string OfferName = Convert.ToString(requestObject.Form["OfferName"]);
                long ExhibitorId = Convert.ToInt64(requestObject.Form["ExhibitorId"]);
                string Image = "";
                if (requestObject.Files.AllKeys.Any())
                    Image = paths[0];

                ExhibitorBanner data = new ExhibitorBanner();
                data = db.ExhibitorBanners.Where(a => a.ExhibitorId == ExhibitorId).FirstOrDefault();
                if (data != null)
                {
                    ExhibitorBanner exhibitorBannerData = db.ExhibitorBanners.Where(c => c.ExhibitorId == ExhibitorId).FirstOrDefault();
                    if (exhibitorBannerData != null && exhibitorBannerData.Id > 0)
                    {
                        exhibitorBannerData.OfferName = OfferName;
                        exhibitorBannerData.ExhibitorId = ExhibitorId;
                        if (Image != "")
                            exhibitorBannerData.Image = Image;

                        db.SaveChanges();

                        resultData.Data = exhibitorBannerData.Image;
                        resultData.Message = "Data Updated Successfully !";
                    }
                }

                else
                {
                    ExhibitorBanner exhibitorBannerData = new ExhibitorBanner();
                    exhibitorBannerData.OfferName = OfferName;
                    exhibitorBannerData.ExhibitorId = ExhibitorId;
                    exhibitorBannerData.Image = Image;

                    db.ExhibitorBanners.Add(exhibitorBannerData);
                    db.SaveChanges();

                    resultData.Data = exhibitorBannerData.Id;
                    resultData.Message = "Data Save Successfully !";
                }


                resultData.IsSuccess = true;
                return resultData;
            }
            catch (Exception ex)

            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData DeleteExhibitorBanner(long id)
        {
            ResultData resultData = new ResultData();
            try
            {
                ExhibitorBanner exhibitorBanner = db.ExhibitorBanners.Where(t => t.Id == id).FirstOrDefault();
                if (exhibitorBanner != null)
                {
                    db.ExhibitorBanners.Remove(exhibitorBanner);
                    db.SaveChanges();
                }

                resultData.Message = "Data Deleted Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 1;
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData GetMyExhibitorBanner(long exhibitorId)
        {
            ResultData resultData = new ResultData();
            try
            {
                List<ExhibitorBanner> exhibitorBanner = new List<ExhibitorBanner>();
                exhibitorBanner = db.ExhibitorBanners.Where(e => e.ExhibitorId == exhibitorId).ToList();
                if (exhibitorBanner != null)
                {
                    resultData.Message = "Data Get Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = exhibitorBanner;
                    return resultData;
                }
                else
                {
                    resultData.Message = "No Data Found !";
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

        [HttpGet]
        public ResultData GetExhibitorBanner()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetExhibitorBannerData_Result> exhibitorBannerList = new List<GetExhibitorBannerData_Result>();
                exhibitorBannerList = db.GetExhibitorBannerData().ToList();
                if (exhibitorBannerList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = exhibitorBannerList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid ExhibitorBanner Detail";
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

        #endregion

        #region Customer

        [HttpPost]
        [ActionName("SaveVisitor")]
        public ResultData SaveVisitor()
        {
            ResultData resultData = new ResultData();
            try
            {
                var properties = Request.Properties as Dictionary<string, object>;
                var requestObject = ((System.Web.HttpContextWrapper)(properties["MS_HttpContext"])).Request;
                long Id = Convert.ToInt64(requestObject.Form["Id"]);
                string MobileNo = Convert.ToString(requestObject.Form["MobileNo"]);
                if (Id != null && Id == 0)
                {
                    List<Customer> customerList = new List<Customer>();
                    customerList = db.Customers.Where(n => n.MobileNo == MobileNo).ToList();
                    if (customerList.Count > 0)
                    {
                        resultData.Message = "Mobile Already Exist !";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }

                string[] paths = sf.Upload(requestObject, Constants.FileTypeVisitor);


                string PersonName = Convert.ToString(requestObject.Form["PersonName"]);

                string Designation = Convert.ToString(requestObject.Form["Designation"]);
                string CompanyName = Convert.ToString(requestObject.Form["CompanyName"]);
                string Address = Convert.ToString(requestObject.Form["Address"]);
                string Country = Convert.ToString(requestObject.Form["Country"]);
                string TelephoneNo = Convert.ToString(requestObject.Form["TelephoneNo"]);
                string Email = Convert.ToString(requestObject.Form["Email"]);
                long StateId = Convert.ToInt64(requestObject.Form["StateId"]);
                long CityId = Convert.ToInt64(requestObject.Form["CityId"]);
                string Image = "";
                if (requestObject.Files.AllKeys.Any())
                    Image = paths[0];

                if (Id != null && Id == 0)
                {
                    Customer customerData = new Customer();
                    customerData.PersonName = PersonName;
                    customerData.MobileNo = MobileNo;
                    customerData.Designation = Designation;
                    customerData.CompanyName = CompanyName;
                    customerData.Address = Address;
                    customerData.Country = Country;
                    customerData.TelephoneNo = TelephoneNo;
                    customerData.Email = Email;
                    customerData.StateId = StateId;
                    customerData.CityId = CityId;
                    customerData.Image = Image;

                    db.Customers.Add(customerData);
                    db.SaveChanges();

                    resultData.Data = customerData.Id;
                    resultData.Message = "Data Save Successfully !";
                }
                else if (Id > 0)
                {
                    Customer customerData = db.Customers.Where(c => c.Id == Id).FirstOrDefault();
                    if (customerData != null && customerData.Id > 0)
                    {
                        customerData.PersonName = PersonName;
                        customerData.MobileNo = MobileNo;
                        customerData.Designation = Designation;
                        customerData.CompanyName = CompanyName;
                        customerData.Address = Address;
                        customerData.Country = Country;
                        customerData.TelephoneNo = TelephoneNo;
                        customerData.Email = Email;
                        customerData.StateId = StateId;
                        customerData.CityId = CityId;
                        if (Image != "")
                            customerData.Image = Image;

                        db.SaveChanges();

                        resultData.Data = customerData.Id;
                        resultData.Message = "Data Updated Successfully !";

                    }
                }

                resultData.IsSuccess = true;
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [ActionName("UpdateVisitorPhoto")]
        public ResultData UpdateVisitorPhoto()
        {
            ResultData resultData = new ResultData();
            try
            {
                var properties = Request.Properties as Dictionary<string, object>;
                var requestObject = ((System.Web.HttpContextWrapper)(properties["MS_HttpContext"])).Request;

                string[] paths = sf.Upload(requestObject, Constants.FileTypeVisitor);
                long Id = Convert.ToInt64(requestObject.Form["Id"]);

                string Image = "";
                if (requestObject.Files.AllKeys.Any())
                    Image = paths[0];

                if (Id != null && Id != 0)
                {
                    Customer visitor = db.Customers.Where(m => m.Id == Id).FirstOrDefault();
                    if (visitor != null && Image != "")
                    {
                        visitor.Image = Image;
                        db.SaveChanges();
                    }

                    resultData.Data = Image;
                    resultData.Message = "Data Updated Successfully !";
                    resultData.IsSuccess = true;
                }
                else
                {
                    resultData.Data = 0;
                    resultData.Message = "Visitor Data Not Match";
                    resultData.IsSuccess = false;
                }

                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData DeleteVisitor(long id)
        {
            ResultData resultData = new ResultData();
            try
            {
                Customer customer = db.Customers.Where(t => t.Id == id).FirstOrDefault();
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }

                resultData.Message = "Data Deleted Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 1;
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData GetVisitor()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetCustomerData_Result> customerList = new List<GetCustomerData_Result>();
                customerList = db.GetCustomerData().ToList();
                if (customerList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = customerList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Customer Detail";
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

        //[HttpGet]
        //public ResultData GetCustomerCoupon(long visitorId)
        //{
        //    ResultData resultData = new ResultData();
        //    try
        //    {

        //        List<GetCustomerCouponData_Result> applyCouponList = new List<GetCustomerCouponData_Result>();
        //        applyCouponList = db.GetCustomerCouponData(visitorId).ToList();
        //        if (applyCouponList != null)
        //        {
        //            resultData.Message = "Data Get Successfully";
        //            resultData.IsSuccess = true;
        //            resultData.Data = applyCouponList;
        //            return resultData;
        //        }
        //        else
        //        {
        //            resultData.Message = "Invalid Customer Detail";
        //            resultData.IsSuccess = true;
        //            resultData.Data = 0;
        //            return resultData;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultData.Message = ex.Message.ToString();
        //        resultData.IsSuccess = false;
        //        resultData.Data = 0;
        //        return resultData;
        //    }

        //}

        [HttpGet]
        public ResultData GetCustomerCoupon(long visitorId)
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetExhibitorDataList> list = new List<GetExhibitorDataList>();

                string data = string.Format("select ac.ExhibitorId,e.PersonName from ApplyCoupon ac left join exhibitor e on ac.ExhibitorId= e.Id WHERE ac.CustomerId='{0}'", visitorId);
                DataTable dt = sf.GetData(data);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        GetExhibitorDataList exhibitorDataListData = new GetExhibitorDataList();
                        exhibitorDataListData.ExhibitorName = item["PersonName"].ToString();
                        List<GetCustomerCouponData_Result> couponList = new List<GetCustomerCouponData_Result>();
                        long exid = Convert.ToInt64(item["ExhibitorId"]);
                        couponList = db.GetCustomerCouponData(visitorId, exid).ToList();
                        exhibitorDataListData.CouponNo = couponList;
                        list.Add(exhibitorDataListData);
                    }
                }

                resultData.Message = "Get Data Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = list;
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }

        }

        [HttpPost]
        public ResultData UpdateVisitorProfile(Customer profiledata)
        {
            ResultData responseData = new ResultData();
            try
            {
                Customer dbCustomer = db.Customers.Where(m => m.Id == profiledata.Id).FirstOrDefault();
                if (dbCustomer != null && dbCustomer.Id > 0)
                {
                    dbCustomer.PersonName = profiledata.PersonName;
                    dbCustomer.MobileNo = profiledata.MobileNo;
                    dbCustomer.Designation = profiledata.Designation;
                    dbCustomer.Address = profiledata.Address;
                    dbCustomer.CompanyName = profiledata.CompanyName;
                    dbCustomer.Designation = profiledata.Designation;
                    dbCustomer.CityId = profiledata.CityId;
                    dbCustomer.StateId = profiledata.StateId;
                    dbCustomer.Country = profiledata.Country;
                    dbCustomer.TelephoneNo = profiledata.TelephoneNo;
                    dbCustomer.Email = profiledata.Email;
                    db.SaveChanges();
                }

                responseData.Message = "Data Updated Successfully";
                responseData.IsSuccess = true;
                responseData.Data = profiledata.Id;
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Message = ex.Message.ToString();
                responseData.IsSuccess = false;
                responseData.Data = 0;
                return responseData;
            }
        }

        [HttpGet]
        public ResultData GetCustomerCouponDetail(long visitorId,long ExhibitorId)
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetCustomerCouponDetail_Result> couponList = new List<GetCustomerCouponDetail_Result>();
                couponList = db.GetCustomerCouponDetail(visitorId, ExhibitorId).ToList();
                if (couponList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = couponList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Customer Detail";
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
        #endregion

        #region DailyDraw

        [HttpGet]
        public ResultData GetDailyDraw()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<DailyDraw> dailyDrawList = new List<DailyDraw>();
                dailyDrawList = db.DailyDraws.ToList();
                if (dailyDrawList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = dailyDrawList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid DailyDraw Detail";
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

        [HttpGet]
        public ResultData GetMeghaDraw()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<MegaDraw> dailyDrawList = new List<MegaDraw>();
                dailyDrawList = db.MegaDraws.ToList();
                if (dailyDrawList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = dailyDrawList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid MegaDraw Detail";
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


        #endregion

        #region RequestForCoupon

        [HttpPost]
        public ResultData SaveRequestForCoupon(RequestForCoupon requestforcoupon)
        {
            ResultData resultData = new ResultData();
            try
            {
                if (requestforcoupon != null && requestforcoupon.Id == 0)
                {
                    AssignCouponExhibitor assignCouponExhibitor = new AssignCouponExhibitor();
                    assignCouponExhibitor = db.AssignCouponExhibitors.Where(e => e.ExhibitorId == requestforcoupon.ExhibitorId).FirstOrDefault();
                    if (assignCouponExhibitor != null)
                    {
                        requestforcoupon.Date = DateTime.Now;
                        requestforcoupon.IsCompleted = false;
                        db.RequestForCoupons.Add(requestforcoupon);
                        db.SaveChanges();
                    }
                    else
                    {
                        string currdate = DateTime.Now.ToString("yyyy-MM-dd");
                        AssignCouponExhibitor assigncouponexhibitor = new AssignCouponExhibitor();
                        assigncouponexhibitor.CouponNo = GenerateCode().ToString();
                        assigncouponexhibitor.Date = currdate;
                        assigncouponexhibitor.ExhibitorId = requestforcoupon.ExhibitorId;
                        assigncouponexhibitor.Price = 0;
                        assigncouponexhibitor.Total = "0";
                        assigncouponexhibitor.Qty = "0";
                        db.AssignCouponExhibitors.Add(assigncouponexhibitor);
                        db.SaveChanges();

                        ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
                        exhibitorCouponQty.AssignCouponExhibitorId = assigncouponexhibitor.Id;
                        exhibitorCouponQty.Qty = 0;
                        db.ExhibitorCouponQties.Add(exhibitorCouponQty);
                        db.SaveChanges();

                        requestforcoupon.Date = DateTime.Now;
                        requestforcoupon.IsCompleted = false;
                        db.RequestForCoupons.Add(requestforcoupon);
                        db.SaveChanges();
                    }

                }
                else if (requestforcoupon.Id > 0)
                {
                    RequestForCoupon oldex = db.RequestForCoupons.Where(a => a.Id == requestforcoupon.Id).FirstOrDefault();
                    oldex.ExhibitorId = requestforcoupon.ExhibitorId;
                    oldex.Qty = requestforcoupon.Qty;
                    oldex.Note = requestforcoupon.Note;
                    db.RequestForCoupons.Add(oldex);
                    db.SaveChanges();
                }
                resultData.Message = "Data Saved Successfully";
                resultData.IsSuccess = true;
                resultData.Data = "1";
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        public int GenerateCode()
        {
            int code = 1001;
            try
            {
                AssignCouponExhibitor assigncouponexhibitor = db.AssignCouponExhibitors.OrderByDescending(s => s.Id).FirstOrDefault();
                if (assigncouponexhibitor != null && assigncouponexhibitor.Id > 0)
                {
                    code = Convert.ToInt32(assigncouponexhibitor.CouponNo) + 1;
                }
                return code;
            }
            catch (Exception)
            {
                return code;
            }
        }


        [HttpGet]
        public ResultData GetRequestForCoupons(long exhibitorId)
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetRequestCouponData_Result> requestCouponList = new List<GetRequestCouponData_Result>();
                requestCouponList = db.GetRequestCouponData(exhibitorId).ToList();
                if (requestCouponList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = requestCouponList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid RequestCoupn Detail";
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

        #endregion

        #region AssignCouponToCustomer

        //[HttpPost]
        //public ResultData SaveApplyCoupon(ApplyCoupon data)
        //{
        //    ResultData resultData = new ResultData();
        //    try
        //    {
        //        ApplyCoupon list = new ApplyCoupon();
        //        list = db.ApplyCoupons.Where(a => a.CustomerId == data.CustomerId && a.ExhibitorId == data.ExhibitorId).FirstOrDefault();
        //        if (list != null)
        //        {
        //            ApplyCoupon applycoupon = new ApplyCoupon();
        //            applycoupon = db.ApplyCoupons.Where(a => a.Id == list.Id).FirstOrDefault();
        //            if (applycoupon != null)
        //            {
        //                int extqty = Convert.ToInt32(applycoupon.Qty);
        //                int newprice = (Convert.ToInt32(data.Qty) + extqty) * 1000;
        //                int newqty = (extqty + Convert.ToInt32(data.Qty));
        //                applycoupon.Qty = Convert.ToString(newqty);
        //                applycoupon.Price = newprice;

        //                db.SaveChanges();

        //                AssignCouponExhibitor assignCouponExhibitor = new AssignCouponExhibitor();
        //                assignCouponExhibitor = db.AssignCouponExhibitors.Where(e => e.ExhibitorId == applycoupon.ExhibitorId).FirstOrDefault();
        //                if (assignCouponExhibitor != null)
        //                {
        //                    ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
        //                    exhibitorCouponQty = db.ExhibitorCouponQties.Where(e => e.AssignCouponExhibitorId == assignCouponExhibitor.Id).FirstOrDefault();
        //                    if (exhibitorCouponQty != null)
        //                    {
        //                        int qty = (Convert.ToInt32(exhibitorCouponQty.Qty) - Convert.ToInt32(data.Qty));
        //                        exhibitorCouponQty.Qty = qty;
        //                        db.SaveChanges();
        //                    }

        //                }

        //                for (var i = 0; i < Convert.ToInt32(data.Qty); i++)
        //                {
        //                    Random generator = new Random();
        //                    string code = generator.Next(1000, 9999).ToString();

        //                    CustomerCoupon customer = new CustomerCoupon();
        //                    customer.CouponNo = code;
        //                    customer.AssignCouponId = list.Id;

        //                    db.CustomerCoupons.Add(customer);
        //                    db.SaveChanges();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            data.Price = (Convert.ToInt32(data.Qty) * 1000);
        //            data.Date = DateTime.Now;
        //            db.ApplyCoupons.Add(data);
        //            db.SaveChanges();

        //            AssignCouponExhibitor assignCouponExhibitor = new AssignCouponExhibitor();
        //            assignCouponExhibitor = db.AssignCouponExhibitors.Where(e => e.ExhibitorId == data.ExhibitorId).FirstOrDefault();
        //            if (assignCouponExhibitor != null)
        //            {
        //                ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
        //                exhibitorCouponQty = db.ExhibitorCouponQties.Where(e => e.AssignCouponExhibitorId == assignCouponExhibitor.Id).FirstOrDefault();
        //                if (exhibitorCouponQty != null)
        //                {
        //                    int qty = (Convert.ToInt32(exhibitorCouponQty.Qty) - Convert.ToInt32(data.Qty));
        //                    exhibitorCouponQty.Qty = qty;
        //                    db.SaveChanges();
        //                }

        //            }

        //            for (var i = 0; i < Convert.ToInt32(data.Qty); i++)
        //            {
        //                Random generator = new Random();
        //                string code = generator.Next(1000, 9999).ToString();

        //                CustomerCoupon customer = new CustomerCoupon();
        //                customer.CouponNo = code;
        //                customer.AssignCouponId = data.Id;

        //                db.CustomerCoupons.Add(customer);
        //                db.SaveChanges();
        //            }
        //        }


        //        resultData.Message = "Data Saved Successfully";
        //        resultData.IsSuccess = true;
        //        resultData.Data = 1;
        //        return resultData;
        //    }
        //    catch (Exception ex)
        //    {
        //        resultData.Message = ex.Message.ToString();
        //        resultData.IsSuccess = false;
        //        resultData.Data = 0;
        //        return resultData;
        //    }
        //}

        [HttpPost]
        public ResultData SaveApplyCoupon(ApplyCoupon data)
        {
            ResultData resultData = new ResultData();
            try
            {
                AssignCouponExhibitor datacoupon = new AssignCouponExhibitor();
                datacoupon = db.AssignCouponExhibitors.Where(a => a.ExhibitorId == data.ExhibitorId).FirstOrDefault();
                DataTable dtw = sf.GetData("SELECT * FROM AssignCouponExhibitor WHERE ExhibitorId='"+ data.ExhibitorId + "'");
                if (datacoupon.ExhibitorId != null)
                {
                    ExhibitorCouponQty exhibitorCouponQtyData = new ExhibitorCouponQty();
                    exhibitorCouponQtyData = db.ExhibitorCouponQties.Where(a => a.AssignCouponExhibitorId == datacoupon.Id).FirstOrDefault();
                    if (exhibitorCouponQtyData != null)
                    {
                        //string Dataq = "SELECT SUM(Convert(int,Qty)) as Qty FROM RequestForCoupon WHERE ExhibitorId='" + data.ExhibitorId + "' AND IsCompleted=1";
                        //DataTable dte = sf.GetData(Dataq);
                        //int ReqQty = Convert.ToInt32(dte.Rows[0]["Qty"]);
                        int existingqty = Convert.ToInt32(exhibitorCouponQtyData.Qty);
                        if (existingqty >= Convert.ToInt32(data.Qty))
                        {
                            ApplyCoupon list = new ApplyCoupon();
                            list = db.ApplyCoupons.Where(a => a.CustomerId == data.CustomerId && a.ExhibitorId == data.ExhibitorId).FirstOrDefault();
                            if (list != null)
                            {
                                ApplyCoupon applycoupon = new ApplyCoupon();
                                applycoupon = db.ApplyCoupons.Where(a => a.Id == list.Id).FirstOrDefault();
                                if (applycoupon != null)
                                {
                                    int extqty = Convert.ToInt32(applycoupon.Qty);
                                    int newprice = (Convert.ToInt32(data.Qty) + extqty) * 1000;
                                    int newqty = (extqty + Convert.ToInt32(data.Qty));
                                    applycoupon.Qty = Convert.ToString(newqty);
                                    applycoupon.Price = newprice;

                                    db.SaveChanges();

                                    AssignCouponExhibitor assignCouponExhibitor = new AssignCouponExhibitor();
                                    assignCouponExhibitor = db.AssignCouponExhibitors.Where(e => e.ExhibitorId == applycoupon.ExhibitorId).FirstOrDefault();
                                    if (assignCouponExhibitor != null)
                                    {
                                        ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
                                        exhibitorCouponQty = db.ExhibitorCouponQties.Where(e => e.AssignCouponExhibitorId == assignCouponExhibitor.Id).FirstOrDefault();
                                        if (exhibitorCouponQty != null)
                                        {
                                            int qty = (Convert.ToInt32(exhibitorCouponQty.Qty) - Convert.ToInt32(data.Qty));
                                            exhibitorCouponQty.Qty = qty;
                                            db.SaveChanges();
                                        }

                                    }

                                    for (var i = 0; i < Convert.ToInt32(data.Qty); i++)
                                    {
                                        Random generator = new Random();
                                        string code = generator.Next(1000, 9999).ToString();
                                        newcodegen:
                                        string dupcheck = string.Format("SELECT * FROM CustomerCoupon WHERE CouponNo='{0}'", code);
                                        DataTable dt = sf.GetData(dupcheck);
                                        if(dt.Rows.Count > 0)
                                        {
                                            goto newcodegen;
                                        }
                                        else
                                        {
                                            CustomerCoupon customer = new CustomerCoupon();
                                            customer.CouponNo = code;
                                            customer.AssignCouponId = list.Id;
                                            customer.IsActive = true;

                                            db.CustomerCoupons.Add(customer);
                                            db.SaveChanges();
                                        }
                                    }
                                    GetCusmoterMobile_Result mobile = new GetCusmoterMobile_Result();
                                    mobile = db.GetCusmoterMobile(data.CustomerId).Where(a => a.ExhibitorId == applycoupon.ExhibitorId).FirstOrDefault();
                                    if (mobile != null)
                                    {
                                        
                                        string title = "Coupon Assigned";
                                        string message = "" + mobile.CompanyName.ToUpper() + " Has Assigned You " + data.Qty + " Coupons !";
                                        SendPushNotification(mobile.FCMToken, message, title);
                                        string qry = string.Format("insert into Notification(Title,Message,Date,ExhibitorId,CustomerId) values('" + title + "','" + message + "','" + DateTime.Now + "',0,'" + data.CustomerId + "')");
                                        sf.ExecuteQuery(qry);
                                        SendSMS sms = new SendSMS();
                                        string res = sms.sendotp("" + mobile.CompanyName.ToUpper() + " Has Assigned You " + data.Qty + " Coupons!", mobile.MobileNo);
                                    }
                                }
                            }
                            else
                            {
                                data.Price = (Convert.ToInt32(data.Qty) * 1000);
                                data.Date = DateTime.Now;
                                db.ApplyCoupons.Add(data);
                                db.SaveChanges();

                                AssignCouponExhibitor assignCouponExhibitor = new AssignCouponExhibitor();
                                assignCouponExhibitor = db.AssignCouponExhibitors.Where(e => e.ExhibitorId == data.ExhibitorId).FirstOrDefault();
                                if (assignCouponExhibitor != null)
                                {
                                    ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
                                    exhibitorCouponQty = db.ExhibitorCouponQties.Where(e => e.AssignCouponExhibitorId == assignCouponExhibitor.Id).FirstOrDefault();
                                    if (exhibitorCouponQty != null)
                                    {
                                        int qty = (Convert.ToInt32(exhibitorCouponQty.Qty) - Convert.ToInt32(data.Qty));
                                        exhibitorCouponQty.Qty = qty;
                                        db.SaveChanges();
                                    }

                                }

                                for (var i = 0; i < Convert.ToInt32(data.Qty); i++)
                                {
                                    newgen:
                                    Random generator = new Random();
                                    string code = generator.Next(1000, 9999).ToString();

                                    string dupcheck = string.Format("SELECT * FROM CustomerCoupon WHERE CouponNo='{0}'", code);
                                    DataTable dt = sf.GetData(dupcheck);
                                    if(dt.Rows.Count > 0)
                                    {
                                        goto newgen;
                                    }
                                    else
                                    {
                                        CustomerCoupon customer = new CustomerCoupon();
                                        customer.CouponNo = code;
                                        customer.AssignCouponId = data.Id;
                                        customer.IsActive = true;

                                        db.CustomerCoupons.Add(customer);
                                        db.SaveChanges();
                                    }
                                    

                                }
                                GetCusmoterMobile_Result mobile = new GetCusmoterMobile_Result();
                                mobile = db.GetCusmoterMobile(list.CustomerId).Where(a => a.ExhibitorId == data.ExhibitorId).FirstOrDefault();
                                if (mobile != null)
                                {
                                    string title = "Coupon Assigned";
                                    string message = "" + mobile.CompanyName.ToUpper() + " Has Assigned You " + data.Qty + " Coupons !";
                                    SendPushNotification(mobile.FCMToken, message, title);
                                    string qry = string.Format("insert into Notification(Title,Message,Date,ExhibitorId,CustomerId) values('" + title + "','" + message + "','" + DateTime.Now + "',0,'" + data.CustomerId + "')");
                                    sf.ExecuteQuery(qry);
                                    SendSMS sms = new SendSMS();
                                    string res = sms.sendotp("" + mobile.CompanyName.ToUpper() + " Has Assigned You " + data.Qty + " Coupons!", mobile.MobileNo);
                                }

                            }


                            resultData.Message = "Data Saved Successfully";
                            resultData.IsSuccess = true;
                            resultData.Data = 1;
                            return resultData;
                        }
                        else
                        {
                            resultData.Message = "You Don't Have Any Coupon";
                            resultData.IsSuccess = false;
                            resultData.Data = 0;
                            return resultData;
                        }
                    }
                    else
                    {
                        resultData.Message = "Invalid Id";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                else
                {
                    resultData.Message = "Invalid Exhibitor";
                    resultData.IsSuccess = false;
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

        #endregion

        #region State

        [HttpGet]
        public ResultData GetState()
        {
            ResultData resultData = new ResultData();
            try
            {
                List<State> state = new List<State>();
                state = db.States.ToList();
                if (state != null)
                {
                    resultData.Message = "Data Get Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = state;
                    return resultData;
                }
                else
                {
                    resultData.Message = "No Data Found !";
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

        #endregion

        #region City

        [HttpGet]
        public ResultData GetCity(long stateId)
        {
            ResultData resultData = new ResultData();
            try
            {
                List<City> city = new List<City>();
                city = db.Cities.Where(c => c.StateId == stateId).ToList();
                if (city != null)
                {
                    resultData.Message = "Data Get Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = city;
                    return resultData;
                }
                else
                {
                    resultData.Message = "No Data Found !";
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

        #endregion

        #region SearchMobile

        [HttpGet]
        public ResultData GetVisitorDataByMobileOrId(long visitorid, string mobile)
        {
            ResultData resultData = new ResultData();
            try
            {
                long idd = visitorid != null ? visitorid : 0;
                string mobileno = mobile != null ? mobile : "";
                List<GetVisitorDataByMobileOrId_Result> visitorByCodeOrId = new List<GetVisitorDataByMobileOrId_Result>();
                visitorByCodeOrId = db.GetVisitorDataByMobileOrId(mobileno, idd).ToList();
                if (visitorByCodeOrId != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = visitorByCodeOrId;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Visitor Detail";
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

        #endregion

        #region DrawWinnerList

        [HttpGet]
        public ResultData GetDrawWinnerList()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetDrawWinnerListData_Result> drawWinnerList = new List<GetDrawWinnerListData_Result>();
                drawWinnerList = db.GetDrawWinnerListData().ToList();
                if (drawWinnerList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = drawWinnerList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Customer Detail";
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


        [HttpGet]
        public ResultData MegaDrawWinner()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetMegaDrawWinnerData_Result> drawWinnerList = new List<GetMegaDrawWinnerData_Result>();
                drawWinnerList = db.GetMegaDrawWinnerData().ToList();
                if (drawWinnerList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = drawWinnerList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Winner Detail";
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


        #endregion

        [HttpGet]
        public ResultData Updategoolgelocation(long Id, string GoolgeLocation)
        {
            ResultData responseData = new ResultData();
            try
            {
                Exhibitor oldex = db.Exhibitors.Where(a => a.Id == Id).FirstOrDefault();
                if (oldex != null && oldex.Id > 0)
                {
                    oldex.GoogleLocation = GoolgeLocation;
                    db.SaveChanges();
                }

                responseData.Message = "Data Updated Successfully";
                responseData.IsSuccess = true;
                responseData.Data = 1;
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Message = ex.Message.ToString();
                responseData.IsSuccess = false;
                responseData.Data = 0;
                return responseData;
            }
        }

        #region UpdateFcmToken

        [HttpGet]
        public ResultData UpdateVisitorFCMToken(long visitorId, string fcmToken)
        {
            ResultData resultData = new ResultData();
            try
            {
                db.UpdateVisitorFcmToken(visitorId, fcmToken);
                resultData.Message = "Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 1;
                return resultData;

            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData UpdateExhibitorFCMToken(long exhibitorId, string fcmToken)
        {
            ResultData resultData = new ResultData();
            try
            {
                db.UpdateExhibitorFcmToken(exhibitorId, fcmToken);
                resultData.Message = "Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 1;
                return resultData;

            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData UpdateCouponStatus(long couponId)
        {
            ResultData resultData = new ResultData();
            try
            {
                db.UpdateCustomerCouponStatus(couponId);

                CustomerCoupon customerCoupon = new CustomerCoupon();
                customerCoupon = db.CustomerCoupons.Where(c => c.Id == couponId).FirstOrDefault();
                if (customerCoupon != null)
                {
                    ApplyCoupon applyCoupon = new ApplyCoupon();
                    applyCoupon = db.ApplyCoupons.Where(a => a.Id == customerCoupon.AssignCouponId).FirstOrDefault();
                    if (applyCoupon != null)
                    {
                        int extqty = Convert.ToInt32(applyCoupon.Qty);
                        int newqty = 0;
                        if (extqty == 0)
                        {
                            newqty = 0;
                        }
                        else
                        {
                            newqty = (extqty - 1);
                        }
                        int extprice = Convert.ToInt32(applyCoupon.Price);
                        int newprice = 0;
                        if (extprice == 0)
                        {
                            newprice = 0;
                        }
                        else
                        {
                            newprice = (extprice - 1000); ;
                        }
                        applyCoupon.Qty = Convert.ToString(newqty);
                        applyCoupon.Price = newprice;
                        db.SaveChanges();

                        AssignCouponExhibitor assignCouponExhibitor = new AssignCouponExhibitor();
                        assignCouponExhibitor = db.AssignCouponExhibitors.Where(a => a.Id == applyCoupon.ExhibitorId).FirstOrDefault();
                        if(assignCouponExhibitor != null)
                        {
                            ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
                            exhibitorCouponQty = db.ExhibitorCouponQties.Where(e => e.AssignCouponExhibitorId == assignCouponExhibitor.Id).FirstOrDefault();
                            if(exhibitorCouponQty != null)
                            {
                                int exitingqty = Convert.ToInt32(exhibitorCouponQty.Qty);
                                int newcoupon = (exitingqty + 1);

                                exhibitorCouponQty.Qty = newcoupon;
                                db.SaveChanges();
                            }
                        }

                        GetCusmoterMobile_Result mobiledata = new GetCusmoterMobile_Result();
                        mobiledata = db.GetCusmoterMobile(applyCoupon.CustomerId).Where(a =>a.ExhibitorId== applyCoupon.ExhibitorId).FirstOrDefault();
                        if (mobiledata != null)
                        {
                            string message = "" + mobiledata.CompanyName + " Cancel your Coupon No:" + customerCoupon.CouponNo + "";
                            SendPushNotification(mobiledata.FCMToken, message, "Coupon Cancelled");
                            string qry = string.Format("insert into Notification(Title,Message,Date,ExhibitorId,CustomerId) values('Coupon Cancelled','" + message + "','" + DateTime.Now + "',0,'" + applyCoupon.CustomerId + "')");
                            sf.ExecuteQuery(qry);
                            SendSMS sms = new SendSMS();
                            string res = sms.sendotp(""+mobiledata.CompanyName+" Cancel your Coupon No:"+ customerCoupon.CouponNo + "", mobiledata.CustomerMobile);
                        }
                       
                    }
                }

                resultData.Message = " Data Save Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 1;
                return resultData;

            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.IsSuccess = false;
                resultData.Data = 0;
                return resultData;
            }
        }


        [HttpGet]
        public ResultData GetNotification(long id,string type)
        {
            ResultData resultData = new ResultData();
            try
            {
                if (type == "Exhibitor")
                {

                    List<Notification> notificationList = new List<Notification>();
                    notificationList = db.Notifications.Where(n => n.ExhibitorId == id).OrderByDescending(a =>a.Id).ToList();
                    if (notificationList != null)
                    {

                        resultData.Message = "Data Get Successfully";
                        resultData.IsSuccess = true;
                        resultData.Data = notificationList;
                        return resultData;
                    }
                    else
                    {
                        resultData.Message = "Invalid Notification Detail";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                else if(type == "Visitor")
                {
                    List<Notification> notificationList = new List<Notification>();
                    notificationList = db.Notifications.Where(n => n.CustomerId == id).OrderByDescending(a => a.Id).ToList();
                    if (notificationList != null)
                    {

                        resultData.Message = "Data Get Successfully";
                        resultData.IsSuccess = true;
                        resultData.Data = notificationList;
                        return resultData;
                    }
                    else
                    {
                        resultData.Message = "Invalid Notification Detail";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                else
                {
                    resultData.Message = "Invalid Data Detail";
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

        #endregion

        public void SendPushNotification(string deviceId, string message, string title)
        {
            try
            {
                WebRequest trequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                trequest.Method = "post";
                //serverkey - key from firebase cloud messaging server  
                trequest.Headers.Add(string.Format("authorization: key={0}", "AAAA625APsI:APA91bHQvG0G_xb1_62yi3tEbGb-w0DvYWeoLysuGTDEm1cGUlllx54sFaH_QLdy6cflsd3muMcsfSuIhbL72RL6Xmnjsm4jco6xKobonr0dfY-_NAgi_ew6TWBco2b6cm-Fy1un-Rr6"));
                //sender id - from firebase project setting  
                trequest.Headers.Add(string.Format("sender: id={0}", "1011167018690"));
                trequest.ContentType = "application/json";
                var payload = new
                {
                    to = deviceId,
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        body = message,
                        title = title,
                        badge = 1
                    }
                };

                string postbody = JsonConvert.SerializeObject(payload).ToString();
                byte[] bytearray = Encoding.UTF8.GetBytes(postbody);
                trequest.ContentLength = bytearray.Length;
                using (Stream datastream = trequest.GetRequestStream())
                {
                    datastream.Write(bytearray, 0, bytearray.Length);
                    using (WebResponse tresponse = trequest.GetResponse())
                    {
                        using (Stream datastreamresponse = tresponse.GetResponseStream())
                        {
                            if (datastreamresponse != null) using (StreamReader treader = new StreamReader(datastreamresponse))
                                {
                                    string sresponsefromserver = treader.ReadToEnd();
                                    //result.response = sresponsefromserver;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

    }
}
