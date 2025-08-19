using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace mage.Bookmarks;


public abstract class BookmarkItem
{
    public string Name { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public BookmarkFolder Parent { get; set; } = null;
    [JsonIgnore]
    public string Path
    {
        get
        {
            if (Parent == null) return Name;
            return Parent.Path + $"/{Name}";
        }
    }
}
