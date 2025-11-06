using System.Windows.Controls;

namespace Labb3_NET22
{
    public partial class ScoreWindowView : UserControl
    {
        public ScoreWindowView(PlayQuizViewModel sw)
        {
            InitializeComponent();
            DataContext = sw;
        }
    }
}