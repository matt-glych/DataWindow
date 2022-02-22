using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWindow
{
    public interface IUsersView
    {
        void SetController(UsersController controller);
        void ClearGrid();
        void AddUserToGrid(User user);
        void UpdateGridWithChangedUser(User user);
        void RemoveUserFromGrid(User user);
        string GetIdOfSelectedUserInGrid();
        void SetSelectedUserInGrid(User user);

        string FirstName { get; set; }
        string LastName { get; set; }

    }
}
