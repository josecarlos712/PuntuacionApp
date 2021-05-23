using UnityEngine;
using UnityEngine.UI;

public class ChangeNumPlayers : MonoBehaviour
{
    public Button buttonPlayers;
    public InputField inputNumPlayers;
    public int MODE;

    public static int UPPLAYERS = 0, DOWNPLAYERS = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(MODE == 0)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(upplayers);
        }
        else
        {
            gameObject.GetComponent<Button>().onClick.AddListener(downplayers);
        }

        inputNumPlayers.text = Configuration.game.getNumPlayers().ToString();
        inputNumPlayers.gameObject.GetComponent<InputField>().onEndEdit.AddListener(editPlayerNumber);
    }

    private void editPlayerNumber(string inputPlayerNumberText)
    {
        int num = int.Parse(inputPlayerNumberText);
        if (num > 0 && num <= 10)
        {
            Configuration.game.setNumPlayers(num);
        }

        Debug.Log("EditPlayers: " + Configuration.game.getNumPlayers());
    }

    private void upplayers()
    {
        int nPlayers = Configuration.game.getNumPlayers();

        if (nPlayers < 10)
        {
            Configuration.game.setNumPlayers(nPlayers + 1);
            inputNumPlayers.text = Configuration.game.getNumPlayers().ToString();
        } else
        {
            Configuration.game.setNumPlayers(10);
            inputNumPlayers.text = Configuration.game.getNumPlayers().ToString();
        }
        Debug.Log("UPPLAYERS: " + Configuration.game.getNumPlayers());
    }
    private void downplayers()
    {
        int nPlayers = Configuration.game.getNumPlayers();

        if (nPlayers > 1)
        {
            Configuration.game.setNumPlayers(nPlayers-1);
            inputNumPlayers.text = Configuration.game.getNumPlayers().ToString();
        }
        else
        {
            Configuration.game.setNumPlayers(1);
            inputNumPlayers.text = Configuration.game.getNumPlayers().ToString();
        }
        Debug.Log("DOWNPLAYERS: " + Configuration.game.getNumPlayers());
    }
}
