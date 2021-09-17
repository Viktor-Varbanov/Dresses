namespace demo
{

    public class AbstractPageValidator<T>
    where T : AbstractPageMap, new()
    {

        public T Map => new T();
    }
}
