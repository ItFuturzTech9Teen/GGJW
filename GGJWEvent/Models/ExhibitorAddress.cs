//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GGJWEvent.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExhibitorAddress
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Latlong { get; set; }
        public Nullable<long> StateId { get; set; }
        public Nullable<long> CityId { get; set; }
        public Nullable<long> ExhibitorId { get; set; }
    }
}
