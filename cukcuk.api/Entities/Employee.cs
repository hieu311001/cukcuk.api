using cukcuk.api.Enum;
using System.ComponentModel.DataAnnotations;

namespace cukcuk.api.Entities
{
    /// <summary>
    /// Class nhân viên
    /// CreatedBy VMHieu 14/07/2022
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required(ErrorMessage = "e004")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required(ErrorMessage = "e005")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Số CMND/CCCD
        /// </summary>
        [Required(ErrorMessage = "e006")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Nơi cấp CMND
        /// </summary>
        public string? IdentityIssuedPlace { get; set; }

        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        public DateTime? IdentityIssuedDate { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "e007")]
        [EmailAddress(ErrorMessage = "e009")]
        public string Email { get; set; }

        /// <summary>
        /// SĐT
        /// </summary>
        [Required(ErrorMessage = "e008")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid? PositionID { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string? PositionName { get; set; }

        /// <summary>
        /// ID phòng ban
        /// </summary>
        public Guid? DepartmentID { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string? TaxCode { get; set; }

        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Ngày gia nhập 
        /// </summary>
        public DateTime? JoiningDate { get; set; }

        /// <summary>
        /// Trạng thái làm việc
        /// </summary>
        public WorkStatus? WorkStatus { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}
