using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class networkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectedToServer();
    }

    private void ConnectedToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("attempting connect");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("successfully connected");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("room1", roomOptions, TypedLobby.Default);

       
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined the room");
        base.OnJoinedRoom();
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("new player joined room");
        base.OnPlayerEnteredRoom(newPlayer);
    }


}
