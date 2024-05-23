namespace MauiApp1;

public interface IUseCase<TOutput>
{
    Task<TOutput> Execute();
}

public interface IUseCase<TInput, TOutput>
{
    Task<TOutput> Execute(TInput input);
}
