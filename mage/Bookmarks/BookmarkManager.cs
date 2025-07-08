using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mage.Bookmarks;

public static class BookmarkManager
{
    public static List<BookmarkFolder> InternalCollections = new List<BookmarkFolder>();
    public static List<BookmarkFolder> GlobalCollections = new List<BookmarkFolder>();
    public static List<BookmarkFolder> ProjectCollections = new List<BookmarkFolder>();

    private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions()
    {
        Converters = { new BookmarkJsonConverter() },
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        AllowTrailingCommas = true,
    };

    public static string Serialize(BookmarkFolder collection)
    {
        return JsonSerializer.Serialize(collection, JsonOptions);
    }

    public static BookmarkFolder Deserialize(string json)
    {
        return JsonSerializer.Deserialize<BookmarkFolder>(json, JsonOptions);
    }
}
