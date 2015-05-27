using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanPlayWPF.KanData
{
    enum KanAPIDumpState
    {
        Normal,
        Output,
        Ignore,
    }
    internal class KanAPIDistributor
    {
        public KanAPIDistributor(string api, KanAPIDumpState state, Func<dynamic, bool> f)
        {
            apiStr = api;
            dumpState = state;
            func = f;
        }

        public string apiStr {get; set; }
        public KanAPIDumpState dumpState {get; set; }
        public Func<dynamic, bool> func {get; set; }
    }

    public class KanDataConnector
    {
        private List<KanAPIDistributor> _apiDistributors = new List<KanAPIDistributor>();

        private static KanDataConnector _instance = null;
        private KanDataConnector() 
        {
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_start2", 
                KanAPIDumpState.Normal, 
                start2_parse));
            
            _apiDistributors.Add(new KanAPIDistributor(
                "/kcsapi/api_req_combined_battle/battle", 
                KanAPIDumpState.Output,
                req_combined_battle_battle_parse));

        }
        public static KanDataConnector Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KanDataConnector();
                }
                return _instance;
            }
        }

        private KanAPIDistributor findDistributorFromApi(string apiStr)
        {
            foreach(KanAPIDistributor item in _apiDistributors)
            {
                if (item.apiStr == apiStr)
                {
                    return item;
                }
            }
            return null;
        }

        //
        private string _pathAndQuery;
        private string _requestBody;
        private string _responseBody;
        private KanReqData _req = new KanReqData();

        private void DAPILog()
        {
            // logout
        }

        public bool Parse(string pathAndQuery, string requestBody, string responseBody)
        {
            _pathAndQuery = pathAndQuery;
            _requestBody = requestBody;
            _responseBody = responseBody;

            var json = DynamicJson.Parse(responseBody);
            if (json.api_result != 1)
            {
                DAPILog();
            }

            var jobj = json.api_data;

            _req.ReadFromString(_pathAndQuery, _requestBody);
            
            KanAPIDistributor distributor = findDistributorFromApi(_pathAndQuery);
            if (distributor == null)
            {
                DAPILog();
                return false;
            }

            if (distributor.dumpState == KanAPIDumpState.Ignore)
            {
                return true;
            }

            if (distributor.dumpState == KanAPIDumpState.Output)
            {
                DAPILog();
            }

            return distributor.func(jobj);
        }
                
        bool start2_parse(dynamic jobj)
        {
//            pksd->start2data.ReadFromJObj(jobj);
//            Console.WriteLine(jobj.api_mst_ship[0].api_id);
            return true;
        }
        bool req_combined_battle_battle_parse(dynamic jobj)
        {
//            pksd->battledata.ReadFromJObj(jobj);

//            pksd->enemyhpdata = updateBattle(pksd->battledata, KANBATTLETYPE_COMBINED_DAY);
//            Console.WriteLine(jobj.api_deck_id);
            return true;
        }
    }
}
