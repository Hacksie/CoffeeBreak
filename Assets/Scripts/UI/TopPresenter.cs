using UnityEngine;

namespace HackedDesign.UI
{
    public class TopPresenter : AbstractPresenter
    {
        [SerializeField] UnityEngine.UI.Text countdownText;
        public override void Repaint()
        {
            countdownText.text = System.TimeSpan.FromMinutes(Game.Instance.Data.Time).ToString("hh':'mm");
            //willSlider.value = Game.Instance.Data.Will;
        }
    }
}