using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmProperties : Form
    {
        public string ProjectName { get; set; }
        public string Comment { get; set; }

        public FrmProperties(string projectName, string comment)
        {
            InitializeComponent();

            ProjectName = projectName;
            Comment = comment;

            _tbxProjectName.Text = projectName;
            _tbxComment.Text = comment;
        }

        private void _btnSave_Click(object sender, System.EventArgs e)
        {
            ProjectName = _tbxProjectName.Text;
            Comment = _tbxComment.Text;

            Close();
        }

        private void _btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
