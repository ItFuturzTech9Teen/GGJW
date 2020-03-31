using GGJWEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;
using System.Data;
using System.Drawing;

namespace GGJWEvent.Controllers
{
    public class ReportsController : Controller
    {
        GGJWEventEntities db = new GGJWEventEntities();
        StudyField sf = new StudyField();

        // GET: Reports
        public void ExhibitorListReport()
        {
            try
            {
                var Filename = "ExhibitorReports";

                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("ExhibitorList");

                ws.Cells["A1"].Value = "Srno";
                ws.Cells["B1"].Value = "PersonName";
                ws.Cells["C1"].Value = "Designation";
                ws.Cells["D1"].Value = "CompanyName";
                ws.Cells["E1"].Value = "Country";
                ws.Cells["F1"].Value = "TelephoneNo";
                ws.Cells["G1"].Value = "MobileNo";
                ws.Cells["H1"].Value = "Email";
                ws.Cells["I1"].Value = "IsVerified";

                ws.Cells["A1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["A1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["A1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["B1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["B1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["B1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["C1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["C1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["C1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["D1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["D1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["D1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["E1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["E1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["E1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["F1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["F1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["F1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["G1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["G1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["G1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["H1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["H1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["H1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["I1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["I1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["I1"].Style.Font.Color.SetColor(Color.White);

                int rowStartFrom = 2;
                int ab = 1;
                List<GetExhibitorDatalists> exhibitorList = new List<GetExhibitorDatalists>();
                string a = string.Format("SELECT * FROM Exhibitor");
                DataTable der = sf.GetData(a);
                foreach (DataRow item in der.Rows)
                {

                    

                    ws.Cells[string.Format("A{0}",rowStartFrom)].Value = ab;
                    ws.Cells[string.Format("B{0}", rowStartFrom)].Value = Convert.ToString(item["PersonName"]);
                    ws.Cells[string.Format("C{0}", rowStartFrom)].Value = Convert.ToString(item["Designation"]);
                    ws.Cells[string.Format("D{0}", rowStartFrom)].Value = Convert.ToString(item["CompanyName"]);
                    ws.Cells[string.Format("E{0}", rowStartFrom)].Value = Convert.ToString(item["Country"]);
                    ws.Cells[string.Format("F{0}", rowStartFrom)].Value = Convert.ToString(item["TelephoneNo"]);
                    ws.Cells[string.Format("G{0}", rowStartFrom)].Value = Convert.ToString(item["MobileNo"]);
                    ws.Cells[string.Format("H{0}", rowStartFrom)].Value = Convert.ToString(item["Email"]);
                    ws.Cells[string.Format("I{0}", rowStartFrom)].Value = item["IsVerified"] == DBNull.Value ? false : Convert.ToBoolean(item["IsVerified"]);
                    rowStartFrom++;
                    ab++;

                    ws.Cells[string.Format("B{0}", rowStartFrom)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("B{0}", rowStartFrom)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("B{0}", rowStartFrom)].Style.Font.Color.SetColor(Color.White);

                    ws.Cells[string.Format("C{0}", rowStartFrom)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("C{0}", rowStartFrom)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("C{0}", rowStartFrom)].Style.Font.Color.SetColor(Color.White);

                    ws.Cells[string.Format("D{0}", rowStartFrom)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("D{0}", rowStartFrom)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("D{0}", rowStartFrom)].Style.Font.Color.SetColor(Color.White);

                    ws.Cells[string.Format("E{0}", rowStartFrom)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("E{0}", rowStartFrom)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("E{0}", rowStartFrom)].Style.Font.Color.SetColor(Color.White);

                    ws.Cells[string.Format("F{0}", rowStartFrom)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("F{0}", rowStartFrom)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("F{0}", rowStartFrom)].Style.Font.Color.SetColor(Color.White);
                    
                    ws.Cells[string.Format("B{0}", rowStartFrom)].Value = "Srno";
                    ws.Cells[string.Format("C{0}", rowStartFrom)].Value = "Address";
                    ws.Cells[string.Format("D{0}", rowStartFrom)].Value = "Latlong";
                    ws.Cells[string.Format("E{0}", rowStartFrom)].Value = "State";
                    ws.Cells[string.Format("F{0}", rowStartFrom)].Value = "City";
                    rowStartFrom++;
                    int ba = 1;

                    string b = string.Format("SELECT * FROM ExhibitorAddress WHERE ExhibitorId='{0}'", Convert.ToInt32(item["Id"]));
                    DataTable dte = sf.GetData(b);
                    foreach (DataRow items in dte.Rows)
                    {
                        ws.Cells[string.Format("B{0}", rowStartFrom)].Value = ba;
                        ws.Cells[string.Format("C{0}", rowStartFrom)].Value = Convert.ToString(items["Address"]);
                        ws.Cells[string.Format("D{0}", rowStartFrom)].Value = Convert.ToString(items["Latlong"]);
                        ba++;
                        
                        var i = Convert.ToInt64(items["StateId"]);
                        DataTable StateNa = sf.GetData(string.Format("SELECT * FROM State WHERE Id='{0}'", i));
                        ws.Cells[string.Format("E{0}", rowStartFrom)].Value = StateNa.Rows[0]["Title"].ToString();

                        var j = Convert.ToInt64(items["CityId"]);
                        DataTable CityNa = sf.GetData(string.Format("SELECT * FROM City WHERE Id='{0}'", j));
                        ws.Cells[string.Format("F{0}", rowStartFrom)].Value = CityNa.Rows[0]["Title"].ToString();
                        rowStartFrom++; 
                    }
                }
                ws.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment:file=" + Filename + ".xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }
            catch (Exception ex)
            {}
        }

        public void CustomerListReport()
        {
            try
            {
                string Filename = "CustomersListReport";
                List<GetCustomerData_Result> customerList = new List<GetCustomerData_Result>();
                customerList = db.GetCustomerData().ToList();

                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(Filename);

                ws.Cells["A1"].Value = "Id";
                ws.Cells["B1"].Value = "MobileNo";
                ws.Cells["C1"].Value = "PersonName";
                ws.Cells["D1"].Value = "Designation";
                ws.Cells["E1"].Value = "CompanyName";
                ws.Cells["F1"].Value = "Address";
                ws.Cells["G1"].Value = "Country";
                ws.Cells["H1"].Value = "TelephoneNo";
                ws.Cells["I1"].Value = "Email";
                ws.Cells["J1"].Value = "IsVerified";
                ws.Cells["K1"].Value = "StateName";
                ws.Cells["L1"].Value = "CityName";

                int rowStartFrom = 2;
                foreach (var item in customerList)
                {
                    ws.Cells[string.Format("A{0}", rowStartFrom)].Value = item.Id;
                    ws.Cells[string.Format("B{0}", rowStartFrom)].Value = item.MobileNo;
                    ws.Cells[string.Format("C{0}", rowStartFrom)].Value = item.PersonName;
                    ws.Cells[string.Format("D{0}", rowStartFrom)].Value = item.Designation;
                    ws.Cells[string.Format("E{0}", rowStartFrom)].Value = item.CompanyName;
                    ws.Cells[string.Format("F{0}", rowStartFrom)].Value = item.Address;
                    ws.Cells[string.Format("G{0}", rowStartFrom)].Value = item.Country;
                    ws.Cells[string.Format("H{0}", rowStartFrom)].Value = item.TelephoneNo;
                    ws.Cells[string.Format("I{0}", rowStartFrom)].Value = item.Email;
                    ws.Cells[string.Format("J{0}", rowStartFrom)].Value = item.IsVerified;
                    ws.Cells[string.Format("K{0}", rowStartFrom)].Value = item.StateName;
                    ws.Cells[string.Format("L{0}", rowStartFrom)].Value = item.CityName;
                    rowStartFrom++;
                }
                ws.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment:file=" + Filename + ".xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ApplyCouponListReport()
        {
            try
            {
                string Filename = "ApplyCouponListReport";
                List<GetTotalCoupon_Result> gettotalcoupon = new List<GetTotalCoupon_Result>();
                gettotalcoupon = db.GetTotalCoupon().ToList();

                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(Filename);


                ws.Cells["A1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["A1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["A1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["B1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["B1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["B1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["C1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["C1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["C1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["D1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["D1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["D1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["E1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["E1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["E1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["F1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["F1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["F1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["G1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells["G1"].Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
                ws.Cells["G1"].Style.Font.Color.SetColor(Color.White);

                ws.Cells["A1"].Value = "Id";
                ws.Cells["B1"].Value = "PersonName";
                ws.Cells["C1"].Value = "Coupon Price";
                ws.Cells["D1"].Value = "Total Coupon Price";
                ws.Cells["E1"].Value = "Pending Coupons";
                ws.Cells["F1"].Value = "Assign Coupons";
                ws.Cells["G1"].Value = "Total Coupons";

                int MainRow = 2;
                int b = 1;
                foreach (var iteme in gettotalcoupon)
                {
                    ws.Cells[string.Format("A{0}", MainRow)].Value = b;
                    ws.Cells[string.Format("B{0}", MainRow)].Value = iteme.PersonName;
                    ws.Cells[string.Format("C{0}", MainRow)].Value = iteme.Price;
                    ws.Cells[string.Format("D{0}", MainRow)].Value = iteme.TotalPrice;
                    ws.Cells[string.Format("E{0}", MainRow)].Value = iteme.Pending;
                    ws.Cells[string.Format("F{0}", MainRow)].Value = iteme.Assign;
                    ws.Cells[string.Format("G{0}", MainRow)].Value = iteme.Total;
                    MainRow++;
                    b++;
                    couponlist mycoup = new couponlist();
                    List<GetCouponAssign> couponassignlist = new List<GetCouponAssign>();
                    string q2 = "Select r.*,e.PersonName From AssignCouponExhibitor r left join Exhibitor e On r.ExhibitorId=e.Id Where r.ExhibitorId = '" + iteme.Id + "'";
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
                    }

                    ws.Cells[string.Format("B{0}", MainRow)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("B{0}", MainRow)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("B{0}", MainRow)].Style.Font.Color.SetColor(Color.White);

                    ws.Cells[string.Format("C{0}", MainRow)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("C{0}", MainRow)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("C{0}", MainRow)].Style.Font.Color.SetColor(Color.White);

                    ws.Cells[string.Format("D{0}", MainRow)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("D{0}", MainRow)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("D{0}", MainRow)].Style.Font.Color.SetColor(Color.White);

                    ws.Cells[string.Format("E{0}", MainRow)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[string.Format("E{0}", MainRow)].Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                    ws.Cells[string.Format("E{0}", MainRow)].Style.Font.Color.SetColor(Color.White);

                    ws.Cells[string.Format("B{0}", MainRow)].Value = "Id";
                    ws.Cells[string.Format("C{0}", MainRow)].Value = "Date";
                    ws.Cells[string.Format("D{0}", MainRow)].Value = "Quantity";
                    ws.Cells[string.Format("E{0}", MainRow)].Value = "Assigned By";
                    MainRow++;

                    int a = 1;
                    foreach (var itemw in mycoup.coup_list)
                    {
                        ws.Cells[string.Format("B{0}", MainRow)].Value = a;
                        ws.Cells[string.Format("C{0}", MainRow)].Value = DateTime.Parse(itemw.Date.ToString()).ToString("yyyy-MM-dd");
                        ws.Cells[string.Format("D{0}", MainRow)].Value = itemw.Qty;
                        ws.Cells[string.Format("E{0}", MainRow)].Value = itemw.AssginBy;
                        MainRow++;
                        a++;
                    }

                    foreach (var itemww in mycoup.cup_assignlist)
                    {
                        ws.Cells[string.Format("B{0}", MainRow)].Value = a;
                        ws.Cells[string.Format("C{0}", MainRow)].Value = DateTime.Parse(itemww.Date).ToString("yyyy-MM-dd");
                        ws.Cells[string.Format("D{0}", MainRow)].Value = itemww.Qty;
                        ws.Cells[string.Format("E{0}", MainRow)].Value = itemww.AssginBy;
                        MainRow++;
                        a++;
                    }
                    MainRow++;

                }
                ws.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment:file=" + Filename + ".xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }
            catch (Exception ex)
            {

            }
        }

        public void CustomerCouponDetail()
        {
            try
            {
                string Filename = "CustomerCouponDetailReport";

            }
            catch (Exception exhibitorListReport)
            {

            }
        }
    }
}