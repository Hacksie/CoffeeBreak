using UnityEngine;

namespace HackedDesign.UI
{
    public class MenuPresenter : AbstractPresenter
    {
        
        public override void Repaint()
        {
            //countdownText.text = System.TimeSpan.FromMinutes(Game.Instance.Data.Time).ToString("hh':'mm");
            //willSlider.value = Game.Instance.Data.Will;
        }

        public void OnPlayClick()
        {
            Game.Instance.SetPlaying();
        }

        public void OnSettingsClick()
        {

        }

        public void OnCreditsClick()
        {

        }

        public void OnQuitClick()
        {
            Game.Instance.Quit();
        }
    }
}