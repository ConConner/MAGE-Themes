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

    private List<BookmarkItem> items = new();
    public List<BookmarkItem> Items
    {
        get => items;
        set
        {
            items = value;
            foreach (BookmarkItem item in items)
            {
                item.Parent = this;
            }
        }
    }

    public void AddItem(BookmarkItem item)
    {
        Items.Add(item);
        item.Parent = this;
    }
}
