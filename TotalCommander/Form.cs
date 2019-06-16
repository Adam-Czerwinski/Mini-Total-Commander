using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCommander
{
    public partial class Form : System.Windows.Forms.Form, IView
    {

        private IPane selectedPane;
        private IPane unselectedPane;
        //musialem dać interfejs na public. Czemu?
        public IPane SelectedPane
        {
            get { return selectedPane; }
            set
            {
                selectedPane = value;
            }
        }

        public IPane UnselectedPane
        {
            get { return unselectedPane; ; }
            set
            {
                unselectedPane = value;
            }
        }

        public IPane LeftPane { get { return leftPane; } }
        public IPane RightPane { get { return rightPane; } }

        public Action<string, string> copy { get; set; }

        public Form()
        {
            InitializeComponent();

            //domyślnie lewy panel będzie zaznaczony po uruchomieniu programu
            SelectedPane = leftPane;
            UnselectedPane = rightPane;
        }

        //Klikniecie przycisku kopiowania
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            copy(SelectedPane.SelectedFileOrDirectoryPath, UnselectedPane.CurrentPath);
        }

        #region zmiana panelu dominującego
        private void leftPane_Enter(object sender, EventArgs e)
        {
            SelectedPane = leftPane;
            UnselectedPane = rightPane;

            AktywujPanel();
            buttonCopy.Text = "Copy>>";
        }

        private void AktywujPanel()
        {
            SelectedPane.Aktywuj();
            UnselectedPane.Dezaktywuj();
        }

        private void rightPane_Enter(object sender, EventArgs e)
        {
            SelectedPane = rightPane;
            UnselectedPane = leftPane;

            buttonCopy.Text = "<<Copy";
            AktywujPanel();
        }
        #endregion
    }
}
