// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using ACadSharp.Attributes;
using ACadSharp.Entities;

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

        public enum ObjectOSnapTypes : short
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

        /// <inheritdoc/>

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
        public short AssociativityFlag { get; set; }

        /// <summary>
        /// Allah e jane ki jinish
        /// </summary>
        [DxfCodeValue(70)]
        public bool TransSpaceFlag { get; set; }

        [DxfCodeValue(71)]
        public RotatedDimensionTypes RotatedDimensionFlag { get; set; }


        [DxfCodeValue(72)]
        public ObjectOSnapTypes ObjectSnapFlag { get; set; }
        [DxfCodeValue(40)]
        public double NearOsnapGeometryParameter { get; set; }

        [DxfCodeValue(DxfReferenceType.Count, 10, 20, 30)]
        public Vector3 OsnapPoint { get; set; }

        [DxfCodeValue(DxfReferenceType.Handle, 331)]
        public Entity MainObject { get; set; }
        [DxfCodeValue(DxfReferenceType.Handle, 332)]
        public Entity OtherObject { get; set; }

        public Dimension DimensionObject { get; set; }
    }
}
