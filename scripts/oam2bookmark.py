import json
import argparse

parser = argparse.ArgumentParser("OAM 2 Bookmark", description="Converts a .json file containing MZM Rom Data into a list of bookmarks for all OAM Animations")
parser.add_argument("filepath", help="Path to a file containing MZM Rom Data in JSON Format", type=str)
parser.add_argument("output", help="Path of the file with the output content", type=str, default="", nargs="?")
args = parser.parse_args()

path: str = args.filepath
with open(path) as json_file:
    data = json.load(json_file)

# Filter list for only OAM Frame lists
filtered_list = [
        entry
        for entry in data
        if "oam" in entry["name"].lower()
        and entry["type"] == "const struct FrameData"
    ]

# Reorganize Data
oam_bookmarks = {"Name": "OAM Data", "Description": "OAM Addresses extracted from the Zero Mission ROM", "Items": []}
object_folders = {}
for entry in filtered_list:
    name_parts = entry["name"].split("_")
    object_name_raw = name_parts[0]
    object_name = object_name_raw[1:-3]  # Remove 's' and 'Oam'
    animation_name = "_".join(name_parts[1:])
    animation_address = entry["addr"]["U"]

    if (not animation_name) and object_name: #Single Animation case
        oam_bookmarks["Items"].append(
            {"Name": object_name, "Value": animation_address}
        )
        object_folders[object_name] = {"Name": object_name, "Items": []}
    else:
        if object_name not in object_folders:
            new_folder = {"Name": object_name, "Items": []}
            object_folders[object_name] = new_folder
            oam_bookmarks["Items"].append(new_folder)

        object_folders[object_name]["Items"].append(
            {"Name": animation_name, "Value": animation_address}
        )

# output data
if (oam_bookmarks):
    outputpath = args.output or (args.filepath + "Bookmarks.json")
    with open(outputpath, "w") as file:
        file.write(json.dumps(oam_bookmarks, indent=4, sort_keys=True))