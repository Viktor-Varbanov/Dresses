namespace Dresses.Pages.AbstractionPageComponents
{

    public abstract class AbstractPage<TMap>
        where TMap : AbstractElementMap, new()
    {
        protected TMap Map() => new TMap();
    }
    public abstract class AbstractPageWithValidator<TMap, TValidator> : AbstractPage<TMap>
    where TMap : AbstractElementMap, new()
    where TValidator : AbstractValidator<TMap>, new()
    {
        public TValidator Validate() => new TValidator();
    }
}
