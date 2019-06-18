using Assets.Scripts.Instances;
using Assets.Scripts.Settings;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class PlayerMove : MonoBehaviour
    {
        #region Fields
        private const float FAIL_SOUND_VOLUME = 0.01f;


        [SerializeField]
        private GameObject stick;
        [SerializeField]
        private AudioClip failSound;


        private Rigidbody2D rigidBody;
        private bool isReadyToCreateStick;
        private AudioSource audioSource;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            GameObject obj = GameObject.Find("Main Camera");
            audioSource = obj.GetComponent<AudioSource>();
            rigidBody = GetComponent<Rigidbody2D>();
        }


        private void Start()
        {
            isReadyToCreateStick = false;
        }


        private void Update()
        {
            MovePlayer();
            if (isReadyToCreateStick)
            {
                CreateStick();
            }
        }


        private void OnEnable()
        {
            Game.OnResetGame += Player_OnResetGame;
        }
        #endregion
        #region Private methods
        private void MovePlayer()
        {
            Block block = Storages.Blocks.Objects.FirstOrDefault(x => x.IsPassed == false);
            Stick lastStickNotPassed = Storages.Sticks.Objects.FirstOrDefault(x => x.IsPassed == false && x.IsMade);
            float playerXPos = transform.position.x;
            float playerYPos = transform.position.y;
            if (block != null)
            {
                float blockRightBorderPos = block.Item.transform.localScale.x / 2 + block.Item.transform.position.x;
                if (playerXPos > blockRightBorderPos)
                    block.IsPassed = true;
                if (lastStickNotPassed != null)
                {
                    MoveBeforeStickEnds(lastStickNotPassed);
                }
                else
                {
                    float playerRightPos = transform.position.x + transform.localScale.x / 2;
                    float pointBeforeStick = blockRightBorderPos - StickSettings.Width;
                    if (playerRightPos < pointBeforeStick - PlayerSettings.MarginFromStick)
                    {
                        isReadyToCreateStick = false;
                        rigidBody.MovePosition(rigidBody.position + new Vector2(PlayerSettings.Speed * Time.deltaTime, 0));
                    }
                    else
                    {
                        isReadyToCreateStick = true;
                    }
                }
            }
            if (transform.position.y < PlayerSettings.PlayerEndGameYPos)
            {
                PlayerSettings.ResetSpeed();
                PlayFailSound();
            }
        }


        private void MoveBeforeStickEnds(Stick lastStickNotPassed)
        {
            isReadyToCreateStick = false;
            float stickXBeginPos = lastStickNotPassed.Item.transform.position.x - lastStickNotPassed.Item.transform.localScale.y / 2;
            float stickXEndPos = lastStickNotPassed.Item.transform.position.x + lastStickNotPassed.Item.transform.localScale.y / 2;
            float playerRightPos = transform.position.x + transform.localScale.x / 2;
            if (playerRightPos >= stickXEndPos)
                lastStickNotPassed.IsPassed = true;
            rigidBody.MovePosition(rigidBody.position + new Vector2(PlayerSettings.Speed * Time.deltaTime, 0));
        }


        private void PlayFailSound()
        {
            audioSource.PlayOneShot(failSound, FAIL_SOUND_VOLUME);
            Game.AppendRestartMenu();
        }


        private void CreateStick()
        {
            Block block = Storages.Blocks.Objects.FirstOrDefault(x => x.IsPassed == false);
            if (block != null)
            {
                if (!block.HasStick)
                {
                    float stickXPos = block.Item.transform.position.x + block.Item.transform.localScale.x / 2 - StickSettings.Width / 2;
                    float stickYPos = block.Item.transform.position.y + block.Item.transform.localScale.y / 2 - StickSettings.Width / 2 + 0.07f;
                    Storages.Sticks.Add(Instantiate(stick, new Vector2(stickXPos, stickYPos), Quaternion.identity));
                    block.HasStick = true;
                }
            }
        }
        #endregion
        #region Event handlers
        private void Player_OnResetGame()
        {
            isReadyToCreateStick = false;
            transform.position = new Vector2(PlayerSettings.DefaultXPos, PlayerSettings.DefaultYPos);
            rigidBody.position = new Vector2(PlayerSettings.DefaultXPos, PlayerSettings.DefaultYPos);
        }
        #endregion
    }
}

