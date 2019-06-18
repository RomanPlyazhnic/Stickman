using Assets.Scripts.Settings;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.Instances
{
    static class Game
    {
        #region Fields
        private const float GAME_COEF_SCALE = 0.001f;


        public delegate void delegateGame();
        public static event delegateGame OnResetGame;
        public static event delegateGame OnStartGame;
        public static event delegateGame OnAppendRestartMenu;
        public static event delegateGame OnAppendMainMenu;
        public static event delegateGame OnDropRestartMenu;
        public static event delegateGame OnDropMainMenu;
        public static event delegateGame OnShowMainMenu;
        #endregion
        #region Properties
        public static int CurrentScore { get; private set; }
        public static int BestScore
        {
            get
            {
                int bestScore;
                if (Int32.TryParse(Save.BestScore, out bestScore))
                {
                    return bestScore;
                }
                return 0;
            }
            private set { }
        }
        public static float GameCoef
        {
            get
            {
                return CurrentScore * GAME_COEF_SCALE + 1;
            }
        }
        public static bool IsAudioEnabled { get; set; }

        public static bool IsInMainMenu { get; set; }
        #endregion
        #region Public methods
        static Game()
        {
            IsAudioEnabled = true;
            IsInMainMenu = true;
            InitGame();
        }


        public static void AddBonusScore()
        {
            CurrentScore += BonusSettings.Score;
        }


        public static void InitGame()
        {
            PlayerSettings.ResetSpeed();
            ResetScore();
        }


        public static void StartGame()
        {
            OnStartGame();
            PlayerSettings.SetSpeed();
        }


        public static void ResetGame()
        {
            ResetScore();
            OnResetGame();
            PlayerSettings.ResetSpeed();
        }


        public static void RestartGame()
        {
            ResetGame();
            OnStartGame();
            PlayerSettings.SetSpeed();
        }


        public static void AppendRestartMenu()
        {
            OnAppendRestartMenu();
        }


        public static void AppendMainMenu()
        {
            OnAppendMainMenu();
        }


        public static void DropRestartMenu()
        {
            OnDropRestartMenu();
        }


        public static void DropMainMenu()
        {
            OnDropMainMenu();
        }


        public static void SaveGame()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Create(Application.persistentDataPath + "/Save.gd"))
            {
                bf.Serialize(file, Save.BestScore);
            }
        }


        public static void LoadGame()
        {
            if (File.Exists(Application.persistentDataPath + "/Save.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream file = File.Open(Application.persistentDataPath + "/Save.gd", FileMode.Open))
                {
                    Save.BestScore = (string)bf.Deserialize(file);
                }
            }
        }
        #endregion
        #region Private methods
        private static void ResetScore()
        {
            CurrentScore = 0;
        }
        #endregion
    }
}

