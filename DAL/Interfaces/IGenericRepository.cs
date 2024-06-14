using System.Linq.Expressions;
using Core.Models.UtilityModels;


namespace DAL.Interfaces
{
    public interface IGenericRepository<T>
    {
        Result<IEnumerable<T>> GetAll();
        Result<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> condition);
        Result<T> GetSingleByCondition(Expression<Func<T, bool>> condition);
        Result<T> Add(T item);
        Result<bool> Update(T item, Expression<Func<T, bool>> condition);
        Result<bool> Delete(Expression<Func<T, bool>> condition);
    }
}
