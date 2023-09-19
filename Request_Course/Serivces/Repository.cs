using X.PagedList;
using Request_Course.Data;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

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

        #region Access
        public async Task ConfrimDoreh(int dorehId)
        {
            var result = await _context.T_Doreh_Darkhasti.SingleOrDefaultAsync(id => id.ID_Doreh_Darkhasti == dorehId);
            result.IsFinaly = true;
            _context.T_Doreh_Darkhasti.Update(result);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Modaresan
        public async Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehforBinding(int pageid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti;
            result = result.Where(x => x.T_L_Vaziyat_Doreh_ID == 3);
            result = result.OrderByDescending(c => c.Date_Create);

            int skip = (pageid - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Doreh_Darkhasti> query = result.Skip(skip).Take(4).ToList();

            return Tuple.Create(query, pageCount);
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDorehforBinding(string search, int pageid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 3);
            if (string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_L_OnvanDoreh).Where(s => s.T_L_OnvanDoreh.Titles_OnvanDoreh == search);
            }
            return result.ToList().ToPagedList(pageid, 1);
        }
        public async Task<int> BindModresToDoreh(int dorehid, int modaresid)
        {
            var result = await GetDoreh_Darkhasti(dorehid);
            result.T_Modaresan_ID = modaresid;
            result.T_L_Vaziyat_Doreh_ID = 5;
            _context.T_Doreh_Darkhasti.Update(result);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task RemoveTeacher(int modaresId)
        {
            var modares = await GetModaresan(modaresId);
            _context.T_Modaresan.Remove(modares);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Doreh
        public async Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDoreh(int pageid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti;
            result = result.OrderByDescending(c => c.Date_Create);

            int skip = (pageid - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Doreh_Darkhasti> query = result.Skip(skip).Take(4).ToList();

            return Tuple.Create(query, pageCount);
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDoreh(string search, string sortOrder, int pageid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti;
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(x => x.T_L_OnvanAsli_ID);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(x => x.T_Mokhatebin_ID);
                    break;
                case "vazieat":
                    result = result.OrderBy(x => x.T_L_Vaziyat_Doreh_ID);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(pageid, 1);
        }
        public async Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehWithoutModares(int pageid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == null);

            result = result.OrderByDescending(c => c.Date_Create);
            int skip = (pageid - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Doreh_Darkhasti> query = result.Skip(skip).Take(4).ToList();
            return Tuple.Create(query, pageCount);

        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDorehWithoutModares(string search, string sortOreder, int pageid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == null && x.T_L_Vaziyat_Doreh_ID == 3);
            switch (sortOreder)
            {
                case "Doreh":
                    result = result.OrderBy(x => x.T_L_OnvanAsli_ID);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(x => x.T_Mokhatebin_ID);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(pageid, 8);

        }
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
        public async Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehMokhatabFaalAdmin(int pageId = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 1);
            result = result.OrderByDescending(x => x.Date_Create);

            int skip = (pageId - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Doreh_Darkhasti> query = result.Skip(skip).Take(4).ToList();

            return Tuple.Create(query, pageCount);

        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDorehMokhatabFaalAdmin(string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 1);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(o => o.Date_Create);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
        }
        public async Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehMokhatabPygiryAdmin(int pageId = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 3);
            result = result.OrderByDescending(x => x.Date_Create);

            int skip = (pageId - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Doreh_Darkhasti> query = result.Skip(skip).Take(4).ToList();

            return Tuple.Create(query, pageCount);
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDorehMokhatabPygiryAdmin(string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 3);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(o => o.Date_Create);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
        }
        public async Task<Tuple<List<T_Doreh_Darkhasti>, int>> GetDorehMokhatabGhablAdmin(int pageId = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 2);
            result = result.OrderByDescending(x => x.Date_Create);

            int skip = (pageId - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Doreh_Darkhasti> query = result.Skip(skip).Take(4).ToList();

            return Tuple.Create(query, pageCount);
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDorehMokhatabGhablAdmin(string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_L_Vaziyat_Doreh_ID == 2);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(o => o.Date_Create);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDoreh_DarkhastisForMokhatab(int MokhatabId = 0, int pageid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_Mokhatebin_ID == MokhatabId && x.IsFinaly == true);
            return result.ToList().ToPagedList(pageid, 1);
        }
        public async Task RemoveDoreh(int DoreId)
        {
            var result = _context.T_Doreh_Darkhasti.SingleOrDefault(x => x.ID_Doreh_Darkhasti == DoreId);
            result.IsFinaly = false;
            _context.T_Doreh_Darkhasti.Update(result);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Requester
        public async Task<Tuple<List<T_Mokhatebin>, int>> GetSherkatha(int pageid = 0)
        {
            IQueryable<T_Mokhatebin> result = _context.T_Mokhatebin;

            int skip = (pageid - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Mokhatebin> query = result.Skip(skip).Take(4).ToList();

            return Tuple.Create(query, pageCount);
        }
        public async Task<IPagedList<T_Mokhatebin>> GetSherkatha(string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Mokhatebin> result = _context.T_Mokhatebin;
            switch (sortOrder)
            {
                case "Name":
                    result = result.OrderBy(o => o.Name_Sherkat);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(s => s.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(paegid, 3);
        }
        public async Task<T_Mokhatebin> GetMokhatebinById(int MokhatabId)
        {
            return _context.T_Mokhatebin.SingleOrDefault(x => x.ID_Mokhatebin == MokhatabId);
        }
        public async Task<bool> SetSatehSherkat(int satehId, int sherkatId)
        {
            var result = await _context.T_Mokhatebin.SingleOrDefaultAsync(x => x.ID_Mokhatebin == sherkatId);
            result.T_L_Sathe_Sherkat_ID = satehId;
            _context.T_Mokhatebin.Update(result);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<T_L_Sathe_Sherkat>> GetSathe_Sherkat()
        {
            return _context.T_L_Sathe_Sherkat.ToList();
        }
        public async Task<int> GetSatehsherkatByName(string sathe)
        {
            return _context.T_L_Sathe_Sherkat.SingleOrDefault(x => x.Titles_Sathe_Sherkat == sathe).ID_Sathe_Sherkat;
        }
        #endregion
        #region User
        public async Task<List<T_Activation>> GetActivations()
        {
            return _context.T_Activation.ToList();
        }
        public async Task<IPagedList<T_Activation>> GetActivations(string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Activation> result = _context.T_Activation;
            switch (sortOrder)
            {
                case "Name":
                    result = result.OrderBy(o => o.NameFamily);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(s => s.NameFamily == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
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
                .Where(x => x.T_L_FildAsli_ID == onvnasli && x.T_L_OnvanDoreh_ID == onvandoreh).Select(x => x.T_Modaresan_ID).ToList();
            OnvanAsli = OnvanAsli.Distinct().ToList();
            List<T_Modaresan> result = new List<T_Modaresan>();
            foreach (var item in OnvanAsli)
            {
                T_Modaresan t_Modaresan = _context.T_Modaresan.SingleOrDefault(d => d.ID_Modaresan == item);
                result.Add(t_Modaresan);
            }
            return result;
        }

        public async Task<List<T_Modaresan>> GetModaresanByOnvanasli(int onvnasli)
        {
            var OnvanAsli = _context.T_Modaresan_Fild_Amozeshi
            .Where(x => x.T_L_FildAsli_ID == onvnasli).Select(x => x.T_Modaresan_ID).ToList();
            OnvanAsli = OnvanAsli.Distinct().ToList();
            List<T_Modaresan> result = new List<T_Modaresan>();
            foreach (var item in OnvanAsli)
            {
                T_Modaresan t_Modaresan = _context.T_Modaresan.SingleOrDefault(d => d.ID_Modaresan == item);
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
        public async Task<IPagedList<T_Modaresan>> GetModaresan(string search, string sortOrder, int pageid = 0)
        {
            IQueryable<T_Modaresan> result = _context.T_Modaresan;

            result = result.OrderByDescending(c => c.DateCreate);
            switch (sortOrder)
            {
                case "nameFamily":
                    result = result.OrderBy(x => x.NameFamily);
                    break;
                case "Phone":
                    result = result.OrderBy(x => x.Phone);
                    break;
                case "Email":
                    result = result.OrderByDescending(x => x.Email);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.NameFamily.Contains(search));
            }

            return result.ToList().ToPagedList(pageid, 1);
        }
        public async Task<int> GetModaresanPage()
        {
            int pageCount = _context.T_Modaresan.Count() / 4;
            return pageCount;
        }
        public async Task<int> AddModares(T_Modaresan t_Modaresan, IFormFile img)
        {
            if (img != null)
            {
                t_Modaresan.img = t_Modaresan.Phone + Path.GetExtension(img.FileName);
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
                if (_Modaresan.img != null)
                {
                    string Deletimg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", _Modaresan.img);
                    if (File.Exists(Deletimg))
                    {
                        File.Delete(Deletimg);
                    }
                }
                _Modaresan.img = _Modaresan.Phone + Path.GetExtension(img.FileName);

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
        public async Task<IPagedList<T_Modaresan>> TeacherRank(string search, int pageid = 0)
        {
            IQueryable<T_Modaresan> result = _context.T_Modaresan.OrderBy(x => x.Rotbe_Modares);
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(s => s.NameFamily == search);
            }
            return result.ToList().ToPagedList(pageid, 1);
        }
        public async Task<int> UpdateAllModares(List<T_Modaresan> t_Modaresans)
        {
            _context.T_Modaresan.UpdateRange(t_Modaresans);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<bool> UniqPhoneModares(string phone)
        {
            var Uniq = _context.T_Modaresan.FirstOrDefaultAsync(x => x.Phone == phone);
            if (Uniq == null)
            {
                return true;
            }
            return false;
        }
        #region Teacher doreh
        public async Task<List<T_Doreh_Darkhasti>> GetDoreh_Teacher(int Teacherid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == Teacherid).ToList();

        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDoreh_Teacher(int Teacherid, string search, string sortOrder, int paegid = 0)
        {

            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == Teacherid);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(o => o.Date_Create);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(paegid, 1);

        }
        public async Task<List<T_Doreh_Darkhasti>> GetDoreh_Faal_Teacher(int teacherid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == teacherid && x.T_L_Vaziyat_Doreh_ID == 1).ToList();
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDoreh_Faal_Teacher(int teacherid, string search, string sortOrder, int paegid = 0)
        {

            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == teacherid && x.T_L_Vaziyat_Doreh_ID == 1);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(o => o.Date_Create);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDoreh_ghabil(int teacherid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == teacherid && x.T_L_Vaziyat_Doreh_ID == 2).ToList();
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDoreh_ghabil(int teacherid, string search, string sortOrder, int paegid = 0)
        {

            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == teacherid && x.T_L_Vaziyat_Doreh_ID == 2);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(o => o.Date_Create);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDoreh_Entezar(int teacherid, string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.Where(x => x.T_Modaresan_ID == teacherid && x.T_L_Vaziyat_Doreh_ID == 5);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                case "Mokhatb":
                    result = result.OrderBy(o => o.Date_Create);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_Mokhatebin).Where(s => s.T_Mokhatebin.Name_Sherkat == search);
            }
            return result.ToList().ToPagedList(paegid, 1);

        }
        public async Task<bool> SetMOdaresToDoreh(int Dorehid)
        {
            var result = _context.T_Doreh_Darkhasti.SingleOrDefault(x => x.ID_Doreh_Darkhasti == Dorehid);
            result.T_L_Vaziyat_Doreh_ID = 1;
            await UpdateDoreh(result);
            return true;
        }
        public async Task<List<int>> GetDorehID_Teacher(int Teacherid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_ModateDoreh_ID == Teacherid).Select(x => x.ID_Doreh_Darkhasti).ToList();
        }
        public async Task<bool> FinishedDoreh(int dorehid)
        {
            var result = _context.T_Doreh_Darkhasti.SingleOrDefault(x => x.ID_Doreh_Darkhasti == dorehid);
            result.T_L_Vaziyat_Doreh_ID = 2;
            await UpdateDoreh(result);
            return true;
        }
        #endregion
        #region Modaresan Sar Fasl
        public async Task<List<string>> GetT_Fasl_Dorehs(int onvanasli, int onvandoreh)
        {
            return _context.T_Fasl_Doreh.Where(x => x.T_L_OnvanDoreh_ID == onvandoreh && x.T_L_OnvanAsli_ID == onvanasli).Select(x => x.Mohtav).ToList();
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
        public async Task<List<T_Modaresan_Fild_Amozeshi>> GetModaresanFildAsli(int Teacherid)
        {
            return _context.T_Modaresan_Fild_Amozeshi.Where(x => x.T_Modaresan_ID == Teacherid).ToList();
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

        public async Task DeleteSherkat(int SherkatId)
        {
            var result = _context.T_Mokhatebin.SingleOrDefault(x => x.ID_Mokhatebin == SherkatId);
        }

        #region Doreh Mokhatbin
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabGhabl(int userid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_Mokhatebin_ID == userid && x.T_L_Vaziyat_Doreh_ID == 2).ToList();
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDorehMokhatabGhabl(int userid, string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.
                Where(x => x.T_Mokhatebin_ID == userid && x.T_L_Vaziyat_Doreh_ID == 2);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_L_OnvanDoreh).Where(s => s.T_L_OnvanDoreh.Titles_OnvanDoreh == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabFaal(int userid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_Mokhatebin_ID == userid && x.T_L_Vaziyat_Doreh_ID == 1).ToList();
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDorehMokhatabFaal(int userid, string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.
               Where(x => x.T_Mokhatebin_ID == userid && x.T_L_Vaziyat_Doreh_ID == 1);
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_L_OnvanDoreh).Where(s => s.T_L_OnvanDoreh.Titles_OnvanDoreh == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
        }
        public async Task<List<T_Doreh_Darkhasti>> GetDorehMokhatabPygiry(int userid)
        {
            return _context.T_Doreh_Darkhasti.Where(x => x.T_L_MokhatabanDoreh_ID == userid && x.T_L_Vaziyat_Doreh_ID == 3).ToList();
        }
        public async Task<IPagedList<T_Doreh_Darkhasti>> GetDorehMokhatabPygiry(int userid, string search, string sortOrder, int paegid = 0)
        {
            IQueryable<T_Doreh_Darkhasti> result = _context.T_Doreh_Darkhasti.
              Where(x => x.T_Mokhatebin_ID == userid && (x.T_L_Vaziyat_Doreh_ID == 3||x.T_L_Vaziyat_Doreh_ID==5));
            switch (sortOrder)
            {
                case "Doreh":
                    result = result.OrderBy(o => o.T_L_OnvanDoreh.Titles_OnvanDoreh);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Include(x => x.T_L_OnvanDoreh).Where(s => s.T_L_OnvanDoreh.Titles_OnvanDoreh == search);
            }
            return result.ToList().ToPagedList(paegid, 1);
        }
        #endregion

        #endregion

        #region Doreh
        public Task<int> AddDoreh()
        {
            throw new NotImplementedException();
        }
        public async Task<int> UpdateDoreh(T_Doreh_Darkhasti doreh_Darkhasti)
        {
            _context.T_Doreh_Darkhasti.Update(doreh_Darkhasti);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<int> Add_Pishnahad_Modares_Doreh(T_Pishnahad_Modares_Doreh t_Pishnahad_Modares_Doreh)
        {
            await _context.T_Pishnahad_Modares_Doreh.AddAsync(t_Pishnahad_Modares_Doreh);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<T_Doreh_Darkhasti> GetDoreh_Darkhasti(int DorehDakhastiId)
        {
            return _context.T_Doreh_Darkhasti.SingleOrDefault(x => x.ID_Doreh_Darkhasti == DorehDakhastiId);
        }
        public async Task<T_Pishnahad_Modares_Doreh> GetPishnahad_Modares_Doreh(int DorehDakhastiId)
        {
            return _context.T_Pishnahad_Modares_Doreh.SingleOrDefault(x => x.T_Doreh_Darkhasti_ID == DorehDakhastiId);
        }
        public async Task<bool> GetModaresPishnahadiForBind(int DrehId, string phone)
        {
            T_Modaresan Modares = _context.T_Modaresan.SingleOrDefault(d => d.Phone == phone);
            if (Modares != null)
            {
                T_Doreh_Darkhasti Doreh = _context.T_Doreh_Darkhasti.SingleOrDefault(x => x.ID_Doreh_Darkhasti == DrehId);
                Doreh.T_Modaresan_ID = Modares.ID_Modaresan;
                Doreh.T_L_Vaziyat_Doreh_ID = 5;
                _context.T_Doreh_Darkhasti.Update(Doreh);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
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
            return _context.T_Mokhatebin.SingleOrDefault(d => d.ID_Mokhatebin == MokhatinDoreh).Name_Sherkat;
        }
        public async Task<string> GetSatehkeyfi(int SatehkeyfiId)
        {
            return _context.T_L_SatheKeyfi_Modares.SingleOrDefault(x => x.ID_L_SatheKeyfi_Modares == SatehkeyfiId).Titles_SatheKeyfi_Modares;
        }
        public async Task<string> GetTeacherName(int TeacherId)
        {
            return _context.T_Modaresan.SingleOrDefault(x => x.ID_Modaresan == TeacherId).NameFamily;
        }
        public async Task<int> GetOnvanAsliByName(string name)
        {
            return _context.T_L_OnvanAsli.SingleOrDefault(x => x.Titles_OnvanAsli == name).ID_L_OnvanAsli;
        }
        public async Task<int> GetOnvanDorehByName(string name)
        {
            return _context.T_L_OnvanDoreh.SingleOrDefault(x => x.Titles_OnvanDoreh == name).ID_OnvanDoreh;
        }

        #endregion

        #region SarFasl 
        public async Task<int> Add_sar_Fasle_Doreh_Pishnahadi(List<T_Fasl_Doreh_Pishnahadi> t_Fasl_Doreh_Pishnahadi)
        {
            await _context.T_Fasl_Doreh_Pishnahadi.AddRangeAsync(t_Fasl_Doreh_Pishnahadi);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<List<string>> GetT_Fasl_Dorehs_Pishnahadi(int Dorehid)
        {
            return _context.T_Fasl_Doreh_Pishnahadi.Where(x => x.T_Doreh_Darkhasti_ID == Dorehid).Select(x => x.Mohtava).ToList();
        }
        public async Task<List<T_Fasl_Doreh_Pishnahadi>> GetT_Fasl_Dorehs_PishnahadiByDoreh(int Dorehid)
        {
            return _context.T_Fasl_Doreh_Pishnahadi.Where(x => x.T_Doreh_Darkhasti_ID == Dorehid).ToList();
        }
        public async Task<int> AddSarFasl(List<T_Fasl_Doreh> t_Fasl_Dorehs)
        {
            await _context.T_Fasl_Doreh.AddRangeAsync(t_Fasl_Dorehs);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<IPagedList<T_Fasl_Doreh>> GetT_Fasle_Dorehs(int pageid)
        {
            IQueryable<T_Fasl_Doreh> result = _context.T_Fasl_Doreh;
            return result.ToList().ToPagedList(pageid, 2);
        }
        public async Task<T_Fasl_Doreh> GetT_Fasl_DorehById(int id)
        {
            return _context.T_Fasl_Doreh.SingleOrDefault(x => x.ID_Fasl_Doreh == id);
        }
        public async Task<int> Update_T_Fasle_Doreh(T_Fasl_Doreh t_Fasl_Doreh)
        {
            _context.T_Fasl_Doreh.Update(t_Fasl_Doreh);
            await _context.SaveChangesAsync();
            return 0;
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

        #region Tools
        public async Task<string> GetDategeElmibyid(int id)
        {
            return _context.T_L_DaragehElmi.SingleOrDefault(x => x.ID_DaragehElmi == id).Titles_DaragehElmi;
        }
        public async Task<string> GetMaghtaeTahsilibyid(int id)
        {
            return _context.T_L_MaghtaeTahsili.SingleOrDefault(x => x.ID_MaghtaeTahsili == id).Titles_MaghtaeTahsili;
        }
        public async Task<string> GetReshtehTahsilibyid(int id)
        {
            return _context.T_L_ReshtehTahsili.SingleOrDefault(x => x.ID_ReshtehTahsili == id).Titles_ReshtehTahsili;
        }
        public async Task<string> GetFildAslibyid(int id)
        {
            return _context.T_L_FildAsli.SingleOrDefault(x => x.ID_FildAsli == id).Titles_FildAsli;
        }
        public async Task<string> GetOnvanDorehbyid(int id)
        {
            return _context.T_L_OnvanDoreh.SingleOrDefault(x => x.ID_OnvanDoreh == id).Titles_OnvanDoreh;
        }
        public async Task<string> GetSematbyid(int id)
        {
            return _context.T_L_Semat.SingleOrDefault(x => x.ID_Semat == id).Titles_Semat;
        }
        public async Task<string> GetOstansbyid(int id)
        {
            return _context.T_L_Ostan.SingleOrDefault(x => x.ID_Ostan == id).Titles_Ostan;
        }
        public async Task<string> GetOnvanAslisbyid(int id)
        {
            return _context.T_L_OnvanAsli.SingleOrDefault(x => x.ID_L_OnvanAsli == id).Titles_OnvanAsli;
        }
        public async Task<string> GetMediaAmozeshisbyid(int id)
        {
            return _context.T_L_MediaAmozeshi.SingleOrDefault(x => x.ID_MediaAmozeshi == id).Titles_MediaAmozeshi;
        }
        public async Task<string> GetRaveshAmozeshisbyid(int id)
        {
            return _context.T_L_RaveshAmozeshi.SingleOrDefault(x => x.ID_L_RaveshAmozeshi == id).Titles_RaveshAmozeshi;
        }
        public async Task<string> GetModateDorehsbyid(int id)
        {
            return _context.T_L_ModateDoreh.SingleOrDefault(x => x.ID_ModateDoreh == id).Titles_ModateDoreh;
        }
        public async Task<string> GetMokhatabanDorehsbyid(int id)
        {
            return _context.T_L_MokhatabanDoreh.SingleOrDefault(x => x.ID_MokhatabanDoreh == id).Titles_MokhatabanDoreh;
        }
        public async Task<string> GetSatheKeyfi_Modaresbyid(int id)
        {
            return _context.T_L_SatheKeyfi_Modares.SingleOrDefault(x => x.ID_L_SatheKeyfi_Modares == id).Titles_SatheKeyfi_Modares;
        }
        public async Task<int> Get_RaveshAmozeshiByName(string name)
        {
            return _context.T_L_RaveshAmozeshi.SingleOrDefault(x => x.Titles_RaveshAmozeshi == name).ID_L_RaveshAmozeshi;
        }
        public async Task<string> GetVaziatDorehbyid(int id)
        {
            return _context.T_L_Vaziyat_Doreh.SingleOrDefault(x => x.ID_L_Vaziyat_Doreh == id).Titles_Vaziyat_Doreh;
        }
        #endregion

        #region Adimns
        public async Task<Tuple<List<T_Admin>, int>> GetAdminsList(int pageid = 0)
        {
            IQueryable<T_Admin> result = _context.T_Admins.Where(x => x.Admin == true);

            int skip = (pageid - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Admin> query = result.Skip(skip).Take(4).ToList();

            return Tuple.Create(query, pageCount);
        }
        public async Task<IPagedList<T_Admin>> GetAdminsList(string search, string soreOrder, int pageid = 0)
        {
            IQueryable<T_Admin> result = _context.T_Admins.Where(x => x.Admin == true);
            switch (soreOrder)
            {
                case "username":
                    result = result.OrderBy(o => o.UserName);
                    break;
                case "phone":
                    result = result.OrderBy(o => o.Phone);
                    break;
                case "name":
                    result = result.OrderBy(o => o.Name);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(s => s.UserName == search);
            }
            return result.ToList().ToPagedList(pageid, 1);
        }
        public async Task<T_Admin> GetAdmin(string username, string password)
        {
            return _context.T_Admins.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }
        public async Task<T_Admin> GetAdmin(string username)
        {
            return _context.T_Admins.SingleOrDefault(x => x.UserName == username);
        }
        public async Task<Tuple<List<T_Admin>, int>> GetUsersList(int pageid = 0)
        {
            IQueryable<T_Admin> result = _context.T_Admins.Where(x => x.User == true);
            int skip = (pageid - 1) * 4;
            int pageCount = result.Count() / 4;
            List<T_Admin> query = result.Skip(skip).Take(4).ToList();
            return Tuple.Create(query, pageCount);
        }
        public async Task<IPagedList<T_Admin>> GetUsersList(string search, string soreOrder, int pageid = 0)
        {
            IQueryable<T_Admin> result = _context.T_Admins.Where(x => x.User == true);
            switch (soreOrder)
            {
                case "username":
                    result = result.OrderBy(o => o.UserName);
                    break;
                case "phone":
                    result = result.OrderBy(o => o.Phone);
                    break;
                case "name":
                    result = result.OrderBy(o => o.Name);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(s => s.UserName == search);
            }
            return result.ToList().ToPagedList(pageid, 1);
        }
        public async Task<int> AddAdmin(T_Admin t_Admin, IFormFile img)
        {
            if (img != null)
            {
                t_Admin.img = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(img.FileName);
                string ImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Admins", t_Admin.img);
                using (var Stream = new FileStream(ImgPath, FileMode.Create))
                {
                    img.CopyTo(Stream);
                }
            }
            else
            {
                t_Admin.img = "defalut.jpg";
            }
            await _context.T_Admins.AddAsync(t_Admin);
            await _context.SaveChangesAsync();
            return 0;

        }
        public async Task<int> EditAdmin(T_Admin t_Admin, IFormFile img)
        {
            if (img != null)
            {
                if (t_Admin.img != null)
                {
                    string Deletimg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Admins", t_Admin.img);
                    if (File.Exists(Deletimg))
                    {
                        File.Delete(Deletimg);
                    }
                }
                t_Admin.img = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(img.FileName);

                string ImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Admins", t_Admin.img);
                using (var Stream = new FileStream(ImgPath, FileMode.Create))
                {
                    img.CopyTo(Stream);
                }
            }
            _context.T_Admins.Update(t_Admin);
            await _context.SaveChangesAsync();
            return 0;
        }
        public async Task<int> RemoveAdmin(string username)
        {
            var t_Admin = _context.T_Admins.SingleOrDefault(x => x.UserName == username);
            if (t_Admin != null)
            {
                if (t_Admin.img != null)
                {
                    string Deletimg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Admins", t_Admin.img);
                    if (File.Exists(Deletimg))
                    {
                        File.Delete(Deletimg);
                    }
                }
                _context.T_Admins.Remove(t_Admin);
                await _context.SaveChangesAsync();
                return 0;
            }
            return 1;
        }

        #endregion

        #region NazarSanji
        public async Task<int> AddNazasanji(T_Nazarsanji t_Nazarsanji)
        {
            await _context.T_Nazarsanji.AddAsync(t_Nazarsanji);
            await _context.SaveChangesAsync();
            return 0;
        }


        public async Task<T_Nazarsanji> GetNazarsanji(int dorehId)
        {
            return _context.T_Nazarsanji.SingleOrDefault(x => x.T_Doreh_Darkhasti_ID == dorehId);
        }
        #endregion



        #region Testing

        public async Task<IPagedList<T_Modaresan>> GetMOdaresanTest(string q = "", string sortOrder = "", int page = 1)
        {
            IQueryable<T_Modaresan> result = _context.T_Modaresan;

            result = result.OrderByDescending(c => c.DateCreate);
            switch (sortOrder)
            {
                case "nameFamily":
                    result = result.OrderBy(x => x.NameFamily);
                    break;
                case "Phone":
                    result = result.OrderBy(x => x.Phone);
                    break;
                case "Email":
                    result = result.OrderByDescending(x => x.Email);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(q))
            {
                result = result.Where(x => x.NameFamily.Contains(q));
            }

            return result.ToList().ToPagedList(page, 1);
        }
        #endregion

        #region Chart
        public async Task<Tuple<List<string>, List<int>>> GetDorehByMonthForChart()
        {

            var calendar = new PersianCalendar();
            var year = new DateTime(calendar.GetYear(DateTime.Now), calendar.GetMonth(DateTime.Now), calendar.GetDayOfMonth(DateTime.Now));
            var model = _context.T_Doreh_Darkhasti.ToList();
            List<int> dateTimes = new List<int>();
            List<string> months = new List<string>() { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            List<int> Numbers = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                dateTimes.Add(i);
            }
            var group = model.Where(x => x.Date_Create.Value.Year == year.Year).GroupBy(x => x.Date_Create.Value.Month);

            var joinde1 = from c in dateTimes
                          join p in @group on c equals p.Key into ps
                          from p in ps.DefaultIfEmpty()
                          select p;

            foreach (var item in joinde1)
            {
                if (item == null)
                {
                    Numbers.Add(0);
                }
                else
                {
                    Numbers.Add(item.Count());
                }
            }
            return Tuple.Create(months, Numbers);

        }


        public async Task<Tuple<List<string>, List<int>>> GetUserByMonthForChart()
        {

            var calendar = new PersianCalendar();
            var year = new DateTime(calendar.GetYear(DateTime.Now), calendar.GetMonth(DateTime.Now), calendar.GetDayOfMonth(DateTime.Now));
            var model = _context.T_Modaresan.ToList();
            List<int> dateTimes = new List<int>();
            List<string> months = new List<string>() { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            List<int> Numbers = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                dateTimes.Add(i);
            }
            var group = model.Where(s => s.DateCreate.Value.Year == year.Year).GroupBy(x => x.DateCreate.Value.Month);

            var joinde1 = from c in dateTimes
                          join p in @group on c equals p.Key into ps
                          from p in ps.DefaultIfEmpty()
                          select p;

            foreach (var item in joinde1)
            {
                if (item == null)
                {
                    Numbers.Add(0);
                }
                else
                {
                    Numbers.Add(item.Count());
                }

            }
            //for (int i = 1; i <= Month_shamsi; i++)
            //{
            //    var sort = model.Where(xx => xx.DateCreate.Value.Month.Equals(i)).Count();
            //    Numbers.Add(sort);
            //    dateTimes.Add(i);
            //}
            return Tuple.Create(months, Numbers);
        }
        #endregion

        #region ConvertDate
        public async Task ConvertDateToShamsimodaresan()
        {
            var calendar = new PersianCalendar();
            var convertDime = _context.T_Modaresan.ToList();
            foreach (var item in convertDime)
            {
                var converting = item.DateCreate.Value;
                item.DateCreate = new DateTime(calendar.GetYear(converting), calendar.GetMonth(converting), calendar.GetDayOfMonth(converting));
            }
            await _context.SaveChangesAsync();
        }

        public async Task ConvertDateToShamsiDoreh()
        {
            var calendar = new PersianCalendar();
            var convertDime = _context.T_Doreh_Darkhasti.ToList();
            foreach (var item in convertDime)
            {
                var converting_cerate = item.Date_Create.Value;
                var convert_Az_pi = item.Date_Az_Pishnahad.Value;
                var convert_ta_pi = item.Date_Ta_Pishnahad.Value;
                item.Date_Create = new DateTime(calendar.GetYear(converting_cerate), calendar.GetMonth(converting_cerate), calendar.GetDayOfMonth(converting_cerate));
                item.Date_Az_Pishnahad = new DateTime(calendar.GetYear(convert_Az_pi), calendar.GetMonth(convert_Az_pi), calendar.GetDayOfMonth(convert_Az_pi));
                item.Date_Ta_Pishnahad = new DateTime(calendar.GetYear(convert_ta_pi), calendar.GetMonth(convert_ta_pi), calendar.GetDayOfMonth(convert_ta_pi));
            }
            await _context.SaveChangesAsync();
        }

        public async Task<DateTime> ConvertDateToShamsi(DateTime dateTime)
        {
            var calendar = new PersianCalendar();
            var converting = dateTime;
            DateTime FinalDate = new DateTime(calendar.GetYear(converting), calendar.GetMonth(converting), calendar.GetDayOfMonth(converting));
            return FinalDate;
        }
        #endregion




    }
}
