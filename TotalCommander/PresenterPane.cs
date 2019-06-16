using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCommander
{
    class PresenterPane
    {
        private IPane pane;
        private Model model;

        public PresenterPane(IPane pane,Model model)
        {
            this.model = model;
            this.pane = pane;

            //przypisanie akcji z paneli do funkcji w tej klasie.
            this.pane.loadDrives += LoadDrives;
            this.pane.loadDirectoriesAndFiles += LoadDirectoriesAndFiles;
        }

        //Metoda ta dodaje do listbox'a z klasy pane pliki i foldery, które otrzymaliśmy z modelu.
        //Modyfikuje otrzymane wyniki poprzez dodanie prefiksu <F> lub <D> w zależności od rodzaju.
        //parametr metody "sciezka" jest ścieżką z której mamy wczytaj pliki i foldery.
        private void LoadDirectoriesAndFiles(string sciezka)
        {
            //pobranie plików i folderów z podanej sciezki
            string[] directoriesAndFiles = model.LoadDirectoriesAndFiles(sciezka);

            //Jeżeli coś poszło nie tak, np. odmowa dostępu do ścieżki. Ustawiłem w metodzie model.LoadDirectoriesAndFiles()
            //że jeżeli odmowa dostepu to zwróci null lub wystąpi inny catch
            if (directoriesAndFiles is null)
                return;

            //sprawdzanie czy to jest plik czy folder i dodanie prefikus <D> lub <F>
            System.IO.FileAttributes fileAttributes;
            for (int i=0;i<directoriesAndFiles.Length;i++)
            {
                //przechowanie atrybutów każdego elementu zwróconego przez model.
                fileAttributes = File.GetAttributes(directoriesAndFiles[i]);

                //usuniecie poczatku, zeby tylko nazwa pliku lub folderu została
                directoriesAndFiles[i] = directoriesAndFiles[i].Remove(0, sciezka.Length);
                
                //jeżeli folder
                if (fileAttributes.HasFlag(FileAttributes.Directory))
                    directoriesAndFiles[i] = directoriesAndFiles[i].Insert(0, "<D>");
                //w innym wypadku
                else
                    directoriesAndFiles[i] = directoriesAndFiles[i].Insert(0, "<F>");
            }

            //jezeli wszystko okej to mozna teraz zmienic CurrentPath w pane, ponieważ
            //Przeszliśmy dalej jezeli chodzi o hierarchię folderów
            pane.CurrentPath = sciezka;
            //teraz aktualizacja listbox'a w pane.
            pane.DirectoriesAndFiles = directoriesAndFiles;
        }

        private void LoadDrives()
        {
            //załadowanie dysków logicznych
            pane.Drives = model.LoadDrivers();
        }

    }
}
