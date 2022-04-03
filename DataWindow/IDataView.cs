using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWindow
{
    public interface IUsersView
    {
        void SetController(DataController controller);
        void ClearGrid();
        void AddDataToGrid(Data data);
        void UpdateGridWithChangedData(Data data);
        void RemoveDataFromGrid(Data data);
        string GetIdOfSelectedDataInGrid();
        void SetSelectedDataInGrid(Data data);

        string DataName { get; set; }
        string DataValue { get; set; }

    }
}
