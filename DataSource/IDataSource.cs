namespace MauiApp1;

public interface IDataSource<T>
{
    void AddRecord(T record);
    void AddRecords(List<T> records);
    T GetRecord(string name);
    List<T> GetRecords();
    void ClearRecords();
}
