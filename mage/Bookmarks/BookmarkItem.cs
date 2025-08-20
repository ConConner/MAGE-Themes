using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace mage.Bookmarks;


public struct BookmarkPath
{
    public BookmarkPath() { }

    public List<BookmarkItem> PathList { get; set; } = new();
    public BookmarkItem Root => PathList[0];
    public BookmarkItem Item => PathList[PathList.Count - 1];

    /// <summary>
    /// Appends path2 on path1
    /// </summary>
    public static BookmarkPath Combine(BookmarkPath path1, BookmarkPath path2)
    {
        path1.PathList.AddRange(path2.PathList);
        return path1;
    }
}

public abstract class BookmarkItem
{
    public string Name { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public BookmarkFolder Parent { get; set; } = null;
    [JsonIgnore]
    public string PathString
    {
        get
        {
            if (Parent == null) return Name;
            return Parent.PathString + $"/{Name}";
        }
    }

    public BookmarkPath CreateBookmarkPath()
    {
        BookmarkPath path = new();
        path.PathList.Add(this);

        if (Parent == null) return path;
        return BookmarkPath.Combine(Parent.CreateBookmarkPath(), path);
    }

    public abstract BookmarkItem CreateDeepCopy();
}
