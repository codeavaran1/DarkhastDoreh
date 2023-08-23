using X.PagedList;
using Request_Course.Models;


namespace Request_Course.Serivces.Interface
{
    public interface IRepository
    {

        #region Admin
        #region Modaresan
        public Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehforBinding(int pageid=0);
        public Task<int> BindModresToDoreh(int dorehid,int modaresid);
        #endregion
        #region Doreh
        public Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDoreh(int pageid=0);
        public Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehWithoutModares(int pageid=0);
        public Task<int> AddOnvanAsliAndOnvanDoreh(string onvanAsli, string onvanDoreh);
        public Task<Tuple<List<T_Doreh_Darkhasti>,int>> GetDorehMokhatabFaalAdmin(int paegid=0);
        public Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehMokhatabPygiryAdmin(int paegid = 0);
        public Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehMokhatabGhablAdmin(int paegid = 0);
        #endregion
        #region requster
        public Task<Tuple<List<T_Mokhatebin>, int>> GetSherkatha(int pageid = 0);
        #endregion
        #region User
        public Task<List<T_Activation>> GetActivations();
        #endregion
        #endregion


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
        public Task<int> UpdateModaresan(T_Modaresan _Modaresan,IFormFile img);
        public Task<T_Modaresan> GetModaresan(string phone);
        public Task<T_Modaresan> GetModaresan(int id);
        public Task<List<T_Modaresan>> GetModaresan(int onvnasli, int onvandoreh);
        public Task<Tuple<List<T_Modaresan>, int>> GetModaresan(int pageid=0,string all="");
        public Task<int> GetModaresanPage();
        #region Modaresan Doreh
        public Task<List<T_Doreh_Darkhasti>> GetDoreh_Teacher(int Teacherid);
        public Task<List<int>> GetDorehID_Teacher(int Teacherid);
        public Task<List<T_Doreh_Darkhasti>> GetDoreh_Faal_Teacher(int teacherid);
        public Task<List<T_Doreh_Darkhasti>> GetDoreh_ghabil(int teacherid);
        #endregion
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
        public Task<T_Doreh_Darkhasti> GetDoreh_Darkhasti(int DorehDakhastiId);
        public Task<T_Pishnahad_Modares_Doreh> GetPishnahad_Modares_Doreh(int DorehDakhastiId);
        public Task<string> GetOnvanAsli(int OnvanAsliId);
        public Task<string> GetOnvanDoreh(int OnvanDorehId);
        public Task<string> GetRavasheAmozeshi(int RaveshAmozeshId);
        public Task<string> GetMediaAmozeshi(int MediaAmozeshiId);
        public Task<string> GetMokhatabinDoreh(int MokhatinDoreh);
        public Task<string> GetSatehkeyfi(int SatehkeyfiId);
        public Task<string> GetTeacherName(int TeacherId);
        public Task<int> GetOnvanAsliByName(string name);
        public Task<int> GetOnvanDorehByName(string name);
        #endregion

        #region Doreh Jadid
        public Task<int> AddDorehJadid(T_Doreh_Darkhasti t_Doreh_Darkhasti);
        public Task<int> UpdateDorehJadid(T_Doreh_Darkhasti t_Doreh_Darkhasti);
        #endregion

        #region Mohktab
        public Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabGhabl(int userid);
        public Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabFaal(int userid);
        public Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabPygiry(int userid);
        #endregion

        #region Sar Fasl Doreh
        public Task<List<string>> GetT_Fasl_Dorehs(int onvanasli,int onvandoreh);
        public Task<List<T_Fasl_Doreh>> GetT_Fasl_Dore(int onvanasli, int onvandoreh);
        public Task<List<string>> GetT_Fasl_Dorehs_Pishnahadi(int Dorehid);
        public Task<int> Add_sar_Fasle_Doreh_Pishnahadi(List<T_Fasl_Doreh_Pishnahadi> t_Fasl_Doreh_Pishnahadi);
        public Task<int> AddSarFasl(List<T_Fasl_Doreh> t_Fasl_Dorehs);

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

        #region Admins
        public Task<Tuple<List<T_Admin>, int>> GetAdminsList(int pageid=0);
        public Task<Tuple<List<T_Admin>, int>> GetUsersList(int pageid=0);
        public Task<T_Admin> GetAdmin(string username, string password);
        public Task<T_Admin> GetAdmin(string username);
        public Task<int> AddAdmin(T_Admin t_Admin,IFormFile img);
        public Task<int> EditAdmin(T_Admin t_Admin, IFormFile img);
        public Task<int> RemoveAdmin(string username);

        #endregion


        #region Nazarsanji
        public Task<int> AddNazasanji(T_Nazarsanji t_Nazarsanji);
        public Task<T_Nazarsanji> GetNazarsanji(int dorehId);
        #endregion


        #region Chart
        public Task<Tuple<List<string>, List<int>>> GetDorehByMonthForChart();
        public Task<Tuple<List<string>, List<int>>> GetUserByMonthForChart();
        #endregion


        #region Test

        public Task<IPagedList<T_Modaresan>> GetMOdaresanTest(string q="",string sortOrder="", int page = 1);
        #endregion

        #region DateTime
        public Task ConvertDateToShamsimodaresan();
        public Task ConvertDateToShamsiDoreh();
        public Task<DateTime> ConvertDateToShamsi(DateTime dateTime);
        #endregion




    }
}
