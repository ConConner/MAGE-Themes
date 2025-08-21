using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Bookmarks;

public static class BookmarkManager
{
    public static List<BookmarkFolder> InternalCollections = new List<BookmarkFolder>();
    public static List<BookmarkFolder> GlobalCollections = new List<BookmarkFolder>();
    public static List<BookmarkFolder> ProjectCollections = new List<BookmarkFolder>();


    // Collection Methods
    public static int FindCollectionInList(List<BookmarkFolder> collections, string name)
    {
        for (int i = 0; i < collections.Count; i++)
        {
            BookmarkFolder f = collections[i];
            if (f.Name == name) return i;
        }
        return -1;
    }

    public static Bookmark FindBookmarkWithOffset(BookmarkFolder collection, int offset)
    {
        foreach (BookmarkItem item in collection.Items)
        {
            if (item is Bookmark bookmark)
            {
                if (bookmark.Value == offset) return bookmark;
            }
            else if (item is BookmarkFolder folder)
            {
                Bookmark result = FindBookmarkWithOffset(folder, offset);
                if (result != null) return result;
            }
        }
        return null;
    }

    public static (Bookmark bookmark, Config.BookmarkCollection collection)? FindBookmarkCollectionWithOffset(int offset)
    {
        foreach (BookmarkFolder collection in ProjectCollections)
        {
            Bookmark match = FindBookmarkWithOffset(collection, offset);
            if (match != null) return (match, Config.BookmarkCollection.Project);
        }
        foreach (BookmarkFolder collection in GlobalCollections)
        {
            Bookmark match = FindBookmarkWithOffset(collection, offset);
            if (match != null) return (match, Config.BookmarkCollection.Global);
        }
        foreach (BookmarkFolder collection in InternalCollections)
        {
            Bookmark match = FindBookmarkWithOffset(collection, offset);
            if (match != null) return (match, Config.BookmarkCollection.Internal);
        }
        return null;
    }

    /// <summary>
    /// Checks if a bookmark with the old offset exists anywhere and asks the user if they want to create a new one in their project file. Returns true if a bookmark was created or updated.
    /// </summary>
    public static bool RepointedDataCreateBookmark(int oldOffset, int newOffset)
    {
        var match = FindBookmarkCollectionWithOffset(oldOffset);
        // No bookmark found, create new one
        if (match == null)
        {
            if (
                MessageBox.Show(
                    $"No matching Bookmark found.\n\nA new Bookmark will be created automatically in your project collections.",
                    "Bookmark found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information
                )
                != DialogResult.OK
            ) return false;

            int collectionIndex = FindCollectionInList(ProjectCollections, "Repointed");
            if (collectionIndex == -1)
            {
                ProjectCollections.Add(new()
                {
                    Name = "Repointed",
                    Description = "Created Automatically\n\r\n\rContains offsets to resources that got repointed by MAGE"
                });
                collectionIndex = ProjectCollections.Count - 1;
            }
            Bookmark newBookmark = new()
            {
                Name = $"From: {Hex.ToString(oldOffset)}",
                Description = $"Repointed data from {Hex.ToString(oldOffset)}",
                Value = newOffset
            };

            ProjectCollections[collectionIndex].AddItem(newBookmark);

            FormBookmarks.UpdateBookmarkEditor();
            return true;
        }
        // Bookmark found but not in project
        if (match.Value.collection == Config.BookmarkCollection.Internal || match.Value.collection == Config.BookmarkCollection.Global)
        {
            string collectionString = match.Value.collection == Config.BookmarkCollection.Internal ? "an internal" : "a global";
            if (
                MessageBox.Show(
                    $"A matching Bookmark was found in {collectionString} collection.\n\nA copy of it will be moved to your project collections and the value will be updated.",
                    "Bookmark found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information
                )
                != DialogResult.OK
            ) return false;

            BookmarkPath bookmarkPath = match.Value.bookmark.CreateBookmarkPath();
            int collectionIndex = FindCollectionInList(ProjectCollections, bookmarkPath.Root.Name);
            if (collectionIndex == -1)
            {
                ProjectCollections.Add(new()
                {
                    Name = bookmarkPath.Root.Name,
                    Description = bookmarkPath.Root.Description
                });
                collectionIndex = ProjectCollections.Count - 1;
            }

            //Adjust value
            Bookmark b = bookmarkPath.Item.CreateDeepCopy() as Bookmark;
            b.Value = newOffset;
            bookmarkPath.PathList[bookmarkPath.PathList.Count - 1] = b;

            ProjectCollections[collectionIndex].AddItemWithPath(bookmarkPath, true, true);
            FormBookmarks.UpdateBookmarkEditor();
            return true;
        }
        // Bookmark found in project. Updating
        else
        {
            if (
                MessageBox.Show(
                    $"A matching Bookmark was found in your project collection.\n\nThe value will be updated.",
                    "Bookmark found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information
                )
                != DialogResult.OK
            ) return false;
            match.Value.bookmark.Value = newOffset;
            FormBookmarks.UpdateBookmarkEditor();
            return true;
        }
    }


    // Serializing
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
