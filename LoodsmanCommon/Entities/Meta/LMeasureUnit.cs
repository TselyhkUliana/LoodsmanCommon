﻿using System.Data;

namespace LoodsmanCommon.Entities.Meta
{
    public class LMeasureUnit
    {
        public LMeasure ParentMeasure { get; }
        public string Guid { get; }
        public string Name { get; }
        public bool IsBase { get; }

        internal LMeasureUnit(LMeasure measure, DataRow dataRow)
        {
            ParentMeasure = measure;

            Guid = dataRow["_ID_UNIT"] as string;
            Name = dataRow["_NAME"] as string;
            IsBase = (int)dataRow["_BASICUNIT"] == 1;
        }
    }
}
