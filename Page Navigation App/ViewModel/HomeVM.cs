using Page_Navigation_App.Model;
using Page_Navigation_App.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel
{
    class HomeVM:ViewModelBase
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalUsersCount));
            }
        }
        public int TotalUsersCount
        {
            get
            {
                return _users.Count;
            }
        }
        public User SelectedUser { get; set; }

        public HomeVM()
        {
            _users = new ObservableCollection<User>()
            {
                new User{ Name = "Alex", Email = "sam@gmail.com", Company = "WallMart", Salary = 9000},
                new User{ Name = "Marry", Email = "marry@gmail.com", Company = "WallMart", Salary = 9000},
                new User{ Name = "Tom", Email = "john@gmail.com", Company = "WallMart", Salary = 9000}
            };
            DeleteUserCommand = new RelayCommand(DeleteSelectedUser, CanDeleteSelectedUser);
        }

        private bool CanDeleteSelectedUser(object arg)
        {
            return SelectedUser != null;
        }

        private void DeleteSelectedUser(object obj)
        {
            if (SelectedUser != null)
            {
                Users.Remove(SelectedUser);
                SelectedUser = null;
                OnPropertyChanged(nameof(TotalUsersCount));
            }
        }

        public ICommand DeleteUserCommand { get; set; }
    }
}
