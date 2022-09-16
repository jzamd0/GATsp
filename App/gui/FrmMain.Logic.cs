using Lib;
using System.Collections.Generic;
using System.Drawing;

namespace App.Gui
{
    public partial class FrmMain
    {
        private bool _isFirstTime;

        private string _lastLocation;

        private List<List<double>> _distances;
        private List<Point> _points;
        private List<string> _headers;
        private List<Edge<string>> _edges;

        private void LoadFirstTime()
        {
            // enable elements for the first time creating or opening a project
            _splitMain.Visible = true;

            _menuView.Enabled = true;
            _mniViewSetup.Checked = true;
            _menuTsp.Enabled = true;

            _mniSaveTsp.Enabled = true;
            _mniSaveTspAs.Enabled = true;
        }

        private void NewProject()
        {
            if (_isFirstTime)
            {
                _isFirstTime = false;
                LoadFirstTime();
            }
        }

        private void OpenProject()
        {
            if (_isFirstTime)
            {
                _isFirstTime = false;
                LoadFirstTime();
            }
        }

        private bool IsProjectEmpty()
        {
            return _distances.IsNullOrEmpty();
        }
    }
}
