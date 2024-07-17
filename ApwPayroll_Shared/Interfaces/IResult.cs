namespace ApwPayroll_Shared.Interfaces
{
    public interface IResult<T>
    {
        List<string> Messages { get; set; }
        bool succeeded { get; set; }
        T Data { get; set; }
        int code { get; set; }
        string Token { get; set; }
    }
}
