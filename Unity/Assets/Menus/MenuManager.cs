using UnityEngine;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas planetMenuCanvas;

    public void ShowPlanetMenu()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        planetMenuCanvas.gameObject.SetActive(true);
    }

    public void ShowMainMenu()
    {
        planetMenuCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
}
