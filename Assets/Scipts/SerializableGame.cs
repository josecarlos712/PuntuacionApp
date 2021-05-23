using System;
using UnityEngine;

namespace Assets.Scipts
{
    [Serializable]
    class SerializableGame
    {
        public string name;
        public int numRounds;
        public int numPlayers;
        public string[] serializablePlayers;

        public void setPlayers(Player[] players) //Convierte un array de jugadores en un array de jugadores serializados y los guarda en la variable /serializablePlayers/
        {
            serializablePlayers = new string[players.Length];
            for (int i = 0;i < serializablePlayers.Length; i++)
            {
                serializablePlayers[i] = JsonUtility.ToJson(players[i]);
            }
        }
    }

    [Serializable]
    class SerializablePlayer
    {
        public string name;
        public string nick;
        public Color color;
    }
}
