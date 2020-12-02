using DeskPapay.DAO;
using DeskPapay.MODEL;
using System;

namespace DeskPapay.CTR
{
    public class Ctr_Login
    {
        private readonly LoginDao loginDao;

        public Ctr_Login()
        {
            loginDao = new LoginDao();
        }

        //INSERIR METODOS VALIDAÇÃO

        public bool Acesso(Login login)
        {
            try
            {
                return loginDao.EfetuarLogin(login);
            }
            catch (Exception)
            {
                return false;
            }
            
        }

    }
}
