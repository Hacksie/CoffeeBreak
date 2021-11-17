using UnityEngine;

namespace HackedDesign.UI
{
    public class TopPresenter : AbstractPresenter
    {
        [SerializeField] UnityEngine.UI.Text countdownText;
        [SerializeField] UnityEngine.UI.Image cupImage;
        [SerializeField] UnityEngine.UI.Image spoonImage;
        [SerializeField] UnityEngine.UI.Image milkImage;

        [SerializeField] Color uncollected;
        [SerializeField] Color collected;

        public override void Repaint()
        {
            countdownText.text = System.TimeSpan.FromMinutes(Game.Instance.Data.Time).ToString("hh':'mm");

            cupImage.color = Game.Instance.Data.HasCoffee ? collected : uncollected;
            spoonImage.color = Game.Instance.Data.HasSpoon ? collected  : uncollected;
            milkImage.color = Game.Instance.Data.HasMilk ? collected : uncollected;
            //willSlider.value = Game.Instance.Data.Will;
        }
    }
}