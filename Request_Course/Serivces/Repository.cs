using Request_Course.Data;
using Request_Course.Models;
using Request_Course.Serivces.Interface;

namespace Request_Course.Serivces
{
    public class Repository : IRepository
    {
        private ReqContexts _context;
        public Repository(ReqContexts reqContexts)
        {
            _context = reqContexts;
        }


        #region Admin
        #region Modaresan
        public async Task<List<T_Doreh_Darkhasti>> GetDorehforBinding()
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 3).ToList();
        }
        public async Task<int> BindModresToDoreh(int dorehid, int modaresid)
        {
            var result =await GetDoreh_Darkhasti(dorehid);
            result.T_Modaresan_ID=modaresid;
            result.T_L_Vaziyat_Doreh_ID = 1;
            _context.T_Doreh_Darkhasti.Update(result);
            await _context.SaveChangesAsync();
            return 0;
        }
        #endregion
        #region Doreh
        public async Task<int> AddOnvanAsliAndOnvanDoreh(string onvanAsli, string onvanDoreh)
        {
            T_L_OnvanAsli t_L_OnvanAsli = new T_L_OnvanAsli()
            {
                Titles_OnvanAsli = onvanAsli,
            };
            T_L_OnvanDoreh t_L_OnvanDoreh = new T_L_OnvanDoreh()
            {
                Titles_OnvanDoreh = onvanDoreh,
            };
            _context.T_L_OnvanAsli.Add(t_L_OnvanAsli);
            _context.T_L_OnvanDoreh.Add(t_L_OnvanDoreh);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabFaal()
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 1).ToList();
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabPygiry()
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 3).ToList();
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabGhabl()
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 2).ToList();
        }
        #endregion
        #region Requester
        public async Task<List<T_Mokhatebin>> GetSherkatha()
        {
            return _context.T_Mokhatebin.ToList();
        }
        #endregion
        #endregion


        #region Activation
        public async Task AddActivation(T_Activation t_Activation)
        {
            await _context.T_Activation.AddAsync(t_Activation);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetUserCode(string phone)
        {
            T_Activation t_Activation = await GetActivation(phone);
            return t_Activation.code;
        }

        public async Task<T_Activation> GetActivation(string phone)
        {
            return _context.T_Activation.SingleOrDefault(x => x.Phone == phone);
        }

        public async Task UpdateActivation(T_Activation t_Activation)
        {
            _context.T_Activation.Update(t_Activation);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Arrive

        public Task<int> AddContacts()
        {
            throw new NotImplementedException();
        }

        public Task<int> ContactsInfo()
        {
            throw new NotImplementedException();
        }


        public Task<int> IsContact()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Modaresin

        public async Task<T_Modaresan> GetModaresan(string phone)
        {
            return _context.T_Modaresan.SingleOrDefault(x => x.Phone == phone);
        }
        public async Task<List<T_Modaresan>> GetModaresan(int onvnasli, int onvandoreh)
        {
            var OnvanAsli = _context.T_Modaresan_Fild_Amozeshi
                .Where(x => x.T_L_OnvanDoreh_ID == onvnasli && x.T_L_OnvanDoreh_ID==onvandoreh).Select(x=>x.T_Modaresan_ID).ToList();
            OnvanAsli=OnvanAsli.Distinct().ToList();
            List<T_Modaresan> result = new List<T_Modaresan>(); 
            foreach (var item in OnvanAsli)
            {
                T_Modaresan t_Modaresan =_context.T_Modaresan.SingleOrDefault(d => d.ID_Modaresan == item);
                result.Add(t_Modaresan);
            }
            return result;
        }
        public async Task<T_Modaresan> GetModaresan(int id)
        {
            return _context.T_Modaresan.SingleOrDefault(x => x.ID_Modaresan == id);
        }
        public async Task<List<T_Modaresan>> GetModaresan()
        {
            return _context.T_Modaresan.ToList();
        }
        public async Task<int> AddModares(T_Modaresan t_Modaresan, IFormFile img)
        {
            if (img != null)
            {
                t_Modaresan.img = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(img.FileName);
                string ImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", t_Modaresan.img);
                using (var Stream = new FileStream(ImgPath, FileMode.Create))
                {
                    img.CopyTo(Stream);
                }
            }
            else
            {
                t_Modaresan.img = "defalut.jpg";
            }
            await _context.T_Modaresan.AddAsync(t_Modaresan);
            await _context.SaveChangesAsync();
            return t_Modaresan.ID_Modaresan;
        }
        public async Task<int> UpdateModaresan(T_Modaresan _Modaresan)
        {
            _context.T_Modaresan.Update(_Modaresan);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<int> UpdateModaresan(T_Modaresan _Modaresan, IFormFile img)
        {
            if (img != null)
            {
                if (_Modaresan.img!=null)
                {
                    string Deletimg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", _Modaresan.img);
                    if (File.Exists(Deletimg))
                    {
                        File.Delete(Deletimg);
                    }
                }
                _Modaresan.img= Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(img.FileName);

                string ImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", _Modaresan.img);
                using (var Stream = new FileStream(ImgPath, FileMode.Create))
                {
                    img.CopyTo(Stream);
                }
            }
            _context.T_Modaresan.Update(_Modaresan);
            await _context.SaveChangesAsync();
            return 0;
        }
        #region Teacher doreh
        public async Task<List<T_Doreh_Darkhasti>> GetDoreh_Teacher(int Teacherid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_ModateDoreh_ID == Teacherid).ToList();
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDoreh_Faal_Teacher(int teacherid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == teacherid && x.T_L_Vaziyat_Doreh_ID == 1).ToList();
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDoreh_ghabil(int teacherid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == teacherid && x.T_L_Vaziyat_Doreh_ID == 2).ToList();
        }
        #endregion
        #region Modaresan Sar Fasl
        public async Task<List<string>> GetT_Fasl_Dorehs(int onvanasli, int onvandoreh)
        {
            return _context.T_Fasl_Doreh.Where(x => x.T_L_OnvanDoreh_ID == onvandoreh && x.T_L_OnvanAsli_ID == onvanasli).Select(x=>x.Mohtav).ToList();
        }
        public async Task<List<T_Fasl_Doreh>> GetT_Fasl_Dore(int onvanasli, int onvandoreh)
        {
            return _context.T_Fasl_Doreh.Where(x => x.T_L_OnvanDoreh_ID == onvandoreh && x.T_L_OnvanAsli_ID == onvanasli).ToList();
        }
        #endregion
        #region Modaresan fild Asli
        public async Task<int> AddModaresanFildAsli(List<T_Modaresan_Fild_Amozeshi> t_Modaresan_Fild_Amozeshi)
        {
            await _context.T_Modaresan_Fild_Amozeshi.AddRangeAsync(t_Modaresan_Fild_Amozeshi);
            await _context.SaveChangesAsync();
            return 0;
        }

        #endregion
        #region Modaresan Tools
        public async Task<string> GetMaghtaeTahsili(int id)
        {
            return _context.T_L_MaghtaeTahsili.SingleOrDefault(x => x.ID_MaghtaeTahsili == id).Titles_MaghtaeTahsili;
        }
        public async Task<string> GetNomrehTadris(int id)
        {
            //don't Have Data and Table
            throw new Exception();
        }
        public Task<string> GetRotbebeinModaresan(int id)
        {
            //don't Have Data and Table
            throw new NotImplementedException();
        }
        public async Task<string> GetSatheKeyfi(int id)
        {
            return _context.T_L_SatheKeyfi_Modares.SingleOrDefault(x => x.ID_L_SatheKeyfi_Modares == id).Titles_SatheKeyfi_Modares;
        }
        public async Task<string> GetTedadDoreh(int id)
        {
            // Not enught Data
            throw new NotImplementedException();
        }
        public async Task<string> GetMadraktahsilibyId(int id)
        {
            return _context.T_L_MaghtaeTahsili.SingleOrDefault(x => x.ID_MaghtaeTahsili == id).Titles_MaghtaeTahsili;
        }
        #endregion
        #endregion

        #region Mokhatabin

        public async Task<T_Mokhatebin> GetMokhatebin(string phone)
        {
            return _context.T_Mokhatebin.SingleOrDefault(d => d.Phone == phone);
        }

        public async Task<int> AddMokhatab(T_Mokhatebin t_Mokhatebin)
        {
            await _context.T_Mokhatebin.AddAsync(t_Mokhatebin);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int> UpdateMokhatab(T_Mokhatebin t_Mokhatab)
        {
            _context.T_Mokhatebin.Update(t_Mokhatab);
            await _context.SaveChangesAsync();
            return 0;
        }


        #region Doreh Mokhatbin
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabGhabl(int userid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_MokhatabanDoreh_ID==userid && x.T_L_Vaziyat_Doreh_ID==2).ToList();
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabFaal(int userid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_MokhatabanDoreh_ID == userid && x.T_L_Vaziyat_Doreh_ID == 1).ToList();
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabPygiry(int userid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_MokhatabanDoreh_ID == userid && x.T_L_Vaziyat_Doreh_ID == 3).ToList();
        }
        #endregion

        #endregion

        #region Doreh
        public Task<int> AddDoreh()
        {
            throw new NotImplementedException();
        }
        public Task<int> UpdateDoreh()
        {
            throw new NotImplementedException();
        }
        public async Task<int> Add_Pishnahad_Modares_Doreh(T_Pishnahad_Modares_Doreh t_Pishnahad_Modares_Doreh)
        {
            await _context.T_Pishnahad_Modares_Doreh.AddAsync(t_Pishnahad_Modares_Doreh);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<T_Doreh_Darkhasti> GetDoreh_Darkhasti(int DorehDakhastiId)
        {
            return  _context.T_Doreh_Darkhasti.SingleOrDefault(x => x.ID_Doreh_Darkhasti == DorehDakhastiId);
        }
        public async Task<T_Pishnahad_Modares_Doreh> GetPishnahad_Modares_Doreh(int DorehDakhastiId)
        {
            return _context.T_Pishnahad_Modares_Doreh.SingleOrDefault(x => x.T_Doreh_Darkhasti_ID == DorehDakhastiId);
        }
        public async Task<string> GetOnvanAsli(int OnvanAsliId)
        {
            return _context.T_L_OnvanAsli.SingleOrDefault(d => d.ID_L_OnvanAsli == OnvanAsliId).Titles_OnvanAsli;
        }
        public async Task<string> GetOnvanDoreh(int OnvanDorehId)
        {
            return _context.T_L_OnvanDoreh.SingleOrDefault(x => x.ID_OnvanDoreh == OnvanDorehId).Titles_OnvanDoreh;
        }
        public async Task<string> GetRavasheAmozeshi(int RaveshAmozeshId)
        {
            return _context.T_L_RaveshAmozeshi.SingleOrDefault(x => x.ID_L_RaveshAmozeshi == RaveshAmozeshId).Titles_RaveshAmozeshi;
        }
        public async Task<string> GetMediaAmozeshi(int MediaAmozeshiId)
        {
            return _context.T_L_MediaAmozeshi.SingleOrDefault(x => x.ID_MediaAmozeshi == MediaAmozeshiId).Titles_MediaAmozeshi;
        }
        public async Task<string> GetMokhatabinDoreh(int MokhatinDoreh)
        {
            return _context.T_L_MokhatabanDoreh.SingleOrDefault(x => x.ID_MokhatabanDoreh == MokhatinDoreh).Titles_MokhatabanDoreh;
        }
        public async Task<string> GetSatehkeyfi(int SatehkeyfiId)
        {
            return _context.T_L_SatheKeyfi_Modares.SingleOrDefault(x => x.ID_L_SatheKeyfi_Modares == SatehkeyfiId).Titles_SatheKeyfi_Modares;
        }
        public async Task<string> GetTeacherName(int TeacherId)
        {
            return _context.T_Modaresan.SingleOrDefault(x => x.ID_Modaresan == TeacherId).NameFamily;
        }
        #endregion

        #region SarFasl pishnahadi
        public async Task<int> Add_sar_Fasle_Doreh_Pishnahadi(List<T_Fasl_Doreh_Pishnahadi> t_Fasl_Doreh_Pishnahadi)
        {
            await _context.T_Fasl_Doreh_Pishnahadi.AddRangeAsync(t_Fasl_Doreh_Pishnahadi);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<List<string>> GetT_Fasl_Dorehs_Pishnahadi(int Dorehid)
        {
            return  _context.T_Fasl_Doreh_Pishnahadi.Where(x => x.T_Doreh_Darkhasti_ID == Dorehid).Select(x=>x.Mohtava).ToList();
        }
        #endregion

        #region Dore Jadid
        public async Task<int> AddDorehJadid(T_Doreh_Darkhasti t_Doreh_Darkhasti)
        {
            await _context.T_Doreh_Darkhasti.AddAsync(t_Doreh_Darkhasti);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int> UpdateDorehJadid(T_Doreh_Darkhasti t_Doreh_Darkhasti)
        {
            _context.T_Doreh_Darkhasti.Update(t_Doreh_Darkhasti);
            await _context.SaveChangesAsync();
            return 0;
        }

        #endregion


        #region Tools T_L_ Get All
        public async Task<List<T_L_MaghtaeTahsili>> GetMaghtaeTahsili()
        {
            return _context.T_L_MaghtaeTahsili.ToList();
        }

        public async Task<List<T_L_ReshtehTahsili>> GetReshtehTahsilis()
        {
            return _context.T_L_ReshtehTahsili.ToList();
        }

        public async Task<List<T_L_DaragehElmi>> GetDaragehElmis()
        {
            return _context.T_L_DaragehElmi.ToList();
        }

        public async Task<List<T_L_FildAsli>> GetFildAslis()
        {
            return _context.T_L_FildAsli.ToList();
        }

        public async Task<List<T_L_OnvanDoreh>> GetOnvanDorehs()
        {
            return _context.T_L_OnvanDoreh.ToList();
        }

        public async Task<List<T_L_Semat>> GetSemats()
        {
            return _context.T_L_Semat.ToList();
        }

        public async Task<List<T_L_Ostan>> GetOstans()
        {
            return _context.T_L_Ostan.ToList();
        }

        public async Task<List<T_L_OnvanAsli>> GetOnvanAslis()
        {
            return _context.T_L_OnvanAsli.ToList();
        }

        public async Task<List<T_L_MediaAmozeshi>> GetMediaAmozeshis()
        {
            return _context.T_L_MediaAmozeshi.ToList();
        }

        public async Task<List<T_L_RaveshAmozeshi>> GetRaveshAmozeshis()
        {
            return _context.T_L_RaveshAmozeshi.ToList();
        }

        public async Task<List<T_L_ModateDoreh>> GetModateDorehs()
        {
            return _context.T_L_ModateDoreh.ToList();
        }

        public async Task<List<T_L_MokhatabanDoreh>> GetMokhatabanDorehs()
        {
            return _context.T_L_MokhatabanDoreh.ToList();
        }

        public async Task<List<T_L_SatheKeyfi_Modares>> GetSatheKeyfi_Modares()
        {
            return _context.T_L_SatheKeyfi_Modares.ToList();
        }



        #endregion
    }
}
