using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    public class MenuState : IState
    {
        private UI.AbstractPresenter menuPresenter;

        public MenuState(UI.AbstractPresenter menuPresenter)
        {
            this.menuPresenter = menuPresenter;
        }

        public bool Playing => true;

        public void Begin()
        {
            this.menuPresenter.Show();
            this.menuPresenter.Repaint();
            //Cursor.visible = true;
        }

        public void End()
        {
            //Cursor.visible = true;
            this.menuPresenter.Hide();
        }

        public void Update()
        {

        }

        public void FixedUpdate()
        {

        }

        public void Start()
        {
            
        }
    }
}
