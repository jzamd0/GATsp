using Lib;
using System.Collections.Generic;
using System.Drawing;

namespace App.Gui
{
    public enum ProjectType
    {
        Matrix,
        Graph,
    }

    public partial class FrmMain
    {
        private bool _isFirstTime = true;
        private ProjectType _projectType;

        private List<List<double>> _distances;
        private List<Point> _points;
        private List<string> _headers;

        private void LoadFirstTime()
        {
            // enable elements for the first time creating or opening a project
            _splitMain.Visible = true;

            _menuView.Enabled = true;
            _mniViewSetup.Checked = true;
            _menuTsp.Enabled = true;

            _mniSaveTsp.Enabled = true;
            _mniSaveTspAs.Enabled = true;

            // form elements are now enabled
            _isFirstTime = false;
        }

        private void LoadProject(ProjectType projectType)
        {
            // load elements depending on the type of the project
            if (projectType == ProjectType.Graph)
            {
                _tabControlSetup.TabPages.Add(_tabCoordinates);
                _tabControlTsp.TabPages.Add(_tabGraph);
                _menuGraph.Enabled = true;
            }
            else if (projectType == ProjectType.Matrix)
            {
                _tabControlSetup.TabPages.Remove(_tabCoordinates);
                _tabControlTsp.TabPages.Remove(_tabGraph);
                _menuGraph.Enabled = false;
            }

            _projectType = projectType;
        }

        private void NewProject(ProjectType projectType)
        {
            if (_isFirstTime)
            {
                LoadFirstTime();
            }

            LoadProject(projectType);
        }

        private void OpenProject(ProjectType projectType)
        {
            // check for erroes when openinga file
            if (_isFirstTime)
            {
                LoadFirstTime();
            }

            LoadProject(projectType);

            // open a dialog to open project depending on project type
            // only the files with the specified extension can be opened
        }

        private bool IsProjectEmpty()
        {
            if (_projectType == ProjectType.Graph)
            {
                return _points.IsNullOrEmpty();
            }
            else if (_projectType == ProjectType.Matrix)
            {
                return _distances.IsNullOrEmpty();
            }

            return true;
        }
    }
}
