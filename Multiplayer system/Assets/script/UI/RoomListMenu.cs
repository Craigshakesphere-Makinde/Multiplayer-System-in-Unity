using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;

    [SerializeField]
    private RoomListing roomlisting;

    private List<RoomListing> listRoom= new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {

           

            //If Removed From List
            if(info.RemovedFromList)
            {
                int index= listRoom.FindIndex(x => x.RoomInfo.Name== info.Name);
                if(index != -1)
                {
                    Destroy(listRoom[index].gameObject);
                    listRoom.RemoveAt(index);
                }             
                


            }

            //IF Added to the list
            else
            {
                RoomListing listing= Instantiate(roomlisting,content);
                
                
                if(listing != null)
                {
                    listing.SetRoomInfo(info);
                    listRoom.Add(listing);
                }

            }
            

        }
        
    } 
    




}
