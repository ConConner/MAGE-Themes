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

    public override BookmarkItem CreateDeepCopy()
    {
        BookmarkFolder copiedFolder = new BookmarkFolder()
        {
            Name = this.Name,
            Description = this.Description
        };

        // Create deep copies of items
        foreach (BookmarkItem item in Items) copiedFolder.AddItem(item.CreateDeepCopy());

        return copiedFolder;
    }
}
