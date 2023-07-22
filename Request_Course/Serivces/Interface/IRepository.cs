using Request_Course.Models;

namespace Request_Course.Serivces.Interface
{
    public interface IRepository
    {
        #region Activation
        public Task AddActivation(T_Activation t_Activation);
        public Task UpdateActivation(T_Activation t_Activation);
        public Task<T_Activation> GetActivation(string phone);
        public Task<string> GetUserCode(string phone);
        #endregion

        #region Arrive
        public Task<int> AddContacts();
        public Task<int> ContactsInfo();
        public Task<int> IsContact();
        #endregion

        #region Modaresin
        public Task<int> AddModares(T_Modaresan t_Modaresan,IFormFile img);
        public Task<int> UpdateModaresan(T_Modaresan _Modaresan);
        public Task<T_Modaresan> GetModaresan(string phone);
        public Task<T_Modaresan> GetModaresan(int id);
        public Task<List<T_Modaresan>> GetModaresan(int onvnasli, int onvandoreh);
        public Task<List<T_Modaresan>> GetModaresan();

        #region Fild Asli Modaresan
        public Task<int> AddModaresanFildAsli(List<T_Modaresan_Fild_Amozeshi> t_Modaresan_Fild_Amozeshi);
        #endregion
        #region Modaresan_Tools
        public Task<string> GetMaghtaeTahsili(int id);
        public Task<string> GetNomrehTadris(int id);
        public Task<string> GetRotbebeinModaresan(int id);
        public Task<string> GetSatheKeyfi(int id);
        public Task<string> GetTedadDoreh(int id);
        public Task<string> GetMadraktahsilibyId(int id);
        
        #endregion
        #endregion

        #region Requster
        public Task<int> AddMokhatab(T_Mokhatebin t_Mokhatebin);
        public Task<int> UpdateMokhatab(T_Mokhatebin t_Mokhatab);
        public Task<T_Mokhatebin> GetMokhatebin(string phone);
        #endregion


        #region doreh
        public Task<int> AddDoreh();
        public Task<int> UpdateDoreh();
        public Task<int> Add_Pishnahad_Modares_Doreh(T_Pishnahad_Modares_Doreh t_Pishnahad_Modares_Doreh);
        #endregion

        #region Doreh Jadid
        public Task<int> AddDorehJadid(T_Doreh_Darkhasti t_Doreh_Darkhasti);
        public Task<int> UpdateDorehJadid(T_Doreh_Darkhasti t_Doreh_Darkhasti);
        #endregion

        #region Sar Fasl Doreh
        public Task<List<T_Fasl_Doreh>> GetT_Fasl_Dorehs(int onvanasli,int onvandoreh);
        public Task<int> Add_sar_Fasle_Doreh_Pishnahadi(List<T_Fasl_Doreh_Pishnahadi> t_Fasl_Doreh_Pishnahadi);
        #endregion



        #region Tools
        public Task<List<T_L_MaghtaeTahsili>> GetMaghtaeTahsili();
        public Task<List<T_L_ReshtehTahsili>> GetReshtehTahsilis();
        public Task<List<T_L_DaragehElmi>> GetDaragehElmis();
        public Task<List<T_L_FildAsli>> GetFildAslis();
        public Task<List<T_L_OnvanDoreh>> GetOnvanDorehs();
        public Task<List<T_L_Semat>> GetSemats();
        public Task<List<T_L_Ostan>> GetOstans();
        public Task<List<T_L_OnvanAsli>> GetOnvanAslis();
        public Task<List<T_L_MediaAmozeshi>> GetMediaAmozeshis();
        public Task<List<T_L_RaveshAmozeshi>> GetRaveshAmozeshis();
        public Task<List<T_L_ModateDoreh>> GetModateDorehs();
        public Task<List<T_L_MokhatabanDoreh>> GetMokhatabanDorehs();
        public Task<List<T_L_SatheKeyfi_Modares>> GetSatheKeyfi_Modares();
        #endregion



    }
}
