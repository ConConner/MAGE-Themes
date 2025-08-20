using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mage.Bookmarks;

public class Bookmark : BookmarkItem
{
    [JsonConstructor]
    public Bookmark() { }
    public int Value { get; set; }

    public override Bookmark CreateDeepCopy()
    {
        return new Bookmark()
        {
            Name = this.Name,
            Description = this.Description,
            Value = this.Value
        };
    }
}
