﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetAssigner : MonoBehaviour {
    [SerializeField]
    GameObject StartRoomObj;

    [SerializeField]
	GameObject[] NormalRoomObj;

    [SerializeField]
    GameObject BossRoomObj;

    [SerializeField]
    GameObject[] EventRoomObj;

    //private bool first_room = false;
    public Vector2 roomDimensions = new Vector2(17,9);//272,144(16에서 4로 축소 밑에도)68,36
	public Vector2 gutterSize = new Vector2(4, 4);//144,64 36,16
    private const int n_NormalMapNum = 6; // 노말맵 개수
    private const int n_EventMapNum = 2; // 이벤트맵 개수
	public void Assign(Room[,] rooms){
		foreach (Room room in rooms){
			//skip point where there is no room
			if (room == null){
				continue;
			}
			//pick a random index for the array
			//int index = Mathf.RoundToInt(Random.value * (sheetsNormal.Length -1));
			//find position to place room
			Vector3 pos = new Vector3(room.gridPos.x * (roomDimensions.x + gutterSize.x), room.gridPos.y * (roomDimensions.y + gutterSize.y), 0);
            RoomInstance myRoom = Instantiate(BuildingMap(room.type), pos, Quaternion.identity).GetComponent<RoomInstance>();
			myRoom.Setup(room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight, RoomCheck(room.type));
			myRoom.transform.SetParent(transform);
            //최적화 코드
            if (room.type.Equals((int)MapState.Start))
            {
                continue;
            }
            myRoom.GetMapTileRend.enabled = false;

        }
	}

    private GameObject BuildingMap(int room)
    {
        int Randnum;
        if (room.Equals((int)MapState.Normal))
        {
            Randnum = Random.Range(0, n_NormalMapNum);
            return NormalRoomObj[Randnum];
        }
        else if (room.Equals((int)MapState.Start))
        {
            return StartRoomObj;
        }
        else if (room.Equals((int)MapState.Boss))
        {
            return BossRoomObj;
        }
        else if (room.Equals((int)MapState.Event))
        {
            Randnum = Random.Range(0, n_EventMapNum);
            return EventRoomObj[Randnum];
        }
        return null;
    }

    private string RoomCheck(int room)
    {
        if (room.Equals((int)MapState.Start))
        {
            return "시작맵";
        }
        else if (room.Equals((int)MapState.Normal))
        {
            return "전투맵";
        }
        else if (room.Equals((int)MapState.Event))
        {
            return "Enter EventMap";
        }
        else if (room.Equals((int)MapState.Boss))
        {
            return "Enter BossMap";
        }
        return "에러";
    }
}
