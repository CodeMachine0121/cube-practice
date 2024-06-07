using cube_practice.Enums;

namespace cube_practice.Models;

public class ApiResponse
{

    public ApiStatus Status { get; set; }
    public object Data { get; set; }
    
    public static ApiResponse SuccessWithData(object data)
    {
        return new ApiResponse()
        {
            Status = ApiStatus.Success,
            Data =  data
        };
    }

    public static ApiResponse Success()
    {
        return new ApiResponse()
        {
            Status = ApiStatus.Success
        };
    }


}