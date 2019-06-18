using Assets.Scripts.Instances;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class RestartMenuAction : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject restartButton;
        [SerializeField]
        private GameObject finalScoreTextField;
        [SerializeField]
        private GameObject bestScoreTextField;


        private TextMeshPro finalScoreText;
        private TextMeshPro bestScoreText;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            finalScoreText = finalScoreTextField.GetComponent<TextMeshPro>();
            bestScoreText = bestScoreTextField.GetComponent<TextMeshPro>();
        }


        private void OnEnable()
        {
            Game.OnAppendRestartMenu += RestartMenu_OnAppendRestartMenu;
            Game.OnDropRestartMenu += RestartMenu_OnDropRestartMenu;
        }
        #endregion
        #region Private methods
        private void RestartMenu_OnAppendRestartMenu()
        {
            ShowOrHide(true);
            finalScoreText.text = "Score: " + Game.CurrentScore.ToString();
            if (Game.CurrentScore > Game.BestScore)
            {
                SaveBestScore();
            }
            bestScoreText.text = "Best score: " + Game.BestScore.ToString();
        }


        private void RestartMenu_OnDropRestartMenu()
        {
            ShowOrHide(false);
        }


        private void ShowOrHide(bool isShow)
        {
            restartButton.SetActive(isShow);
            finalScoreTextField.SetActive(isShow);
            bestScoreTextField.SetActive(isShow);
        }


        private void SaveBestScore()
        {
            Save.BestScore = Game.CurrentScore.ToString();
            Game.SaveGame();
        }
        #endregion
    }
}


