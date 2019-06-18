using Assets.Scripts.Instances;
using UnityEngine;

namespace Assets.Scripts.Menu.Components
{
    public class StartButtonAction : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private AudioClip clickSound;


        private AudioSource audioSource;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            GameObject obj = GameObject.Find("Main Camera");
            audioSource = obj.GetComponent<AudioSource>();
        }


        private void OnMouseDown()
        {
            audioSource.PlayOneShot(clickSound);
            Game.StartGame();
        }
        #endregion
    }
}

