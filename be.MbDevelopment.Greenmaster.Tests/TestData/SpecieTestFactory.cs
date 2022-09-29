﻿using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using be.MbDevelopment.Greenmaster.Models.StaticData.Time;

namespace be.MbDevelopment.Greenmaster.Tests.TestData;

public static class SpecieTestFactory
{
    public static Specie NewSpecie()
    {
        var commonNames = new EnumVDictionary<Language, string>() { };
        commonNames.Add(Language.Nl, "Paradijsvogelbloem");
        return new Specie(new PlantNaming("Strelitzia", "Reginae", commonNames), new PlantProperties(false, false, new LeafColors(Color.Green, Color.Green),
            new FloweringInfo(false, new[] { Color.MultiColor }, new[] { Month.July, Month.August }),
            Lifecycle.Perennial), new PlantDimensions(0.7,0.6));
    }
}