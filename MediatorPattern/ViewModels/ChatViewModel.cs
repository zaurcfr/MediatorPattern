using MediatorPattern.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MediatorPattern.ViewModels
{
    class ChatViewModel
    {
        public MainViewModel MainViewModel { get; set; }
        public string Nickname { get; set; }
        public string Message { get; set; }
        public RelayCommand SendCommand { get; set; }
        public RelayCommand LeaveCommand { get; set; }
        public ChatViewModel(MainViewModel mainViewModel,string nickname)
        {
            MainViewModel = mainViewModel;
            Nickname = nickname;
            SendCommand = new RelayCommand(
                (e) =>
                {
                    MainViewModel.MessageList.Add($"{Nickname}: {Message}");
                });
            LeaveCommand = new RelayCommand(
                (e) =>
                {
                    MainViewModel.MessageList.Add($"{Nickname} left chat.");
                    MainViewModel.chatView.Close();
                });
        }
    }
}
