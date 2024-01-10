using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using Microsoft.Maui.Graphics;
using System.Threading.Tasks;

namespace MauiApp1.Controls
{
    public class ScrollingTextControl : Label
    {
        public ScrollingTextControl()
        {
            // Configuration des propriétés du Label pour l'apparence du texte défilant
            FontSize = 16;
            TextColor = Colors.Black;
            FontAttributes = FontAttributes.None;
            HorizontalOptions = LayoutOptions.Start;
            VerticalOptions = LayoutOptions.Center;
            LineBreakMode = LineBreakMode.CharacterWrap;

            // Le texte s'écrira progressivement
            var fullText = "Bienvenue sur Feeding Rabbits, gérer l'alimentation et le suivi de vos lapins en un seul clic";
            Text = string.Empty;

            Task.Run(async () =>
            {
                await Task.Delay(100);

                for (int i = 0; i < fullText.Length; i++)
                {
                    string partialText = fullText.Substring(0, i + 1);

                    await Dispatcher.DispatchAsync(() =>
                    {
                        Text = partialText;
                    });

                    await Task.Delay(100);
                }
            });
        }
    }
}
