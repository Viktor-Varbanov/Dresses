namespace demo
{

    public class AbstractPage<TMap, TValidator>
    where TMap : AbstractPageMap, new()
    where TValidator : AbstractPageValidator<TMap>, new()
    {

        public TValidator Validate() => new TValidator();
    }
}
