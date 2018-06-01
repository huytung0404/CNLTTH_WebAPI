using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class LOAISACHClient
    {
        public IEnumerable<LOAISACHModel> HienThiLOAISACH()
        {
            IEnumerable<LOAISACHModel> LOAISACHList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LOAISACH").Result;
            LOAISACHList = response.Content.ReadAsAsync<IEnumerable<LOAISACHModel>>().Result;

            return LOAISACHList;
        }
        public int ThemMoiLOAISACH(LOAISACHModel LOAISACHModels)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("LOAISACH", LOAISACHModels).Result;
            return 1;
        }
        public int XoaLOAISACH(int MaLoaiSach)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("LOAISACH/" + MaLoaiSach).Result;
            return 1;
        }
        public bool SuaLOAISACH(LOAISACHModel LOAISACHModels)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("LOAISACH/" + LOAISACHModels.MaLoaiSach, LOAISACHModels).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public LOAISACHModel TimKiemLOAISACHTheoMa(int MaLoaiSach)
        {
            LOAISACHModel LOAISACHList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LOAISACH/" + MaLoaiSach).Result;
            LOAISACHList = response.Content.ReadAsAsync<LOAISACHModel>().Result;
            return LOAISACHList;
        }
    }
}
