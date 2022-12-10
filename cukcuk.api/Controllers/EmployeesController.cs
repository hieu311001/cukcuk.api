using cukcuk.api.Entities;
using cukcuk.api.Entities.DTO;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace cukcuk.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// API thêm 1 nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên muốn thêm vào</param>
        /// <returns>ID của nhân viên được thêm mới</returns>
        /// CreatedBy VMHieu 14/07/2022
        [HttpPost]
        public IActionResult InsertEmployee([FromBody] Employee employee)
        {
            try
            {
                // Khởi tạo kết nối tới db
                string connectionString = "Server=3.0.89.182;Port=3306;Database=WDT.2022.VMHIEU;Uid=dev;Pwd=12345678";
                var mySqlConnection = new MySqlConnection(connectionString);

                //Chuẩn bị câu lệnh INSERT INTO
                string insertCommand = "INSERT INTO employee (EmployeeID, EmployeeCode, EmployeeName, DateOfBirth, Gender, IdentityNumber, IdentityIssuedPlace, IdentityIssuedDate, Email, PhoneNumber, PositionID, DepartmentID, TaxCode, Salary, JoiningDate, WorkStatus, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy)" +
                    "VALUES(@EmployeeID, @EmployeeCode, @EmployeeName, @DateOfBirth, @Gender, @IdentityNumber, @IdentityIssuedPlace, @IdentityIssuedDate, @Email, @PhoneNumber, @PositionID, @DepartmentID, @TaxCode, @Salary, @JoiningDate, @WorkStatus, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy) ";

                // Chuẩn bị tham số đầu vào cho câu lệnh INSERT INTO
                var parameters = new DynamicParameters();
                var dateTimeNow = DateTime.Now;
                var EmployeeId = Guid.NewGuid();
                parameters.Add("@EmployeeID", EmployeeId);
                parameters.Add("@EmployeeCode", employee.EmployeeCode);
                parameters.Add("@EmployeeName", employee.EmployeeName);
                parameters.Add("@DateOfBirth", employee.DateOfBirth);
                parameters.Add("@Gender", employee.Gender);
                parameters.Add("@IdentityNumber", employee.IdentityNumber);
                parameters.Add("@IdentityIssuedPlace", employee.IdentityIssuedPlace);
                parameters.Add("@IdentityIssuedDate", employee.IdentityIssuedDate);
                parameters.Add("@Email", employee.Email);
                parameters.Add("@PhoneNumber", employee.PhoneNumber);
                parameters.Add("@PositionID", employee.PositionID);
                parameters.Add("@DepartmentID", employee.DepartmentID);
                parameters.Add("@TaxCode", employee.TaxCode);
                parameters.Add("@Salary", employee.Salary);
                parameters.Add("@JoiningDate", employee.JoiningDate);
                parameters.Add("@WorkStatus", employee.WorkStatus);
                parameters.Add("@CreatedDate", dateTimeNow);
                parameters.Add("@CreatedBy", employee.CreatedBy);
                parameters.Add("@ModifiedDate", dateTimeNow);
                parameters.Add("@ModifiedBy", employee.ModifiedBy);

                // Thực hiện gọi vào db để chạy câu lệnh INSERT INTO với tham số đầu vào ở trên
                var affectedRows = mySqlConnection.Execute(insertCommand, parameters);

                // Xử lý kết quả trả về ở db
                if (affectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, EmployeeId);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (MySqlException mySqlException)
            {
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e003");
                }
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// Sửa 1 nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên muốn sửa</param>
        /// <param name="employeeID">ID của nhân viên muốn sửa</param>
        /// <returns>ID của nhân viên được update</returns>
        /// CreatedBy VMHieu 14/07/2022
        [HttpPut("{employeeID}")]
        public IActionResult UpdateEmployee([FromRoute] Guid employeeID, [FromBody] Employee employee)
        {
            try
            {
                // Khởi tạo kết nối tới db
                string connectionString = "Server=3.0.89.182;Port=3306;Database=WDT.2022.VMHIEU;Uid=dev;Pwd=12345678";
                var mySqlConnection = new MySqlConnection(connectionString);
                
                // Chuẩn bị câu lệnh Update
                string updateEmployeeCommand = "UPDATE employee e " + 
                    "SET EmployeeCode = @EmployeeCode, " +
                        "EmployeeName = @EmployeeName, " +
                        "DateOfBirth = @DateOfBirth, " +
                        "Gender = @Gender, " + 
                        "IdentityNumber = @IdentityNumber, " +
                        "IdentityIssuedPlace = @IdentityIssuedPlace, " +
                        "IdentityIssuedDate = @IdentityIssuedDate, " +
                        "Email = @Email, " +
                        "PhoneNumber = @PhoneNumber, " +
                        "PositionID = @PositionID, " +
                        "DepartmentID = @DepartmentID, " +
                        "TaxCode = @TaxCode, " +
                        "Salary = @Salary, " +
                        "JoiningDate = @JoiningDate, " +
                        "WorkStatus = @WorkStatus, " +
                        "ModifiedDate = @ModifiedDate, " +
                        "ModifiedBy = @ModifiedBy " +
                        "WHERE EmployeeID = @EmployeeID;";

                // Chuẩn bị tham số đầu vào cho câu lệnh Update
                var parameters = new DynamicParameters();
                var dateTimeNow = DateTime.Now;
                parameters.Add("@EmployeeID", employeeID);
                parameters.Add("@EmployeeCode", employee.EmployeeCode);
                parameters.Add("@EmployeeName", employee.EmployeeName);
                parameters.Add("@DateOfBirth", employee.DateOfBirth);
                parameters.Add("@Gender", employee.Gender);
                parameters.Add("@IdentityNumber", employee.IdentityNumber);
                parameters.Add("@IdentityIssuedPlace", employee.IdentityIssuedPlace);
                parameters.Add("@IdentityIssuedDate", employee.IdentityIssuedDate);
                parameters.Add("@Email", employee.Email);
                parameters.Add("@PhoneNumber", employee.PhoneNumber);
                parameters.Add("@PositionID", employee.PositionID);
                parameters.Add("@DepartmentID", employee.DepartmentID);
                parameters.Add("@TaxCode", employee.TaxCode);
                parameters.Add("@Salary", employee.Salary);
                parameters.Add("@JoiningDate", employee.JoiningDate);
                parameters.Add("@WorkStatus", employee.WorkStatus);
                parameters.Add("@ModifiedDate", dateTimeNow);
                parameters.Add("@ModifiedBy", employee.ModifiedBy);

                // Thực hiện gọi vào db để chạy câu lệnh UPDATE với tham số đầu vào ở trên
                var affectedRows = mySqlConnection.Execute(updateEmployeeCommand, parameters);

                // Xử lý kết quả trả về ở db
                if (affectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, employeeID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (MySqlException mySqlException)
            {
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e003");
                }
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API sửa 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn xóa</param>
        /// <returns>ID của nhân viên đã xóa</returns>
        /// CreatedBy VMHieu 14/07/2022
        [HttpDelete("{employeeID}")]
        public IActionResult DeleteEmployee([FromRoute] Guid employeeID)
        {
            try
            {
                // Khởi tạo kết nối tới db
                string connectionString = "Server=3.0.89.182;Port=3306;Database=WDT.2022.VMHIEU;Uid=dev;Pwd=12345678";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị câu lệnh Update
                string deleteEmployeeCommand = "DELETE FROM employee WHERE EmployeeID = @EmployeeID";

                // Chuẩn bị tham số đầu vào cho câu lệnh Update
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", employeeID);

                // Thực hiện gọi vào db để chạy câu lệnh UPDATE với tham số đầu vào ở trên
                var affectedRows = mySqlConnection.Execute(deleteEmployeeCommand, parameters);

                // Xử lý kết quả trả về ở db
                if (affectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, employeeID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }


        /// <summary>
        /// API lọc
        /// </summary>
        /// <param name="code">Mã nhân viên</param>
        /// <param name="name">Tên nhân viên</param>
        /// <param name="positionID">ID vị trí</param>
        /// <param name="departmentID">ID phòng ban</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// CreatedBy VMHieu 14/07/2022
        [HttpGet("filter")]
        public IActionResult FilterEmployees([FromQuery] string? code, [FromQuery] string? name,
            [FromQuery] Guid? positionID, [FromQuery] Guid? departmentID)
        {
            //try
            {
                string connectionString = "Server=3.0.89.182;Port=3306;Database=WDT.2022.VMHIEU;Uid=dev;Pwd=12345678";
                var mySqlConnection = new MySqlConnection(connectionString);

                string storedProcName = "Proc_Employee_Filter";

                var parameters = new DynamicParameters();
                parameters.Add("@$Sort", "ModifiedDate DESC");

                var whereSearch = new List<string>();
                var whereFilter = new List<string>();

                if (code != null)
                {
                    whereSearch.Add($"EmployeeCode LIKE '%{code}%'");
                }
                if (name != null)
                {
                    whereSearch.Add($"EmployeeName LIKE '%{name}%'");
                }
                if (positionID != null)
                {
                    whereFilter.Add($"PositionID LIKE '%{positionID}%'");
                }
                if (departmentID != null)
                {
                    whereFilter.Add($"DepartmentID LIKE '%{departmentID}%'");
                }

                string search = string.Join(" OR ", whereSearch);
                string filter = string.Join(" AND ", whereFilter);
                string whereClause = "";
                if (search != "" && filter == "")
                {
                    whereClause = $"WHERE ({search})";
                }
                else if (search == "" && filter != "")
                {
                    whereClause = $"WHERE ({filter})";
                }
                else if (search != "" && filter != "")
                {
                    whereClause = $"WHERE ({search}) AND {filter}";
                }

                parameters.Add("@$Where", whereClause);

                var multipleResults = mySqlConnection.QueryMultiple(storedProcName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (multipleResults != null)
                {
                    var employees = multipleResults.Read<Employee>();
                    var totalCount = multipleResults.Read<long>().Single();
                    return StatusCode(StatusCodes.Status200OK, new FilterData<Employee>()
                    {
                        Data = employees.ToList(),
                        TotalCount = totalCount
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }

            }
            //catch (Exception ex)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, "e001");
            //}
        }

        /// <summary>
        /// Lấy ra toàn bộ nhân viên
        /// </summary>
        /// <returns>Trả về thông tin của toàn bộ nhân viên</returns>
        /// CreatedBy VMHieu 14/07/2022
        [HttpGet]

        public IActionResult GetAllEmployee()
        {
            //try
            {
                string connectionString = "Server=3.0.89.182;Port=3306;Database=WDT.2022.VMHIEU;Uid=dev;Pwd=12345678";
                var mySqlConnection = new MySqlConnection(connectionString);

                var getAllEmployeeCommand = "Proc_Employee_GetAllEmployee";

                var result = mySqlConnection.Query<Employee>(getAllEmployeeCommand, commandType: System.Data.CommandType.StoredProcedure);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                } else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            //catch (Exception ex)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, "e001");
            //}
        }

        /// <summary>
        /// Lấy thông tin của 1 nhân viên thông qua ID
        /// </summary>
        /// <param name="employeeID">ID của nhân viên</param>
        /// <returns>Bản ghi chứa thông tin nv đó</returns>
        /// CreatedBy VMHieu 14/07/2022
        [HttpGet("{employeeID}")]
        public IActionResult GetEmployeeByID([FromRoute] Guid employeeID)
        {
            try
            {
                string connectionString = "Server=3.0.89.182;Port=3306;Database=WDT.2022.VMHIEU;Uid=dev;Pwd=12345678";
                var mySqlConnection = new MySqlConnection(connectionString);

                string storedEmployeeName = "Proc_Employee_GetByEmployeeId";

                var parameters = new DynamicParameters();
                parameters.Add("@$EmployeeID", employeeID);

                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedEmployeeName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (employee != null)
                {
                    return StatusCode(StatusCodes.Status200OK, employee);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }

        }

        /// <summary>
        /// Lấy ra mã EmployeeCode lớn nhất sau đó + 1
        /// </summary>
        /// <returns> EmployeeCodeMax+1 </returns>
        /// CreatedBy VMHieu 14/07/2022
        [HttpGet("new-code")]
        public IActionResult getNewEmployeeCode()
        {
            try
            {
                string connectionString = "Server=3.0.89.182;Port=3306;Database=WDT.2022.VMHIEU;Uid=dev;Pwd=12345678";
                var mySqlConnection = new MySqlConnection(connectionString);

                string storedNewEmployeeCode = "Proc_Employee_GetMaxCode";

                string newEmployeeCode = mySqlConnection.QueryFirstOrDefault<String>(storedNewEmployeeCode, commandType: System.Data.CommandType.StoredProcedure);

                string newCode = "NV" + (Int64.Parse(newEmployeeCode.Substring(2)) + 1).ToString();

                if (newCode != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new NewEmployeeCode()
                    {
                        ///data = newCode
                        data=newEmployeeCode
                    }) ; 
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
        
    }
}
