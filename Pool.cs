using System;
using System.Collections.Generic;
using System.Linq;

namespace SwordJet
{
    [Serializable]
    public class Pool
    {
        public List<int> fighters = new List<int>();
        public List<List<Fight>> rounds = new List<List<Fight>>();
        public string name;

        public Pool()
        {

        }

        public List<Fight> GenerateSwissRound(Tournament tournament)
        {
            List<Fight> round = new List<Fight>();

            int offset = 0;

            while (round.Count == 0)
            {
                bool breakout = false;

                if (offset >= fighters.Count)
                {
                    //shit... what now?
                    return null; //???? I think we've got this...
                }

                //clone the pool fighter list so we don't remove from the master list
                List<int> roundFighters = new List<int>();
                roundFighters.AddRange(fighters);

                //if there are an odd number of fighters in this pool
                if (roundFighters.Count % 2 == 1)
                {
                    int oddFightIndex = roundFighters.Count - 1;

                    for (int i = roundFighters.Count - 1; i > -1; i--)
                    {
                        List<Fight> fighterFights = tournament.GetPoolFightsByFighter(roundFighters[i]);

                        bool hasHadOddFight = false;

                        foreach (Fight f in fighterFights)
                        {
                            if (f.oddFight)
                            {
                                hasHadOddFight = true;
                                break;
                            }
                        }

                        if (!hasHadOddFight)
                        {
                            oddFightIndex = i;
                            break;
                        }
                    }

                    Fight fight = new Fight(roundFighters[oddFightIndex], int.MaxValue);
                    fight.oddFight = true;
                    round.Add(fight);
                    roundFighters.Remove(fight.fighterA);
                }



                for (int l = 0; l < roundFighters.Count;)
                {
                    int opponent = l;

                    int tries = 0;
                    do
                    {
                        opponent += (1 + offset);

                        if (opponent >= roundFighters.Count) opponent -= roundFighters.Count;

                        tries++;

                        //start again if we fuck up too much
                        if (tries > ConfigValues.fightGenerationRetryLimit || opponent >= roundFighters.Count || opponent == l)
                        {
                            round.Clear();
                            offset++;
                            breakout = true;
                            break;
                        }
                    }
                    //ensure the fight hasn't happened already
                    while (tournament.HasFightHappenedAlready(new Fight(roundFighters[l], roundFighters[opponent])) && opponent != l);

                    if (breakout) break;

                    if (opponent < roundFighters.Count && opponent != l)
                    {
                        Fight fight = new Fight(roundFighters[l], roundFighters[opponent]);
                        round.Add(fight);
                        roundFighters.Remove(fight.fighterA);
                        roundFighters.Remove(fight.fighterB);
                    }
                }
            }

            rounds.Add(round);
            return round;
        }

        public List<Fight> GenerateRound()
        {
            List<Fight> round = new List<Fight>();

            //clone the pool fighter list so we don't remove from the master list
            List<int> roundFighters = new List<int>();
            roundFighters.AddRange(fighters);
            Helpers.Shuffle(roundFighters);

            int? prevFighterA = null;
            int? prevFighterB = null;

            int k = rounds.Count;
            if (k > 0)
            {
                prevFighterA = rounds[k - 1][rounds[k - 1].Count - 1].fighterA;
                prevFighterB = rounds[k - 1][rounds[k - 1].Count - 1].fighterB;

                while (roundFighters[0] == prevFighterA || roundFighters[0] == prevFighterB)
                {
                    int f = roundFighters[0];
                    roundFighters.RemoveAt(0);
                    roundFighters.Add(f);
                }
            }

            //don't increment l because we will be removing from the list while iterating anyway
            for (int l = 0; l < roundFighters.Count;)
            {
                int opponent = 0;

                //if there is more than one fighter in this round, generate a normal fight
                if (roundFighters.Count > 1)
                {
                    int tries = 0;
                    do
                    {
                        opponent = Helpers.rng.Next(l + 1, roundFighters.Count);
                        tries++;

                        //start again if we fuck up too much
                        if (tries > ConfigValues.fightGenerationRetryLimit) return null;
                    }
                    //ensure the fight hasn't happened already, and the fighter isn't fighting themselves (that would be pretty dumb)
                    //also try and make sure that the first fight of a round does not contain either of the fighters from the last fight of the previous round
                    //not always possible; if we fail too many times on that condition, just allow it
                    while (HasFightHappenedAlready(new Fight(roundFighters[l], roundFighters[opponent])) || opponent == l || (prevFighterA != null && prevFighterB != null
                                && (roundFighters[opponent] == prevFighterA || roundFighters[opponent] == prevFighterB)
                                && round.Count == 0 && roundFighters.Count > 4 && tries < (ConfigValues.fightGenerationRetryLimit / 2)));

                    Fight fight = new Fight(roundFighters[l], roundFighters[opponent]);
                    round.Add(fight);
                    roundFighters.Remove(fight.fighterA);
                    roundFighters.Remove(fight.fighterB);
                }
                //odd fight if only one fighter left - find a fight from the pool which has not happened yet
                else
                {
                    int tries = 0;
                    do
                    {
                        opponent = Helpers.rng.Next(l + 1, fighters.Count);
                        tries++;

                        //start again if we fuck up too much
                        if (tries > ConfigValues.fightGenerationRetryLimit) return null;
                    }
                    //ensure the fight hasn't happened already, and the fighter isn't fighting themselves, and the opponent was not in the last fight
                    while (HasFightHappenedAlready(new Fight(roundFighters[l], fighters[opponent])) || roundFighters[l] == fighters[opponent] || round.Last().fighterA == fighters[opponent] || round.Last().fighterB == fighters[opponent]);

                    Fight fight = new Fight(roundFighters[l], fighters[opponent]);
                    fight.oddFight = true;
                    round.Add(fight);
                    roundFighters.Remove(fight.fighterA);
                }
            }

            rounds.Add(round);

            return round;
        }

        public bool HasFightHappenedAlready(Fight newFight)
        {
            return (FindFight(newFight) != null);
        }

        public Fight FindFight(Fight newFight)
        {
            foreach (List<Fight> round in rounds)
            {
                foreach (Fight fight in round)
                {
                    if (fight.Equals(newFight)) return fight;
                }
            }
            return null;
        }

        public bool IsComplete()
        {
            foreach (List<Fight> round in rounds)
            {
                foreach (Fight fight in round)
                {
                    if (!fight.IsComplete()) return false;
                }
            }

            return true;
        }
    }
}
