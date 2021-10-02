namespace Casino.Identity.Models
{
    public class UserOutputModel
    {
        public UserOutputModel(string token)
        {
            this.Token = token;
        }

        public UserOutputModel(double balance)
        {
            this.Balance = balance;
        }

        public string Token { get; }
        public double Balance { get; }
    }
}
