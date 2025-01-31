﻿using System;
using System.Runtime.InteropServices;
using CTrue.FsConnect;
namespace MsfsConnect
{
    public enum Requests
    {
        PlaneInfo = 0,
        ContineousPlaneInfo = 1,
        SimObjects = 2,
        PlanePosition = 3,
        /// <summary>
        /// Requests done by the aircraft manager
        /// </summary>
        AircraftManager = 4
    }
    public enum Definitions
    {
        PlaneInfo = 0,
        PlanePosition = 1,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlaneInfoResponse
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Title;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Category;
        [SimVar(NameId = FsSimVar.PlaneLatitude, UnitId = FsUnit.Radian)]
        public double Latitude;
        [SimVar(NameId = FsSimVar.PlaneLongitude, UnitId = FsUnit.Radian)]
        public double Longitude;
        [SimVar(NameId = FsSimVar.PlaneAltitudeAboveGround, UnitId = FsUnit.Feet)]
        public double AltitudeAboveGround;
        [SimVar(NameId = FsSimVar.PlaneAltitude, UnitId = FsUnit.Feet)]
        public double Altitude;
        [SimVar(NameId = FsSimVar.PlaneHeadingDegreesTrue, UnitId = FsUnit.Degree)]
        public double Heading;
        [SimVar(NameId = FsSimVar.AirspeedTrue, UnitId = FsUnit.Knot)]
        public double Speed;

        public override string ToString()
        {
            return $"Title: {Title}, Category: {Category}, Pos: ({FsUtils.Rad2Deg(Latitude):F4}, {FsUtils.Rad2Deg(Longitude):F4}), Alt: {Altitude:F0} ft, Hdg: {Heading:F1} deg, Speed: {Speed:F0} kt";

        }
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlanePosition
    {
        [SimVar(NameId = FsSimVar.PlaneLatitude, UnitId = FsUnit.Degree)]
        public double Latitude;
        [SimVar(NameId = FsSimVar.PlaneLongitude, UnitId = FsUnit.Degree)]
        public double Longitude;
        [SimVar(NameId = FsSimVar.PlaneAltitude, UnitId = FsUnit.Feet)]
        public double Altitude;
        [SimVar(NameId = FsSimVar.PlaneHeadingDegreesTrue, UnitId = FsUnit.Degree)]
        public double Heading;

        public override string ToString()
        {
            return $"Pos: ({Latitude:F4}, {Longitude:F4}), Alt: {Altitude:F0} ft, Hdg: {Heading:F1} deg";

        }
    };
}
