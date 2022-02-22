using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWindow
{
    public class UsersController
    {
        // data interfaces
        IUsersView _view;
        IList _users;
        User _selectedUser;

        public UsersController(IUsersView view)
        {
            _view = view;
            _users = new List<User>();
            view.SetController(this);
        }

        public IList Users
        {
            get { return ArrayList.ReadOnly(_users); }
        }

        // update View with User details
        private void UpdateViewDetailValues(User user)
        {
            _view.FirstName = user.FirstName;
            _view.LastName = user.LastName;
        }

        // update User with View details
        private void UpdateUserWithViewValues(User user)
        {
            user.FirstName = _view.FirstName;
            user.LastName = _view.LastName;
        }

        // load a view
        public void LoadView()
        {
            // clear the grid
            _view.ClearGrid();

            // add each user to the grid from the view
            foreach (User user  in _users)
                _view.AddUserToGrid(user);
        }
        
        // change the selected user by id
        public void SelectedUserChanged(string selectedUserId)
        {
            foreach (User user in _users)
            {
                if(user.ID == selectedUserId)
                {
                    _selectedUser = user;
                    UpdateViewDetailValues(user);
                    _view.SetSelectedUserInGrid(user);
                    break;
                }
            }
        }

        // add a new user
        public void AddNewUser()
        {
            _selectedUser = new User("" /* first name */,  "" /* last name */);
            UpdateViewDetailValues(_selectedUser);
        }

        // remove a users
        public void RemoveUser()
        {
            string id = _view.GetIdOfSelectedUserInGrid();
            User toRemove = null;
            if(id != "")
            {
                // find user to remove by id
                foreach (User user in _users)
                {
                    if (user.ID == id)
                    {
                        toRemove = user;
                        break;
                    }
                }

                // remove the user
                if(toRemove != null)
                {
                    int newSelectedIndex = _users.IndexOf(toRemove);
                    _users.Remove(toRemove);
                    _view.RemoveUserFromGrid(toRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _users.Count)
                    {
                        _view.SetSelectedUserInGrid((User)_users[newSelectedIndex]);
                    }
                }
            }
        }
        
        // save data, adding user to database the grid
        public void Save()
        {
           
            UpdateUserWithViewValues(_selectedUser);
            if (_selectedUser != null)
            {
                if (!_users.Contains(_selectedUser))
                {
                    // add new user if not existing
                    _users.Add(_selectedUser);
                    _view.AddUserToGrid(_selectedUser);
                    
                    MessageBox.Show(DBLogic.AddNewUser(_selectedUser));
                }
                else
                {
                    // else update user
                    _view.UpdateGridWithChangedUser(_selectedUser);
                }

                _view.SetSelectedUserInGrid(_selectedUser);
            }
            else
            {
                Console.WriteLine("ENTER ID");
            }
            
        }
    }
}
