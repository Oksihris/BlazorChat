using BlazorChat.Shared.DTOs;
using System.ComponentModel;

namespace BlazorChat.Client.States
{
    public class AuthenticationState : INotifyPropertyChanged
    {
        public const string AuthStoreKey = "authkey";

        public event PropertyChangedEventHandler? PropertyChanged;
       //public string? Name { get; set; }
        
        //public int Id { get; set; }
       
       public UserDto User { get; set; } = default;
        public string? Token { get; set; }    

    
        private bool _isAuthenticated;

        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set { 
                if (_isAuthenticated != value)
                {
                    _isAuthenticated = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAuthenticated)));
                }

                }
        }

        public void LoadState(AuthResponseDto authResponseDto)
        {
            //Name = authResponseDto.User.Name;
            //Id = authResponseDto.User.Id;
            User= authResponseDto.User;
            Token = authResponseDto.Token;
            IsAuthenticated = true;
        }
        public void UnLoadState()
        {
            //Id = 0;
            //Name = null;
            User = default;
            Token = null;
            IsAuthenticated = false;
        }

    }
}
