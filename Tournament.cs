using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace SwordJet
{
    [Serializable]
    public class Tournament
    {
        public enum TournamentStage { REGISTRATION = 0, POOLFIGHTS, TIEBREAKERS, ELIMINATIONS, FINALS, CLOSED }
        public enum PoolType { FIXEDROUNDS = 0, ROUNDROBIN = 1, SWISSPAIRS = 2 }
        public enum EliminationType { RANDOMISED = 0, MATCHED = 1 }

        public string name;
        public int numberOfRounds;
        public int numberOfPools;
        public int fightTimeMinutes;
        public TournamentStage stage = TournamentStage.REGISTRATION;
        public PoolType poolType = PoolType.FIXEDROUNDS;
        public EliminationType eliminationType = EliminationType.RANDOMISED;
        public int eliminationSize;
        public bool matchedEliminations;
        public int winPoints;
        public int drawPoints;
        public int lossPoints;
        public int? doubleThreshold;

        public List<Club> clubs = new List<Club>();
        public List<Fighter> fighters = new List<Fighter>();
        public List<Pool> pools = new List<Pool>();
        public Pool tieBreakers = null;
        public List<Pool> eliminations = new List<Pool>();
        public List<Fight> finals = new List<Fight>();

        public Tournament()
        {
            name = "Tournament - " + DateTime.Today.ToString("dd MM yyyy");
            numberOfPools = 1;
            numberOfRounds = 1;
            fightTimeMinutes = 1;
            eliminationSize = 8;
            matchedEliminations = false;
            winPoints = 3;
            drawPoints = 2;
            lossPoints = 1;
            doubleThreshold = null;
        }

        public int GetNextFighterID()
        {
            if (fighters.Count > 0)
            {
                return fighters.OrderBy(o => o.id).Last().id + 1;
            }
            return 1;
        }

        public Fighter GetFighterByID(int id)
        {
            foreach (Fighter f in fighters)
            {
                if (f.id == id) return f;
            }

            return null;
        }

        public Fight GetFightByID(Guid id)
        {
            foreach (Pool p in pools)
            {
                foreach (List<Fight> r in p.rounds)
                {
                    foreach (Fight f in r)
                    {
                        if (f.fightID == id) return f;
                    }
                }
            }

            foreach (Pool p in eliminations)
            {
                foreach (List<Fight> r in p.rounds)
                {
                    foreach (Fight f in r)
                    {
                        if (f.fightID == id) return f;
                    }
                }
            }

            if (tieBreakers != null)
            {
                foreach (List<Fight> r in tieBreakers.rounds)
                {
                    foreach (Fight f in r)
                    {
                        if (f.fightID == id) return f;
                    }
                }
            }

            foreach (Fight f in finals)
            {
                if (f.fightID == id) return f;
            }

            return null;
        }

        public List<Fight> GetPoolFightsByFighter(int fighterId)
        {
            List<Fight> fights = new List<Fight>();

            foreach (Pool p in pools)
            {
                foreach (List<Fight> round in p.rounds)
                {
                    foreach (Fight f in round)
                    {
                        if (f.fighterA == fighterId || f.fighterB == fighterId) fights.Add(f);
                    }
                }
            }

            return fights;
        }

        public bool HasFightHappenedAlready(Fight f)
        {
            return (FindFight(f) != null);
        }

        public Fight FindFight(Fight f)
        {
            foreach (Pool p in pools)
            {
                Fight fight = p.FindFight(f);
                if (fight != null) return fight;
            }

            return null;
        }

        public DataView GetFightersDataView()
        {
            DataTable table = new DataTable();

            if (stage == TournamentStage.CLOSED)
            {
                table.Columns.Add("FinishingRank", typeof(int));
            }

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Pool", typeof(string));
            table.Columns.Add("PoolScore", typeof(int));
            table.Columns.Add("PoolDoubles", typeof(int));
            table.Columns.Add("PoolBuchholz", typeof(double));
            table.Columns.Add("HitScore", typeof(int));

            foreach (Pool p in eliminations)
            {
                table.Columns.Add(p.name, typeof(string));
            }

            if (finals.Count > 0)
            {
                table.Columns.Add("Finals", typeof(string));
            }

            table.Columns.Add("TieBreakerScore", typeof(int));
            table.Columns.Add("ElimSort", typeof(int));

            foreach (Fighter fighter in fighters)
            {
                DataRow row = table.NewRow();

                if (stage == Tournament.TournamentStage.CLOSED)
                {
                    int rank = GetFighterFinalRank(fighter);
                    row["FinishingRank"] = rank;
                }


                row["ID"] = fighter.id;
                row["Name"] = fighter.name;

                string poolname = "";
                foreach (Pool p in pools)
                {
                    if (p.fighters.Contains(fighter.id)) poolname = p.name;
                }
                row["Pool"] = poolname;

                row["PoolScore"] = GetFighterScore(fighter);

                row["PoolDoubles"] = GetFighterDoubles(fighter);

                row["PoolBuchholz"] = GetFighterBuchholzScore(fighter);

                row["HitScore"] = GetFighterHitScore(fighter);

                row["TieBreakerScore"] = GetFighterTieBreakerScore(fighter);

                Dictionary<string, string> elimResults = GetFighterEliminationResults(fighter);
                int elimSort = 0;

                for (int i = 0; i < eliminations.Count; i++)
                {
                    Pool p = eliminations[i];
                    string r = elimResults[p.name];
                    row[p.name] = r;
                    elimSort += ((r == "WIN") ? 2 * (i + 1) : ((r == "LOSS") ? 1 * (i + 1) : 0));
                }

                if (finals.Count > 0)
                {
                    string r = GetFighterFinalsResult(fighter);
                    row["Finals"] = r;
                    elimSort += ((r == "WIN") ? 2 * eliminations.Count : ((r == "LOSS") ? 1 * eliminations.Count : 0));
                }

                row["ElimSort"] = elimSort;
                table.Rows.Add(row);
            }

            DataView dv = table.DefaultView;
            dv.Sort = "ElimSort DESC, PoolScore DESC, PoolDoubles ASC, HitScore DESC, PoolBuchholz DESC, TieBreakerScore DESC";
            if (stage == TournamentStage.CLOSED)
            {
                dv.Sort = "FinishingRank ASC, " + dv.Sort;
            }

            return dv;
        }

        public int GetFighterScore(Fighter fighter)
        {
            int score = 0;

            foreach (Pool pool in pools)
            {
                if (pool.fighters.Contains(fighter.id))
                {
                    foreach (List<Fight> round in pool.rounds)
                    {
                        foreach (Fight fight in round)
                        {
                            Fight.FightResult result = Fight.FightResult.PENDING;

                            if (fight.fighterA == fighter.id)
                            {
                                result = fight.fighterAResult;
                            }
                            else if (fight.fighterB == fighter.id && !fight.oddFight)
                            {
                                result = fight.fighterBResult;
                            }

                            if (result != Fight.FightResult.PENDING)
                            {
                                int gainedScore = 0;

                                switch (result)
                                {
                                    case Fight.FightResult.WIN: gainedScore = winPoints; break;
                                    case Fight.FightResult.LOSS: gainedScore = lossPoints; break;
                                    case Fight.FightResult.DRAW: gainedScore = drawPoints; break;
                                    case Fight.FightResult.DQ: gainedScore = 0; break;
                                }

                                score += gainedScore;
                                break;
                            }
                        }
                    }
                }
            }

            return score;
        }

        public int GetFighterDoubles(Fighter fighter)
        {
            int doubles = 0;

            foreach (Pool pool in pools)
            {
                if (pool.fighters.Contains(fighter.id))
                {
                    foreach (List<Fight> round in pool.rounds)
                    {
                        foreach (Fight fight in round)
                        {
                            Fight.FightResult result = Fight.FightResult.PENDING;

                            if (fight.fighterA == fighter.id)
                            {
                                result = fight.fighterAResult;
                            }
                            else if (fight.fighterB == fighter.id && !fight.oddFight)
                            {
                                result = fight.fighterBResult;
                            }

                            if (result != Fight.FightResult.PENDING)
                            {
                                doubles += fight.doubleCount;
                                break;
                            }
                        }
                    }
                }
            }

            return doubles;
        }

        public int GetFighterHitScore(Fighter fighter)
        {
            int given = 0;
            int received = 0;

            foreach (Pool pool in pools)
            {
                if (pool.fighters.Contains(fighter.id))
                {
                    foreach (List<Fight> round in pool.rounds)
                    {
                        foreach (Fight fight in round)
                        {
                            foreach (Exchange exch in fight.exchanges)
                            {
                                if (fight.fighterA == fighter.id)
                                {
                                    given += exch.fighterAScore;
                                    received += exch.fighterBScore;
                                }
                                else if (fight.fighterB == fighter.id && !fight.oddFight)
                                {
                                    given += exch.fighterBScore;
                                    received += exch.fighterAScore;
                                }
                            }
                        }
                    }
                }
            }

            return given - received;
        }

        public double GetFighterBuchholzScore(Fighter fighter)
        {
            int buchholz = 0;
            int fightCount = 0;

            foreach (Pool pool in pools)
            {
                if (pool.fighters.Contains(fighter.id))
                {
                    foreach (List<Fight> round in pool.rounds)
                    {
                        foreach (Fight fight in round)
                        {
                            if (!fight.oddFight)
                            {
                                Fight.FightResult result = Fight.FightResult.PENDING;

                                if (fight.fighterA == fighter.id)
                                {
                                    result = fight.fighterAResult;
                                }
                                else if (fight.fighterB == fighter.id && !fight.oddFight)
                                {
                                    result = fight.fighterBResult;
                                }

                                if (result != Fight.FightResult.PENDING)
                                {
                                    Fighter opponent = null;
                                    if (fight.fighterA == fighter.id) opponent = GetFighterByID(fight.fighterB);
                                    else opponent = GetFighterByID(fight.fighterA);

                                    int opponentScore = GetFighterScore(opponent);
                                    int opponentDoubles = GetFighterDoubles(opponent);

                                    buchholz += Math.Max(0,(opponentScore - opponentDoubles));
                                    fightCount++;

                                    break;
                                } 
                            }
                        }
                    }
                }
            }

            return (fightCount == 0) ? 0 : Math.Round((double)(buchholz / fightCount),2);
        }

        public int GetFighterTieBreakerScore(Fighter fighter)
        {
            if (tieBreakers != null)
            {
                if (tieBreakers.fighters.Contains(fighter.id))
                {
                    int score = 0;

                    foreach (List<Fight> r in tieBreakers.rounds)
                    {
                        foreach (Fight f in r)
                        {
                            if (f.fighterA == fighter.id) score += (f.fighterAResult == Fight.FightResult.WIN) ? 1 : 0;
                            else if (f.fighterB == fighter.id && !f.oddFight) score += (f.fighterBResult == Fight.FightResult.WIN) ? 1 : 0;
                        }
                    }

                    return score;
                }
            }

            return 0;
        }

        public Dictionary<string, string> GetFighterEliminationResults(Fighter fighter)
        {
            Dictionary<string, string> retList = new Dictionary<string, string>();

            foreach (Pool p in eliminations)
            {
                string result = "-";

                if (p.fighters.Contains(fighter.id))
                {
                    foreach (Fight f in p.rounds[0])
                    {
                        if (f.fighterA == fighter.id)
                        {
                            result = f.fighterAResult.ToString();
                            break;
                        }
                        if (f.fighterB == fighter.id)
                        {
                            result = f.fighterBResult.ToString();
                            break;
                        }
                    }
                }

                retList.Add(p.name, result);
            }

            return retList;
        }

        public string GetFighterFinalsResult(Fighter fighter)
        {
            foreach (Fight f in finals)
            {
                if (f.fighterA == fighter.id)
                {
                    return f.fighterAResult.ToString();
                }
                if (f.fighterB == fighter.id)
                {
                    return f.fighterBResult.ToString();
                }
            }

            return "-";
        }

        public int GetFighterFinalRank(Fighter fighter)
        {
            if (stage == TournamentStage.CLOSED)
            {
                if (finals[1].fighterA == fighter.id)
                {
                    if (finals[1].fighterAResult == Fight.FightResult.WIN) return 1;
                    else return 2;
                }
                else if (finals[1].fighterB == fighter.id)
                {
                    if (finals[1].fighterBResult == Fight.FightResult.WIN) return 1;
                    else return 2;
                }

                if (finals[0].fighterA == fighter.id)
                {
                    if (finals[0].fighterAResult == Fight.FightResult.WIN) return 3;
                    else return 4;
                }
                else if (finals[0].fighterB == fighter.id)
                {
                    if (finals[0].fighterBResult == Fight.FightResult.WIN) return 3;
                    else return 4;
                }

                for (int i = eliminations.Count - 1; i > -1; i--)
                {
                    int bracketRank = 4 + -(i - (eliminations.Count - 1));
                    foreach (Fight f in eliminations[i].rounds[0])
                    {
                        if (f.fighterA == fighter.id && f.fighterAResult == Fight.FightResult.LOSS) return bracketRank;
                        if (f.fighterB == fighter.id && f.fighterBResult == Fight.FightResult.LOSS) return bracketRank;
                    }
                }
            }

            return fighters.Count;
        }

        public bool IsLatestBracket(Pool p)
        {
            if (finals.Count > 0) return false;

            if (eliminations.Count > 0)
            {
                if (eliminations.Last().name == p.name) return true;
            }
            else
            {
                if (tieBreakers != null && tieBreakers.name == p.name) return true;
            }

            return false;
        }

        public bool ExtendPools()
        {
            if (stage == TournamentStage.POOLFIGHTS)
            {
                if (poolType == PoolType.FIXEDROUNDS)
                {
                    int poolFighters = pools[0].fighters.Count;

                    //ensure pools can be extended
                    if ((poolFighters - 1) <= (numberOfRounds + 1)) return false;

                    foreach (Pool p in pools)
                    {
                        p.GenerateRound();
                    }

                    numberOfRounds++;

                    return true;
                }
                else if (poolType == PoolType.SWISSPAIRS)
                {
                    List<Pool> newPools = GenerateSwissPools();
                    if (newPools != null) return true;
                    else return false;
                }
            }

            return false;
        }

        public Pool GenerateRoundRobinPool(string name, List<int> fighters)
        {
            Pool pool = new Pool();
            pool.name = name;
            pool.fighters = fighters;

            List<int[]> distinctPairs = pool.fighters.GetDistinctPairs();
            List<Fight> fightsFull = new List<Fight>();
            foreach(int[] pair in distinctPairs)
            {
                fightsFull.Add(new Fight(pair[0], pair[1]));
            }
            fightsFull.Shuffle();

            List<Fight> round = new List<Fight>();

            bool allowDouble = false;

            while (fightsFull.Count > 0)
            {
                for (int i = 0; i < fightsFull.Count;)
                {
                    if (round.Count == 0)
                    {
                        round.Add(fightsFull[i]);
                        fightsFull.RemoveAt(i);
                    }
                    else
                    {
                        if ((fightsFull[i].fighterA != round.Last().fighterA
                           && fightsFull[i].fighterA != round.Last().fighterB
                           && fightsFull[i].fighterB != round.Last().fighterA
                           && fightsFull[i].fighterB != round.Last().fighterB)
                           || allowDouble)
                        {
                            round.Add(fightsFull[i]);
                            fightsFull.RemoveAt(i);
                            allowDouble = false;
                            break;
                        }
                        else { i++; }
                    }

                    if (i >= fightsFull.Count) allowDouble = true;
                }
            }

            pool.rounds.Add(round);
            //pool.rounds.AddRange(round.Split(pool.fighters.Count / 2));

            return pool;
        }

        public Pool GenerateFixedPool(string name, List<int> fighters)
        {
            Pool pool = new Pool();
            pool.name = name;
            pool.fighters = fighters;

            int roundsThisPool = numberOfRounds;

            for (int k = 0; k < roundsThisPool; k++)
            {
                List<Fight> round = pool.GenerateRound();

                if (round == null) return null;
            }

            return pool;
        }

        public List<Pool> GeneratePools()
        {
            //try to ensure it's mathematically possible to generate this tournament before we start
            if ((fighters.Count / ((poolType == PoolType.SWISSPAIRS) ?  2 : numberOfPools)) < numberOfRounds) return null;

            switch (poolType)
            {
                case PoolType.FIXEDROUNDS:
                    return GenerateFixedPools();

                case PoolType.ROUNDROBIN:
                    return GenerateRoundRobin();

                case PoolType.SWISSPAIRS:
                    return GenerateSwissPools();

                default:
                    return null;
            }
        }

        public List<Pool> GenerateSwissPools()
        {
            if (fighters.Count / 2 < numberOfRounds) return null;

            DataView vw = GetFightersDataView();

            vw.Table.Columns.Add("Random", typeof(int));

            foreach(DataRow row in vw.Table.Rows)
            {
                row["Random"] = Helpers.rng.Next(0, 100);
            }

            vw.Sort += ", Random";

            int poolSwap = 0;

            List<Fight> topFights = null;
            List<Fight> bottomFights = null;

            while (topFights == null || bottomFights == null)
            {
                List<int> topFighters = new List<int>();
                List<int> bottomFighters = new List<int>();

                int firstPoolSize = vw.Count / 2;
                if (firstPoolSize % 2 == 1)
                {
                    if (pools.Count / 2 < numberOfRounds / 2)
                    {
                        firstPoolSize++;
                    }
                    else
                    {
                        firstPoolSize--;
                    }
                }

                for (int i = 0; i < vw.Count; i++)
                {
                    if (i > firstPoolSize)
                    {
                        bottomFighters.Add((int)vw[i]["ID"]);
                    }
                    else
                    {
                        topFighters.Add((int)vw[i]["ID"]);
                    }
                }

                for (int i = 0; i < poolSwap; i++)
                {
                    if (i >= topFighters.Count || i >= bottomFighters.Count) return null;

                    int topFighterSwap = topFighters[topFighters.Count - (1 + i)];
                    int bottomFighterSwap = bottomFighters[i];

                    topFighters.Remove(topFighterSwap);
                    topFighters.Add(bottomFighterSwap);
                    bottomFighters.Remove(bottomFighterSwap);
                    bottomFighters.Add(topFighterSwap);
                }

                Pool topPool = new Pool();
                topPool.fighters = topFighters;
                topPool.name = "Top Pool " + ((pools.Count / 2) + 1).ToString();
                topFights = topPool.GenerateSwissRound(this);

                Pool bottomPool = new Pool();
                bottomPool.fighters = bottomFighters;
                bottomPool.name = "Bottom Pool " + ((pools.Count / 2) + 1).ToString();
                bottomFights = bottomPool.GenerateSwissRound(this);

                if (topFights != null && bottomFights != null)
                {
                    pools.Add(topPool);
                    pools.Add(bottomPool);
                }
                else poolSwap++;
            }

            return pools;
        }

        public List<Pool> GenerateRoundRobin()
        {
            int fightersPerPool = fighters.Count / numberOfPools;
            pools = new List<Pool>();

            //clone the list of fighters so we don't remove from the master list
            List<Fighter> fightersClone = new List<Fighter>();
            fightersClone.AddRange(fighters);

            for (int i = 0; i < numberOfPools; i++)
            {
                List<string> poolNames = new List<string>();
                poolNames.AddRange(ConfigValues.poolNames);

                int nameIndex = Helpers.rng.Next(0, poolNames.Count);
                string name = poolNames[nameIndex];
                poolNames.RemoveAt(nameIndex);

                List<int> poolFighters = new List<int>();

                //add random fighters to the pool until we have the correct size
                for (int j = 0; j < fightersPerPool; j++)
                {
                    int randIndex = Helpers.rng.Next(0, fightersClone.Count);
                    poolFighters.Add(fightersClone[randIndex].id);
                    fightersClone.RemoveAt(randIndex);
                }

                //if there are any odd fighters, add them to the last pool
                if (i == numberOfPools - 1 && fightersClone.Count > 0)
                {
                    while (fightersClone.Count > 0)
                    {
                        poolFighters.Add(fightersClone[0].id);
                        fightersClone.RemoveAt(0);
                    }
                }

                pools.Add(GenerateRoundRobinPool(name, poolFighters));
            }

            return pools;
        }

        public List<Pool> GenerateFixedPools()
        {
            int fightersPerPool = fighters.Count / numberOfPools;
            pools = new List<Pool>();

            //clone the list of fighters so we don't remove from the master list
            List<Fighter> fightersClone = new List<Fighter>();
            fightersClone.AddRange(fighters);

            for (int i = 0; i < numberOfPools; i++)
            {
                List<string> poolNames = new List<string>();
                poolNames.AddRange(ConfigValues.poolNames);

                int nameIndex = Helpers.rng.Next(0, poolNames.Count);
                string name = poolNames[nameIndex];
                poolNames.RemoveAt(nameIndex);

                List<int> poolFighters = new List<int>();

                //add random fighters to the pool until we have the correct size
                for (int j = 0; j < fightersPerPool; j++)
                {
                    int randIndex = Helpers.rng.Next(0, fightersClone.Count);
                    poolFighters.Add(fightersClone[randIndex].id);
                    fightersClone.RemoveAt(randIndex);
                }

                //if there are any odd fighters, add them to the last pool
                if (i == numberOfPools - 1 && fightersClone.Count > 0)
                {
                    while (fightersClone.Count > 0)
                    {
                        poolFighters.Add(fightersClone[0].id);
                        fightersClone.RemoveAt(0);
                    }
                }

                pools.Add(GenerateFixedPool(name, poolFighters));
            }

            return pools;
        }

        public bool GenerateNextEliminationBracket()
        {
            Pool bracket = new Pool();

            if (eliminations.Count > 0)
            {
                foreach (Fight f in eliminations.Last().rounds.Last())
                {
                    if (f.fighterAResult == Fight.FightResult.WIN) bracket.fighters.Add(f.fighterA);
                    else bracket.fighters.Add(f.fighterB);
                }
            }
            else
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Score", typeof(int));
                table.Columns.Add("Doubles", typeof(int));
                table.Columns.Add("HitScore", typeof(int));
                table.Columns.Add("TieBreaker", typeof(int));
                table.Columns.Add("Buchholz", typeof(double));

                foreach (Fighter fighter in fighters)
                {
                    DataRow row = table.NewRow();

                    row["ID"] = fighter.id;
                    row["Score"] = GetFighterScore(fighter);
                    row["Doubles"] = GetFighterDoubles(fighter);
                    row["HitScore"] = GetFighterHitScore(fighter);
                    row["TieBreaker"] = GetFighterTieBreakerScore(fighter);
                    row["Buchholz"] = GetFighterBuchholzScore(fighter);

                    table.Rows.Add(row);
                }

                DataView dv = table.DefaultView;
                dv.Sort = "Score DESC, Doubles ASC, HitScore DESC, Buchholz DESC, TieBreaker DESC";

                for (int i = 0; i < eliminationSize; i++)
                {
                    if (i == eliminationSize - 1)
                    {
                        //handle tie-breakers
                        if (tieBreakers == null)
                        {
                            List<int> tiedFighters = new List<int>();
                            tiedFighters.Add((int)dv[i]["ID"]);

                            int j = i + 1;

                            int lastPlaceScore = (int)dv[i]["Score"];
                            int lastPlaceDoubles = (int)dv[i]["Doubles"];
                            int lastPlaceHitScore = (int)dv[i]["HitScore"];
                            double lastPlaceBuchholz = (double)dv[i]["Buchholz"];

                            //work down list
                            while (lastPlaceScore == (int)dv[j]["Score"] && lastPlaceDoubles == (int)dv[j]["Doubles"]
                                && lastPlaceHitScore == (int)dv[j]["HitScore"]
                                && lastPlaceBuchholz == (double)dv[j]["Buchholz"])
                            {
                                tiedFighters.Add((int)dv[j]["ID"]);
                                j++;
                            }

                            j = i - 1;

                            if (tiedFighters.Count > 1)
                            {
                                //work up list
                                while (lastPlaceScore == (int)dv[j]["Score"] && lastPlaceDoubles == (int)dv[j]["Doubles"]
                                    && lastPlaceHitScore == (int)dv[j]["HitScore"]
                                    && lastPlaceBuchholz == (double)dv[j]["Buchholz"])
                                {
                                    tiedFighters.Add((int)dv[j]["ID"]);
                                    j--;
                                }

                                tieBreakers = new Pool();
                                tieBreakers.name = "Tie Breakers";
                                tieBreakers.fighters = tiedFighters;

                                List<Fight> tieBreakerFights = new List<Fight>();

                                //ensure every permutation happens
                                List<int[]> pairs = tieBreakers.fighters.GetDistinctPairs();
                                foreach (int[] pair in pairs)
                                {
                                    Fight f = new Fight(pair[0], pair[1]);

                                    Fight oldFight = FindFight(f);

                                    if (oldFight != null)
                                    {
                                        if (f.fighterA == oldFight.fighterA)
                                        {
                                            f.fighterAResult = oldFight.fighterAResult;
                                            f.fighterBResult = oldFight.fighterBResult;
                                        }
                                        else
                                        {
                                            f.fighterAResult = oldFight.fighterBResult;
                                            f.fighterBResult = oldFight.fighterAResult;
                                        }
                                    }

                                    f.allowDraw = false;
                                    tieBreakerFights.Add(f);
                                }

                                tieBreakers.rounds.Add(tieBreakerFights);

                                return false;
                            }
                        }
                    }

                    bracket.fighters.Add((int)dv[i]["ID"]);
                }
            }

            switch (bracket.fighters.Count)
            {
                case 4:
                    bracket.name = "Semi Finals";
                    break;

                case 8:
                    bracket.name = "Quarter Finals";
                    break;

                default:
                    bracket.name = "Top " + bracket.fighters.Count;
                    break;
            }

            //if we want a random bracket, shuffle on the first round of elims
            if (eliminationType == EliminationType.RANDOMISED && eliminations.Count == 0)
            {
                bracket.fighters.Shuffle();
            }

            List<Fight> fights = new List<Fight>();

            for (int i = 0; i < bracket.fighters.Count / 2; i++)
            {
                Fight fight = new Fight();
                fight.fighterA = bracket.fighters[i];
                fight.fighterB = bracket.fighters[bracket.fighters.Count - (i + 1)];
                fight.allowDraw = false;

                fights.Add(fight);
            }
            bracket.rounds.Add(fights);
            eliminations.Add(bracket);

            return true;
        }

        public void GenerateFinals()
        {
            if (eliminations.Last().fighters.Count == 4)
            {
                Fight bronzeFight = new Fight();
                Fight goldFight = new Fight();

                Fight fightA = eliminations.Last().rounds.Last().First();
                if (fightA.fighterAResult == Fight.FightResult.WIN)
                {
                    goldFight.fighterA = fightA.fighterA;
                    bronzeFight.fighterA = fightA.fighterB;
                }
                else
                {
                    goldFight.fighterA = fightA.fighterB;
                    bronzeFight.fighterA = fightA.fighterA;
                }

                Fight fightB = eliminations.Last().rounds.Last().Last();
                if (fightB.fighterAResult == Fight.FightResult.WIN)
                {
                    goldFight.fighterB = fightB.fighterA;
                    bronzeFight.fighterB = fightB.fighterB;
                }
                else
                {
                    goldFight.fighterB = fightB.fighterB;
                    bronzeFight.fighterB = fightB.fighterA;
                }

                bronzeFight.allowDraw = false;
                goldFight.allowDraw = false;
                finals = new List<Fight>() { bronzeFight, goldFight };
            }
        }

        public string AdvanceTournament()
        {
            if (IsComplete())
            {
                switch (stage)
                {
                    case TournamentStage.REGISTRATION:

                        GeneratePools();

                        if (pools == null)
                        {
                            return "Error while generating pool fights - are there enough fighters per pool?";
                        }
                        else
                        {
                            stage = TournamentStage.POOLFIGHTS;
                            return "Pool Fights generated.";
                        }

                    case TournamentStage.POOLFIGHTS:

                        /*if (poolType == PoolType.SWISSPAIRS && pools.Count < (numberOfRounds * 2))
                        {
                            GenerateSwissPools();
                            return "Next round generated";
                        }
                        else */if (GenerateNextEliminationBracket())
                        {
                            stage = TournamentStage.ELIMINATIONS;
                            return "Eliminations generated";
                        }
                        else
                        {
                            stage = TournamentStage.TIEBREAKERS;
                            return "There are fighters tied for qualification. A tie breaker pool has been generated to settle the tie.";
                        }

                    case TournamentStage.TIEBREAKERS:

                        if (GenerateNextEliminationBracket())
                        {
                            stage = TournamentStage.ELIMINATIONS;
                            return "Eliminations generated";
                        }
                        else
                        {
                            return "";
                        }

                    case TournamentStage.ELIMINATIONS:

                        //check if we are moving to the finals
                        if (eliminations.Last().fighters.Count == 4)
                        {
                            stage = TournamentStage.FINALS;
                            GenerateFinals();
                            return "Finals generated";
                        }
                        else
                        {
                            GenerateNextEliminationBracket();
                            return "Next elimination bracket generated";
                        }

                    case TournamentStage.FINALS:


                        stage = Tournament.TournamentStage.CLOSED;
                        return "Tournament closed";

                    default: break;
                }
            }
            else
            {
                return "Fights are not all complete!";
            }

            return "";
        }

        public bool IsComplete()
        {
            foreach (Pool pool in pools)
            {
                if (!pool.IsComplete()) return false;
            }

            foreach (Pool pool in eliminations)
            {
                if (!pool.IsComplete()) return false;
            }

            foreach (Fight fight in finals)
            {
                if (!fight.IsComplete()) return false;
            }

            return true;
        }
    }

}
