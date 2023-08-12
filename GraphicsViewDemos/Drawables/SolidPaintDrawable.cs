using Microsoft.Maui.Graphics;
using Microsoft.UI.Xaml.Controls;

namespace GraphicsViewDemos.Drawables
{
    public class PushButton
    {
        public float left = 0;
        public float top = 0;
        public float width = 0;
        public float height = 0;

        public SolidPaint paint = new SolidPaint(Colors.Silver);
        public RectF rect = new RectF(100, 100, 200, 100);

        public PushButton()
        {
        }

        public void Draw(ICanvas canvas)
        {
            canvas.SetFillPaint(paint, rect);
            canvas.SetShadow(new SizeF(10, 10), 10, Colors.Grey);
            canvas.FillRoundedRectangle(rect, 12);
        }
    }


    public class Label
    {
        public Label()
        {
        }

        public void Draw(ICanvas canvas, Microsoft.Maui.Graphics.Font font, float fontSize, RectF rect)
        {
            string prompt = "Hello, Maui.Graphics!";
            SizeF strSize = canvas.GetStringSize(prompt, font, fontSize);

            canvas.DrawString
            (
                value: prompt,
                x: rect.X,
                y: rect.Y,
                width: rect.Width,
                height: rect.Height,
                horizontalAlignment: HorizontalAlignment.Center,
                verticalAlignment: VerticalAlignment.Center,
                textFlow: TextFlow.OverflowBounds,
                lineSpacingAdjustment: 0
            );
        }
    }


    public class SolidPaintDrawable : IDrawable
    {
        Microsoft.Maui.Graphics.Font font = new Microsoft.Maui.Graphics.Font("OpenSansSemibold");
        float deltaFontSize = 4;
        float fontSize = 32;

        PushButton pushButton = new PushButton();
        Label label = new Label();

        protected IDispatcherTimer quickTimer = null;

        protected GraphicsView graphicsView = null;


        public SolidPaintDrawable()
        {
            quickTimer = Application.Current.Dispatcher.CreateTimer();
            quickTimer.Interval = TimeSpan.FromMilliseconds(1);
            quickTimer.IsRepeating = true;
            quickTimer.Tick += (s, e) => OnQuickTimer(s, e);
        }


        public void SetGraphicsView(GraphicsView graphicsView)
        {
            this.graphicsView = graphicsView;
        }


        public void StartQuickTimer()
        {
            quickTimer.Start();
        }


        public void StopQuickTimer()
        {
            quickTimer.Stop();
        }


        protected async void OnQuickTimer(object sender, EventArgs args)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                fontSize += deltaFontSize;
                pushButton.rect.Width += 1;
                pushButton.rect.Height += 1;
                graphicsView.Invalidate();
            });
        }


        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            pushButton.Draw(canvas);
            label.Draw(canvas, font, fontSize, pushButton.rect);
        }
    }
}
