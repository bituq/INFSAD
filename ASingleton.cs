namespace Singleton;

public abstract class ASingleton<T>
    where T : ASingleton<T>
{
    public ASingleton()
    {
        instance ??= this;
    }

    public static ASingleton<T>? instance;

    public T GetInstance() => (T)instance;
}