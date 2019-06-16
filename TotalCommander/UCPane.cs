using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TotalCommander
{
    public partial class UCPane : UserControl, IPane
    {
        public UCPane()
        {
            InitializeComponent();
        }

        public string CurrentPath { get { return textBoxPath.Text; } set { textBoxPath.Text = value; } }
        public string[] Drives { set { comboBoxDrives.Items.Clear(); if (!(value is null)) comboBoxDrives.Items.AddRange(value); } }
        public string[] DirectoriesAndFiles { set { listBoxDirectoriesAndFiles.Items.Clear(); listBoxDirectoriesAndFiles.Items.AddRange(value); } }
        //CurrentPath + wybranu plik/folder
        public string SelectedFileOrDirectoryPath
        {
            get
            {
                //jezeli nie jest wybrany zaden plik lub folder
                if (listBoxDirectoriesAndFiles.SelectedIndex == -1)
                    return null;
                //pobranie nazwy pliku lub folderu bez prefiksu
                string nazwa = listBoxDirectoriesAndFiles.SelectedItem.ToString().Remove(0, listBoxDirectoriesAndFiles.SelectedItem.ToString().LastIndexOf(">") + 1);
                return CurrentPath + nazwa;
            }
        }

        public Action loadDrives { get; set; }
        public Action<string> loadDirectoriesAndFiles { get; set; }

        //jeżeli rozwiniemy comboBoxa to wywołujemy akcję loadDrives
        private void comboBoxDrives_Click(object sender, EventArgs e)
        {
            loadDrives();
        }

        //Jeżeli zmienimy dysk w comboBoxie
        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aktualizujemy currentPath
            CurrentPath = comboBoxDrives.SelectedItem.ToString();
            //wczytujemy pliki i foldery z wybranego dysku
            loadDirectoriesAndFiles(CurrentPath);
        }

        //Kliknięcie dwa razy na listbox'a
        private void listBoxDirectoriesAndFiles_DoubleClick(object sender, EventArgs e)
        {
            //jeżeli nic nie jest zaznaczone
            if (listBoxDirectoriesAndFiles.SelectedItem is null)
                return;

            //pobranie nazwy pliku lub folderu
            string nazwa = listBoxDirectoriesAndFiles.SelectedItem.ToString();

            //Sprawdzam czy podwójne kliknięcie to kliknięcie na plik.
            //Sprawdzam od 0 do 3 dlatego, że każdy folder/plik ma prefiks <D> lub <F>
            //Jezeli tak, to nic nie rób.
            if (nazwa.StartsWith("<F>"))
                return;

            //jezeli to folder to usuwamy prefiks <D>, zeby sciezka się zgadzała
            nazwa = listBoxDirectoriesAndFiles.SelectedItem.ToString().Remove(0, listBoxDirectoriesAndFiles.SelectedItem.ToString().LastIndexOf(">") + 1);

            //a teraz wczytujemy pliki i foldery ze ścieżki do której chcemy przejść. Dodajemy na koniec znak '\\', ponieważ
            //tak to byśmy wysłałi np. "C:\\nazwa_folderu"
            //a potrzebujemy "C:\\nazwa_folderu\"
            //wtedy wszystko gra (Jakoś się nie zaglębiałem, chyba jestem leniwy, ale tak zrobiłem i działa. Na razie to wystarczy)
            loadDirectoriesAndFiles(CurrentPath + nazwa + '\\');
        }

        //Jeżeli chcemy się cofnąć w hierarchii katalogów
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //Bierzemy sciezke bez nazwy pliku lub folderu.
            //CurrentPath.Substring(0, CurrentPath.Length - 2).LastIndexOf('\\')+1 jest to przedostatnie wystąpienie znaku '\\'
            string nazwa = CurrentPath.Substring(0, CurrentPath.Substring(0, CurrentPath.Length - 2).LastIndexOf('\\') + 1);
            loadDirectoriesAndFiles(nazwa);
        }

        //jeżeli CurrentPath się zmieni, to sprawdzamy co ono zawiera. Wtedy wiemy czy możemy włączyć przycisk back lub nie.
        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            //jezeli nie da się cofnąć bo jestesmy w głownym katalogu dyskowym, czyli np C:\ (3 znaki)
            if (CurrentPath.Length <= 3)
                buttonBack.Enabled = false;
            else
                buttonBack.Enabled = true;
        }

        //zmiana koloru panelu
        public void Aktywuj()
        {
            BackColor = System.Drawing.SystemColors.ActiveBorder;
        }

        public void Dezaktywuj()
        {
            BackColor = System.Drawing.SystemColors.Control;
        }
    }
}
