namespace cukcuk.api.Entities.DTO
{
    /// <summary>
    /// Dữ liệu trả về khi lọc và phân trang
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu truyền vào để nhận dữ liệu mà mảng trả về</typeparam>
    /// CreatedBy VMHieu 14/07/2022
    public class FilterData<T>
    {
        /// <summary>
        /// Mảng data chứa dữ liệu
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// Tổng số bản ghi có trong data
        /// </summary>
        public long TotalCount { get; set; }
    }
}
