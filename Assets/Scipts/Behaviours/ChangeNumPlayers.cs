using UnityEngine;
using UnityEngine.UI;

public class ChangeNumPlayers : MonoBehaviour
{
    public Button buttonPlayers;
    public InputField inputNumPlayers;
    public int MODE;
    public GameObject game;

    public static int UPPLAYERS = 0, DOWNPLAYERS = 1;
    public static int MAXNUMPLAYERS = 8;

    // Start is called before the first frame update
    void Start()
    {
        if (MODE == 0)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(upplayers);
        }
        else
        {
            gameObject.GetComponent<Button>().onClick.AddListener(downplayers);
        }

        inputNumPlayers.text = game.GetComponent<Game>().getNumPlayers().ToString();
        inputNumPlayers.gameObject.GetComponent<InputField>().onEndEdit.AddListener(editPlayerNumber);
    }

    private void editPlayerNumber(string inputPlayerNumberText)
    {
        int num = int.Parse(inputPlayerNumberText);
        if (num > 0 && num <= MAXNUMPLAYERS)
        {
            game.GetComponent<Game>().setNumPlayers(num);
        }

        Debug.Log("EditPlayers: " + game.GetComponent<Game>().getNumPlayers());
    }

    private void upplayers()
    {
        int nPlayers = game.GetComponent<Game>().getNumPlayers();

        if (nPlayers < MAXNUMPLAYERS)
        {
            game.GetComponent<Game>().setNumPlayers(nPlayers + 1);
            inputNumPlayers.text = game.GetComponent<Game>().getNumPlayers().ToString();
        }
        else
        {
            game.GetComponent<Game>().setNumPlayers(10);
            inputNumPlayers.text = game.GetComponent<Game>().getNumPlayers().ToString();
        }
        //Debug.Log("UPPLAYERS: " + game.GetComponent<Game>().getNumPlayers());
    }
    private void downplayers()
    {
        int nPlayers = game.GetComponent<Game>().getNumPlayers();

        if (nPlayers > 1)
        {
            game.GetComponent<Game>().setNumPlayers(nPlayers - 1);
            inputNumPlayers.text = game.GetComponent<Game>().getNumPlayers().ToString();
        }
        else
        {
            game.GetComponent<Game>().setNumPlayers(1);
            inputNumPlayers.text = game.GetComponent<Game>().getNumPlayers().ToString();
        }
        //Debug.Log("DOWNPLAYERS: " + game.GetComponent<Game>().getNumPlayers());
    }
}
