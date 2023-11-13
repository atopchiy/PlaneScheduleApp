namespace PlaneScheduleApp.Helpers;

public static class DictionaryHelper
{
    public static void RemoveRange<TKey, TValue>(this Dictionary<TKey,TValue> dictionary, IEnumerable<TKey> keysToRemove) 
        where TKey : notnull
    {
        foreach (var key in keysToRemove)
        {
            try
            { 
                dictionary.Remove(key);
            }
            catch (Exception)
            {
                Console.WriteLine($"Could not remove key: {key} from dictionary");
                throw;
            }
        }
    }
}