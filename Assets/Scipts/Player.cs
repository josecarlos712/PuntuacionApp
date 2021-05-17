using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/*
 TO-DO
    * FUNCIONES
    

*/

/// <summary>
/// Clase Player (Jugador) que almacena la infomacion de este y la tabla de puntuaciones de todas las rondas jugadas
/// </summary>
public class Player : MonoBehaviour
{
    private int totalScore = 0; // Almacena el total de puntos
    private int[] scoreBoard; // Almacena la puntuación de cada ronda
    //private User user = null; // Almacena el usuario elegido para jugar (Aun sin utilidad)
    private string pseudonym = "Anónimo"; // Nombre que usará el jugador
    private Color color = Color.black;  // Color identificativo del jugador

    /// <summary>
    /// Contructor base de Player. Instancia un jugador.
    /// </summary>
    /// <param name="pseudonym">Seudonimo del jugador.</param>
    /// <param name="color">Color representativo del jugador.</param>
    public Player(string pseudonym, Color color)
    {
        this.pseudonym = pseudonym;
        this.color = color;
        //Inicializacion
        Array.ForEach(scoreBoard, delegate (int n)
        {
            n = 0;
        });

        Console.WriteLine(scoreBoard.ToString());
    }
    /// <summary>
    /// Sobrecarga de Player(string pseudonym, Color color).
    /// </summary>
    /// <param name="pseudonym">Seudonimo del jugador.</param>
    public Player(string pseudonym) : this(pseudonym, Color.blue) { }

    void Start()
    {
        int rondas = Configuration.game.getLimitRounds();
        scoreBoard = new int[rondas];

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Metodos ----------------------------------------------------------------
    /// <summary>
    /// Añade la puntuación de la ronda al scoreboard y actualiza la puntuación total.
    /// </summary>
    /// <param name="score">Puntuación a añadir.</param>
    /// <param name="round">Ronda actual de la partida.</param>
    public void addScoreRound(int score, int round)
    {
        if (round < scoreBoard.Length)
            scoreBoard[round] = score;
        else
            throw new IndexOutOfRangeException("La ronda " + round + " supera la maxima ronda.");

        this.totalScore = scoreBoard.Sum(); //Actualiza el totalScore con un sumatorio del scoreBoardd
    }

    //Getters and Setters
    /// <summary>
    /// Getter de la puntuacion total.
    /// </summary>
    /// <returns>Integer. Puntuacion total.</returns>
    public int getScore() => this.totalScore;
    /// <summary>
    /// Setter de la puntuacion total.
    /// </summary>
    /// <param name="score">Puntuacion total.</param>
    public void setScore(int score) => this.totalScore = score;
    /// <summary>
    /// Getter de la tabla de puntuaciones.
    /// </summary>
    /// <returns>Integer. Puntuacion total.</returns>
    public int[] getScoreBoard() => this.scoreBoard;
    /// <summary>
    /// Setter de la tabla de puntuaciones.
    /// </summary>
    /// <param name="scoreBoard">Tabla de puntuaciones.</param>
    public void setScoreBoard(int[] scoreBoard) => this.scoreBoard = scoreBoard;

    //Getter y Setter de la variable user
    /*public User getUser()
    {
        return this.user;
    }

    public void setUser(User user)
    {
        this.user = user;
    }*/

    /// <summary>
    /// Getter del seudonimo.
    /// </summary>
    /// <returns>string. Seudonimo</returns>
    public string getPseudonym() => this.pseudonym;
    /// <summary>
    /// Setter del seudonimo del jugador.
    /// </summary>
    /// <param name="pseudonym">Seudonimo del jugador</param>
    public void setPseudonym(string pseudonym) => this.pseudonym = pseudonym;
    /// <summary>
    /// Getter de la variable color.
    /// </summary>
    /// <returns>Color. Color del jugador</returns>
    public Color getColor() => this.color;
    /// <summary>
    /// Setter del color del jugador.
    /// </summary>
    /// <param name="color">Color del jugador.</param>
    public void setColor(Color color) => this.color = color;

    // Funciones basicas
}

// Namespace con funciones relacionadas con la clase Player
namespace PlayerNamespace
{
    /// <summary>
    /// Comparador de jugadores por puntuación.
    /// </summary>
    public class PlayerPointsComparator : Comparer<Player>
    {
        /// <summary>
        /// Funcion sobrescrita de Compare. Compara dos jugadores por su puntuación. El primero respecto al segundo.
        /// </summary>
        /// <param name="x">Primer jugador.</param>
        /// <param name="y">Segundo jugador.</param>
        /// <returns></returns>
        public override int Compare(Player x, Player y)
        {
            return x.getScore() - y.getScore();
        }
    }
}


