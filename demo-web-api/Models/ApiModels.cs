namespace demo_web_api.Models
{
    /// <summary>
    /// 共用 API 物件模型
    /// </summary>
    public class ApiResponse<T>
    {
        public bool success { get; set; } = false;

        public T data { get; set; }

        public string message { get; set; } = "";
    }

    public class RestaurantResponseModel
    {
        public string restaurnatName { get; set; } = "";
    }
}
