using GGJWEvent.Models;
using Newtonsoft.Json;
using GGJWEvent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;

namespace GGJWEvent.Controllers
{
    public class HomeAPIController : ApiController
    {
        GGJWEventEntities db = new GGJWEventEntities();
        StudyField sf = new StudyField();

        #region Exhibitor
        //[ActionName("SaveExhibitor")]
        //public ResultData SaveExhibitor()
        //{
        //    ResultData resultData = new ResultData();
        //    try
        //    {
        //        var properties = Request.Properties as Dictionary<string, object>;
        //        var requestObject = ((System.Web.HttpContextWrapper)(properties["MS_HttpContext"])).Request;
        //        long Id = Convert.ToInt64(requestObject.Form["Id"]);
        //        string MobileNo = Convert.ToString(requestObject.Form["MobileNo"]);
        //        if (Id != null && Id == 0)
        //        {
        //            List<Exhibitor> customerList = new List<Exhibitor>();
        //            customerList = db.Exhibitors.Where(n => n.MobileNo == MobileNo).ToList();
        //            if (customerList.Count > 0)
        //            {
        //                resultData.Message = "Mobile Already Exist !";
        //                resultData.IsSuccess = true;
        //                resultData.Data = 0;
        //                return resultData;
        //            }
        //        }

        //        string[] paths = sf.Upload(requestObject, Constants.FileTypeExhibitor);

        //        string PersonName = Convert.ToString(requestObject.Form["PersonName"]);
        //        string Designation = Convert.ToString(requestObject.Form["Designation"]);
        //        string CompanyName = Convert.ToString(requestObject.Form["CompanyName"]);
        //        string Address = Convert.ToString(requestObject.Form["Address"]);
        //        string Address1 = Convert.ToString(requestObject.Form["Address1"]);
        //        string Address2 = Convert.ToString(requestObject.Form["Address2"]);
        //        string Country = Convert.ToString(requestObject.Form["Country"]);
        //        string TelephoneNo = Convert.ToString(requestObject.Form["TelephoneNo"]);
        //        string Email = Convert.ToString(requestObject.Form["Email"]);
        //        long StateId = Convert.ToInt64(requestObject.Form["StateId"]);
        //        long CityId = Convert.ToInt64(requestObject.Form["CityId"]);
        //        string GoogleLocation = Convert.ToString(requestObject.Form["GoogleLocation"]);
        //        string LatLong = Convert.ToString(requestObject.Form["LatLong"]);
        //        string LatLong2 = Convert.ToString(requestObject.Form["LatLong2"]);
        //        string LatLong3 = Convert.ToString(requestObject.Form["LatLong3"]);
        //        string Image = "";
        //        if (requestObject.Files.AllKeys.Any())
        //            Image = paths[0];

        //        if (Id != null && Id == 0)
        //        {
        //            Exhibitor oldex = new Exhibitor();
        //            oldex.MobileNo = MobileNo;
        //            oldex.PersonName = PersonName;
        //            oldex.StateId = StateId;
        //            oldex.TelephoneNo = TelephoneNo;
        //            oldex.Email = Email;
        //            oldex.Designation = Designation;
        //            oldex.Country = Country;
        //            oldex.CityId = CityId;
        //            oldex.Address = Address;
        //            oldex.Address1 = Address1;
        //            oldex.Address2 = Address2;
        //            oldex.CompanyName = CompanyName;
        //            oldex.GoogleLocation = GoogleLocation;
        //            oldex.LatLong = LatLong;
        //            oldex.LatLong2 = LatLong2;
        //            oldex.LatLong3 = LatLong3;
        //            oldex.Image = Image;
        //            db.Exhibitors.Add(oldex);
        //            db.SaveChanges();
        //            DataTable dt = sf.GetData("SELECT TOP 1 * FROM Exhibitor ORDER BY Id DESC");
        //            string Ids = dt.Rows[0]["Id"].ToString();
        //            string str = string.Format("INSERT INTO AssignCouponExhibitor(ExhibitorId,Price,Qty,Total,Date) VALUES('{0}','{1}','{2}','{3}','{4}')", Ids, 0, 0, 0, DateTime.Now.ToString("yyyy-MM-dd"));
        //            sf.ExecuteQuery(str);
        //            DataTable dts = sf.GetData("SELECT TOP 1 * FROM AssignCouponExhibitor ORDER BY Id DESC");
        //            string Idss = dts.Rows[0]["Id"].ToString();
        //            string strs = string.Format("INSERT INTO ExhibitorCouponQty(AssignCouponExhibitorId,Qty) VALUES('{0}','{1}')", Idss, 0);
        //            sf.ExecuteQuery(strs);
        //        }
        //        else if (Id > 0)
        //        {
        //            Exhibitor oldex = db.Exhibitors.Where(a => a.Id == Id).FirstOrDefault();
        //            {
        //                Exhibitor exh = new Exhibitor();
        //                exh = db.Exhibitors.Where(e => e.Id == Id && e.MobileNo == MobileNo).FirstOrDefault();
        //                if(exh != null)
        //                {
        //                    oldex.MobileNo = MobileNo;
        //                    oldex.PersonName = PersonName;
        //                    oldex.StateId = StateId;
        //                    oldex.TelephoneNo = TelephoneNo;
        //                    oldex.Email = Email;
        //                    oldex.Designation = Designation;
        //                    oldex.Country = Country;
        //                    oldex.CityId = CityId;
        //                    oldex.Address = Address;
        //                    oldex.Address1 = Address1;
        //                    oldex.Address2 = Address2;
        //                    oldex.CompanyName = CompanyName;
        //                    oldex.GoogleLocation = GoogleLocation;
        //                    oldex.LatLong = LatLong;
        //                    oldex.LatLong2 = LatLong2;
        //                    oldex.LatLong3 = LatLong3;
        //                    if (Image != "")
        //                        oldex.Image = Image;
        //                    db.SaveChanges();
        //                }
        //                else
        //                {
        //                    Exhibitor exhibi = new Exhibitor();
        //                    exhibi = db.Exhibitors.Where(e => e.MobileNo == MobileNo).FirstOrDefault();
        //                    if(exhibi != null)
        //                    {
        //                        resultData.Message = "Mobile Already Exist !";
        //                        resultData.IsSuccess = true;
        //                        resultData.Data = 0;
        //                        return resultData;
        //                    }
        //                    else
        //                    {
        //                        oldex.MobileNo = MobileNo;
        //                        oldex.PersonName = PersonName;
        //                        oldex.StateId = StateId;
        //                        oldex.TelephoneNo = TelephoneNo;
        //                        oldex.Email = Email;
        //                        oldex.Designation = Designation;
        //                        oldex.Country = Country;
        //                        oldex.CityId = CityId;
        //                        oldex.Address = Address;
        //                        oldex.Address1 = Address1;
        //                        oldex.Address2 = Address2;
        //                        oldex.CompanyName = CompanyName;
        //                        oldex.GoogleLocation = GoogleLocation;
        //                        oldex.LatLong = LatLong;
        //                        oldex.LatLong2 = LatLong2;
        //                        oldex.LatLong3 = LatLong3;
        //                        if (Image != "")
        //                            oldex.Image = Image;
        //                        db.SaveChanges();
        //                    }

        //                }
        //            }
                  
        //        }

