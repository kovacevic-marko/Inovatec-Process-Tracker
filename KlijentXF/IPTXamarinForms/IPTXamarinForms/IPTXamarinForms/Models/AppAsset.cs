using System;

namespace IPTXamarinForms.Models
{
    public class AppAsset
    {
        public Nullable<int> SequenceNumber { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public string BodyStyle { get; set; }
        public Nullable<int> Year { get; set; }
        public string VIN { get; set; }
        public Nullable<int> Condition { get; set; }
        public Nullable<int> Mileage { get; set; }
        public Nullable<decimal> MSRP { get; set; }
        public Nullable<decimal> AdjustedMSRP { get; set; }
        public Nullable<decimal> WholesaleClean { get; set; }
        public string Type { get; set; }
        public int AssetTypeName { get; set; } //mozda je isto kao Type, ali prikazati oba pa cemo lako skloniti ako je visak
        public Nullable<decimal> LenderBookValue { get; set; }
        public Nullable<decimal> OriginalBookValue { get; set; }
        public string OriginalBookType { get; set; }
    }
}
