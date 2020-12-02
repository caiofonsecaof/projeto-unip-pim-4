namespace DeskPapay.MODEL
{
    public class Login
    {
        public string UserName { get; set; }
        public string UserSenha { get; set; }

        public Login() //construtor vazio é possivel instanciar sem parâmetros
        {

        }

        public Login(string userName, string userSenha) //construtor preenchido possibilita instanciar com parâmetros
        {
            UserName = userName;
            UserSenha = userSenha;
        }
    }
}
