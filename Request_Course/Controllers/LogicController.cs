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

        public async Task<IActionResult> ComputeModares(int ID_Modares)
        {
            var TeacherOfDoreh = await _services.GetDorehID_Teacher(ID_Modares);
            
            double meanReall = 0;
            int Counter = 0;
            foreach (var item in TeacherOfDoreh)
            {
                var nazar = await _services.GetNazarsanji(item);
                if (nazar!=null)
                {
                    Counter += 1;
                    int[] inpu = new int[4];
                    int[] Zarib = new int[4];
                    Zarib[0] = 3;
                    Zarib[1] = 1;
                    Zarib[2] = 1;
                    Zarib[3] = 2;
                    inpu[0] = nazar.Num_Tasalot.Value;
                    inpu[1] = nazar.Num_Roayat_Sarfasl.Value;
                    inpu[2] = nazar.Num_Roayat_Nazm.Value;
                    inpu[3] = nazar.Num_TamoolBaFaragir.Value;
                    meanReall += await weightedMean(inpu, Zarib, 4);
                }
                
            }
            meanReall=meanReall/Counter;
            meanReall=meanReall * 20 / 5;
           var Modares= await _services.GetModaresan(ID_Modares);
            Modares.Nomreh_Keyfi = ((decimal)meanReall);
            Modares.Avg_Nomreh_Tadris= ((decimal)meanReall);
            if (meanReall>=15)
            {
                Modares.Sathe_Keyfi = 4;
            }
            else if (meanReall>=10)
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


            return View();
        }



        public async Task<IActionResult> ComputeRetbe()
        {
            var Modares= await _services.GetModaresan();
            int rank = 1;
            foreach (var item in Modares)
            {
                var maximum = Modares.Max(x => x.Avg_Nomreh_Tadris);
                var ModaresTemp= Modares.FirstOrDefault(x=>x.Avg_Nomreh_Tadris==maximum);
                ModaresTemp.Rotbe_Modares = rank;
                await _services.UpdateModaresan(ModaresTemp);
                Modares.Remove(ModaresTemp);
                rank++;
            }
            return View();
        }


        public async Task<double> weightedMean(int[] X, int[] W, int n=4)
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
