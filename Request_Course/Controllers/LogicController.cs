using Microsoft.AspNetCore.Mvc;
using Request_Course.Serivces.Interface;

namespace Request_Course.Controllers
{
    public class LogicController : Controller
    {
        private IRepository _services;
        public LogicController(IRepository repository)
        {
            _services = repository;
        }

        public async Task<IActionResult> ComputeModaresByModaresId(int ID_Modares)
        {
            var TeacherOfDoreh = await _services.GetDorehID_Teacher(ID_Modares);

            double meanReall = 0;
            int Counter = 0;
            foreach (var item in TeacherOfDoreh)
            {
                var nazar = await _services.GetNazarsanji(item);
                
                if (nazar != null)
                {
                    Counter += 1;
                    int[] inpu = new int[4];
                    int[] Zarib = new int[4];
                    Zarib[0] = 1;
                    Zarib[1] = 1;
                    Zarib[2] = 1;
                    Zarib[3] = 1;
                    inpu[0] = nazar.Num_Tasalot.Value;
                    inpu[1] = nazar.Num_Roayat_Sarfasl.Value;
                    inpu[2] = nazar.Num_Roayat_Nazm.Value;
                    inpu[3] = nazar.Num_TamoolBaFaragir.Value;
                    meanReall += await weightedMean(inpu, Zarib, 4);
                }

            }
            meanReall = meanReall / Counter;
            meanReall = meanReall * 20 / 5;
            var Modares = await _services.GetModaresan(ID_Modares);
            Modares.Nomreh_Keyfi = ((decimal)meanReall);
            Modares.Avg_Nomreh_Tadris = ((decimal)meanReall);
            if (meanReall >= 15)
            {
                Modares.Sathe_Keyfi = 4;
            }
            else if (meanReall >= 10)
            {
                Modares.Sathe_Keyfi = 3;
            }
            else if (meanReall >= 5)
            {
                Modares.Sathe_Keyfi = 2;
            }
            else if (meanReall >= 0)
            {
                Modares.Sathe_Keyfi = 1;
            }
            await ComputeRetbe();
            return View();
        }


        public async Task<IActionResult> ComputeModaresByDorehid(int DorehId)
        {

            var doreh = await _services.GetDoreh_Darkhasti(DorehId);
            double meanReall = 0;
            var nazar = await _services.GetNazarsanji(DorehId);
            if (nazar != null)
            {
                int[] inpu = new int[4];
                int[] Zarib = new int[4];
                Zarib[0] = 1;
                Zarib[1] = 1;
                Zarib[2] = 1;
                Zarib[3] = 1;
                inpu[0] = nazar.Num_Tasalot.Value;
                inpu[1] = nazar.Num_Roayat_Sarfasl.Value;
                inpu[2] = nazar.Num_Roayat_Nazm.Value;
                inpu[3] = nazar.Num_TamoolBaFaragir.Value;
                meanReall += await weightedMean(inpu, Zarib, 4);
            }

            meanReall = meanReall * 20 / 5;
            var Modares = await _services.GetModaresan(doreh.T_Modaresan_ID.Value);
            if (Modares.Nomreh_Keyfi_float!=null)
            {
                var nomreh_keyfi_temp = Modares.Nomreh_Keyfi_float;
                var nomreh_Tadris_temp = Modares.Nomreh_Keyfi_float;
                Modares.Nomreh_Keyfi_float = (nomreh_keyfi_temp + (float)meanReall)/2;
                Modares.Avg_Nomreh_Tadris_float =(nomreh_Tadris_temp + (float)meanReall)/2;
            }
            else
            {
                Modares.Nomreh_Keyfi_float = (float)meanReall;
                Modares.Avg_Nomreh_Tadris_float = (float)meanReall;
            }
            
            if (Modares.Nomreh_Keyfi_float >= 15)
            {
                Modares.Sathe_Keyfi = 4;
            }
            else if (Modares.Nomreh_Keyfi_float >= 10)
            {
                Modares.Sathe_Keyfi = 3;
            }
            else if (Modares.Nomreh_Keyfi_float >= 5)
            {
                Modares.Sathe_Keyfi = 2;
            }
            else if (Modares.Nomreh_Keyfi_float >= 0)
            {
                Modares.Sathe_Keyfi = 1;
            }
            var phone =_services.GetMokhatebinById(doreh.T_Mokhatebin_ID.Value).Result.Phone;
             await _services.UpdateModaresan(Modares);
             await  ComputeRetbe();
            return RedirectToAction("ok", "Mokhatab", new { phone =phone});

        }



        public async Task<IActionResult> ComputeRetbe()
        {
            var Modares = await _services.GetModaresan();
            int rank = 1;
            float temp_nomreh=0;
            var ModaresOreder=Modares.OrderByDescending(x => x.Avg_Nomreh_Tadris_float).ToList();
            foreach (var item in ModaresOreder)
            {
                if (item.Avg_Nomreh_Tadris_float==null)
                {
                    item.Rotbe_Modares = rank;
                    continue;
                }
                if(temp_nomreh != item.Avg_Nomreh_Tadris_float)
                {
                    item.Rotbe_Modares = rank;
                    temp_nomreh=item.Avg_Nomreh_Tadris_float.Value;
                    rank++;
                }
                else
                {
                    rank--;
                    item.Rotbe_Modares = rank;
                    rank++; 
                }

            }
           await _services.UpdateAllModares(ModaresOreder);
            return null;
        }


        public async Task<double> weightedMean(int[] X, int[] W, int n = 4)
        {
            int sum = 0, numWeight = 0;

            for (int i = 0; i < n; i++)
            {
                numWeight = numWeight + X[i] * W[i];
                sum = sum + W[i];
            }

            return (float)(numWeight) / sum;
        }
    }
}
