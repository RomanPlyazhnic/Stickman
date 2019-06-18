using Assets.Scripts.Instances;
using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MainMenuAction : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject startButton;
        [SerializeField]
        private GameObject audioButton;
        [SerializeField]
        private GameObject camera;


        private Camera cameraView;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            cameraView = camera.GetComponent<Camera>();
        }


        private void Start()
        {
            MainMenu_OnShowMainMenu();
        }


        private void OnEnable()
        {
            Game.OnStartGame += MainMenu_OnStartGame;
            Game.OnShowMainMenu += MainMenu_OnShowMainMenu;
        }
        #endregion
        #region Event handlers
        private void MainMenu_OnShowMainMenu()
        {
            cameraView.orthographicSize = CameraSettings.MainMenuDistance;
            Game.IsInMainMenu = true;
            ShowOrHide(true);
        }


        private void MainMenu_OnStartGame()
        {
            Game.IsInMainMenu = false;
            ShowOrHide(false);
        }


        private void ShowOrHide(bool isShow)
        {
            startButton.SetActive(isShow);
            audioButton.SetActive(isShow);
        }
        #endregion
    }
}

