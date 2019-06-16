using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCommander
{
    class Model
    {
        private string CurrentPath;
        private string[] Drives;
        private string[] DirectoriesAndFiles;

        public Model() { }

        public string[] LoadDrivers()
        {
            //rezerwacja miejsca
            Drives = new string[System.IO.DriveInfo.GetDrives().Length];
            
            int numerator = 0;
            foreach (var i in System.IO.DriveInfo.GetDrives())
                Drives[numerator++] = i.ToString();
            
            return Drives;
        }

        public bool Copy(string zrodlo, string cel)
        {
            //jezeli zrodlo jest takie samo jak cel to zakoncz
            if (zrodlo.Equals(cel))
                return false;


            System.IO.FileAttributes fileAttributes = File.GetAttributes(zrodlo);

            //jeżeli folder
            if (fileAttributes.HasFlag(FileAttributes.Directory))
            {
                foreach (string dirPath in Directory.GetDirectories(zrodlo, "*",
                SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(zrodlo, cel));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(zrodlo, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(zrodlo, cel), true);
            }
            //w innym wypadku
            else
            {
                try
                {
                string nazwa = zrodlo.Substring(zrodlo.LastIndexOf('\\')+1);
                File.Copy(zrodlo, cel+nazwa,true);

                }
                catch(Exception error) { MessageBox.Show(error.Message); }
            }

            return true;
        }

        public string[] LoadDirectoriesAndFiles(string path)
        {
            try
            {
                //rezerwacja miejsca na pliki i foldery
                DirectoriesAndFiles = new string[System.IO.Directory.GetDirectories(path).Length+ System.IO.Directory.GetFiles(path).Length];
                //najpierw uzupełnienie o foldery
                System.IO.Directory.GetDirectories(path).CopyTo(DirectoriesAndFiles, 0);
                //teraz uzupełnienie o pliki
                System.IO.Directory.GetFiles(path).CopyTo(DirectoriesAndFiles, System.IO.Directory.GetDirectories(path).Length);
            }
            //brak dostępu
            catch(UnauthorizedAccessException error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
            //nośnik nie jest gotowy lub inny błąd IO
            catch (System.IO.IOException error)
            {
                MessageBox.Show(error.Message);
                return null;
            }

            CurrentPath = path;
            return DirectoriesAndFiles;
        }
    }
}
