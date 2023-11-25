namespace NLayer.Core.UnitOfWorks;

public interface IUnitOfWork
{
    Task CommitAsync(); // SaveChangesAsync() metodu için
    void Commit(); // SaveChanges() metodu için
}