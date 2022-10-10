using System.Drawing;

namespace App
{
    public class CanvasOptions
    {
        public int PointWidth { get; set; }
        public int PointHeight { get; set; }
        public Color NodeColor { get; set; }
        public Color FirstNodeColor { get; set; }
        public Color NodeTextColor { get; set; }
        public Font NodeFont { get; set; }
        public Color LineColor { get; set; }
        public Color BackColor { get; set; }

        public CanvasOptions()
        {
        }

        public CanvasOptions(int pointWidth, int pointHeight, Color nodeColor, Color firstNodeColor, Color nodeTextColor, Font nodeFont, Color lineColor, Color backColor)
        {
            PointWidth = pointWidth;
            PointHeight = pointHeight;
            NodeColor = nodeColor;
            FirstNodeColor = firstNodeColor;
            NodeTextColor = nodeTextColor;
            NodeFont = nodeFont;
            LineColor = lineColor;
            BackColor = backColor;
        }
    }
}
