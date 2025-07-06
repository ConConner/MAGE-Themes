using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace mage.Bookmarks;


public abstract class BookmarkItem
{
    public string Name { get; set; }
    public string Description { get; set; }
}
