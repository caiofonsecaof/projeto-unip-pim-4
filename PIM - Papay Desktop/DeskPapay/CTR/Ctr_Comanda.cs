using DeskPapay.DAO;
using DeskPapay.DTO;
using DeskPapay.MODEL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DeskPapay.CTR
{
    public class Ctr_Comanda
    {
        private ComandaDao comandaDao;

        public Ctr_Comanda()
        {
            comandaDao = new ComandaDao();
        }

        public List<ComandaDTO> BuscarComandas(int idcomanda)
        {
            return comandaDao.BuscarComandas(idcomanda);
        }

        
        public void AddItem(ComandaDTO comanda)
        {
            comandaDao.InserirComandas(comanda);
        }

        public void RemoverComanda(int idComanda)
        {
            comandaDao.RemoverComanda(idComanda);
        }
    }
}