        //        resultData.Message = "Data Saved Successfully";
        //        resultData.IsSuccess = true;
        //        resultData.Data = "Image";
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
        [ActionName("SaveExhibitorV1")]
        public ResultData SaveExhibitorV1()
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
                    List<Exhibitor> customerList = new List<Exhibitor>();
                    customerList = db.Exhibitors.Where(n => n.MobileNo == MobileNo).ToList();
                    if (customerList.Count > 0)
                    {
                        resultData.Message = "Mobile Already Exist !";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                string[] paths = sf.Upload(requestObject, Constants.FileTypeExhibitor);
                string PersonName = Convert.ToString(requestObject.Form["PersonName"]);
                string Designation = Convert.ToString(requestObject.Form["Designation"]);
                string CompanyName = Convert.ToString(requestObject.Form["CompanyName"]);
                string Country = Convert.ToString(requestObject.Form["Country"]);
                string TelephoneNo = Convert.ToString(requestObject.Form["TelephoneNo"]);
                string Email = Convert.ToString(requestObject.Form["Email"]);
                string Addresses = Convert.ToString(requestObject.Form["Addresses"]);
                JArray jsonVal = JArray.Parse(Addresses) as JArray; ;
               
                string Image = "";
                if (requestObject.Files.AllKeys.Any())
                       Image = paths[0];



                if (Id != null && Id == 0)
                {
                    Exhibitor oldex = new Exhibitor();
                    oldex.MobileNo = MobileNo;
                    oldex.PersonName = PersonName;
                    oldex.TelephoneNo = TelephoneNo;
                    oldex.Email = Email;
                    oldex.Designation = Designation;
                    oldex.Country = Country;
                    oldex.CompanyName = CompanyName;
                    oldex.Image = Image;
                    db.Exhibitors.Add(oldex);
                    db.SaveChanges();

                    DataTable dt = sf.GetData("SELECT TOP 1 * FROM Exhibitor ORDER BY Id DESC");
                    string Ids = dt.Rows[0]["Id"].ToString();
                    dynamic AddressesList = jsonVal;
                    foreach (dynamic exhibitor in AddressesList)
                    {
                        string a = string.Format("INSERT INTO ExhibitorAddress(Address,Latlong,StateId,CityId,ExhibitorId) VALUES('{0}','{1}','{2}','{3}','{4}')", exhibitor.Address, exhibitor.Latlong,exhibitor.StateId,exhibitor.CityId, Ids);
                        sf.ExecuteQuery(a);
                    }
                    string str = string.Format("INSERT INTO AssignCouponExhibitor(ExhibitorId,Price,Qty,Total,Date) VALUES('{0}','{1}','{2}','{3}','{4}')", Ids, 0, 0, 0, DateTime.Now.ToString("yyyy-MM-dd"));
                    sf.ExecuteQuery(str);
                    DataTable dts = sf.GetData("SELECT TOP 1 * FROM AssignCouponExhibitor ORDER BY Id DESC");
                    string Idss = dts.Rows[0]["Id"].ToString();
                    string strs = string.Format("INSERT INTO ExhibitorCouponQty(AssignCouponExhibitorId,Qty) VALUES('{0}','{1}')", Idss, 0);
                    sf.ExecuteQuery(strs);
                }
                else if (Id > 0)
                {
                    Exhibitor oldex = db.Exhibitors.Where(a => a.Id == Id).FirstOrDefault();
                    {
                        Exhibitor exh = new Exhibitor();
                        exh = db.Exhibitors.Where(e => e.Id == Id && e.MobileNo == MobileNo).FirstOrDefault();
                        if (exh != null)
                        {
                            oldex.MobileNo = MobileNo;
                            oldex.PersonName = PersonName;
                            oldex.TelephoneNo = TelephoneNo;
                            oldex.Email = Email;
                            oldex.Designation = Designation;
                            oldex.Country = Country;
                            oldex.CompanyName = CompanyName;
                            if (Image != "")
                                oldex.Image = Image;
                            db.SaveChanges();

                            dynamic AddressesList = jsonVal;
                            string aa = string.Format("SELECT * FROM ExhibitorAddress WHERE ExhibitorId='{0}'", Id);
                            DataTable dte = sf.GetData(aa);
                            if(dte.Rows.Count > 0)
                            {
                                string d = string.Format("DELETE FROM ExhibitorAddress WHERE ExhibitorId='{0}'", Id);
                                sf.ExecuteQuery(d);
                                foreach (dynamic exhibitor in AddressesList)
                                {
                                    string a = string.Format("INSERT INTO ExhibitorAddress(Address,Latlong,StateId,CityId,ExhibitorId) VALUES('{0}','{1}','{2}','{3}','{4}')", exhibitor.Address, exhibitor.Latlong, exhibitor.StateId, exhibitor.CityId, Id);
                                    sf.ExecuteQuery(a);
                                }
                            }
                        }
                        else
                        {
                            Exhibitor exhibi = new Exhibitor();
                            exhibi = db.Exhibitors.Where(e => e.MobileNo == MobileNo).FirstOrDefault();
                            if (exhibi != null)
                            {
                                resultData.Message = "Mobile Already Exist !";
                                resultData.IsSuccess = true;
                                resultData.Data = 0;
                                return resultData;
                            }
                            else
                            {
                                oldex.MobileNo = MobileNo;
                                oldex.PersonName = PersonName;
                                oldex.TelephoneNo = TelephoneNo;
                                oldex.Email = Email;
                                oldex.Designation = Designation;
                                oldex.Country = Country;
                                oldex.CompanyName = CompanyName;
                                if (Image != "")
                                    oldex.Image = Image;
                                db.SaveChanges();

                                dynamic AddressesList = jsonVal;
                                string aa = string.Format("SELECT * FROM ExhibitorAddress WHERE ExhibitorId='{0}'", Id);
                                DataTable dte = sf.GetData(aa);
                                if (dte.Rows.Count > 0)
                                {
                                    string d = string.Format("DELETE FROM ExhibitorAddress WHERE ExhibitorId='{0}'", Id);
                                    sf.ExecuteQuery(d);
                                    foreach (dynamic exhibitor in AddressesList)
                                    {
                                        string a = string.Format("INSERT INTO ExhibitorAddress(Address,Latlong,StateId,CityId,ExhibitorId) VALUES('{0}','{1}','{2}','{3}','{4}')", exhibitor.Address, exhibitor.Latlong, exhibitor.StateId, exhibitor.CityId, Id);
                                        sf.ExecuteQuery(a);
                                    }
                                }
                            }

                        }
                    }

                }


                resultData.Message = "Data Saved Successfully";
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
        public ResultData DeleteExhibitor(int Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                Exhibitor oldex = db.Exhibitors.Where(a => a.Id == Id).FirstOrDefault();
                db.Exhibitors.Remove(oldex);
                db.SaveChanges();
                sf.ExecuteQuery(string.Format("DELETE FROM ExhibitorAddress WHERE ExhibitorId='{0}'", Id));
                DataTable dr = sf.GetData(string.Format("SELECT *  FROM AssignCouponExhibitor WHERE ExhibitorId='{0}'", Id));
                foreach (DataRow item in dr.Rows)
                {
                    sf.ExecuteQuery(string.Format("DELETE FROM ExhibitorCouponQty WHERE AssignCouponExhibitorId='{0}'", item["Id"].ToString()));
                    sf.ExecuteQuery(string.Format("DELETE FROM AssignCouponExhibitor WHERE ExhibitorId='{0}'", item["Id"].ToString()));
                }
                
                resultData.Message = "Data Deleted Successfully";
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
                    exhibitor.IsVerified = item["IsVerified"] == DBNull.Value?false:Convert.ToBoolean(item["IsVerified"]);
                    exhibitor.Image = Convert.ToString(item["Image"]);

                    List<GetExhibitorAddresses> addlist = new List<GetExhibitorAddresses>();
                    string b = string.Format("SELECT * FROM ExhibitorAddress WHERE ExhibitorId='{0}'",Convert.ToInt32(item["Id"]));
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
        #endregion

        #region RequestForCoupon
        [HttpPost]
        public ResultData SaveRequestCoupon(RequestForCoupon requestforcoupon)
        {
            ResultData resultData = new ResultData();
            try
            {
                if (requestforcoupon != null && requestforcoupon.Id == 0)
                {
                    db.RequestForCoupons.Add(requestforcoupon);
                    db.SaveChanges();
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

        [HttpGet]
        public ResultData DeleteRequestCoupon(int Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                RequestForCoupon oldex = db.RequestForCoupons.Where(a => a.Id == Id).FirstOrDefault();
                db.RequestForCoupons.Remove(oldex);
                db.SaveChanges();

                resultData.Message = "Data Deleted Successfully";
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

        [HttpGet]
        public ResultData GetRequestForCoupons()
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetRequestForCoupon_Result> rfc = db.GetRequestForCoupon().ToList();
                resultData.Message = "Data Get Successfully";
                resultData.IsSuccess = true;
                resultData.Data = rfc;
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
        public ResultData GetAssignedCoupons()
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetAssignedCoupons_Result> rfc = db.GetAssignedCoupons().ToList();

                resultData.Message = "Data Deleted Successfully";
                resultData.IsSuccess = true;
                resultData.Data = rfc;
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
        public ResultData UpdateRequest(long Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                string Data = "UPDATE RequestForCoupon SET IsCompleted='true' WHERE Id='" + Id + "'";
                sf.ExecuteQuery(Data);

                string currdate = DateTime.Now.ToString("yyyy-MM-dd");
                RequestForCoupon request = new RequestForCoupon();
                request = db.RequestForCoupons.Where(a => a.Id == Id).FirstOrDefault();
                if (request != null)
                {
                    AssignCouponExhibitor oldex = db.AssignCouponExhibitors.Where(a => a.ExhibitorId == request.ExhibitorId).FirstOrDefault();

                    int extqty = Convert.ToInt32(oldex.Qty);
                    int newqty = (extqty + Convert.ToInt32(request.Qty));

                    int extprice = Convert.ToInt32(oldex.Total);
                    int newprice = (Convert.ToInt32(request.Qty) + extqty) * 1000;

                    oldex.Qty = Convert.ToString(newqty);
                    oldex.Total = Convert.ToString(newprice);
                    oldex.Date = currdate;
                    db.SaveChanges();

                    ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
                    exhibitorCouponQty = db.ExhibitorCouponQties.Where(e => e.AssignCouponExhibitorId == oldex.Id).FirstOrDefault();
                    if (exhibitorCouponQty != null)
                    {
                        int existingqty = Convert.ToInt32(exhibitorCouponQty.Qty);
                        int updateqty = (existingqty + Convert.ToInt32(request.Qty));
                        exhibitorCouponQty.Qty = Convert.ToInt32(updateqty);
                        db.SaveChanges();
                    }

                    string ass = string.Format("SELECT * FROM Exhibitor WHERE Id='{0}'", request.ExhibitorId);
                    DataTable dre = sf.GetData(ass);
                    if(dre.Rows.Count == 1)
                    {
                        DataRow dr = dre.Rows[0];
                        string title = "Coupon Assigned By Admin";
                        string message = "Admin Has Assigned You " + request.Qty + " Coupons As Per Request !";
                        SendPushNotification(dr["FCMToken"].ToString(), message, title);
                        string qry = string.Format("insert into Notification(Title,Message,Date,ExhibitorId,CustomerId) values('" + title + "','" + message + "','" + DateTime.Now + "','" + request.ExhibitorId + "',0)");
                        sf.ExecuteQuery(qry);
                    }
                }
                
                
                resultData.Message = "Coupon Assigned Successfully";
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

        #region ExhibitorOffer
        [HttpGet]
        public ResultData DeleteExhibitorOffer(int Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                ExhibitorBanner oldex = db.ExhibitorBanners.Where(a => a.Id == Id).FirstOrDefault();
                db.ExhibitorBanners.Remove(oldex);
                db.SaveChanges();

                resultData.Message = "Data Deleted Successfully";
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

        #region History
        [HttpGet]
        public ResultData GetCouponToExhibitor()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetCouponToExhibitor_Result> CouponexhibitorList = new List<GetCouponToExhibitor_Result>();
                CouponexhibitorList = db.GetCouponToExhibitor().ToList();
                if (CouponexhibitorList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = CouponexhibitorList;
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

        #region AssignCoupon

        [HttpPost]
        public ResultData SaveAssignCoupon(AssignCouponExhibitor assigncouponexhibitor)
        {
            ResultData resultData = new ResultData();
            try
            {
                string currdate = DateTime.Now.ToString("yyyy-MM-dd");
                if (assigncouponexhibitor != null && assigncouponexhibitor.Id == 0 )
                {
                    assigncouponexhibitor.CouponNo = GenerateCode().ToString();
                    assigncouponexhibitor.Date = currdate;
                    db.AssignCouponExhibitors.Add(assigncouponexhibitor);
                    db.SaveChanges();

                    ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
                    exhibitorCouponQty.AssignCouponExhibitorId = assigncouponexhibitor.Id;
                    exhibitorCouponQty.Qty = Convert.ToInt32(assigncouponexhibitor.Qty);
                    db.ExhibitorCouponQties.Add(exhibitorCouponQty);
                    db.SaveChanges();

                    GetExhibitorMobileno_Result mobiledata = new GetExhibitorMobileno_Result();
                    mobiledata = db.GetExhibitorMobileno(assigncouponexhibitor.ExhibitorId).FirstOrDefault();
                    if (mobiledata != null)
                    {
                        string title = "Coupon Assigned";
                        string message = "You Have Assigned " + assigncouponexhibitor.Qty + " Coupon !";
                        SendPushNotification(mobiledata.FCMToken, message, title);

                        SendSMS sms = new SendSMS();
                        string res = sms.sendotp("" + assigncouponexhibitor.Qty + " you Have Assigned Coupon", mobiledata.ExhibitorMobile);
                    }

                }
                else if (assigncouponexhibitor.Id > 0 && assigncouponexhibitor.ExhibitorId > 0)
                {
                    AssignCouponExhibitor oldex = db.AssignCouponExhibitors.Where(a => a.Id == assigncouponexhibitor.Id).FirstOrDefault();

                    int extqty = Convert.ToInt32(oldex.Qty);
                    int newqty = (extqty + Convert.ToInt32(assigncouponexhibitor.Qty));

                    int extprice = Convert.ToInt32(oldex.Total);
                    int newprice = (extprice + Convert.ToInt32(assigncouponexhibitor.Total));


                    oldex.CouponNo = assigncouponexhibitor.CouponNo;
                    oldex.ExhibitorId = assigncouponexhibitor.ExhibitorId;
                    oldex.Qty = Convert.ToString(newqty);
                    oldex.Price = assigncouponexhibitor.Price;
                    oldex.Total = Convert.ToString(newprice);
                    oldex.Date = currdate;
                    db.SaveChanges();

                    ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
                    exhibitorCouponQty = db.ExhibitorCouponQties.Where(e => e.AssignCouponExhibitorId == oldex.Id).FirstOrDefault();
                    if (exhibitorCouponQty != null)
                    {
                        int existingqty = Convert.ToInt32(exhibitorCouponQty.Qty);
                        int updateqty = (existingqty + Convert.ToInt32(assigncouponexhibitor.Qty));
                        exhibitorCouponQty.Qty = Convert.ToInt32(updateqty);
                        db.SaveChanges();
                    }
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

        [HttpGet]
        public ResultData GetAssignCouponToExhibitor()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetCouponToExhibitor_Result> CouponexhibitorList = new List<GetCouponToExhibitor_Result>();
                CouponexhibitorList = db.GetCouponToExhibitor().ToList();
                if (CouponexhibitorList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = CouponexhibitorList;
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

        [HttpGet]
        public ResultData DeleteAssignCoupon(int Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                AssignCouponExhibitor oldex = db.AssignCouponExhibitors.Where(a => a.Id == Id).FirstOrDefault();
                db.AssignCouponExhibitors.Remove(oldex);
                db.SaveChanges();

                resultData.Message = "Data Deleted Successfully";
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

        #endregion
        #region ExhibitorList
        [HttpGet]
        public ResultData GetExhibitorList()
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
        #endregion

        #region CustomerList
        [HttpGet]
        public ResultData GetCustomerList()
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
       
        [HttpGet]
        public ResultData DeleteCustomer(string Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                string a = string.Format("DELETE FROM Customer WHERE Id='{0}'",Id);
                sf.ExecuteQuery(a);

                resultData.Message = "Data Deleted Successfully !";
                resultData.Data = 1;
                resultData.IsSuccess = true;
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.Data = 0;
                resultData.IsSuccess = false;
                return resultData;
            }
        }
        #endregion

        #region AssignCouponList

        [HttpGet]
        public ResultData GetAssignCouponList()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetCouponToExhibitor_Result> CouponexhibitorList = new List<GetCouponToExhibitor_Result>();
                CouponexhibitorList = db.GetCouponToExhibitor().ToList();
                if (CouponexhibitorList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = CouponexhibitorList;
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

        #region Draw

        [HttpPost]
        [ActionName("SaveDraw")]
        public ResultData SaveDraw()
        {
            ResultData resultData = new ResultData();
            try
            {
                var properties = Request.Properties as Dictionary<string, object>;
                var requestObject = ((System.Web.HttpContextWrapper)(properties["MS_HttpContext"])).Request;

                string[] paths = sf.Upload(requestObject, Constants.FileTypeDailyDraw);

                long Id = Convert.ToInt64(requestObject.Form["Id"]);
                string DrawName = Convert.ToString(requestObject.Form["DrawName"]);
                DateTime Date = Convert.ToDateTime(requestObject.Form["Date"]);
                string DrawCount = Convert.ToString(requestObject.Form["DrawCount"]);
                string Prize = Convert.ToString(requestObject.Form["Prize"]);
                string Image = "";
                if (requestObject.Files.AllKeys.Any())
                    Image = paths[0];

                if (Id != null && Id == 0)
                {
                    DailyDraw dailydraw = new DailyDraw();
                    dailydraw.DrawName = DrawName;
                    dailydraw.Date = Date;
                    dailydraw.DrawCount = DrawCount;
                    dailydraw.Prize = Prize;
                    dailydraw.Image = Image;

                    db.DailyDraws.Add(dailydraw);
                    db.SaveChanges();

                    resultData.Data = dailydraw.Id;
                    resultData.Message = "Data Save Successfully !";
                }
                else if (Id > 0)
                {
                    DailyDraw dailydraw = db.DailyDraws.Where(c => c.Id == Id).FirstOrDefault();
                    if (dailydraw != null && dailydraw.Id > 0)
                    {
                        dailydraw.DrawName = DrawName;
                        dailydraw.Date = Date;
                        dailydraw.DrawCount = DrawCount;
                        dailydraw.Prize = Prize;
                        if (Image != "")
                            dailydraw.Image = Image;

                        db.SaveChanges();

                        resultData.Data = dailydraw.Id;
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

        [HttpGet]
        public ResultData GetDraw()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<DailyDraw> dailydraw = new List<DailyDraw>();
                dailydraw = db.DailyDraws.ToList();
                if (dailydraw != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = dailydraw;
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
        public ResultData DeleteDailyDraw(int Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                DailyDraw oldex = db.DailyDraws.Where(a => a.Id == Id).FirstOrDefault();
                db.DailyDraws.Remove(oldex);
                db.SaveChanges();

                resultData.Message = "Data Deleted Successfully";
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

        [HttpGet]
        public ResultData GetDailydraw(DateTime Date)
        {
            ResultData resultData = new ResultData();
            try
            {
                List<DailyDraw> dailydraw = new List<DailyDraw>();
                dailydraw = db.DailyDraws.Where(a => a.Date == Date).ToList();
                if (dailydraw != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = dailydraw;
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

        #endregion

        #region State

        [HttpPost]
        public ResultData SaveState(State data)
        {
            ResultData resultData = new ResultData();
            try
            {
                if (data != null && data.Id == 0)
                {
                    db.States.Add(data);
                    db.SaveChanges();
                }
                else if (data.Id > 0)
                {
                    State oldState = db.States.Where(n => n.Id == data.Id).FirstOrDefault();
                    if (oldState != null)
                    {
                        oldState.Title = data.Title;

                        db.SaveChanges();
                    }
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

        [HttpGet]
        public ResultData DeleteState(long id)
        {
            ResultData resultData = new ResultData();
            try
            {
                State state = db.States.Where(t => t.Id == id).FirstOrDefault();
                if (state != null)
                {
                    db.States.Remove(state);
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

        [HttpPost]
        public ResultData SaveCity(City data)
        {
            ResultData resultData = new ResultData();
            try
            {
                if (data != null && data.Id == 0)
                {
                    db.Cities.Add(data);
                    db.SaveChanges();
                }
                else if (data.Id > 0)
                {
                    City oldCity = db.Cities.Where(n => n.Id == data.Id).FirstOrDefault();
                    if (oldCity != null)
                    {
                        oldCity.Title = data.Title;
                        oldCity.StateId = data.StateId;

                        db.SaveChanges();
                    }
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

        [HttpGet]
        public ResultData DeleteCity(long id)
        {
            ResultData resultData = new ResultData();
            try
            {
                City city = db.Cities.Where(t => t.Id == id).FirstOrDefault();
                if (city != null)
                {
                    db.Cities.Remove(city);
                    db.SaveChanges();
                }

                resultData.Message = "Data Deleted Successfully";
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
        public ResultData GetCities()
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetCities_Result> Cities = db.GetCities().OrderBy(a => a.Title).ToList();
                if (Cities != null)
                {
                    resultData.Message = "Data Get Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = Cities;
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

        #region AssignCouponCustomer
        [HttpGet]
        public ResultData GetAssignCouponCustomer()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetApplyCouponCustomer_Result> applycouponcustomer = new List<GetApplyCouponCustomer_Result>();
                applycouponcustomer = db.GetApplyCouponCustomer().ToList();
                if (applycouponcustomer != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = applycouponcustomer;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid applycouponcustomer Detail";
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

        #region Notification
        [HttpGet]
        public ResultData GetDataList(string type)
        {
            ResultData resultData = new ResultData();
            try
            {
                if (type == "Exhibitor")
                {
                    string strData = "SELECT * FROM Exhibitor";
                    List<Exhibitor> exhibitor = new List<Exhibitor>();
                    List<notification_person_list> userlist = new List<notification_person_list>();
                    exhibitor = db.Exhibitors.ToList();
                    if (exhibitor != null)
                    {
                        foreach (Exhibitor item in exhibitor)
                        {
                            notification_person_list user = new notification_person_list();
                            user.Id = Convert.ToInt32(item.Id);
                            user.Name = item.PersonName;
                            user.ContactNo = item.MobileNo;
                            user.Selected = false;
                            userlist.Add(user);
                        }
                        resultData.Message = "Data Get Successfully !";
                        resultData.IsSuccess = true;
                        resultData.Data = userlist;
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
                else if (type == "Visitor")
                {
                    List<Customer> customer = new List<Customer>();
                    List<notification_person_list> userlist = new List<notification_person_list>();
                    customer = db.Customers.ToList();
                    if (customer != null)
                    {
                        foreach (Customer item in customer)
                        {
                            notification_person_list user = new notification_person_list();
                            user.Id = Convert.ToInt32(item.Id);
                            user.Name = item.PersonName;
                            user.ContactNo = item.MobileNo;
                            user.Selected = false;
                            userlist.Add(user);
                        }
                        resultData.Message = "Data Get Successfully !";
                        resultData.IsSuccess = true;
                        resultData.Data = userlist;
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
                    resultData.Message = "Invalid Data Detail !";
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
        public ResultData GetFcmToken(List<SendNotifications> notification)
        {
            ResultData resultData = new ResultData();
            try
            {
                foreach (SendNotifications data in notification)
                {
                    if (data.type == "Exhibitor")
                    {

                        Exhibitor exhibitor = new Exhibitor();
                        exhibitor = db.Exhibitors.Where(e => e.Id == data.id).FirstOrDefault();
                        if (exhibitor != null)
                        {
                            SendPushNotification(exhibitor.FCMToken, data.message, data.title);
                            string qry = string.Format("insert into Notification(Title,Message,Date,ExhibitorId,CustomerId) values('" + data.title + "','" + data.message + "','" + DateTime.Now + "','" + data.id + "',0)");
                            sf.ExecuteQuery(qry);
                            SendSMS sms = new SendSMS();
                            string res = sms.sendotp("" + data.title + ", "+ data.message + "", exhibitor.MobileNo);

                        }
                    }
                    else if (data.type == "Visitor") 
                    {
                        Customer customer = new Customer();
                        customer = db.Customers.Where(c => c.Id == data.id).FirstOrDefault();
                        if (customer != null)
                        {
                            SendPushNotification(customer.FCMToken, data.message, data.title);
                            string qry = string.Format("insert into Notification(Title,Message,Date,ExhibitorId,CustomerId) values('"+ data.title + "','"+ data.message + "','"+ DateTime.Now +"',0,'"+ data.id + "')");
                            sf.ExecuteQuery(qry);
                            SendSMS sms = new SendSMS();
                            string res = sms.sendotp("" + data.title + ", " + data.message + "", customer.MobileNo);
                        }
                    }
                    else
                    {
                        resultData.Message = "Invalid Data Detail !";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                resultData.Message = "Message Send Successfully !";
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

        public void SendPushNotificationWthData(string deviceId, string message, string title, GetCustomerFCMToken_Result data)
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
                    },
                    data = new
                    {
                        Name = data.PersonName,
                        DrawName = data.DrawName,
                        CouponNo = data.CouponNo,
                        WinnerPosition = data.NumberOfResult,
                        Date = data.Date
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

        public void SendPushNotificationWthdata(string deviceId, string message, string title, GetCustomerFCMTokenMega_Result data)
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
                    },
                    data = new
                    {
                        Name = data.PersonName,
                        DrawName = data.DrawName,
                        CouponNo = data.CouponNo,
                        WinnerPosition = data.NumberOfResult,
                        Date = data.Date
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

        #endregion

        #region DrawCoupon

        [HttpGet]
        public ResultData CheckDrawComplete(string DrawId)
        {
            ResultData resultData = new ResultData();
            try
            {
                DataTable GetDraw = sf.GetData(string.Format("SELECT * FROM DailyDraw WHERE Id='{0}'", Convert.ToInt32(DrawId)));
                if (GetDraw.Rows.Count == 1)
                {
                    int DrawCount = Convert.ToInt32(GetDraw.Rows[0]["DrawCount"]);
                    DataTable dt = sf.GetData(string.Format("SELECT * FROM Draw WHERE DrawId='{0}'", Convert.ToInt32(DrawId)));
                    if (dt.Rows.Count == DrawCount)
                    {
                        resultData.Message = "Successfully !";
                        resultData.IsSuccess = true;
                        resultData.Data = 1;
                        return resultData;
                    }
                    else
                    {
                        resultData.Message = "Successfully !";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                resultData.Message = "Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 0;
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.Data = 0;
                resultData.IsSuccess = false;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData GetCouponNo(string DrawId, string Position)
        {
            ResultData resultData = new ResultData();
            try
            {
                RecreateCoupon:
                GetDrawCoupon_Result draw = new GetDrawCoupon_Result();
                draw = db.GetDrawCoupon().FirstOrDefault();
                if (draw != null)
                {

                    DataTable GetDraw = sf.GetData(string.Format("SELECT * FROM DailyDraw WHERE Id='{0}'", Convert.ToInt32(DrawId)));
                    if (GetDraw.Rows.Count == 1)
                    {
                        int DrawCount = Convert.ToInt32(GetDraw.Rows[0]["DrawCount"]);
                        DataTable dt = sf.GetData(string.Format("SELECT * FROM Draw WHERE DrawId='{0}'", Convert.ToInt32(DrawId)));
                        if (dt.Rows.Count < DrawCount)
                        {

                            DataTable dupdt = sf.GetData(string.Format("SELECT * FROM Draw WHERE CouponNo='{1}'", draw.CouponNo));
                            if (dupdt.Rows.Count > 0)
                            {
                                goto RecreateCoupon;
                            }
                            DataTable dtR = sf.GetData(string.Format("SELECT * FROM Draw WHERE DrawId='{0}' AND NumberOfResult='{1}'", Convert.ToInt32(DrawId), Convert.ToInt32(Position)));
                            if (dtR.Rows.Count > 0)
                            {
                                resultData.Message = "UnDefined Customer Successfully !";
                                resultData.IsSuccess = true;
                                resultData.Data = 0;
                                return resultData;
                            }
                            else
                            {
                                DataTable CustomerDt = sf.GetData(string.Format("SELECT * From Customer WHERE Id='{0}'", draw.CustomerId));
                                if (CustomerDt.Rows.Count > 0)
                                {
                                    Draw d = new Draw();
                                    d.CouponNo = draw.CouponNo;
                                    d.CustomerId = draw.CustomerId;
                                    d.Date = Convert.ToString(DateTime.Now);
                                    d.DrawId = Convert.ToInt64(DrawId);
                                    d.NumberOfResult = Position;
                                    db.Draws.Add(d);
                                    db.SaveChanges();

                                    DataBag dataBag = new DataBag();
                                    dataBag.CouponNo = draw.CouponNo;
                                    dataBag.CustomerId = Convert.ToString(draw.CustomerId);
                                    dataBag.PersonName = CustomerDt.Rows[0]["PersonName"].ToString();
                                    dataBag.NumberOfResult = Position;
                                    dataBag.DrawId = DrawId;
                                    dataBag.Image = CustomerDt.Rows[0]["Image"].ToString();

                                    string Title = "Congratulation, " + CustomerDt.Rows[0]["PersonName"].ToString() + "";
                                    string message = "Congratulation, " + CustomerDt.Rows[0]["PersonName"].ToString() + ", You've Won the '" + GetDraw.Rows[0]["Prize"] + "' in the Following " + GetDraw.Rows[0]["DrawName"] + "";
                                    GetCustomerFCMToken_Result data = new Models.GetCustomerFCMToken_Result();
                                    SendPushNotificationWthData(CustomerDt.Rows[0]["FCMToken"].ToString(), Title, message, data);
                                    resultData.Message = "Successfully !";
                                    resultData.IsSuccess = true;
                                    resultData.Data = dataBag;
                                    return resultData;
                                }
                            }

                            resultData.Message = "UnDefined Customer Successfully !";
                            resultData.IsSuccess = true;
                            resultData.Data = 0;
                            return resultData;
                        }
                    }

                    resultData.Message = "Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = 0;
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
        public ResultData GetWinnerCouponNo(string DrawId)
        {
            ResultData resultData = new ResultData();
            try
            {
                DataTable dt = sf.GetData(string.Format("SELECT * FROM Draw WHERE DrawId='{0}'", Convert.ToInt32(DrawId)));
                if (dt.Rows.Count > 0)
                {

                    List<Draw> da = new List<Draw>();
                    foreach (DataRow item in dt.Rows)
                    {
                        Draw d = new Draw();
                        d.Id = Convert.ToInt64(item["Id"]);
                        d.CouponNo = item["CouponNo"].ToString();
                        d.CustomerId = Convert.ToInt64(item["CustomerId"]);
                        d.Date = item["Date"].ToString();
                        d.DrawId = Convert.ToInt64(item["DrawId"]);
                        d.NumberOfResult = item["NumberOfResult"].ToString();
                        da.Add(d);
                    }

                    resultData.Message = "Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = da;
                    return resultData;
                }
                resultData.Message = "Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 0;
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
        public ResultData GetDrawCards(string DrawId)
        {
            ResultData resultData = new ResultData();
            try
            {
                DataTable dt = sf.GetData(string.Format("SELECT * FROM DailyDraw WHERE Id='{0}'", DrawId));
                if (dt.Rows.Count > 0)
                {
                    resultData.Message = "NO Cards";
                    resultData.IsSuccess = true;
                    resultData.Data = Convert.ToInt32(dt.Rows[0]["DrawCount"]);
                    return resultData;
                }
                else
                {
                    resultData.Message = "NO Cards";
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
        public ResultData GetDrawWinnerList(long drawId)
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetDrawWinnerData_Result> drawWinnerList = new List<GetDrawWinnerData_Result>();
                drawWinnerList = db.GetDrawWinnerData(drawId).ToList();
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
        public ResultData GetMegaDrawWinnerList()
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

        #region Dashboard

        [HttpGet]
        public ResultData GetDashboardCountList()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<GetDashboardCount_Result> dashboardcountList = new List<GetDashboardCount_Result>();
                dashboardcountList = db.GetDashboardCount().ToList();
                if (dashboardcountList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = dashboardcountList;
                    return resultData;
                }
                else
                {
                    resultData.Message = "Invalid Count Detail";
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

        #region ApplyCouponList
        [HttpGet]
        public ResultData GetApplyCouponList()
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetTotalCoupon_Result> gettotalcoupon = new List<GetTotalCoupon_Result>();
                gettotalcoupon = db.GetTotalCoupon().ToList();
                if (gettotalcoupon != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = gettotalcoupon;
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
        //public ResultData GetCouponList(long Id)
        //{
        //    ResultData resultData = new ResultData();
        //    GetallData Data = new GetallData();
        //    List<GetCouponList_Result> couponlist = new List<GetCouponList_Result>();
        //    List<GetCouponAssign_Result> couponassign = new List<GetCouponAssign_Result>();
        //    try
        //    {
        //        couponlist = db.GetCouponList(Id).ToList();
        //        getCouponassign = db.GetCouponAssign(Id).ToList();
        //        foreach (GetCouponAssign_Result dr in getCouponassign)
        //        {
        //            if (getCouponassign != null)
        //            {
        //                foreach (GetCouponList_Result drr in gettotalcoupon)
        //                {
        //                    getlist c = new getlist();
        //                    GetCouponList_Result r = new GetCouponList_Result();
        //                    GetCouponAssign_Result a = new GetCouponAssign_Result();

        //                    c.gettotalcoupon = a;
        //                    c.getCouponassign = r;
        //                }
        //            }
        //        }
        //        resultData.Message = "Data Get Successfully";
        //        resultData.IsSuccess = true;
        //        resultData.Data = Q;
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

        #endregion

        #region CustomerCouponDetail
        [HttpGet]
        public ResultData GetCustomerCouponList()
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetCouponDetail_Result> gettotalcoupon = new List<GetCouponDetail_Result>();
                gettotalcoupon = db.GetCouponDetail().ToList();
                if (gettotalcoupon != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = gettotalcoupon;
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
        public ResultData UpdateCouponStatus(long Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                db.UpdateCustomerCouponStatus(Id);

                CustomerCoupon customerCoupon = new CustomerCoupon();
                customerCoupon = db.CustomerCoupons.Where(c => c.Id == Id).FirstOrDefault();
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
                        if (assignCouponExhibitor != null)
                        {
                            ExhibitorCouponQty exhibitorCouponQty = new ExhibitorCouponQty();
                            exhibitorCouponQty = db.ExhibitorCouponQties.Where(e => e.AssignCouponExhibitorId == assignCouponExhibitor.Id).FirstOrDefault();
                            if (exhibitorCouponQty != null)
                            {
                                int exitingqty = Convert.ToInt32(exhibitorCouponQty.Qty);
                                int newcoupon = (exitingqty + 1);

                                exhibitorCouponQty.Qty = newcoupon;
                                db.SaveChanges();
                            }
                        }
                        GetCusmoterMobile_Result mobiledata = new GetCusmoterMobile_Result();
                        mobiledata = db.GetCusmoterMobile(applyCoupon.CustomerId).FirstOrDefault();
                        if (mobiledata != null)
                        {
                            string title = "Coupon Cancel";
                            string message = "" + mobiledata.CompanyName + " cancel your one coupon !";

                            SendPushNotification(mobiledata.FCMToken, message, title);


                            //SendSMS sms = new SendSMS();
                            //string res = sms.sendotp("" + mobiledata.CompanyName + " cancel your one coupon", mobiledata.CustomerMobile);
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
        #endregion

        #region Draw

        [HttpPost]
        [ActionName("SaveMegaDraw")]
        public ResultData SaveMegaDraw()
        {
            ResultData resultData = new ResultData();
            try
            {
                var properties = Request.Properties as Dictionary<string, object>;
                var requestObject = ((System.Web.HttpContextWrapper)(properties["MS_HttpContext"])).Request;

                string[] paths = sf.Upload(requestObject, Constants.FileTypeMegaDraw);

                long Id = Convert.ToInt64(requestObject.Form["Id"]);
                string DrawName = Convert.ToString(requestObject.Form["DrawName"]);
                string Date = Convert.ToString(requestObject.Form["Date"]).ToString();
                int DrawCount = Convert.ToInt32(requestObject.Form["DrawCount"]);
                string Prize = Convert.ToString(requestObject.Form["Prize"]);
                string Image = "";
                if (requestObject.Files.AllKeys.Any())
                    Image = paths[0];

                if (Id != null && Id == 0)
                {
                    MegaDraw megadraw = new MegaDraw();
                    megadraw.DrawName = DrawName;
                    megadraw.Date = Date;
                    megadraw.DrawCount = DrawCount;
                    megadraw.Prize = Prize;
                    megadraw.Image = Image;

                    db.MegaDraws.Add(megadraw);
                    db.SaveChanges();

                    resultData.Data = megadraw.Id;
                    resultData.Message = "Data Save Successfully !";
                }
                else if (Id > 0)
                {
                    MegaDraw megadraw = db.MegaDraws.Where(c => c.Id == Id).FirstOrDefault();
                    if (megadraw != null && megadraw.Id > 0)
                    {
                        megadraw.DrawName = DrawName;
                        megadraw.Date = Date;
                        megadraw.DrawCount = DrawCount;
                        megadraw.Prize = Prize;
                        if (Image != "")
                            megadraw.Image = Image;

                        db.SaveChanges();

                        resultData.Data = megadraw.Id;
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

        [HttpGet]
        public ResultData GetMegaDraw()
        {
            ResultData resultData = new ResultData();
            try
            {

                List<MegaDraw> megadraw = new List<MegaDraw>();
                megadraw = db.MegaDraws.ToList();
                if (megadraw != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = megadraw;
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
        public ResultData DeleteMegaDraw(int Id)
        {
            ResultData resultData = new ResultData();
            try
            {
                MegaDraw oldex = db.MegaDraws.Where(a => a.Id == Id).FirstOrDefault();
                db.MegaDraws.Remove(oldex);
                db.SaveChanges();

                resultData.Message = "Data Deleted Successfully";
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

        #endregion

        #region MegaDrawCoupon

        [HttpGet]
        public ResultData CheckMegaDrawComplete(string MegaDrawId)
        {
            ResultData resultData = new ResultData();
            try
            {
                DataTable GetDraw = sf.GetData(string.Format("SELECT * FROM MegaDraw WHERE Id='{0}'", Convert.ToInt32(MegaDrawId)));
                if (GetDraw.Rows.Count == 1)
                {
                    int DrawCount = Convert.ToInt32(GetDraw.Rows[0]["DrawCount"]);
                    DataTable dt = sf.GetData(string.Format("SELECT * FROM MegaDrawWinner WHERE MegaDrawId='{0}'", Convert.ToInt32(MegaDrawId)));
                    if (dt.Rows.Count == DrawCount)
                    {
                        resultData.Message = "Successfully !";
                        resultData.IsSuccess = true;
                        resultData.Data = 1;
                        return resultData;
                    }
                    else
                    {
                        resultData.Message = "Successfully !";
                        resultData.IsSuccess = true;
                        resultData.Data = 0;
                        return resultData;
                    }
                }
                resultData.Message = "Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 0;
                return resultData;
            }
            catch (Exception ex)
            {
                resultData.Message = ex.Message.ToString();
                resultData.Data = 0;
                resultData.IsSuccess = false;
                return resultData;
            }
        }

        [HttpGet]
        public ResultData GetMegaCouponNo(string MegaDrawId, string Position)
        {
            ResultData resultData = new ResultData();
            try
            {
                RecreateCoupon:
                GetCoupon_Result draw = new GetCoupon_Result();
                draw = db.GetCoupon().FirstOrDefault();
                if (draw != null)
                {

                    DataTable GetDraw = sf.GetData(string.Format("SELECT * FROM MegaDraw WHERE Id='{0}'", Convert.ToInt32(MegaDrawId)));
                    if (GetDraw.Rows.Count == 1)
                    {
                        int DrawCount = Convert.ToInt32(GetDraw.Rows[0]["DrawCount"]);
                        DataTable dt = sf.GetData(string.Format("SELECT * FROM MegaDrawWinner WHERE MegaDrawId='{0}'", Convert.ToInt32(MegaDrawId)));
                        if (dt.Rows.Count < DrawCount)
                        {

                            DataTable dupdt = sf.GetData(string.Format("SELECT * FROM MegaDrawWinner WHERE MegaDrawId='{0}' AND CouponNo='{1}'", Convert.ToInt32(MegaDrawId), draw.CouponNo));
                            if (dupdt.Rows.Count > 0)
                            {
                                goto RecreateCoupon;
                            }
                            DataTable dtR = sf.GetData(string.Format("SELECT * FROM MegaDrawWinner WHERE MegaDrawId='{0}' AND NumberOfResult='{1}'", Convert.ToInt32(MegaDrawId), Convert.ToInt32(Position)));
                            if (dtR.Rows.Count > 0)
                            {
                                resultData.Message = "UnDefined Customer Successfully !";
                                resultData.IsSuccess = true;
                                resultData.Data = 0;
                                return resultData;
                            }
                            else
                            {
                                DataTable CustomerDt = sf.GetData(string.Format("SELECT * From Customer WHERE Id='{0}'", draw.CustomerId));
                                if (CustomerDt.Rows.Count > 0)
                                {
                                    MegaDrawWinner d = new MegaDrawWinner();
                                    d.CouponNo = draw.CouponNo;
                                    d.CustomerId = draw.CustomerId;
                                    d.Date = Convert.ToString(DateTime.Now);
                                    d.MegaDrawId = Convert.ToInt64(MegaDrawId);
                                    d.NumberOfResult = Position;
                                    db.MegaDrawWinners.Add(d);
                                    db.SaveChanges();

                                    DataBag dataBag = new DataBag();
                                    dataBag.CouponNo = draw.CouponNo;
                                    dataBag.CustomerId = Convert.ToString(draw.CustomerId);
                                    dataBag.PersonName = CustomerDt.Rows[0]["PersonName"].ToString();
                                    dataBag.NumberOfResult = Position;
                                    dataBag.DrawId = MegaDrawId;
                                    dataBag.Image = CustomerDt.Rows[0]["Image"].ToString();

                                    string Title = "Congratulation, " + CustomerDt.Rows[0]["PersonName"].ToString() + "";
                                    string message = "Congratulation, " + CustomerDt.Rows[0]["PersonName"].ToString() + ", You've Won the " + GetDraw.Rows[0]["Prize"] + " in the Following " + GetDraw.Rows[0]["DrawName"] + " ";
                                    GetCustomerFCMTokenMega_Result data = new GetCustomerFCMTokenMega_Result();
                                    SendPushNotificationWthdata(CustomerDt.Rows[0]["FCMToken"].ToString(), Title, message, data);
                                    resultData.Message = "Successfully !";
                                    resultData.IsSuccess = true;
                                    resultData.Data = dataBag;
                                    return resultData;
                                }
                            }

                            resultData.Message = "UnDefined Customer Successfully !";
                            resultData.IsSuccess = true;
                            resultData.Data = 0;
                            return resultData;
                        }
                    }

                    resultData.Message = "Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = 0;
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

        [HttpGet]
        public ResultData GetWinnerMegaCouponNo(string MegaDrawId)
        {
            ResultData resultData = new ResultData();
            try
            {
                DataTable dt = sf.GetData(string.Format("SELECT * FROM MegaDrawWinner WHERE MegaDrawId='{0}'", Convert.ToInt32(MegaDrawId)));
                if (dt.Rows.Count > 0)
                {

                    List<MegaDrawWinner> da = new List<MegaDrawWinner>();
                    foreach (DataRow item in dt.Rows)
                    {
                        MegaDrawWinner d = new MegaDrawWinner();
                        d.Id = Convert.ToInt64(item["Id"]);
                        d.CouponNo = item["CouponNo"].ToString();
                        d.CustomerId = Convert.ToInt64(item["CustomerId"]);
                        d.Date = item["Date"].ToString();
                        d.MegaDrawId = Convert.ToInt64(item["MegaDrawId"]);
                        d.NumberOfResult = item["NumberOfResult"].ToString();
                        da.Add(d);
                    }

                    resultData.Message = "Successfully !";
                    resultData.IsSuccess = true;
                    resultData.Data = da;
                    return resultData;
                }
                resultData.Message = "Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = 0;
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
        public ResultData GetMegaDrawCards(string MegaDrawId)
        {
            ResultData resultData = new ResultData();
            try
            {
                DataTable dt = sf.GetData(string.Format("SELECT * FROM MegaDraw WHERE Id='{0}'", MegaDrawId));
                if (dt.Rows.Count > 0)
                {
                    resultData.Message = "NO Cards";
                    resultData.IsSuccess = true;
                    resultData.Data = Convert.ToInt32(dt.Rows[0]["DrawCount"]);
                    return resultData;
                }
                else
                {
                    resultData.Message = "NO Cards";
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

        #region GetCouponList
        [HttpGet]
        public ResultData GetCouponsListV1(long Id)
        {
            List<couponlist> mycouplist = new List<couponlist>();
            couponlist mycoup = new couponlist();
            ResultData resultData = new ResultData();
            try
            {
                List<GetCouponAssign> couponassignlist = new List<GetCouponAssign>();
                string q2 = "Select r.*,e.PersonName From AssignCouponExhibitor r left join Exhibitor e On r.ExhibitorId=e.Id Where r.ExhibitorId = '" + Id + "'";
                DataTable dt = sf.GetData(q2);
                foreach (DataRow item in dt.Rows)
                {
                    GetCouponAssign coupnassign = new GetCouponAssign();
                    List<GetCouponList> cuplist = new List<GetCouponList>();
                    coupnassign.Id = Convert.ToInt64(item["Id"]);
                    coupnassign.CouponNo = Convert.ToString(item["CouponNo"]);
                    coupnassign.ExhibitorId = Convert.ToInt64(item["ExhibitorId"]);
                    coupnassign.Price = Convert.ToDecimal(item["Price"]);
                    coupnassign.Date = Convert.ToString(item["Date"]);
                    coupnassign.PersonName = Convert.ToString(item["PersonName"]);
                    coupnassign.AssginBy = "Assign By Admin";
                    int TempQty = Convert.ToInt32(item["Qty"]);

                    string q1 = "Select r.Id,r.ExhibitorId,r.Qty,r.Date,e.PersonName,ac.CouponNo From RequestForCoupon r left join Exhibitor e On r.ExhibitorId=e.Id left join AssignCouponExhibitor ac On ac.ExhibitorId=e.Id Where r.IsCompleted = 1 And r.ExhibitorId = '" + Convert.ToInt32(item["ExhibitorId"]) + "'";
                    DataTable dtr = sf.GetData(q1);
                    foreach (DataRow items in dtr.Rows)
                    {
                        TempQty = TempQty - Convert.ToInt32(items["Qty"]);
                        GetCouponList cl = new GetCouponList();
                        cl.Id = Convert.ToInt64(items["Id"]);
                        cl.CouponNo = Convert.ToString(items["CouponNo"]);
                        cl.Qty = Convert.ToString(items["Qty"]);
                        cl.PersonName = Convert.ToString(items["PersonName"]);
                        cl.ExhibitorId = Convert.ToInt64(items["ExhibitorId"]);
                        cl.Date = Convert.ToDateTime(items["Date"]);
                        cl.AssginBy = "Requested Exhibtor";
                        cuplist.Add(cl);
                    }
                    coupnassign.Qty = Convert.ToString(TempQty);
                    couponassignlist.Add(coupnassign);
                    mycoup.cup_assignlist = couponassignlist;
                    mycoup.coup_list = cuplist;
                    mycouplist.Add(mycoup);
                }

                resultData.Message = "Data Get Successfully !";
                resultData.IsSuccess = true;
                resultData.Data = mycouplist;
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
        ////    [HttpGet]
        ////    public ResultData GetCouponLists(long Id)
        ////    {
        ////        ResultData resultData = new ResultData();
        ////        GetallData Data = new GetallData();
        ////        List<GetCouponList> couponlist = new List<GetCouponList>();
        ////        List<GetCouponAssign> couponassign = new List<GetCouponAssign>();
        ////        List<Count> count = new List<Count>();
        ////        try
        ////        {
        ////            DataTable dtt = new DataTable();
        ////            string q2 = "Select r.*,e.PersonName From AssignCouponExhibitor r left join Exhibitor e On r.ExhibitorId=e.Id Where r.ExhibitorId = '" + Id + "'";
        ////            if (dtt.Rows.Count > 0)
        ////            {
        ////                foreach (DataRow drr in dtt.Rows)
        ////                {
        ////                    GetCouponList cl = new GetCouponList();
        ////                    GetCouponAssign ca = new GetCouponAssign();
        ////                    Count c = new Count();
        ////                    int extqty = (Convert.ToInt32(ca.Qty));
        ////                    if (extqty == 0)
        ////                    {
        ////                        extqty = 0;
        ////                    }
        ////                    else
        ////                    {
        ////                        extqty = (Convert.ToInt32(ca.Qty) - Convert.ToInt32(cl.Qty));
        ////                    }
        ////                    c.Qty = Convert.ToString(extqty);
        ////                    ca.CouponNo = Convert.ToString(drr["CouponNo"]);
        ////                    ca.Qty = c.Qty;
        ////                    ca.PersonName = Convert.ToString(drr["PersonName"]);
        ////                    ca.Date = Convert.ToString(drr["Date"]);
        ////                    couponassign.Add(ca);
        ////                }

        ////                DataTable dt = new DataTable();
        ////                string q1 = "Select r.Id,r.ExhibitorId,r.Qty,r.Date,e.PersonName,ac.CouponNo From RequestForCoupon r left join Exhibitor e On r.ExhibitorId=e.Id left join AssignCouponExhibitor ac On ac.ExhibitorId=e.Id Where r.IsCompleted = 1 And r.ExhibitorId = '" + Id + "'";
        ////                dt = sf.GetData(q1);
        ////                foreach (DataRow dr in dt.Rows)
        ////                {
        ////                    GetCouponList cl = new GetCouponList();
        ////                    cl.CouponNo = Convert.ToString(dr["CouponNo"]);
        ////                    cl.Qty = Convert.ToString(dr["Qty"]);
        ////                    cl.PersonName = Convert.ToString(dr["PersonName"]);
        ////                    cl.Date = Convert.ToDateTime(dr["Date"]);
        ////                    couponlist.Add(cl);

        ////                }
        ////                Data.assign = couponassign;
        ////                Data.list = couponlist;
        ////            }


        ////            resultData.Message = "Search Data Get Successfully";
        ////            resultData.Data = Data;
        ////            resultData.IsSuccess = true;
        ////            return resultData;

        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            resultData.Message = ex.Message.ToString();
        ////            resultData.IsSuccess = false;
        ////            resultData.Data = 0;
        ////            return resultData;
        ////        }
        ////    }

        #region GetCustomerCouponWithExhibitorDetail

        [HttpGet]
        public ResultData GetCustomerCouponWithExhibitorDetail()
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetCustomerCouponHistoryData_Result> applyCouponList = new List<GetCustomerCouponHistoryData_Result>();
                applyCouponList = db.GetCustomerCouponHistoryData().ToList();
                if (applyCouponList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = applyCouponList;
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

        public ResultData GetExhibitorListDetail(long id)
        {
            ResultData resultData = new ResultData();
            try
            {
                List<GetExhibitorByCustomerCoupon_Result> applyCouponList = new List<GetExhibitorByCustomerCoupon_Result>();
                applyCouponList = db.GetExhibitorByCustomerCoupon(id).ToList();
                if (applyCouponList != null)
                {
                    resultData.Message = "Data Get Successfully";
                    resultData.IsSuccess = true;
                    resultData.Data = applyCouponList;
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

        #endregion


    }
}
