﻿namespace be.MbDevelopment.Greenmaster.Models.Entities;

public class Position
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Position(double x, double y, double z = 0)
    {
        X = x;
        Y = y;
        Z = z;
    }
}