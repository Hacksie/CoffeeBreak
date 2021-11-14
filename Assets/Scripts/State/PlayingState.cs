using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    public class PlayingState : IState
    {
        private PlayerController player;
        private UI.AbstractPresenter topPresenter;
        private UI.AbstractPresenter bottomPresenter;

        public PlayingState(PlayerController player, UI.AbstractPresenter topPresenter, UI.AbstractPresenter bottomPresenter)
        {
            this.player = player;
            this.topPresenter = topPresenter;
            this.bottomPresenter = bottomPresenter;
        }

        public bool Playing => true;

        public void Begin()
        {
            this.topPresenter.Show();
            this.bottomPresenter.Show();
            Cursor.visible = false;
        }

        public void End()
        {
            Cursor.visible = true;
            this.topPresenter.Hide();
            this.bottomPresenter.Hide();
            //this.player.Freeze();
        }

        public void Update()
        {
            Game.Instance.Data.Time -= Time.deltaTime;
            this.player.UpdateBehaviour();
            this.topPresenter.Repaint();
            this.bottomPresenter.Repaint();
        }

        public void FixedUpdate()
        {
            this.player.FixedUpdateBehaviour();
        }

        public void Start()
        {
            //GameManager.Instance.SetPaused();
        }
    }
}
