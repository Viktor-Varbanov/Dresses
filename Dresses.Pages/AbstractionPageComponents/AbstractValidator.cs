namespace Dresses.Pages.AbstractionPageComponents
{
    public abstract class AbstractValidator<TMap>
    where TMap : AbstractElementMap, new()
    {
        public TMap Map => new TMap();
    }
}