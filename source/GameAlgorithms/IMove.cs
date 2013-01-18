namespace Quarto.Algorithms
{
    public interface IMove<T>
    {
        T ApplyTo(T state);
    }
}
