using System;
using System.Drawing;
using System.IO;

namespace mage.Actions.RoomEditor
{
    public class EditRoomObject : RoomAction
    {
        private enum EditType { Edit, Move };

        // fields
        private RoomObject obj;
        private EditType actionType;
        private int objNum;
        private Rectangle region;

        // constructor for network deserialization only
        internal EditRoomObject() { }

        // constructor (edit)
        public EditRoomObject(RoomObject newObj, int objNum, bool move)
        {
            if (move)
            {
                actionType = EditType.Move;
                combine = true;
            }
            else
            {
                actionType = EditType.Edit;
                combine = false;
            }
            this.objNum = objNum;
            this.obj = newObj;
        }

        public override void Do(Room room)
        {
            RoomObject prev = null;
            if (obj is Enemy)
            {
                Enemy curr = room.enemyList[objNum];
                prev = curr.Copy();
                curr.SetValue(obj);
                room.enemyList.Edited = true;
            }
            else if (obj is Door)
            {
                Door curr = room.doorList[objNum];
                prev = curr.Copy();
                curr.SetValue(obj);
                room.doorList.Edited = true;
            }
            else if (obj is Scroll)
            {
                Scroll curr = room.scrollList[objNum / 6];
                prev = curr.Copy();
                curr.SetValue(obj);
                room.scrollList.Edited = true;
            }

            region = Rectangle.Union(prev.DrawingBounds, obj.DrawingBounds);
            obj = prev;
        }

        public override void Undo(Room room)
        {
            Do(room);
        }

        public override Rectangle AffectedRegion
        {
            get
            {
                int x = (region.X / 16) * 16;
                int y = (region.Y / 16) * 16;
                int w = ((region.Width / 16) + 2) * 16;
                int h = ((region.Height / 16) + 2) * 16;
                return new Rectangle(x, y, w, h);
            }
        }

        public override string ActionText
        {
            get
            {
                string text;
                if (actionType == EditType.Edit) { text = "Edit "; }
                else { text = "Move "; }

                if (obj is Enemy) { return text + "sprite"; }
                if (obj is Door) { return text + "door"; }
                if (obj is Scroll) { return text + "scroll"; }
                return text;
            }
        }

        public override bool TryCombine(Action a)
        {
            EditRoomObject newer = a as EditRoomObject;
            if (newer != null && combine && this.actionType == EditType.Move && 
                newer.actionType == EditType.Move && this.objNum == newer.objNum)
            {
                return true;
            }
            return false;
        }

        public override ActionType Type => ActionType.EditRoomObjects;

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write((byte)actionType);
            writer.Write(objNum);
            writer.Write((byte)obj.ObjectType);
            obj.Serialize(writer);
        }

        public override void Deserialize(BinaryReader reader)
        {
            actionType = (EditType)reader.ReadByte();
            combine = actionType == EditType.Move;
            objNum = reader.ReadInt32();
            RoomObjectType objType = (RoomObjectType)reader.ReadByte();
            obj = RoomObject.FromNetwork(objType, reader);
        }

    }
}
