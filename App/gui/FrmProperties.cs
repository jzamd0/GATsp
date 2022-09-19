using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmProperties : Form
    {
        public string Name { get; set; }
        public string Comment { get; set; }

        public FrmProperties(string name, string comment)
        {
            InitializeComponent();

            Name = name;
            Comment = comment;

            _tbxName.Text = name;
            _tbxComment.Text = comment;
        }

        private void _btnSave_Click(object sender, System.EventArgs e)
        {
            Name = _tbxName.Text;
            Comment = _tbxComment.Text;

            Close();
        }

        private void _btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
