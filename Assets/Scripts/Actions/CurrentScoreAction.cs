using Assets.Scripts.Instances;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class CurrentScoreAction : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject camera;


        private TextMeshPro scoreText;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            scoreText = GetComponent<TextMeshPro>();
        }


        private void Start()
        {
            gameObject.SetActive(false);
        }


        private void Update()
        {
            scoreText.text = Game.CurrentScore.ToString();
            transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);
        }


        private void OnEnable()
        {
            Game.OnAppendMainMenu += CurrentScore_OnAppendMenu;
            Game.OnAppendRestartMenu += CurrentScore_OnAppendMenu;
            Game.OnStartGame += CurrentScore_OnStartGame;
        }
        #endregion
        #region Event handlers
        private void CurrentScore_OnStartGame()
        {
            gameObject.SetActive(true);
        }


        private void CurrentScore_OnAppendMenu()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}

