using System.ComponentModel.DataAnnotations;

namespace ProniaTask.ViewModels.Account
{
    public class LoginVM
    {
        public string UserNameorEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }


    }
}
