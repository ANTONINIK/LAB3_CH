using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB3_CH
{
    delegate TKey KeySelector<TKey> (ResearchTeam rt);
    class ResearchTeamCollection<TKey>
    {
        private Dictionary<TKey, ResearchTeam> teams;
        private KeySelector<TKey> KeySelector;

        public ResearchTeamCollection(KeySelector<TKey> keySelector)
        {
            teams = new Dictionary<TKey, ResearchTeam>();
            KeySelector = keySelector;
        }
        public void AddDefaults()
        {
            ResearchTeam team = new ResearchTeam();
            teams.Add(KeySelector(team), team);
        }
        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            foreach (ResearchTeam team in researchTeams)
            {
                teams.Add(KeySelector(team), team);
            }
        }
        public override string ToString()
        {
            string str = $"Здесь содержится {teams.Count} ResearchTeams: \n";
            foreach (ResearchTeam info in teams.Values)
            {
                str += info.ToString();
            }
            return str;
        }

        public virtual string ToShortString()
        {
            string str = $"Здесь содержится {teams.Count} ResearchTeams: \n";
            foreach (ResearchTeam info in teams.Values)
            {
                str += info.ToShortString();
            }
            return str;
        }
        public DateTime GetLastPaper
        {
            get
            {
                if (teams.Count > 0) return teams.Values.Max(rest => rest.LastPaper());
                return new DateTime();

            }
        }
        public IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> TimeFrameGroup
        {
            get
            {
                return teams.GroupBy(obj => obj.Value.Duration);
            }
        }
        public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameValue(TimeFrame value)
        {
            return teams.Where(obj => obj.Value.Duration == value);
        }
    }
}
