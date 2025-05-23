// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using CSMath;

namespace ACadSharp.Objects
{
    /// <summary>
    /// DxfDimensionAssociativity class
    /// </summary>
    public sealed class DimensionAssociativity : NonGraphicalObject
    {
        public enum RotatedDimensionTypes : short
        {
            Parallel,
            Perpendicular,
        }

        public enum ObjectOSnapTypes : byte
        {
             None = 0,
             Endpoint = 1,
             Midpoint = 2,
             Center = 3,
             Node = 4,
             Quadrant = 5,
             Intersection = 6,
             Insertion = 7,
             Perpendicular = 8,
             Tangent = 9,
             Nearest = 10,
             ApparentIntersection = 11,
             Parallel = 12,
             StartPoint = 13,
        }

        [Flags]
        public enum DimassocAssociativityPoint : short
        {
            First = 1,
            Second = 2,
            Third = 4,
            Fourth = 8
        }

        public struct ObjectSnapPointReference
        {
            public ObjectOSnapTypes SnapType { get; }
            public Entity Geometry { get; set;  }
            public short SubentType { get; }
            public int GsMarker { get; }
            public double Parameter { get; }
            public XYZ Point { get; }
            public bool HasLastPointReference { get; }

            public ObjectSnapPointReference(ObjectOSnapTypes snapTyle, short subentType, int gsMarker, double parameter, XYZ point, bool hasLastPointReference)
            {
                SnapType = snapTyle;
                SubentType = subentType;
                GsMarker = gsMarker;
                Parameter = parameter;
                Point = point;
                HasLastPointReference = hasLastPointReference;
            }
        }

        /// <inheritdoc/>
        public override ObjectType ObjectType => ObjectType.UNLISTED;

        /// <inheritdoc/>
        public override string ObjectName => DxfFileToken.ObjectDimAssoc;

        /// <inheritdoc/>
        public override string SubclassMarker => DxfSubclassMarker.DimAssoc;

        /// <summary>
        /// 1 = First point reference
        /// 2 = Second point reference
        /// 4 = Third point reference
        /// 8 = Fourth point reference
        /// </summary>
        [DxfCodeValue(90)]
        public DimassocAssociativityPoint AssociativityFlag { get; set; }

        /// <summary>
        /// Allah e jane ki jinish
        /// </summary>
        [DxfCodeValue(70)]
        public bool TransSpaceFlag { get; set; }

        [DxfCodeValue(71)]
        public RotatedDimensionTypes RotatedDimensionFlag { get; set; }

        public ObjectSnapPointReference[] PointRefs { get; set; }

        public Dimension DimensionObject { get; set; }

        public DimensionAssociativity() : base("ACAD_DIMASSOC") 
        {
        }
    }
}
