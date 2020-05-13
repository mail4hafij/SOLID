namespace WEB.LIB
{
    public interface IPostback<T>
    {
        T Form { get; set; }
    }
}