//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocumentProcessing.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Document
    {
        public int IdDocument { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SerialPassport { get; set; }
        public string NumberPassport { get; set; }
        public System.DateTime DateOfInsurence { get; set; }
        public string DriverLicense { get; set; }
        public int IdOpenInsurance { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string SerialCTC { get; set; }
        public string NumberCTC { get; set; }
    
        public virtual OpenInsurance OpenInsurance { get; set; }
    }
}
