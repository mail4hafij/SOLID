namespace WEB.LIB
{
    public interface IModel<out T>
    {
        T Form { get; }
    }
}