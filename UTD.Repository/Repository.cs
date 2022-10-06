using UTD.Models;

namespace UTD.Repository
{
    //TODO: Come ON now.  Don't just use a static class for in-memory storage of all objects.  That's a rookie mistake.
    public static class Repository
    {
        private static List<UTDModel> AllTrackedItems = new();

        public static void Add(UTDModel item)
        {
            AllTrackedItems.Add(item);

            var itemType = item.GetType();
            var fields = itemType.GetFields();
            foreach (var field in fields)
            {
                if (itemType.IsAssignableFrom(typeof(UTDModel)))
                {
                    var val = field.GetValue(item);
                    if (val != null)
                    {
                        Add((UTDModel)field.GetValue(item));
                    }
                }

                foreach (var i in itemType.GetInterfaces())
                {
                    if (i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)) && i.GetGenericArguments()[0].IsAssignableFrom(typeof(UTDModel)))
                    {
                        var children = (IEnumerable<UTDModel>)field.GetValue(item);
                        foreach (var child in children)
                        {
                            Add(child);
                        }
                    }
                }

                //TODO: Theoretically, we should also handle Dictionaries and other such generic cases.  But since this is a temporary repo implementation... probably no need.
            }
        }

        public static UTDModel GetById(Guid id)
        {
            return AllTrackedItems.FirstOrDefault(m => m.Id == id && !m.IsDeleted);
        }

        public static IEnumerable<T> GetAll<T>() where T : UTDModel{
            var toReturn = new List<T>();

            foreach (var item in AllTrackedItems)
            {
                if(item.GetType() == typeof(T) && !item.IsDeleted)
                {
                    toReturn.Add((T) item);
                }
            }

            return toReturn;
        }

        public static IEnumerable<T> GetAll<T>(Func<T, bool> condition) where T : UTDModel
        {
            var toReturn = new List<T>();

            foreach (var item in AllTrackedItems)
            {
                if (item.GetType() == typeof(T) && condition((T)item) && !item.IsDeleted)
                {
                    toReturn.Add((T)item);
                }
            }

            return toReturn;
        }
        
        public static void Delete(UTDModel item)
        {
            item.IsDeleted = true;
        }

        public static void RemoveAllItemsFromMemory()
        {
            AllTrackedItems.Clear();
        }
    }
}