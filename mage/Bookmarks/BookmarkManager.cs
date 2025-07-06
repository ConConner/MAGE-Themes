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
    public static List<BookmarkFolder> BookmarkCollections = new List<BookmarkFolder>();

    public static List<BookmarkFolder> TestBookmarks = new List<BookmarkFolder>()
    {
        new BookmarkFolder()
        {
            Name = "My First Collection",
            Items = new()
            {
                new BookmarkFolder()
                {
                    Name = "Samus Graphics",
                    Description = "Everything about Samsus",
                    Items = new() 
                    {
                        new Bookmark() {Name="Samus Arm", Description="Just her Arm", Value=69},
                        new Bookmark() {Name="Samus Leg", Description="Legma my balls", Value=429},
                        new Bookmark() {Name="Samus Boobs", Description="Whoa hold on there", Value=666999},
                        new BookmarkFolder()
                        {
                            Name = "Deeper level Folder",
                            Description = "This is very deep",
                            Items = new()
                        }
                    }
                },
                new BookmarkFolder()
                {
                    Name = "Weapon Graphics",
                    Description = "GFX GFX FXG XGF",
                    Items = new()
                    {
                        new Bookmark() {Name="Boring Bookmark", Description="", Value=0}
                    }
                },
            }
        }
    };

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
