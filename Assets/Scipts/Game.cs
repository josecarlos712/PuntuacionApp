using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scipts;
class Game : MonoBehaviour
{
    /*
    TO-DO
        - Esta clase guarda y administra al conjunto de jugadores
        - Alcenas los jugadores que estan en la partida, asi que sirve como
            nexo entre estos por si hay que hacer alguna operacion que implique a ambos.
        -
    */
    public InputField inputName, inputNumRounds, inputNumPlayers;
    public GameObject playerForm;
    public Button submitButton;

    private int numPlayers, numRounds, currentRound;
    private List<Player> players;
    private string gameName;
    // Constructores
    // Resumen:
    //  Al constructor se le pasa la forma de finalizar el juego pasando como argumento
    //      FINISH_MODE una de las constantes FINISHMODE
    public Game(string name, int numPlayers, int limit)
    {
        this.gameName = name;
        this.numPlayers = numPlayers;
        this.players = new List<Player>();
    }

    public Game(string serializableGame) //Creacion de un juego mediante una cadena JSON
    {

    }

    public Game() : this("New Game", 1, 7) { }

    // Metodos
    public void Start()
    {
        submitButton.onClick.AddListener(newGame);
        Debug.Log("Iniciado el juego");
    }
    public void newGame()
    {
        /*this.name = inputName.text;
        this.numRounds = int.Parse(inputNumRounds.text);
        this.numPlayers = int.Parse(inputNumPlayers.text);*/

        InputField[] ips = playerForm.transform.GetComponentsInChildren<InputField>();
        ColorPicker cp = playerForm.transform.GetComponentInChildren<ColorPicker>();
        //Player p = new Player();    

        currentRound = 0;

        //saveGameToJSON();
        //Posible cambio: No hacer copia de la lista de jugadores y asi la pantalla se iria actualizando ordenando los jugadores por puntos
        /* Actualizacion del orden de jugadores por puntuaciones
        var ordererPlayers = new List<Player>(players); //Se hace una copia de la lista de jugadores para no afectar al orden original
        ordererPlayers.Sort(new PlayerPointsComparator()); //Ordena los jugadores por puntos
        this.currentPoints = ordererPlayers[0].getScore();//Se guarda la mayor puntuación
        */
    }

    public void saveGameToJSON()
    {
        SerializableGame sGame = new SerializableGame();

        sGame.name = this.gameName;
        sGame.numPlayers = this.numPlayers;
        sGame.numRounds = this.numRounds;
        sGame.setPlayers(this.players.ToArray());

        string jsonGame = JsonUtility.ToJson(sGame);
        Debug.Log(jsonGame);
    }

    public void addPlayer(Player player)
    {
        if (!players.Contains(player))
            players.Add(player);
    }

    // Getters and setters
    public int getNumPlayers()
    {
        return this.numPlayers;
    }

    public void setNumPlayers(int numPlayers)
    {
        this.numPlayers = numPlayers;
    }

    public int getLimitRounds()
    {
        return this.numRounds;
    }

    public void setLimitRounds(int limitRounds)
    {
        this.numRounds = limitRounds;
    }
}