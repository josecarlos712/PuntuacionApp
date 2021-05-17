using System;
using System.Collections.Generic;
using PlayerNamespace;
class Game
{
    /*
    TO-DO
        - Esta clase guarda y administra al conjunto de jugadores
        - Alcenas los jugadores que estan en la partida, asi que sirve como
            nexo entre estos por si hay que hacer alguna operacion que implique a ambos.
        -
    */
    public const int FINISHMODE_ROUNDS = 0, FINISHMODE_TIME = 1, FINISHMODE_POINTS = 2;
    private int numPlayers, limitRounds, limitTime, limitPoints, finishMode,
        currentRound, currentTime, currentPoints;
    private List<Player> players;
    // Constructores
    // Resumen:
    //  Al constructor se le pasa la forma de finalizar el juego pasando como argumento
    //      FINISH_MODE una de las constantes FINISHMODE
    public Game(int numPlayers, int limit, int FINISH_MODE)
    {
        this.numPlayers = numPlayers;
        this.finishMode = FINISH_MODE;
        players = new List<Player>();

        switch (FINISH_MODE)
        {
            case FINISHMODE_TIME:
                this.limitTime = limit;
                break;
            case FINISHMODE_ROUNDS:
                this.limitRounds = limit;
                break;
            case FINISHMODE_POINTS:
            default:
                this.limitPoints = limit;
                break;
        }
    }

    // Metodos
    public void newGame()
    {
        switch (finishMode)
        {
            case FINISHMODE_TIME:
                currentTime = limitTime;
                break;
            case FINISHMODE_ROUNDS:
                currentRound = 0;
                break;
            case FINISHMODE_POINTS:
                currentPoints = 0;
            //Posible cambio: No hacer copia de la lista de jugadores y asi la pantalla se iria actualizando ordenando los jugadores por puntos
                /* Actualizacion del orden de jugadores por puntuaciones
                var ordererPlayers = new List<Player>(players); //Se hace una copia de la lista de jugadores para no afectar al orden original
                ordererPlayers.Sort(new PlayerPointsComparator()); //Ordena los jugadores por puntos
                this.currentPoints = ordererPlayers[0].getScore();//Se guarda la mayor puntuación
                */
                break;
        }
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
        return this.limitRounds;
    }

    public void setLimitRounds(int limitRounds)
    {
        this.limitRounds = limitRounds;
    }

    public int getLimitTime()
    {
        return this.limitTime;
    }

    public void setLimitTime(int limitTime)
    {
        this.limitTime = limitTime;
    }

    public int getLimitPoints()
    {
        return this.limitPoints;
    }

    public void setLimitPoints(int limitPoints)
    {
        this.limitPoints = limitPoints;
    }

    public int getfinishMode()
    {
        return this.finishMode;
    }

    public void setfinishMode(int finishMode)
    {
        this.finishMode = finishMode;
    }
}