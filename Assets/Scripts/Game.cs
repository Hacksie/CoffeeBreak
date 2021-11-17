using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class Game : MonoBehaviour
    {
        [Header("Referenced Game Objects")]
        [SerializeField] private PlayerController player = null;

        [Header("Setings")]
        [SerializeField] private GameSettings gameSettings;        

        [Header("Data")]
        [SerializeField] private GameData gameData;        

        [Header("UI")]
        [SerializeField] private UI.MenuPresenter menuCanvas = null;        
        [SerializeField] private UI.TopPresenter topCanvas = null;        
        [SerializeField] private UI.BottomPresenter bottomCanvas = null;        


        public static Game Instance { get; private set; }

        private IState state = new EmptyState();

        public IState State
        {
            get
            {
                return state;
            }
            private set
            {
                state.End();
                state = value;
                state.Begin();
            }
        }

        public PlayerController Player { get { return player; } private set { player = value; } }
        public GameData Data { get { return gameData; } private set { gameData = value; }}
        public GameSettings Settings { get { return gameSettings; } private set { gameSettings = value; }}

        Game()
        {
            Instance = this;
        }      

        void Update() => state.Update();
        void FixedUpdate() => state.FixedUpdate();     

        public void SetMenu() => State = new MenuState(menuCanvas);
        public void SetPlaying() => State = new PlayingState(Player, topCanvas, bottomCanvas);
        public void SetGameOver() => State = new GameOverState();
        public void Quit() => Application.Quit();

        void Start()
        {

            //PlayerPreferences.Instance.Load();
            Reset();
            HideAllUI();
            //SetPlaying();
            SetMenu();
        }     

        private void Reset()
        {
            Data.Reset(gameSettings);
        }

        private void HideAllUI()
        {
            menuCanvas.Hide();
            topCanvas.Hide();
            bottomCanvas.Hide();
            // dialogCanvas.Hide();
            // backpackCanvas.Hide();
            // timeCanvas.Hide();
            // shipCanvas.Hide();
            // playerCanvas.Hide();
        }           

    }
}