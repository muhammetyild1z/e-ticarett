//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projee.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Sepet
    {
        public int SPT_ID { get; set; }
        public Nullable<int> STO_ID { get; set; }
        public Nullable<decimal> MIKTAR { get; set; }
        public Nullable<decimal> BR_FYT 
        { 
            get; 
            set; 
        }

        public Nullable<decimal> TOPLAM
        {
            get
            {
                return MIKTAR * BR_FYT;
            }
            set
            {
                value = MIKTAR * BR_FYT;
            }
        }
        public Nullable<int> MUS_ID { get; set; }
        public Nullable<System.DateTime> CDate { get; set; }
    }
}
