using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string VersionName = "1.0";
    [SerializeField]
    private GameObject LoginMenu;
    [SerializeField]
    private GameObject ConnectPanel;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private InputField UsernameInput;
    [SerializeField]
    private InputField PasswordInput;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void OnConnectedToMaster() 
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput() 
    {
        if (UsernameInput.text.Length >= 3)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        LoginMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;

    }

    public void JoinGame()
    { 
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom("None", roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom() 
    {
        PhotonNetwork.LoadLevel("MainGame");
    }
}
