using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCAdmin
{
    class Presenter
    {
        Model _model;
        IView _view;

        public Presenter(IView view, Model model)
        {
            _view = view;
            _model = model;

            _view.Load += Load;
        }

        private void Load()
        {
            Change[] dataObj = _model.LoadData();
            string[,] data = new string[dataObj.Length, 5];

            int index = 0;
            foreach (Change c in dataObj)
            {
                data[index, 0] = c.Id.ToString();
                data[index, 1] = c.User;
                data[index, 2] = c.Source;
                data[index, 3] = c.Destination;
                data[index, 4] = c.DateTime;
                index++;
            }
            _view.Data = data;
        }
    }
}
