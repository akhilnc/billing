using System;
namespace billing.Data.Models
{
    public partial class MstUser
    {
        public int Id { get; set; }
        public string UId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string ProfileImage { get; set; }
        public string MobileNo { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public  MstUserRole Role { get; set; }
    }
}
