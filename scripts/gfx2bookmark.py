import json
import argparse

parser = argparse.ArgumentParser("GFX 2 Bookmark", description="Converts a .json file containing MZM Rom Data into a list of bookmarks for all Sprite GFX labels")
parser.add_argument("filepath", help="Path to a file containing MZM Rom Data in JSON Format", type=str)
parser.add_argument("output", help="Path of the file with the output content", type=str, default="", nargs="?")
args = parser.parse_args()

path: str = args.filepath
with open(path) as json_file:
    data = json.load(json_file)

# Filter list for only OAM Frame lists
exclude = {"tileset", "samus", "armcannon"}
gfx_list = [
    entry
    for entry in data
    if "gfx" in entry["name"].lower()
    and (entry["type"] == "const u32" or entry["type"] == "const u8")
    and not any(word in entry["name"].lower() for word in exclude)
]
pal_list = [
    entry
    for entry in data
    if "pal" in entry["name"].lower()
    and (entry["type"] == "const u16" or entry["type"] == "const u8")
    and not any(word in entry["name"].lower() for word in exclude)
]


# Reorganize Data
graphics_bookmarks = {"Name": "Graphics Data", "Description": "GFX and PAL Addresses extracted from the Zero Mission ROM", "Items": []}
gfx_bookmarks = {"Name": "GFX Data", "Description": "Graphics Addresses extracted from the Zero Mission ROM", "Items": []}
pal_bookmarks = {"Name": "PAL Data", "Description": "Palette Addresses extracted from the Zero Mission ROM", "Items": []}

gfx_entries = {}
for entry in gfx_list:
    name = entry["name"][1:].replace("Gfx", "")
    address = entry["addr"]["U"]

    gfx_bookmarks["Items"].append(
        {"Name": name, "Value": address}
    )

for entry in pal_list:
    name = entry["name"][1:]
    address = entry["addr"]["U"]

    pal_bookmarks["Items"].append(
        {"Name": name, "Value": address}
    )

graphics_bookmarks["Items"].append(gfx_bookmarks)
graphics_bookmarks["Items"].append(pal_bookmarks)

# output data
if (graphics_bookmarks):
    outputpath = args.output or (args.filepath + "Bookmarks.json")
    with open(outputpath, "w") as file:
        file.write(json.dumps(graphics_bookmarks, indent=4, sort_keys=True))