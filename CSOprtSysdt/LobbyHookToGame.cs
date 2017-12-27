using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.NetworkLobby;
using UnityEngine.Networking;
[DisallowMultipleComponent]
public class FragmasLobbyHook : LobbyHook 
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer,
        GameObject gamePlayer)
    {
        LobbyPlayer LobbyPlyr = lobbyPlayer.GetComponent<LobbyPlayer> ();
        PlayerNetworkScrpt GamePlyr = gamePlayer.GetComponent<PlayerNetworkScrpt> ();

        GamePlyr.playerName = LobbyPlyr.playerName;
        GamePlyr.playerColor = LobbyPlyr.playerColor;
    }
}

public class LobbyHookToGame :LobbyHook {
        public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer,
            GameObject gamePlayer)
        {
            LobbyPlayer lPlayer = lobbyPlayer.GetComponent<LobbyPlayer> ();
        PlayerNetworkScrpt MMOPlyr = gamePlayer.GetComponent<PlayerNetworkScrpt> ();

        MMOPlyr.playerName = lPlayer.playerName;
        MMOPlyr.playerColor = lPlayer.playerColor;
        }
    }