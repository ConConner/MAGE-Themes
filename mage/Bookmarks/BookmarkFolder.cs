using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

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

    public int CountBookmarks()
    {
        int count = 0;
        foreach (BookmarkItem item in Items)
        {
            if (item is Bookmark) count++;
            if (item is BookmarkFolder folder) count += folder.CountBookmarks();
        }
        return count;
    }

    public void AddItem(BookmarkItem item)
    {
        Items.Add(item);
        item.Parent = this;
    }

    public bool Contains(BookmarkItem item)
    {
        foreach (BookmarkItem bi in Items)
        {
            if (
                item.GetType().Equals(bi.GetType())
                && item.Name == bi.Name
            ) return true;
        }
        return false;
    }

    public BookmarkItem Find(BookmarkItem item)
    {
        foreach (BookmarkItem bi in Items)
        {
            if (
                item.GetType().Equals(bi.GetType())
                && item.Name == bi.Name
            ) return bi;
        }
        return null;
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

    /// <summary>
    /// Adds an item from a BookmarkPath, optionally including all folders up to the item. 
    /// </summary>
    public void AddItemWithPath(BookmarkPath path, bool includeFullPath, bool autoReplace)
    {
        BookmarkFolder lastParent = this;
        if (includeFullPath)
        {
            for (int i = 1; i < path.PathList.Count - 1; i++)
            {
                BookmarkFolder next = path.PathList[i] as BookmarkFolder;
                BookmarkFolder copyOfNext = new()
                {
                    Name = next.Name,
                    Description = next.Description,
                };

                if (!lastParent.Contains(next))
                {
                    lastParent.AddItem(copyOfNext);
                    lastParent = copyOfNext;
                }
                else lastParent = lastParent.Find(next) as BookmarkFolder;
            }
        }

        // Add final item
        if (lastParent.Contains(path.Item))
        {
            if (
                autoReplace ||
                MessageBox.Show("Item already exists, do you want to overwrite it?",
                    "Item already exists",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                )
                == DialogResult.Yes
            )
            {
                BookmarkItem old = lastParent.Find(path.Item);
                lastParent.Items.Remove(old);
                lastParent.AddItem(path.Item.CreateDeepCopy());
            }
        }
        else lastParent.AddItem(path.Item.CreateDeepCopy());
    }
}
