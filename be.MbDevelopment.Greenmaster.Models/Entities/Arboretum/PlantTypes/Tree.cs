﻿using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class Tree : Plant
{
    public Tree(Specie specie, Position location = null!) : base(specie, new PlantThresholds(true,
        Lifecycle.Perennial,
        0,
        0.25,
        1.2,
        0,
        true), location)
    {
    }
}