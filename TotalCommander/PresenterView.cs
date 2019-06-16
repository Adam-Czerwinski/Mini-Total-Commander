using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCommander
{
    class PresenterView
    {
        private IView view;
        private Model model;

        public PresenterView(IView view, Model model)
        {
            this.view = view;
            this.model = model;
            this.view.copy += Copy;
        }

        //kopiowanie plikow lub folderów
        private void Copy(string zrodlo, string cel)
        {
            if (zrodlo is null || cel is null)
                return;

            //jezeli kopiowanie się powiedzie to odświeżyć listboxa
            if (model.Copy(zrodlo, cel))
                //SelectedPane to ten z ktorego kopiujemy pliki. Dlatego musimy odswiezyc ten drugi.
                view.UnselectedPane.loadDirectoriesAndFiles(view.UnselectedPane.CurrentPath);
        }
    }
}
