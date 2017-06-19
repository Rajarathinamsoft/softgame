using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SoftGameEFDataModel;
using SoftGameEFDataModel.Entities;

namespace SoftGameService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SoftGameQueryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SoftGameQueryService.svc or SoftGameQueryService.svc.cs at the Solution Explorer and start debugging.
    public class SoftGameQueryService : ISoftGameQueryService
    {
        public List<GamesInfo> GetAllGames()
        {
            List<GamesInfo> gamelst = new List<GamesInfo>();
            SoftcrylicEntities tstDb = new SoftcrylicEntities();
            var lstGames = from k in tstDb.GamesInfoes select k;
            foreach (var item in lstGames)
            {
                GamesInfo usr = new GamesInfo();
                usr.GameId = item.GameId;
                usr.GameName = item.GameName;
                gamelst.Add(usr);

            }
            return gamelst;
        }

        public List<GamesInfo> GetRandomUser()
        {
            List<GamesInfo> gamelst = new List<GamesInfo>();
            SoftcrylicEntities tstDb = new SoftcrylicEntities();
            var lstGames = (from k in tstDb.GamesInfoes select k).OrderBy(x => Guid.NewGuid()).Take(1).ToList();            
            foreach (var item in lstGames)
            {
                GamesInfo usr = new GamesInfo();
                usr.GameId = item.GameId;
                usr.GameName = item.GameName;
                gamelst.Add(usr);

            }
            return gamelst;
        }
    }
}
