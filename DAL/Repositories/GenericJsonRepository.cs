using System.Linq.Expressions;
using System.Text.Json;
using DAL.Interfaces;
using Core.Models.UtilityModels;
using Newtonsoft.Json;

namespace DAL.Repositories
{
    public class GenericJsonRepository<T> : IGenericRepository<T>
    {
        private readonly string _filePath;

        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };

        public GenericJsonRepository(string filePath = null)
        {
            _filePath = filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{typeof(T).Name}.json");

            EnsureFileExists();
        }

        public Result<IEnumerable<T>> GetAll()
        {
            var items = ReadFromFile();

            return Result<IEnumerable<T>>.Success(items);
        }

        public Result<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> condition)
        {
            try
            {
                var items = ReadFromFile();
                var filteredItems = items.AsQueryable().Where(condition).ToList();

                return Result<IEnumerable<T>>.Success(filteredItems);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<T>>.Failure("Error retrieving data.");
            }
        }

        public Result<T> GetSingleByCondition(Expression<Func<T, bool>> condition)
        {
            try
            {
                var items = ReadFromFile();
                var item = items.AsQueryable().Where(condition).FirstOrDefault();

                if (item != null)
                {
                    return Result<T>.Success(item);
                }
                else
                {
                    return Result<T>.Failure("Item not found.");
                }
            }
            catch (Exception ex)
            {
                return Result<T>.Failure("Error retrieving data.");
            }
        }

        public Result<T> Add(T item)
        {
            try
            {
                var items = ReadFromFile();
                items.Add(item);
                WriteToFile(items);

                return Result<T>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<T>.Failure("Error adding data.");
            }
        }

        public Result<bool> Update(T item, Expression<Func<T, bool>> condition)
        {
            try
            {
                var items = ReadFromFile();
                var itemToUpdate = items.FirstOrDefault(condition.Compile());

                if (itemToUpdate == null)
                {
                    return Result<bool>.Failure("Item not found.");
                }

                items.Remove(itemToUpdate);
                items.Add(item);
                WriteToFile(items);

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Error updating data.");
            }
        }

        public Result<bool> Delete(Expression<Func<T, bool>> condition)
        {
            try
            {
                var items = ReadFromFile();
                var itemsToRemove = items.Where(condition.Compile()).ToList();

                if (!itemsToRemove.Any())
                {
                    return Result<bool>.Failure("Item not found.");
                }

                foreach (var item in itemsToRemove)
                {
                    items.Remove(item);
                }

                WriteToFile(items);

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Error deleting data.");
            }
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                WriteToFile(new List<T>());
            }
        }

        private List<T> ReadFromFile()
        {
            using var reader = new StreamReader(_filePath);
            var json = reader.ReadToEnd();
            var items = JsonConvert.DeserializeObject<List<T>>(json, _settings);

            return items;
        }

        private void WriteToFile(List<T> items)
        {
            var json = JsonConvert.SerializeObject(items, _settings);
            File.WriteAllText(_filePath, json);
        }
    }
}