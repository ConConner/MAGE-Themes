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
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        AllowTrailingCommas = true,
    };
    private static JsonSerializerOptions JsonOptionsIndented = new JsonSerializerOptions()
    {
        Converters = { new BookmarkJsonConverter() },
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        AllowTrailingCommas = true,
    };

    public static string Serialize(BookmarkFolder collection, bool writeIndented = true)
    {
        JsonSerializerOptions options = writeIndented ? JsonOptionsIndented : JsonOptions;
        return JsonSerializer.Serialize(collection, options);
    }

    public static BookmarkFolder Deserialize(string json)
    {
        return JsonSerializer.Deserialize<BookmarkFolder>(json, JsonOptions);
    }

    public static string SerializeCollections(List<BookmarkFolder> collections, bool writeIndented = true)
    {
        JsonSerializerOptions options = writeIndented ? JsonOptionsIndented : JsonOptions;
        List<BookmarkItem> castList = collections.Cast<BookmarkItem>().ToList();
        return JsonSerializer.Serialize(castList, options);
    }

    public static List<BookmarkFolder> DeserializeCollections(string json)
    {
        List<BookmarkItem> result = JsonSerializer.Deserialize<List<BookmarkItem>>(json, JsonOptions);
        return result.Cast<BookmarkFolder>().ToList();
    }
}
