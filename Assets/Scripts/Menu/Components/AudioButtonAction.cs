using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.Components
{
    public class AudioButtonAction : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Sprite enableSprite;
        [SerializeField]
        private Sprite disableSprite;


        private Image image;
        private Button button;
        private AudioSource audioSource;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            GameObject obj = GameObject.Find("Main Camera");
            audioSource = obj.GetComponent<AudioSource>();
            image = GetComponent<Image>();
            button = GetComponent<Button>();
        }


        private void OnEnable()
        {
            button.onClick.AddListener(SwitchAudio);
        }
        #endregion
        #region Private methods
        private void SwitchAudio()
        {
            if (audioSource.enabled)
            {
                image.sprite = disableSprite;
                audioSource.enabled = false;
            }
            else
            {
                image.sprite = enableSprite;
                audioSource.enabled = true;
            }
        }
        #endregion
    }
}

