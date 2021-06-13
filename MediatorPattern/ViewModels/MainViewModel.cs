using MediatorPattern.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string _nickname;

        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; OnPropertyChanged(); }
        }
        public ChatView chatView;
        private List<ChatViewModel> subscribers = new List<ChatViewModel>();
        public ObservableCollection<string> MessageList { get; set; } = new ObservableCollection<string>();
        public RelayCommand JoinCommand { get; set; }

        public MainViewModel()
        {
            JoinCommand = new RelayCommand(
                (e) =>
                {
                    subscribers.Add(new ChatViewModel(this, Nickname));
                    chatView = new ChatView { DataContext = subscribers[subscribers.Count - 1] };
                    chatView.Show();
                    MessageList.Add($"{Nickname} joined chat.");

                });
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
