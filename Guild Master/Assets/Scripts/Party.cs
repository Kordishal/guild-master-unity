﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party {

    public List<Adventurer> Members;

    public Travel getFastestTravel()
    {
        // get all the movement stuff and figure out which one goes the fastest and the furthest. 

        double max_distance_walking = int.MaxValue;
        bool all_adventurers_can_still_walk = true;

        foreach (Adventurer a in Members)
        {
            if (a.Skills[(int)AdventurerSkills.SkillNames.Walking].CurrentUses > 0)
            {
                if (a.Skills[(int)AdventurerSkills.SkillNames.Walking].Distance < max_distance_walking)
                    max_distance_walking = a.Skills[(int)AdventurerSkills.SkillNames.Walking].Distance;
            }
            else
                all_adventurers_can_still_walk = false;
                
        }


        if (all_adventurers_can_still_walk)
        {
            return new Travel(AdventurerSkills.SkillNames.Walking, max_distance_walking);
        }
        else
        {
            return new Travel(AdventurerSkills.SkillNames.Walking, 0);
        }
    }


    public struct Travel
    {
        public AdventurerSkills.SkillNames SkillUsed;
        public double Distance;

        public Travel(AdventurerSkills.SkillNames skillUsed, double distance)
        {
            SkillUsed = skillUsed;
            Distance = distance;
        }
    }

    public Party(List<Adventurer> adventurers)
    {
        Members = adventurers;
    }

}