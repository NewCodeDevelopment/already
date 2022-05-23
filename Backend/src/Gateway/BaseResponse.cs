namespace Gateway;

public class BaseResponse<T> where T : BaseDto
{
    public T Response { get; set; }

    public BaseResponse(T response)
    {
        Response = response;
    }
}
public class BaseResponseList<T> where T : BaseDto
{
    public List<T> Response { get; set; }

    public BaseResponseList(List<T> response)
    {
        Response = response;
    }
}