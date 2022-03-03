namespace kongsberg.Interfaces;

public interface ISensor<T>
{
    public abstract T Generate();
}
