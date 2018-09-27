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
        public enum AfterblowBehaviour { IGNORE = 0, WEIGHT = 1 };

        public string name;
        public int numberOfRounds;
        public int numberOfPools;
        public int? scoreThreshold;
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
        public AfterblowBehaviour afterblowBehaviour;
        public int penaltyThreshold;

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
            scoreThreshold = null;
            eliminationSize = 8;
            matchedEliminations = false;
            winPoints = 3;
            drawPoints = 2;
            lossPoints = 1;
            doubleThreshold = null;
        }

        //return the next fighter ID to use when creating new fighters
        public int GetNextFighterID()
        {
            if (fighters.Count > 0)
            {
                return fighters.OrderBy(o => o.id).Last().id + 1;
            }
            return 1;
        }

        //return a fighter with the given ID
        public Fighter GetFighterByID(int id)
        {
            foreach (Fighter f in fighters)
            {
                if (f.id == id) return f;
            }

            return null;
        }

        //return a fight with the given ID
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

        //get a list of all of the pool fights with the given fighter ID
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

        //return true if two fighters have already fought in the pools
        public bool HasFightHappenedAlready(Fight f)
        {
            return (FindFight(f) != null);
        }

        //get a pool fight which involves the same fighters as the given fight
        //returns null if no match found
        public Fight FindFight(Fight f)
        {
            foreach (Pool p in pools)
            {
                Fight fight = p.FindFight(f);
                if (fight != null) return fight;
            }

            return null;
        }

        //get a sorted data view of all tournament fighters
        public DataView GetFightersDataView()
        {
            DataTable table = new DataTable();

            //if the tournament is over, add a "finishing rank" column
            if (stage == TournamentStage.CLOSED)
            {
                table.Columns.Add("FinishingRank", typeof(int));
            }

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Pool", typeof(string));
            table.Columns.Add("PoolScore", typeof(double));
            table.Columns.Add("PoolDoubles", typeof(int));
            table.Columns.Add("PoolBuchholz", typeof(double));
            table.Columns.Add("PoolHitScore", typeof(int));

            //add a column for each round of eliminations
            foreach (Pool p in eliminations)
            {
                table.Columns.Add(p.name, typeof(string));
            }

            //if finals exist, add a column for finals
            if (finals.Count > 0)
            {
                table.Columns.Add("Finals", typeof(string));
            }

            table.Columns.Add("TieBreakerScore", typeof(int));
            table.Columns.Add("ElimSort", typeof(int));

            foreach (Fighter fighter in fighters)
            {
                DataRow row = table.NewRow();

                //if the tournament is finished, get the fighter's finishing rank
                if (stage == TournamentStage.CLOSED)
                {
                    int rank = GetFighterFinalRank(fighter);
                    row["FinishingRank"] = rank;
                }

                row["ID"] = fighter.id;
                row["Name"] = fighter.name;

                //get the fighter's pool name
                //if swiss pairs, will return the last pool the fighter was in
                string poolname = "";
                foreach (Pool p in pools)
                {
                    if (p.fighters.Contains(fighter.id)) poolname = p.name;
                }
                row["Pool"] = poolname;

                //get the fighters score details
                row["PoolScore"] = Math.Round(GetFighterScore(fighter),1);
                row["PoolDoubles"] = GetFighterDoubles(fighter);
                row["PoolBuchholz"] = GetFighterBuchholzScore(fighter);
                row["PoolHitScore"] = GetFighterHitScore(fighter);
                row["TieBreakerScore"] = GetFighterTieBreakerScore(fighter);

                //get a dictionary of the fighter's result in each round of eliminations
                Dictionary<string, string> elimResults = GetFighterEliminationResults(fighter);
                int elimSort = 0;

                //calculate a sort factor based on the fighter's result in each round of eliminations
                for (int i = 0; i < eliminations.Count; i++)
                {
                    Pool p = eliminations[i];
                    string r = elimResults[p.name];
                    row[p.name] = r;
                    //a win is worth 2 * round number + 1, a loss is worth round number + 1, no result is worth 0
                    elimSort += ((r == "WIN") ? 2 * (i + 1) : ((r == "LOSS") ? (i + 1) : 0));
                }

                //if there are finals, calculate a sort factor based on the fighters result
                if (finals.Count > 0)
                {
                    string r = GetFighterFinalsResult(fighter);
                    row["Finals"] = r;
                    //a win is worth number of elims * 2, a loss is worth number of eliminations
                    elimSort += ((r == "WIN") ? 2 * eliminations.Count : ((r == "LOSS") ? eliminations.Count : 0));
                }

                row["ElimSort"] = elimSort;
                table.Rows.Add(row);
            }

            DataView dv = table.DefaultView;

            //sort the view
            //TODO add config options for this to be customised
            dv.Sort = "ElimSort DESC, PoolScore DESC, PoolDoubles ASC, PoolHitScore DESC, PoolBuchholz DESC, TieBreakerScore DESC";

            //if tournament is finished, just sort by final rank
            if (stage == TournamentStage.CLOSED)
            {
                dv.Sort = "FinishingRank ASC, " + dv.Sort;
            }

            return dv;
        }

        //return the given fighter's pool score
        public double GetFighterScore(Fighter fighter)
        {
            int score = 0;
            int numberOfFights = 0;

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
                            else if (fight.fighterB == fighter.id && !fight.oddFight) //if this was an odd fight and the fighter is the odd fighter, don't include the result in score
                            {
                                result = fight.fighterBResult;
                            }

                            //only include fights where the fight complete
                            if (result != Fight.FightResult.PENDING)
                            {
                                int gainedScore = 0;

                                //select the approriate score based on the fighter's result
                                switch (result)
                                {
                                    case Fight.FightResult.WIN: gainedScore = winPoints; break;
                                    case Fight.FightResult.LOSS: gainedScore = lossPoints; break;
                                    case Fight.FightResult.DRAW: gainedScore = drawPoints; break;
                                    case Fight.FightResult.DQ: gainedScore = 0; break;
                                }

                                score += gainedScore;
                                numberOfFights++;
                                //break;
                            }
                        }
                    }
                }
            }

            return (numberOfFights == 0) ? 0.0 : (double)score/(double)numberOfFights;
        }

        //return a given fighter's number of doubles from all of their pool fights
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
                            else if (fight.fighterB == fighter.id && !fight.oddFight) //if this was an odd fight and the fighter is the odd fighter, don't include the result in score
                            {
                                result = fight.fighterBResult;
                            }

                            //only include matches which are finished
                            if (result != Fight.FightResult.PENDING)
                            {
                                doubles += fight.doubleCount;
                                //break;
                            }
                        }
                    }
                }
            }

            return doubles;
        }

        //return a given fighter's hit score (hits given - hits received) from their pool fights
        public int GetFighterHitScore(Fighter fighter)
        {
            int given = 0;
            int received = 0;
            int penalties = 0;

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
                                //add hits given/received from each exchange to the score
                                if (fight.fighterA == fighter.id)
                                {
                                    given += exch.fighterAScore;
                                    received += exch.fighterBScore;
                                    penalties += (exch.penaltyA ? 1 : 0);
                                }
                                else if (fight.fighterB == fighter.id && !fight.oddFight) //if this was an odd fight and the fighter is the odd fighter, don't include the result in score
                                {
                                    given += exch.fighterBScore;
                                    received += exch.fighterAScore;
                                    penalties += (exch.penaltyB ? 1 : 0);
                                }
                            }
                        }
                    }
                }
            }

            //subtract accrued penalties
            if(penaltyThreshold > 0) given = Math.Max(0, (given - (penalties / penaltyThreshold)));

            return given - received;
        }

        //return a given fighter's buchholz score - likely not needed for breaking ties anymore - only calculate if there is a tie?
        public double GetFighterBuchholzScore(Fighter fighter)
        {
            double buchholz = 0;
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
                                else if (fight.fighterB == fighter.id && !fight.oddFight) //if this was an odd fight and the fighter is the odd fighter, don't include the result in score
                                {
                                    result = fight.fighterBResult;
                                }

                                //only add score if fight is complete
                                if (result != Fight.FightResult.PENDING)
                                {
                                    Fighter opponent = null;
                                    if (fight.fighterA == fighter.id) opponent = GetFighterByID(fight.fighterB);
                                    else opponent = GetFighterByID(fight.fighterA);

                                    double opponentScore = GetFighterScore(opponent);
                                    int opponentDoubles = GetFighterDoubles(opponent);

                                    //don't allow negative scores
                                    buchholz += Math.Max(0,(opponentScore - opponentDoubles));
                                    fightCount++;

                                    //break;
                                } 
                            }
                        }
                    }
                }
            }

            //return the buchholz
            return (fightCount == 0) ? 0 : Math.Round((buchholz / fightCount),2);
        }

        //get the fighter's score in tie breaker round
        //almost certainly won't be needed - ties very unlikely due to hit score and buchholz
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
                            //each win is worth 1 point
                            if (f.fighterA == fighter.id) score += (f.fighterAResult == Fight.FightResult.WIN) ? 1 : 0;
                            else if (f.fighterB == fighter.id && !f.oddFight) score += (f.fighterBResult == Fight.FightResult.WIN) ? 1 : 0;
                        }
                    }

                    return score;
                }
            }

            return 0;
        }

        //return the given fighter's elimination results
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

        //return the given fighter's finals result
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

        //return the fighter's final rank
        public int GetFighterFinalRank(Fighter fighter)
        {
            if (stage == TournamentStage.CLOSED)
            {
                //winning the final "gold" fight is first place, losing it is second
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

                //winning the final "bronze" fight is third place, losing it is fourth
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

                //if the fighter was eliminated before the finals, their final rank is the rank of the bracket (e.g., a loss at quarter finals is fifth place)
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

            //if the fighter did not qualify, their final rank is shared last place
            return fighters.Count;
        }

        //return true if the given pool is the latest round of eliminations
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

        //add another round of pool fights, if possible
        //returns true if successful, false if not
        public bool ExtendPools()
        {
            //only allow pools to be extended during pool fights, obviously
            if (stage == TournamentStage.POOLFIGHTS)
            {
                //if it's a fixed rounds pool -
                if (poolType == PoolType.FIXEDROUNDS)
                {
                    int poolFighters = pools[0].fighters.Count;

                    //ensure pools can be extended
                    if ((poolFighters - 1) <= (numberOfRounds + 1)) return false;

                    //generate a round for each pool
                    foreach (Pool p in pools)
                    {
                        p.GenerateRound();
                    }

                    //increment the total number of rounds
                    numberOfRounds++;

                    return true;
                }
                //if it's a swiss pairs pool -
                else if (poolType == PoolType.SWISSPAIRS)
                {
                    //try to generate some new swiss pools
                    List<Pool> newPools = GenerateSwissPools();
                    if (newPools != null) return true;
                    else return false;
                }
            }

            return false;
        }

        //generate a "round robin" pool - everybody fights everybody
        public Pool GenerateRoundRobinPool(string name, List<int> fighters)
        {
            Pool pool = new Pool();
            pool.name = name;
            pool.fighters = fighters;

            //get every possible distinct fight in the pool
            List<int[]> distinctPairs = pool.fighters.GetDistinctPairs();
            List<Fight> fightsFull = new List<Fight>();
            foreach(int[] pair in distinctPairs)
            {
                fightsFull.Add(new Fight(pair[0], pair[1]));
            }

            //randomise fight order
            fightsFull.Shuffle();

            List<Fight> round = new List<Fight>();

            bool allowDouble = false;

            //try to logically order all of the fights
            //avoid the same fighter fighting twice in a row if possible
            while (fightsFull.Count > 0)
            {
                for (int i = 0; i < fightsFull.Count;)
                {
                    //if this is the first fight, just add it without checking
                    if (round.Count == 0)
                    {
                        round.Add(fightsFull[i]);
                        fightsFull.RemoveAt(i);
                    }
                    else
                    {
                        //if neither of the fighters in this fight were fighting last, OR we are allowing fighters to fight twice in a row, add the fight
                        if ((fightsFull[i].fighterA != round.Last().fighterA
                           && fightsFull[i].fighterA != round.Last().fighterB
                           && fightsFull[i].fighterB != round.Last().fighterA
                           && fightsFull[i].fighterB != round.Last().fighterB)
                           || allowDouble)
                        {
                            round.Add(fightsFull[i]);
                            fightsFull.RemoveAt(i);

                            //reset the flag for allowing two fights in a row, and go back to the start of the list
                            allowDouble = false;
                            break;
                        }
                        else { i++; }
                    }

                    //if we haven't found a unique fight, allow the same fighter to fight twice in a row
                    if (i >= fightsFull.Count) allowDouble = true;
                }
            }

            //add the fights to the pool as once big round
            pool.rounds.Add(round);

            //could use this to break it into rounds instead, probably not necessary
            //pool.rounds.AddRange(round.Split(pool.fighters.Count / 2));

            return pool;
        }

        //generate a "fixed" pool - everybody has the specified number of fights
        public Pool GenerateFixedPool(string name, List<int> fighters)
        {
            Pool pool = new Pool();
            pool.name = name;
            pool.fighters = fighters;

            int roundsThisPool = numberOfRounds;

            //generate the correct number of fights
            for (int k = 0; k < roundsThisPool; k++)
            {
                List<Fight> round = pool.GenerateRound();

                if (round == null) return null;
            }

            return pool;
        }

        //generate the pools for this tournament
        public List<Pool> GeneratePools()
        {
            //try to ensure it's mathematically possible to generate this tournament before we start
            if ((fighters.Count / ((poolType == PoolType.SWISSPAIRS) ?  2 : numberOfPools)) < numberOfRounds) return null;

            //generate the correct type of pools
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

        //generate "swiss pairings" pool (fighters divided into a top pool and bottom pool each round)
        public List<Pool> GenerateSwissPools()
        {
            //if (fighters.Count / 2 < numberOfRounds) return null;

            //get all tournament fighters
            DataView vw = GetFightersDataView();

            //add a random sort column
            vw.Table.Columns.Add("Random", typeof(int));

            //populate random sort column
            foreach(DataRow row in vw.Table.Rows)
            {
                row["Random"] = Helpers.rng.Next(0, 100);
            }

            //sort by the random column
            vw.Sort += ", Random";

            //number of fighters to swap between top and bottom pools
            //will be incremented if we don't find enough distinct fights
            int poolSwap = 0;

            //list of fights for the top and bottom pools
            List<Fight> topFights = null;
            List<Fight> bottomFights = null;

            while (topFights == null || bottomFights == null)
            {
                List<int> topFighters = new List<int>();
                List<int> bottomFighters = new List<int>();

                //if we need an odd fight, switch it between the two pools each round
                int firstPoolSize = vw.Count / 2;
                if (firstPoolSize % 2 == 1)
                {
                    if ((pools.Count / 2) % 2 == 1)//(pools.Count / 2 < numberOfRounds / 2)
                    {
                        firstPoolSize++;
                    }
                    else
                    {
                        firstPoolSize--;
                    }
                }

                //add fighters to correct pools
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

                //swap fighters between pools to try and find distinct fights for everybody
                for (int i = 0; i < poolSwap; i++)
                {
                    //just give up, it's not happening...
                    if (i >= topFighters.Count || i >= bottomFighters.Count) return null;

                    int topFighterSwap = topFighters[topFighters.Count - (1 + i)];
                    int bottomFighterSwap = bottomFighters[i];

                    topFighters.Remove(topFighterSwap);
                    topFighters.Add(bottomFighterSwap);
                    bottomFighters.Remove(bottomFighterSwap);
                    bottomFighters.Add(topFighterSwap);
                }

                //try to generate top pool
                Pool topPool = new Pool();
                topPool.fighters = topFighters;
                topPool.name = "Top Pool " + ((pools.Count / 2) + 1).ToString();
                topFights = topPool.GenerateSwissRound(this);
                
                //try to generate bottom pool
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
            int oddFighters = fighters.Count % numberOfPools;
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

                if(oddFighters > i)
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
                table.Columns.Add("Score", typeof(double));
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

                            double lastPlaceScore = (double)dv[i]["Score"];
                            int lastPlaceDoubles = (int)dv[i]["Doubles"];
                            int lastPlaceHitScore = (int)dv[i]["HitScore"];
                            double lastPlaceBuchholz = (double)dv[i]["Buchholz"];

                            //work down list
                            while ((j < fighters.Count) && (lastPlaceScore == (double)dv[j]["Score"] && lastPlaceDoubles == (int)dv[j]["Doubles"]
                                && lastPlaceHitScore == (int)dv[j]["HitScore"]
                                && lastPlaceBuchholz == (double)dv[j]["Buchholz"]))
                            {
                                tiedFighters.Add((int)dv[j]["ID"]);
                                j++;
                            }

                            j = i - 1;

                            if (tiedFighters.Count > 1)
                            {
                                //work up list
                                while ((j >= 0) && (lastPlaceScore == (double)dv[j]["Score"] && lastPlaceDoubles == (int)dv[j]["Doubles"]
                                    && lastPlaceHitScore == (int)dv[j]["HitScore"]
                                    && lastPlaceBuchholz == (double)dv[j]["Buchholz"]))
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
                        else */
                        if(fighters.Count < eliminationSize)
                        {
                            return "Not enough fighters for selected elimination size!";
                        }

                        if (GenerateNextEliminationBracket())
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
