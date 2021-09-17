namespace Dresses.Pages.AbstractionPageComponents
{
    public abstract class AbstractValidator<TMap>
    where TMap : AbstractElementMap, new()
    {
        protected TMap Map => new TMap();
    }
}
