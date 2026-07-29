using System;
using System.Drawing;
using System.IO;

namespace mage.Actions.RoomEditor
{
    public class AddRemoveRoomObject : RoomAction
    {
        private enum OperationType { Add, Remove };

        // fields
        private RoomObject obj;
        private int objNum;
        private OperationType actionType;

        // constructor for network deserialization only
        internal AddRemoveRoomObject() { }

        // constructor (add)
        public AddRemoveRoomObject(Room room, Type type, Point pos)
        {
            actionType = OperationType.Add;
            combine = false;

            if (type == typeof(Enemy))
            {
                obj = new Enemy();
                objNum = room.enemyList.Count;
            }
            else if (type == typeof(Door))
            {
                obj = DoorData.NewDoor(room.AreaID, room.RoomID);
                objNum = room.doorList.Count;
            }
            else if (type == typeof(Scroll))
            {
                obj = new Scroll();
                objNum = room.scrollList.Count * 6;
            }

            obj.Add(pos);
        }

        // constructor (remove)
        public AddRemoveRoomObject(RoomObject prevObj, int objNum)
        {
            actionType = OperationType.Remove;
            combine = false;
            this.objNum = objNum;
            this.obj = prevObj;
        }

        public override void Do(Room room)
        {
            bool add = (actionType == OperationType.Add);
            DoAction(room, add);
        }

        public override void Undo(Room room)
        {
            bool add = (actionType == OperationType.Remove);
            DoAction(room, add);
        }

        private void DoAction(Room room, bool add)
        {
            if (obj is Enemy)
            {
                if (add)
                {
                    room.enemyList.AddEnemy((Enemy)obj, objNum);
                    //room.enemyList.SetEnemyBounds((Enemy)obj);
                }
                else
                {
                    room.enemyList.RemoveEnemy(objNum);
                }
            }
            else if (obj is Door)
            {
                if (add)
                {
                    room.doorList.AddDoor((Door)obj, objNum);
                }
                else
                {
                    room.doorList.RemoveDoor(objNum);
                }
            }
            else if (obj is Scroll)
            {
                if (add)
                {
                    room.scrollList.AddScroll((Scroll)obj, objNum);
                }
                else
                {
                    room.scrollList.RemoveScroll(objNum);
                }
            }

            if (add) Sound.PlaySound("add.wav");
            else Sound.PlaySound("remove.wav");
        }

        public override Rectangle AffectedRegion
        {
            get { return obj.DrawingBounds; }
        }

        public override string ActionText
        {
            get
            {
                string text;
                if (actionType == OperationType.Add) { text = "Add "; }
                else { text = "Remove "; }

                if (obj is Enemy) { return text + "sprite"; }
                if (obj is Door) { return text + "door"; }
                if (obj is Scroll) { return text + "scroll"; }
                return text;
            }
        }

        public override ActionType Type => ActionType.AddRemoveRoomObject;

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write((byte)actionType);
            writer.Write(objNum);
            writer.Write((byte)obj.ObjectType);
            obj.Serialize(writer);
        }

        public override void Deserialize(BinaryReader reader)
        {
            actionType = (OperationType)reader.ReadByte();
            objNum = reader.ReadInt32();
            RoomObjectType objType = (RoomObjectType)reader.ReadByte();
            obj = RoomObject.FromNetwork(objType, reader);
        }

    }
}
