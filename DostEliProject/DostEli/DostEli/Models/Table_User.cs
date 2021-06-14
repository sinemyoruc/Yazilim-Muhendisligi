//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DostEli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Table_User
    {
       public int User_Id { get; set; }
        [DisplayName("Ad�n�z")]
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz")]
        public string UserFirstName { get; set; }
        [DisplayName("Soyad�n�z")]
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz")]
        public string UserLastName { get; set; }
        [DisplayName("Adresiniz")]
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz")]
        public string Adress { get; set; }
        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz")]
        public string Email { get; set; }
        [DisplayName("Kullan�c� Ad�n�z")]
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz")]
        public string UserName { get; set; }
        [DisplayName("�ifreniz")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz")]
        public string Password { get; set; }
        [DisplayName("�ifrenizi Tekrar Giriniz")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz")]
        public string ConfirmPassword { get; set; }
    }
}
