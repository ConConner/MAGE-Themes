using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mage.Bookmarks;

public class BookmarkJsonConverter : JsonConverter<BookmarkItem>
{
    public override bool CanConvert(Type typeToConvert) =>
        typeof(BookmarkItem).IsAssignableFrom(typeToConvert);

    public override BookmarkItem Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // First, peek ahead to determine the type.
        // We can't consume the reader, so we clone it.
        var readerClone = reader;
        string typeIdentifier = null;
        while (readerClone.Read() && readerClone.TokenType != JsonTokenType.EndObject)
        {
            if (readerClone.TokenType == JsonTokenType.PropertyName)
            {
                var propName = readerClone.GetString();
                if (propName == "Items" || propName == "Items")
                {
                    typeIdentifier = "BookmarkFolder";
                    break;
                }
                if (propName == "Value")
                {
                    typeIdentifier = "Bookmark";
                    break;
                }
            }
        }

        // Now, deserialize based on the determined type.
        return typeIdentifier switch
        {
            "BookmarkFolder" => DeserializeBookmarkFolder(ref reader, options),
            "Bookmark" => DeserializeBookmark(ref reader, options),
            _ => throw new JsonException("Cannot determine BookmarkItem type from properties.")
        };
    }

    private Bookmark DeserializeBookmark(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var bookmark = new Bookmark();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propName = reader.GetString();
                reader.Read(); // Move to the value
                switch (propName)
                {
                    case "Name":
                        bookmark.Name = reader.GetString();
                        break;
                    case "Description":
                        bookmark.Description = reader.GetString();
                        break;
                    case "Value":
                        bookmark.Value = reader.GetInt32();
                        break;
                }
            }
        }
        return bookmark;
    }

    private BookmarkFolder DeserializeBookmarkFolder(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var BookmarkFolder = new BookmarkFolder();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propName = reader.GetString();
                reader.Read(); // Move to the value
                switch (propName)
                {
                    case "Name":
                        BookmarkFolder.Name = reader.GetString();
                        break;
                    case "Items": // Or "Items"
                        // This is the key: delegate list deserialization back to the
                        // main serializer, which WILL use this converter for the items.
                        BookmarkFolder.Items = JsonSerializer.Deserialize<List<BookmarkItem>>(ref reader, options);
                        break;
                }
            }
        }
        return BookmarkFolder;
    }

    public override void Write(
        Utf8JsonWriter writer,
        BookmarkItem value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        switch (value)
        {
            case Bookmark bookmark:
                writer.WriteString("Name", bookmark.Name);
                if (bookmark.Description != null)
                {
                    writer.WriteString("Description", bookmark.Description);
                }
                writer.WriteNumber("Value", bookmark.Value);
                break;

            case BookmarkFolder BookmarkFolder:
                writer.WriteString("Name", BookmarkFolder.Name);
                if (BookmarkFolder.Description != null)
                {
                    writer.WriteString("Description", BookmarkFolder.Description);
                }
                writer.WritePropertyName("Items");
                JsonSerializer.Serialize(writer, BookmarkFolder.Items, options);
                break;

            default:
                throw new JsonException("Unknown BookmarkItem type.");
        }

        writer.WriteEndObject();
    }
}
