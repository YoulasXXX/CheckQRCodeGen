//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckQRCodeGen.Models
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media.Imaging;

    public partial class Users
    {
        public int userId { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string surNaem { get; set; }
        public BitmapImage userQRCODE { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}
