using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scipts;
using System.Linq;
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
    public GameObject playerFormPrefab, playerForm, anchorPlayerForms;
    public Button submitButton;

    private int numPlayers = 1, //NumPlayers debe ser al menos 1
                antNumPlayers = 0, //NumPlayers al inicio de la escena
        numRounds, currentRound; 
    private List<Player> players;
    private List<GameObject> formPlayers = new List<GameObject>();
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

        foreach (Transform child in playerForm.transform)
        {
            if (child.tag == "Player")
            {
                formPlayers.Add(child.gameObject);
                Debug.Log("Añadido child a players");
            }
        }
    }

    public void Update()
    {
        //Revisión del numero de jugadores
        if (antNumPlayers != numPlayers)
        {
            if (antNumPlayers < numPlayers)
            {
                int index = antNumPlayers;
                //Se añade un nuevo formulario de jugador vacio
                int interForm = 0; //Espacio entre formularios
                GameObject f = Instantiate(playerFormPrefab, anchorPlayerForms.transform.localPosition - new Vector3(0, index * playerFormPrefab.GetComponent<RectTransform>().rect.height + interForm, 0), Quaternion.identity); //Instanciacion del formulario
                f.transform.SetParent(playerForm.transform, false); //Establecer el formulario del jugador como hijo del formulario de cracion de partida
                f.transform.localScale = new Vector3(1, 1, 1); //Cambio de escala
                formPlayers.Add(f); //Se añade a la lista de formularios
                antNumPlayers = formPlayers.Count(); //Se actualiza el numero de formularios en pantalla
            }
            else if (antNumPlayers > numPlayers)
            {
                int index = antNumPlayers - 1;
                //Se elimina el ultimo formulario de jugador
                Destroy(formPlayers[index]);
                formPlayers.Remove(formPlayers[index]);
                antNumPlayers = formPlayers.Count();
            }
        }
    }

    /// <summary>
    /// Recolecta los datos del formulario y guarda los datos en Configuracion.
    /// </summary>
    public void newGame()
    {
        /*this.name = inputName.text;
        this.numRounds = int.Parse(inputNumRounds.text);
        this.numPlayers = int.Parse(inputNumPlayers.text);*/

        InputField[] ips = playerFormPrefab.transform.GetComponentsInChildren<InputField>();
        ColorPicker cp = playerFormPrefab.transform.GetComponentInChildren<ColorPicker>();
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

    /// <summary>
    /// Guarda la plantilla de la partida como JSON en un archivo externo para poder recuperarlo mas tarde con la funcion loadGameFromJSON.
    /// </summary>
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

    /// <summary>
    /// (TO-DO) Carga una plantilla de partida a partir de un JSON almacenado en un archivo externo.
    /// </summary>
    /// <param name="id">Ruta o identificador para seleccionar la partida a cargar</param>
    public void loadGameFronJSON(string id)
    {

    }

    public void addPlayer(Player player)
    {
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