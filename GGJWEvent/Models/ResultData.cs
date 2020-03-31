using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGJWEvent.Models
{
    public class ResultData
    {
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }

    public class GetExhibitorDatalists
    {
        public long Id { get; set; }
        public string PersonName { get; set; }
        public string Designation { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string FCMToken { get; set; }
        public Nullable<bool> IsVerified { get; set; }
        public string Image { get; set; }
        public List<GetExhibitorAddresses> AddressList { get; set; }
    }

    public class GetExhibitorAddresses
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Latlong { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public long StateId { get; set; }
        public long CityId { get; set; }
        public long ExhibitorId { get; set; }
    }

    public class notification_person_list
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string FCMToken { get; set; }
        public bool Selected { get; set; }
    }
    public class couponlist
    {
        public List<GetCouponAssign> cup_assignlist { get; set; }
        public List<GetCouponList> coup_list { get; set; }
    }
    public class SendNotifications
    {
        public string type { get; set; }
        public long id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
    }

    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public class UserLogin
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class DataBag
    {
        public string NumberOfResult { get; set; }
        public string CustomerId { get; set; }
        public string CouponNo { get; set; }
        public string DrawId { get; set; }
        public string PersonName { get; set; }
        public string Image { get; set; }
    }
    public class ApplyCouponList
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long ExhibitorId { get; set; }
        public string PersonName { get; set; }
        public string IsActive { get; set; }
        public string Qty { get; set; }
        public string qty { get; set; }
        public decimal Price { get; set; }
        public string TotalQtyLeft { get; set; }
    }

    public class GetExhibitorDataList
    {
        public string ExhibitorName { get; set; }
        public List<GetCustomerCouponData_Result> CouponNo { get; set; }
    }
    public class GetExhibitorData
    {
        public List<GetCustomerCouponDetail_Result> CouponNo { get; set; }
    }

    public class GetCustomerCouponByExhibitorIdList
    {
        public List<GetcustomerCouponByExhibitorIdData_Result> CouponNo { get; set; }
    }
    public class GetallData
    {
        public List<GetCouponList> list { get; set; }
        public List<GetCouponAssign> assign { get; set; }
    }

    public class Count
    {
        public long Id { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Qty { get; set; }
    }
    public class GetCouponList
    {
        public long Id { get; set; }
        public Nullable<long> ExhibitorId { get; set; }
        public string Qty { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string PersonName { get; set; }
        public string CouponNo { get; set; }
        public string AssginBy { get; set; }
    }
    public class GetCouponAssign
    {
        public long Id { get; set; }
        public string CouponNo { get; set; }
        public Nullable<long> ExhibitorId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Qty { get; set; }
        public string Total { get; set; }
        public string Date { get; set; }
        public string PersonName { get; set; }
        public string AssginBy { get; set; }
    }
}