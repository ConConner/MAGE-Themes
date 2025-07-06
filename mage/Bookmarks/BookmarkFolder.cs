using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mage.Bookmarks;

public class BookmarkFolder : BookmarkItem
{
    [JsonConstructor]
    public BookmarkFolder() { }
    public List<BookmarkItem> Items { get; set; } = new List<BookmarkItem>();
}
